package nta.med.service.ihis.handler.bill;

import java.math.BigDecimal;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.apache.logging.log4j.util.Strings;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.common.util.DateTimes;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bil.Bil0102Repository;
import nta.med.data.model.ihis.bill.BIL2016R01GrdReportInfo;
import nta.med.data.model.ihis.bill.BIL2016R01GrdReportPaidDisCountInfo;
import nta.med.service.ihis.proto.BillModelProto;
import nta.med.service.ihis.proto.BillServiceProto;

@Service
@Scope("prototype")
public class BIL2016R01GrdReportHandler extends
		ScreenHandler<BillServiceProto.BIL2016R01GrdReportRequest, BillServiceProto.BIL2016R01GrdReportResponse> {
	private static final Log LOGGER = LogFactory.getLog(BIL2016R01GrdReportHandler.class);

	@Resource
	private Bil0102Repository bil0102Repository;

	@Override
	@Transactional(readOnly = true)
	public BillServiceProto.BIL2016R01GrdReportResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, BillServiceProto.BIL2016R01GrdReportRequest request) throws Exception {
		BillServiceProto.BIL2016R01GrdReportResponse.Builder response = BillServiceProto.BIL2016R01GrdReportResponse
				.newBuilder();
		String offset = request.getOffset();
		Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
		if (Strings.isEmpty(request.getPageNumber())) {
			offset = "0" ;
		}
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		Date fromDate = null;
		Date toDate = null;
		BigDecimal totalDiscount = new BigDecimal("0");
		BigDecimal totalPaid = new BigDecimal("0");
		if(!Strings.isEmpty(request.getFromMonth())){
			 fromDate = new Date(DateTimes.parse(DateUtil.PATTERN_YYYYMMDD_BLANK, request.getFromMonth().concat("01")));
		}
		if(!Strings.isEmpty(request.getToMonth())){
			toDate = new Date(DateTimes.addSeconds(DateTimes.addMonths(DateTimes.parse(DateUtil.PATTERN_YYYYMM_BLANK, request.getToMonth()), 1), -1));
		}
		if(!Strings.isEmpty(request.getFromDate())){
			fromDate = DateUtil.toDate(request.getFromDate(), DateUtil.PATTERN_YYMMDD);
		}
		if(!Strings.isEmpty(request.getToDate())){
			toDate = new Date(DateTimes.addSeconds(DateTimes.addDays(DateTimes.parse(DateUtil.PATTERN_YYMMDD, request.getToDate()), 1), -1));
		}
		
		List<BIL2016R01GrdReportInfo> listReportInfos = bil0102Repository.getGrdReportList(hospCode, language, fromDate,
				toDate, request.getAssignDept(), request.getAssignDoctor(), request.getExeDept(),
				request.getExeDoctor(), request.getServiceId(), request.getPersonId(), startNum,
				CommonUtils.parseInteger(offset));
		
		List<BIL2016R01GrdReportPaidDisCountInfo> paidDiscountReport = bil0102Repository.getBIL2016R01GrdReportPaidDisCountInfo(hospCode, language, fromDate,
				toDate, request.getAssignDept(), request.getAssignDoctor(), request.getExeDept(),
				request.getExeDoctor(), request.getServiceId(), request.getPersonId(), startNum,
				CommonUtils.parseInteger(offset));
		if(!CollectionUtils.isEmpty(paidDiscountReport)){
			for(BIL2016R01GrdReportPaidDisCountInfo item : paidDiscountReport){
				totalDiscount = totalDiscount.add(item.getTotalDiscount() != null ? item.getTotalDiscount() : new BigDecimal("0"));
				totalPaid = totalPaid.add(item.getTotalPaid() != null ? item.getTotalPaid() : new BigDecimal("0"));
			}
		}
		LOGGER.info("BIL2016R01GrdReportHandler total discountByTotalInvoice : " + totalDiscount);
		
		if (!CollectionUtils.isEmpty(listReportInfos)) {
			for (BIL2016R01GrdReportInfo item : listReportInfos) {
				BillModelProto.BIL2016R01GrdReportInfo.Builder info = BillModelProto.BIL2016R01GrdReportInfo.newBuilder();
				if(!StringUtils.isEmpty(item.getActingDate())) {
					info.setActingDate(item.getActingDate().toString());
				}
				if(!StringUtils.isEmpty(item.getServiceId())) {
					info.setServiceId(item.getServiceId());
				}
				if(!StringUtils.isEmpty(item.getServiceName())) {
					info.setServiceName(item.getServiceName());
				}
				if(!StringUtils.isEmpty(item.getExecuteDept())) {
					info.setExecuteDept(item.getExecuteDept());
				}
				if(!StringUtils.isEmpty(item.getExecuteDoctor())) {
					info.setExecuteDoctor(item.getExecuteDoctor());
				}
				if(!StringUtils.isEmpty(item.getAssignDept())) {
					info.setAssignDept(item.getAssignDept());
				}
				if(!StringUtils.isEmpty(item.getAssignDoctor())) {
					info.setAssignDoctor(item.getAssignDoctor());
				}
				if(!StringUtils.isEmpty(item.getQuantity())) {
					info.setQuantity(item.getQuantity());
				}
				if(item.getSum() != null){
					info.setSum(String.format("%.0f",item.getSum()));
				}
				if(item.getDiscount() != null) {
					info.setDiscount(String.format("%.0f",item.getDiscount()));
				}
				response.addGrdList(info);
			}
			if(totalDiscount != null){
				response.setSumDiscount(String.format("%.0f", totalDiscount));
			}
			if(totalPaid != null){
				response.setSumAmountPaid(String.format("%.0f", totalPaid));
			}
		}
		return response.build();
	}
}
