package nta.med.service.ihis.handler.bill;

import java.math.BigDecimal;
import java.text.DecimalFormat;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.lang3.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.bas.Bas0001;
import nta.med.core.domain.bill.Bil0101;
import nta.med.core.domain.out.Out0101;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.bil.Bil0101Repository;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.bill.LoadGridBIL2016U02Info;
import nta.med.service.ihis.proto.BillModelProto;
import nta.med.service.ihis.proto.BillServiceProto;
import nta.med.service.ihis.proto.BillServiceProto.LoadGridBIL2016U02Request;
import nta.med.service.ihis.proto.BillServiceProto.LoadGridBIL2016U02Response;

@Service
@Scope("prototype")
@Transactional
public class LoadGridBIL2016U02Handler
		extends ScreenHandler<BillServiceProto.LoadGridBIL2016U02Request, BillServiceProto.LoadGridBIL2016U02Response> {
	
	private static final Log LOGGER = LogFactory.getLog(LoadGridBIL2016U02Handler.class);
	
//	@Resource
//	private Bil0101RepositoryImpl bil0101RepositoryImpl;
	
	@Resource
	private CommonRepository commonRepository;
	
	@Resource
	private Bas0001Repository bas0001Repository;
	
	@Resource
	private Out0101Repository out0101Repository;
	@Resource
	private Out1001Repository out1001Repository;
	@Resource
	private Bil0101Repository bil0101Repository;
	
	@Override
	public LoadGridBIL2016U02Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			LoadGridBIL2016U02Request request) throws Exception {
		
		BillServiceProto.LoadGridBIL2016U02Response.Builder response = BillServiceProto.LoadGridBIL2016U02Response.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		if("Y".equals(request.getPayYn()) || "C".equals(request.getPayYn()) || "D".equals(request.getPayYn())){
			boolean isActiveInvoice = "Y".equals(request.getPayYn()) || "D".equals(request.getPayYn());
			response.setInvoiceNo(request.getInvoiceNo());
			List<LoadGridBIL2016U02Info> invoiceDetailList = bil0101Repository.getInvoiceDetailList(hospCode, request.getInvoiceNo(), isActiveInvoice);
			
			if(!CollectionUtils.isEmpty(invoiceDetailList)){
				DecimalFormat df = new DecimalFormat("###.###");
				LoadGridBIL2016U02Info firstItem = invoiceDetailList.get(0);
				
				if(firstItem.getTotalDiscount() != null) response.setTotalDiscount(df.format(firstItem.getTotalDiscount()));
				if(firstItem.getPaymentCode() != null) response.setPaymentCode(firstItem.getPaymentCode());
				if(firstItem.getPaymentName() != null) response.setPaymentName(firstItem.getPaymentName());
				if(firstItem.getPaidName() != null) response.setPaidName(firstItem.getPaidName());
				response.setDiscountType(firstItem.getDiscountType());
				response.setDiscountReasonTotal(firstItem.getDiscountReasonMaster());
				response.setRevertType(firstItem.getRevertType());
				response.setRevertComment(firstItem.getRevertComment());
				
				for (LoadGridBIL2016U02Info item : invoiceDetailList) {
					BillModelProto.LoadGridBIL2016U02Info.Builder info = BillModelProto.LoadGridBIL2016U02Info.newBuilder();
					BeanUtils.copyProperties(item, info, language);
					if(item.getPrice() != null) info.setPrice(df.format(item.getPrice()));
					if(item.getAmount() != null) info.setAmount(df.format(item.getAmount()));
					if(item.getInsurancePay() != null) info.setInsurancePay(df.format(item.getInsurancePay()));
					if(item.getPatientPay() != null) info.setPatientPay(df.format(item.getPatientPay()));
					if(item.getDiscount() != null) info.setDiscount(df.format(item.getDiscount()));
					if(item.getAmountPaid() != null) info.setAmountPaid(df.format(item.getAmountPaid()));
					if(item.getAmountDebt() != null) info.setAmountDebt(df.format(item.getAmountDebt()));
					response.addInvoiceDetail(info);
				}
				if(!StringUtils.isEmpty(request.getParentInvoiceNo())){
//					List<LoadGridBIL2016U02SumInfo> sumInfo = bil0101RepositoryImpl.getLoadGridBIL2016U02SumInfoByParentInvoiceNo(hospCode, request.getParentInvoiceNo());
//					if(!CollectionUtils.isEmpty(sumInfo)){
//						BigDecimal totalPatientPay = sumInfo.get(0).getSumAmount().subtract(sumInfo.get(0).getSumDiscount());
//						if(sumInfo.get(0).getSumAmount() != null) response.setTotalAmount(df.format(sumInfo.get(0).getSumAmount()));
//						if(sumInfo.get(0).getSumDiscount() != null) response.setTotalPatientDiscount(df.format(sumInfo.get(0).getSumDiscount()));
//						if(totalPatientPay != null) response.setTotalPatientPay(df.format(totalPatientPay));
//						if(sumInfo.get(0).getSumAmountPaid() != null) response.setTotalAmountPaid(df.format(sumInfo.get(0).getSumAmountPaid()));
//						if(sumInfo.get(0).getSumAmountDept() != null) response.setTotalAmountDebt(df.format(sumInfo.get(0).getSumAmountDept()));
//					}
					List<Bil0101> bil0101s = bil0101Repository.findByHospCodeParentInvoiceNo(hospCode, request.getParentInvoiceNo());
					BigDecimal totalDiscount = new BigDecimal("0");
					BigDecimal totalAmountPaid = new BigDecimal("0");
					BigDecimal totalPatientPay = new BigDecimal("0");
					BigDecimal amount = new BigDecimal("0");
					BigDecimal totalAmountDebt = new BigDecimal("0");
					if(!CollectionUtils.isEmpty(bil0101s)){
						for(Bil0101 bil0101 : bil0101s){
							totalDiscount = totalDiscount.add(bil0101.getDiscount() != null ? bil0101.getDiscount() : new BigDecimal("0"));
							totalAmountPaid = totalAmountPaid.add(bil0101.getAmountPaid() != null ? bil0101.getAmountPaid() : new BigDecimal("0"));
							if(bil0101.getInvoiceNo().equalsIgnoreCase(bil0101.getParentInvoiceNo())){
								amount = bil0101.getAmount();
								totalAmountDebt = bil0101.getAmountDebt();
							}
						}
						totalPatientPay = amount.subtract(totalDiscount);
						if(amount != null) response.setTotalAmount(df.format(amount));
						if(totalDiscount != null) response.setTotalPatientDiscount(df.format(totalDiscount));
						if(totalPatientPay != null) response.setTotalPatientPay(df.format(totalPatientPay));
						if(totalAmountPaid != null) response.setTotalAmountPaid(df.format(totalAmountPaid));
						if(totalAmountDebt != null) response.setTotalAmountDebt(df.format(totalAmountDebt));
						
					}
				}
			}
		} else if("N".equals(request.getPayYn())){
//			String nextSqq = commonRepository.getNextValByHospCode(hospCode, "BIL0101_SEQ");
//			if(nextSqq == null){
//				LOGGER.info("Could not get next sequence BIL0101_SEQ, hosp_code = " + hospCode);
//				return response.build();
//			}
//			
//			String invoiceNo = hospCode + "_" + StringUtils.leftPad(nextSqq, 8, "0");
//			response.setInvoiceNo(invoiceNo);
			//Double fkOut1001 = Double.valueOf(request.getPkout1001());
			Double fkOut1001 = CommonUtils.parseDouble(request.getPkout1001());
			
			List<Out0101> patientList = out0101Repository.getByBunho(hospCode, request.getPatientCode());
			String billingType = !CollectionUtils.isEmpty(patientList) ? patientList.get(0).getBillingType() : "N";
			if(org.springframework.util.StringUtils.isEmpty(billingType)) billingType = "N";
			
			List<LoadGridBIL2016U02Info> invoiceUnPayDetailList = bil0101Repository.getInvoiceUnPayDetailList(hospCode, language, request.getPatientCode(), fkOut1001, billingType);
//			if("1".equals(request.getType())){
//				invoiceUnPayDetailList = bil0101Repository.getInvoiceUnPayDetailList(hospCode, language, request.getPatientCode(), fkOut1001, billingType);
//			}else if("2".equals(request.getType())){
//				invoiceUnPayDetailList = out1001Repository.getInvoiceUnPayForAdmissionFeeDetailList(hospCode, language, request.getPatientCode(), fkOut1001, billingType);
//			}
			if(!CollectionUtils.isEmpty(invoiceUnPayDetailList)){
				DecimalFormat df = new DecimalFormat("###.###");
				BigDecimal amount = new BigDecimal("0");
				BigDecimal totalDiscount = new BigDecimal("0");
				for (LoadGridBIL2016U02Info item : invoiceUnPayDetailList) {
					BillModelProto.LoadGridBIL2016U02Info.Builder info = BillModelProto.LoadGridBIL2016U02Info.newBuilder();
					BeanUtils.copyProperties(item, info, language);
					if(item.getPrice() != null) info.setPrice(df.format(item.getPrice()));
					if(item.getAmount() != null) info.setAmount(df.format(item.getAmount()));
					if(item.getInsurancePay() != null) info.setInsurancePay(df.format(item.getInsurancePay()));
					if(item.getPatientPay() != null) info.setPatientPay(df.format(item.getPatientPay()));
					if(item.getDiscount() != null) info.setDiscount(df.format(item.getDiscount()));
					if(item.getTotalDiscount() != null) response.setTotalDiscount(df.format(item.getTotalDiscount()));
					if(item.getAmountPaid() != null) info.setAmountPaid(df.format(item.getAmountPaid()));
					if(item.getAmountDebt() != null) info.setAmountDebt(df.format(item.getAmountDebt()));
					response.addInvoiceDetail(info);
					amount = amount.add(item.getAmount() != null ? item.getAmount() : new BigDecimal("0"));
					totalDiscount = totalDiscount.add(item.getDiscount() != null ? item.getDiscount() : new BigDecimal("0"));
				}
				if(amount != null) {
					response.setTotalAmount(df.format(amount));
					response.setTotalPatientPay(df.format(amount.subtract(totalDiscount)));
					response.setTotalAmountDebt(df.format(amount.subtract(totalDiscount)));
				}
			}
		}
		
		List<Bas0001> hospList = bas0001Repository.findLatestByHospCode(hospCode);
		if(!CollectionUtils.isEmpty(hospList)){
			Bas0001 hosp = hospList.get(0);
			response.setYoyangName(hosp.getYoyangName() == null ? "" : hosp.getYoyangName());
			response.setAdress(hosp.getAddress() == null ? "" : hosp.getAddress());
			response.setTel(hosp.getTel() == null ? "" : hosp.getTel());
			response.setEmail(hosp.getEmail() == null ? "" : hosp.getEmail());
			response.setWebsite(hosp.getHomepage() == null ? "" : hosp.getHomepage());
		}
		
		return response.build();
	}
	
}
