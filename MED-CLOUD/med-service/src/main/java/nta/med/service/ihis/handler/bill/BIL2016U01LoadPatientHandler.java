package nta.med.service.ihis.handler.bill;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.CommonEnum;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bil.Bil0101Repository;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.model.ihis.bill.BIL2016U01LoadPatientInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.BillModelProto;
import nta.med.service.ihis.proto.BillServiceProto;
import nta.med.service.ihis.proto.BillServiceProto.BIL2016U01LoadPatientRequest;
import nta.med.service.ihis.proto.BillServiceProto.BIL2016U01LoadPatientResponse;

@Service
@Scope("prototype")
public class BIL2016U01LoadPatientHandler extends ScreenHandler<BillServiceProto.BIL2016U01LoadPatientRequest, BillServiceProto.BIL2016U01LoadPatientResponse> {

	private static final Log LOGGER = LogFactory.getLog(BIL2016U01LoadPatientHandler.class);
	   
	@Resource
	private Ocs1003Repository ocs1003Repository;
	@Resource
	private Bil0101Repository bil0101Repository;
	
	@Override
	@Transactional(readOnly = true)
	public BIL2016U01LoadPatientResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			BIL2016U01LoadPatientRequest request) throws Exception {
		BillServiceProto.BIL2016U01LoadPatientResponse.Builder response = BillServiceProto.BIL2016U01LoadPatientResponse.newBuilder();
		Date visitDate = DateUtil.toDate(request.getCommingDate(), DateUtil.PATTERN_YYMMDD);
		Date toDate = DateUtil.toDate(request.getToDate(), DateUtil.PATTERN_YYMMDD);
		String hospCode = getHospitalCode(vertx, sessionId);
		String suname = request.getSuname();
		String bunho = request.getBunho();
		String invoiceNo = request.getBillNumber();
		List<BIL2016U01LoadPatientInfo> patientInfos = new ArrayList<BIL2016U01LoadPatientInfo>();
		if(CommonEnum.TAB_INVOICE_PAY.getValue().equals(request.getTab())){
			patientInfos = bil0101Repository.getPaidTabBIL2016U01LoadPatientInfo(hospCode, visitDate, toDate, bunho, suname, invoiceNo);
		}else if(CommonEnum.TAB_INVOICE_UNPAY.getValue().equals(request.getTab())){
			patientInfos = ocs1003Repository.getBIL2016U01LoadPatientInfo(hospCode, getLanguage(vertx, sessionId), visitDate, toDate, bunho, suname, invoiceNo);
		} else if(CommonEnum.TAB_INVOICE_CANCEL.getValue().equals(request.getTab())){
			patientInfos = bil0101Repository.getCancelTabBIL2016U01LoadPatientInfo(hospCode, visitDate, toDate, bunho, suname, invoiceNo);
		}else if(CommonEnum.TAB_INVOICE_UNCOMPLETED.getValue().equals(request.getTab())){
			patientInfos = bil0101Repository.getUnCompletedTabBIL2016U01LoadPatientInfo(hospCode, visitDate, toDate, bunho, suname, invoiceNo);
		}
		
		if(!CollectionUtils.isEmpty(patientInfos)){
			for(BIL2016U01LoadPatientInfo item : patientInfos){
				BillModelProto.BIL2016U01LoadPatientInfo.Builder info = BillModelProto.BIL2016U01LoadPatientInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				if (item.getFkout() != null) {
					info.setFkout(String.format("%.0f",item.getFkout()));
				}
				if(item.getSumAmount() != null){
					info.setSumAmount(String.format("%.0f",item.getSumAmount()));
				}
				if(item.getSumDebt() != null){
					info.setSumDebt(String.format("%.0f",item.getSumDebt()));
				}
				if(item.getSumDiscount() != null){
					info.setSumDiscount(String.format("%.0f",item.getSumDiscount()));
				}
				if(item.getSumPaid() != null){
					info.setSumPaid(String.format("%.0f",item.getSumPaid()));
				}
				if(item.getStatusFlg() != null){
					info.setStatusFlg(String.format("%.0f",item.getStatusFlg()));
				}
				response.addLst(info);
			}
		}
		
		List<ComboListItemInfo> itemInfos = bil0101Repository.getTotalAmount(hospCode, visitDate, toDate, bunho, suname, invoiceNo);
		if(!CollectionUtils.isEmpty(itemInfos)){
			if(!StringUtils.isEmpty(itemInfos.get(0).getCode())){
				response.setRevenue(itemInfos.get(0).getCode());
			}
			if(!StringUtils.isEmpty(itemInfos.get(0).getCodeName())){
				response.setTotalPatient(itemInfos.get(0).getCodeName());
			}
		}
		
		return response.build();
	}

}
