package nta.med.service.ihis.handler.bill;

import java.math.BigDecimal;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.bill.Bil0101;
import nta.med.core.domain.bill.Bil0102;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.bil.Bil0101Repository;
import nta.med.data.dao.medi.bil.Bil0102Repository;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.service.ihis.proto.BillModelProto;
import nta.med.service.ihis.proto.BillServiceProto;
import nta.med.service.ihis.proto.BillServiceProto.SaveBIL2016U02Request;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class SaveBIL2016U02Handler extends ScreenHandler<BillServiceProto.SaveBIL2016U02Request, SystemServiceProto.UpdateResponse>{

	private static final Log LOGGER = LogFactory.getLog(SaveBIL2016U02Handler.class);
	
	@Resource                                                                                                       
	private Bil0101Repository bil0101Repository;
	
	@Resource                                                                                                       
	private Bil0102Repository bil0102Repository;
	
	@Resource
	private Out0101Repository out0101Repository;
	
	@Resource
	private Ocs1003Repository ocs1003Repository;
	@Resource                                                                                                       
	private Out1001Repository out1001Repository;
	@Resource                                                                                                       
	private CommonRepository commonRepository;
	
	@Override
	@Transactional(rollbackFor = Throwable.class)
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			SaveBIL2016U02Request request) throws Exception {
		
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		response.setResult(true);
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = getUserId(vertx, sessionId);
//		String invoiceNo = request.getInvoiceNo();
		if(DataRowState.ADDED.getValue().equals(request.getRowState())){
			String nextSqq = commonRepository.getNextValByHospCode(hospCode, "BIL0101_SEQ");
			if(nextSqq == null){
				LOGGER.info("Could not get next sequence BIL0101_SEQ, hosp_code = " + hospCode);
				response.setResult(false);
				return response.build();
			}
			String invoiceNo = hospCode + "_" + StringUtils.leftPad(nextSqq, 8, "0");
			boolean invoiceMaster = saveInvoiceMaster(hospCode, userId, request, invoiceNo);
			if(invoiceMaster){
				boolean saveResult = saveInvoiceDetail(hospCode, userId, request, invoiceNo);
				if(saveResult){
					response.setMsg(invoiceNo);
					response.setResult(saveResult);
					LOGGER.info("Save Invoice master [BIL0101] OK: Invoice No = " + invoiceNo);
					LOGGER.info("Save Invoice detail [BIL0102/OCS1003]: Invoice No = " + invoiceNo + ", result = " + saveResult);
				}else{
					LOGGER.info("Save Invoice master [BIL0102] fail: Invoice No = " + invoiceNo);
					response.setResult(false);
				}
				
			} else {
				LOGGER.info("Save Invoice master [BIL0101] fail: Invoice No = " + invoiceNo);
				response.setResult(false);
			}
		} else if (DataRowState.DELETED.getValue().equals(request.getRowState())) {
			boolean deleteResult = deleteInvoice(hospCode, request.getInvoiceNo(), userId, request);
			response.setResult(deleteResult);
			LOGGER.info("Delete InvoiceL Invoice No = " + request.getInvoiceNo() + ", result = " + deleteResult);
		}
		
		if(!response.getResult()){
			throw new ExecutionException(response.setResult(false).build());
		}
		
		return response.build();
	}
	
	private boolean deleteInvoice(String hospCode, String invoiceNo, String userId, BillServiceProto.SaveBIL2016U02Request request){
		BigDecimal amountDebt = CommonUtils.parseBigDecimal(request.getAmountDebtLatest());
		String parentInvoiceNo = request.getParentInvoiceNo();
		boolean result = false;
//		cancel invoice in  master table
		if(bil0101Repository.deactiveInvoiceByInvoiceNo(userId, request.getRevertComment(), hospCode, invoiceNo) > 0){
			if(bil0101Repository.updateDebtByParentInvoiceEqualInvoice(amountDebt, userId, hospCode, parentInvoiceNo) > 0){
				result = true;
			}else{
				LOGGER.info("cant deleteInvoice updateAmountDebtByParentInvoiceNo: parentInvoiceNo No = " + parentInvoiceNo);
				return false;
			}
		}else{
			LOGGER.info("cant deleteInvoice deactiveInvoiceByInvoiceNo: Invoice No = " + request.getInvoiceNo());
			return false;
		}
//		cancel invoice in detail table
		if(result && request.getParentInvoiceNo().equalsIgnoreCase(request.getInvoiceNo())){
			Double fkout1001 = CommonUtils.parseDouble(request.getFkout1001());
			LOGGER.info("update deleteInvoice ParentInvoiceNo = InvoiceNo: Invoice No = " + request.getInvoiceNo());
			List<Bil0102> bil0102s = bil0102Repository.findByHospCodeInvoiceNo(hospCode, invoiceNo);
			if(!CollectionUtils.isEmpty(bil0102s)){
				for(Bil0102 bil0102 : bil0102s){
					if(!"AF".equalsIgnoreCase(bil0102.getOrderGrp())){
						LOGGER.info("update deleteInvoice type = 1 , invoiceNo = " + invoiceNo);
								int updOcs = ocs1003Repository.updatePaidYn("C", userId, new Date(), hospCode, bil0102.getFkocs1003());
								if(updOcs <= 0) return false;
								LOGGER.info("update deleteInvoice updatePaidYn OK: Invoice No = " + invoiceNo);
					}else if("AF".equalsIgnoreCase(bil0102.getOrderGrp())){
						LOGGER.info("update deleteInvoice type = 2 , invoiceNo = " + invoiceNo);
						int updOut = out1001Repository.updateOut1001PaidYn(hospCode, fkout1001, "C", userId,  new Date());
						if(updOut <= 0) return false;
						LOGGER.info("update deleteInvoice updateOut1001PaidYn OK: Invoice No = " + invoiceNo);
					}else{
						LOGGER.info("update deleteInvoice OrderGrp is wrong: Invoice No = " + invoiceNo + " OrderGrp " + bil0102.getOrderGrp());
						return false;
					}
					int detailDel = bil0102Repository.deactiveInvoiceDetail(hospCode, invoiceNo);
					if(detailDel <= 0) return false;
					LOGGER.info("update deleteInvoice deactiveInvoiceDetail OK: Invoice No = " + invoiceNo);
				}
			}
		}
		
//		int detailDel = 0;
//		
//		if(masterDel > 0){
//			detailDel = bil0102Repository.deactiveInvoiceDetail(hospCode, invoiceNo);
//		}
//		
//		if(masterDel > 0 && detailDel > 0){
//			List<BillModelProto.LoadGridBIL2016U02Info> invoiceDetailList =  request.getListInfoList();
//			if(!CollectionUtils.isEmpty(invoiceDetailList)){
//				for (BillModelProto.LoadGridBIL2016U02Info info : invoiceDetailList) {
//					Double fkocs1003 = StringUtils.isEmpty(info.getFkocs1003()) ? null : Double.parseDouble(info.getFkocs1003().replace(",", "."));
//					Double fkout1001 = CommonUtils.parseDouble(request.getFkout1001());
//					//int updOcs = ocs1003Repository.modifyPaidYn("C", hospCode, fkocs1003);
//					if(request.getParentInvoiceNo().equalsIgnoreCase(request.getInvoiceNo())){
//						LOGGER.info("update deleteInvoice ParentInvoiceNo = InvoiceNo: Invoice No = " + request.getInvoiceNo());
//						if("1".equals(request.getType())){
//							int updOcs = ocs1003Repository.updatePaidYn("C", userId, new Date(), hospCode, fkocs1003);
//							if(updOcs <= 0) return false;
//							LOGGER.info("update deleteInvoice updatePaidYn OK: Invoice No = " + request.getInvoiceNo());
//						}else if("2".equals(request.getType())){
//							int updOut = out1001Repository.updateOut1001PaidYn(hospCode, fkout1001, "C", userId,  new Date());
//							if(updOut <= 0) return false;
//							LOGGER.info("update deleteInvoice updateOut1001PaidYn OK: Invoice No = " + request.getInvoiceNo());
//						}
//					}
//					
//				}
//			}
//		}
		
		return result;
	}
	
	private boolean saveInvoiceMaster(String hospCode, String userId, BillServiceProto.SaveBIL2016U02Request request, String invoiceNo){
		List<BillModelProto.LoadGridBIL2016U02Info> invoiceDetailList =  request.getListInfoList();
//		if request.getDiscount() = 0 means get discount by service else discount by invoice
			String parentInvoiceNo = request.getParentInvoiceNo().trim();
			BigDecimal discount = CommonUtils.parseBigDecimal(request.getDiscount().trim()) != null ? CommonUtils.parseBigDecimal(request.getDiscount().trim()) : new BigDecimal("0");
			if(discount.compareTo(new BigDecimal("0")) == 0 && StringUtils.isEmpty(parentInvoiceNo)){
				if(!CollectionUtils.isEmpty(invoiceDetailList)){
					for(BillModelProto.LoadGridBIL2016U02Info info : invoiceDetailList){
						BigDecimal discountByService = CommonUtils.parseBigDecimal(info.getDiscount().trim()) != null ? CommonUtils.parseBigDecimal(info.getDiscount().trim()) : new BigDecimal("0");
						discount = discount.add(discountByService);
					}
				}
			}
			Bil0101 bil0101 = new Bil0101();
			Date birth = StringUtils.isEmpty(request.getBirth()) ? null : DateUtil.toDate(request.getBirth(), DateUtil.PATTERN_YYMMDD);
			Date visitDate = StringUtils.isEmpty(request.getNaewonDate()) ? null : DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD);
			BigDecimal amount = CommonUtils.parseBigDecimal(request.getAmount().trim()) != null ? CommonUtils.parseBigDecimal(request.getAmount().trim()) : new BigDecimal("0");
			BigDecimal payMoney = CommonUtils.parseBigDecimal(request.getPayMoney().trim()) != null ? CommonUtils.parseBigDecimal(request.getPayMoney().trim()) : new BigDecimal("0");
			BigDecimal amountDept = amount.subtract(discount).subtract(payMoney);
			BigDecimal statusFlg = new BigDecimal("2");
			if(StringUtils.isEmpty(parentInvoiceNo)){
				statusFlg = amountDept.compareTo(new BigDecimal("0")) == 0 ? new BigDecimal("2") : new BigDecimal("3");;
			}else{
				BigDecimal lastetAmountDebt = bil0101Repository.getLasteDebtBIL2016U02(hospCode, parentInvoiceNo);
				if(lastetAmountDebt != null){
					amountDept = lastetAmountDebt.subtract(discount).subtract(payMoney);
				}
			}
			bil0101.setInvoiceNo(invoiceNo);
			bil0101.setInvoiceDate(DateUtil.toDate(request.getInvoiceDate(), DateUtil.PATTERN_YYMMDD));
			bil0101.setBunho(request.getBunho());
			bil0101.setPatientNm(request.getSuname());
			bil0101.setPatientGender(request.getSex());
			bil0101.setPatientDob(birth);
			bil0101.setPatientAddr(request.getAddress());
			bil0101.setDeptCd(request.getGwa());
			bil0101.setDeptNm(request.getGwaName());
			bil0101.setDoctor(request.getDoctor());
			bil0101.setDoctorNm(request.getDoctorName());
			bil0101.setVisitDate(visitDate);
			bil0101.setPaidName(request.getPaidName());
			bil0101.setCashierNm(userId);									// UserName
			bil0101.setPaymentCd(request.getPaymentCode());
			bil0101.setPaymentNm(request.getPaymentName());
