package nta.med.service.ihis.handler.bill;

import java.text.DecimalFormat;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import java.util.stream.Collectors;

import javax.annotation.Resource;

import org.apache.commons.lang3.StringUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bil.Bil0101Repository;
import nta.med.data.model.ihis.bill.BIL2016U02PrintAmountInfo;
import nta.med.data.model.ihis.bill.LoadGridBIL2016U02Info;
import nta.med.service.ihis.proto.BillModelProto;
import nta.med.service.ihis.proto.BillServiceProto;
import nta.med.service.ihis.proto.BillServiceProto.BIL0102U00DataReportRequest;
import nta.med.service.ihis.proto.BillServiceProto.BIL0102U00DataReportResponse;

@Service
@Scope("prototype")
public class BIL0102U00DataReportHandler extends ScreenHandler<BillServiceProto.BIL0102U00DataReportRequest, BillServiceProto.BIL0102U00DataReportResponse>{
	@Resource
	private Bil0101Repository bil0101Repository;
	@Override
	@Transactional(readOnly = true)
	public BIL0102U00DataReportResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			BIL0102U00DataReportRequest request) throws Exception {
		BillServiceProto.BIL0102U00DataReportResponse.Builder response = BillServiceProto.BIL0102U00DataReportResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String invoiceNo = request.getInvoiceNo();
		String parentInvoiceNo = request.getParentInvoiceNo();
		List<LoadGridBIL2016U02Info> invoiceDetailList = bil0101Repository.getInvoiceDetailList(hospCode, invoiceNo, false);
		DecimalFormat df = new DecimalFormat("###.###");
		if(!CollectionUtils.isEmpty(invoiceDetailList)){
			Map<String, List<LoadGridBIL2016U02Info>> groupByDeptCodeMap = invoiceDetailList.stream().collect(Collectors.groupingBy(LoadGridBIL2016U02Info::getOrderGroupNm));
			Iterator<?> it = groupByDeptCodeMap.entrySet().iterator();
	        while (it.hasNext()) {
				Map.Entry pairs = (Map.Entry) it.next();
				BillModelProto.BIL0102U00DataReportInfo.Builder groupInfo = BillModelProto.BIL0102U00DataReportInfo.newBuilder();
				groupInfo.setDepartment(StringUtils.isEmpty(pairs.getKey().toString()) ? "" : pairs.getKey().toString());
				List<LoadGridBIL2016U02Info> invoiceGroup = (List<LoadGridBIL2016U02Info>) pairs.getValue();
				for (LoadGridBIL2016U02Info item : invoiceGroup) {
					BillModelProto.LoadGridBIL2016U02Info.Builder info = BillModelProto.LoadGridBIL2016U02Info.newBuilder();
					BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					if(item.getPrice() != null) info.setPrice(df.format(item.getPrice()));
					if(item.getAmount() != null) info.setAmount(df.format(item.getAmount()));
					if(item.getInsurancePay() != null) info.setInsurancePay(df.format(item.getInsurancePay()));
					if(item.getPatientPay() != null) info.setPatientPay(df.format(item.getPatientPay()));
					if(item.getDiscount() != null) info.setDiscount(df.format(item.getDiscount()));
					if(item.getAmountPaid() != null) info.setAmountPaid(df.format(item.getAmountPaid()));
					if(item.getAmountDebt() != null) info.setAmountDebt(df.format(item.getAmountDebt()));
					groupInfo.addInvoiceDetail(info);
				}
				response.addInvoiceDetail(groupInfo);
				
			}
		}
		BIL2016U02PrintAmountInfo amountInfo = bil0101Repository.getBIL2016U02PrintMoneyInfo(hospCode, parentInvoiceNo, invoiceNo);
		if(amountInfo != null){
			if(amountInfo.getAmount() != null) response.setSumAmountInvoice(df.format(amountInfo.getAmount()));
			if(amountInfo.getAmountPaid() != null) response.setPaidInvoice(df.format(amountInfo.getAmountPaid()));
			if(amountInfo.getAmountDebt() != null) response.setTotalDebt(df.format(amountInfo.getAmountDebt()));
			if(amountInfo.getTotalAmountPaid() != null) response.setTotalPaid(df.format(amountInfo.getTotalAmountPaid()));
		}
//		List<Bil0101> bil0101s = bil0101Repository.findByParentInvoiceNoOrderByCreated(hospCode, parentInvoiceNo);
//		if(!CollectionUtils.isEmpty(bil0101s)){
//			BigDecimal amountPaid =  new BigDecimal("0");
//			BigDecimal amountDebt =  new BigDecimal("0");
//			BigDecimal totalAmount = new BigDecimal("0");
//			BigDecimal totalAmountPaid = new BigDecimal("0");
//			Date createdDateByInvoiceNo = null;
//			for(Bil0101 bil0101 : bil0101s){
//				if(bil0101.getInvoiceNo().equalsIgnoreCase(bil0101.getParentInvoiceNo())){
//					totalAmount = bil0101.getAmount() != null ? bil0101.getAmount() : new BigDecimal("0");
//					BigDecimal discount = bil0101.getDiscount() != null ? bil0101.getDiscount() : new BigDecimal("0");
//					totalAmount = totalAmount.subtract(discount);
//				}
//				if(invoiceNo.equalsIgnoreCase(bil0101.getInvoiceNo())){
//					amountPaid = bil0101.getAmountPaid() != null ? bil0101.getAmountPaid() : new BigDecimal("0");
//					amountDebt = bil0101.getAmountDebt() != null ? bil0101.getAmountDebt() : new BigDecimal("0");
//					if(parentInvoiceNo.equalsIgnoreCase(invoiceNo)){
//						amountDebt = totalAmount.subtract(amountPaid);
//					}
//					createdDateByInvoiceNo = bil0101.getCreated();
//				}
//				if(createdDateByInvoiceNo != null && createdDateByInvoiceNo.compareTo(bil0101.getCreated()) >= 0){
//					totalAmountPaid = totalAmountPaid.add(bil0101.getAmountPaid() != null ? bil0101.getAmountPaid() : new BigDecimal("0"));
//				}
//			}
//			if(totalAmount != null) response.setSumAmountInvoice(df.format(totalAmount));
//			if(amountPaid != null) response.setPaidInvoice(df.format(amountPaid));
//			if(amountDebt != null) response.setTotalDebt(df.format(amountDebt));
//			if(totalAmountPaid != null) response.setTotalPaid(df.format(totalAmountPaid));
//		}
		return response.build();
	}

}