//			bil0101.setStatusFlg(new BigDecimal(2));
			bil0101.setStatusFlg(statusFlg);
			bil0101.setPatientGrp(request.getBunhoType());
			bil0101.setPatientGrpNm(request.getBunhoTypeName());
			bil0101.setAmount(amount);
			bil0101.setDiscount(discount);
			bil0101.setFkout1001(CommonUtils.parseDouble(request.getFkout1001()));
			bil0101.setSysId(userId);
			bil0101.setUpdId(userId);
			bil0101.setCreated(new Date());
			bil0101.setUpdated(new Date());
			bil0101.setActiveFlg(new BigDecimal(1));
			bil0101.setHospCode(hospCode);
			bil0101.setPatientTel(request.getPhone());
			bil0101.setDiscountComment(request.getDiscountReasonTotal());
			bil0101.setDiscountType(request.getDiscountType());
			bil0101.setParentInvoiceNo(StringUtils.isEmpty(parentInvoiceNo) ? invoiceNo : parentInvoiceNo);
			bil0101.setAmountPaid(payMoney);
			bil0101.setAmountDebt(amountDept);
			
			bil0101Repository.save(bil0101);
			if(!StringUtils.isEmpty(parentInvoiceNo)){
				BigDecimal updateAmountDept = null ;
				BigDecimal parentStatusFlg = null;
				List<Bil0101> bil0101s = bil0101Repository.findByHospCodeParentInvoiceEqualInvoice(hospCode, parentInvoiceNo);
				if(!CollectionUtils.isEmpty(bil0101s)){
					BigDecimal currentAmountDept = bil0101s.get(0).getAmountDebt();
					parentStatusFlg = bil0101s.get(0).getStatusFlg();
					updateAmountDept = currentAmountDept.subtract(CommonUtils.parseBigDecimal(request.getPayMoney())).subtract(discount);
					parentStatusFlg  = updateAmountDept.compareTo(new BigDecimal("0")) == 0  ? new BigDecimal("2") : parentStatusFlg;
				}
				int updBil0101 = bil0101Repository.updateAmountDebt(updateAmountDept, userId, new Date(), 
						parentStatusFlg, hospCode, request.getParentInvoiceNo());
				if(updBil0101 <= 0) return false;
				LOGGER.info("update saveInvoiceDetail updateAmountDebt OK: Invoice No = " + request.getInvoiceNo());
			}
			return true;
	}
	
	private boolean saveInvoiceDetail(String hospCode, String userId, BillServiceProto.SaveBIL2016U02Request request, String invoiceNo){
		List<BillModelProto.LoadGridBIL2016U02Info> invoiceDetailList =  request.getListInfoList();
		if(!CollectionUtils.isEmpty(invoiceDetailList)){
			Double fkout1001 = CommonUtils.parseDouble(request.getFkout1001());
			for (BillModelProto.LoadGridBIL2016U02Info info : invoiceDetailList) {
				if("Y".equals(info.getCheckYn())){
					if(StringUtils.isEmpty(request.getParentInvoiceNo())){
						Bil0102 bil0102 = new Bil0102();
						Date orderDate = StringUtils.isEmpty(info.getOrderDate()) ? null : DateUtil.toDate(info.getOrderDate(), DateUtil.PATTERN_YYMMDD);
						Date actingDate = StringUtils.isEmpty(info.getActingDate()) ? null : DateUtil.toDate(info.getActingDate(), DateUtil.PATTERN_YYMMDD);
						Double fkocs1003 = StringUtils.isEmpty(info.getFkocs1003()) ? null : Double.parseDouble(info.getFkocs1003().replace(",", "."));
//						String orderGrp = "2".equals(request.getType()) ? "AF" : info.getOrderGroupCd();
						String orderGrp = fkocs1003 == null ? "AF" : info.getOrderGroupCd();
						bil0102.setInvoiceNo(invoiceNo);
						bil0102.setBunho(request.getBunho());	
						bil0102.setHangmogCode(info.getHangmogCode());
						bil0102.setHangmogName(info.getHangmogName());
						bil0102.setUnit(info.getUnit());
						bil0102.setQuantity(info.getQuantity());
						bil0102.setPrice(CommonUtils.parseBigDecimal(info.getPrice()));
						bil0102.setDiscount(CommonUtils.parseBigDecimal(info.getDiscount()));
						bil0102.setInsurancePay(CommonUtils.parseBigDecimal(info.getInsurancePay()));
						bil0102.setOtherPay(null);	
						bil0102.setPatientPay(CommonUtils.parseBigDecimal(info.getPatientPay()));
						bil0102.setAmount(CommonUtils.parseBigDecimal(info.getAmount()));
						bil0102.setDeptReqCd(info.getDeptReqCd());
						bil0102.setDeptReqNm(info.getDeptReqNm());
						bil0102.setDeptExcCd(info.getDeptExcCd());
						bil0102.setDeptExcNm(info.getDeptExcNm());
						bil0102.setDoctorReq(info.getDoctorReqCd());
						bil0102.setDoctorReqNm(info.getDoctorReqNm());
						bil0102.setDoctorExc(info.getDoctorExcCd());
						bil0102.setDoctorExcNm(info.getDoctorExcNm());
//						bil0102.setOrderGrp(info.getOrderGroupCd());
						bil0102.setOrderGrp(orderGrp);
						bil0102.setOrderGrpNm(info.getOrderGroupNm());
						bil0102.setOrderDate(orderDate);
						bil0102.setActingDate(actingDate);
						bil0102.setSysId(userId);
						bil0102.setUpdId(userId);
						bil0102.setActiveFlg(new BigDecimal(1));
						bil0102.setHospCode(hospCode);
						bil0102.setDiscountReason(info.getDiscountReason());
						bil0102.setFkocs1003(fkocs1003);
						
						Bil0102 savedObj =  bil0102Repository.save(bil0102);
						if(savedObj == null) return false;
						if(fkocs1003 != null){
							int updOcs = ocs1003Repository.updatePaidYnAndIfDataSendYn("Y", userId, new Date(), "Y", new Date(), hospCode, fkocs1003);
							if(updOcs <= 0) return false;
							LOGGER.info("update saveInvoiceDetail updatePaidYn OK: Invoice No = " + request.getInvoiceNo());
						}else if(fkocs1003 == null){
							int updOut = out1001Repository.updateOut1001PaidYn(hospCode, fkout1001, "Y", userId,  new Date());
							if(updOut <= 0) return false;
							LOGGER.info("update saveInvoiceDetail updateOut1001PaidYn OK: Invoice No = " + request.getInvoiceNo());
						}
					}
				}else if("N".equals(info.getCheckYn())){
					Double fkocs1003 = StringUtils.isEmpty(info.getFkocs1003()) ? null : Double.parseDouble(info.getFkocs1003().replace(",", "."));
					if(fkocs1003 != null){
						int updOcs = ocs1003Repository.updatePaidYnAndIfDataSendYn("C", userId, new Date(), "N", new Date(), hospCode, fkocs1003);
						if(updOcs <= 0) return false;
					}else if(fkocs1003 == null){
						int updOut = out1001Repository.updateOut1001PaidYn(hospCode, fkout1001, "C", userId,  new Date());
						if(updOut <= 0) return false;
						LOGGER.info("update saveInvoiceDetail updateOut1001PaidYn OK case check Yn = N: Invoice No = " + request.getInvoiceNo());
					}
					
				}
			}
		}
		
		return true;
	}
}
