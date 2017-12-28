package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs0503Repository;
import nta.med.data.model.ihis.ocsa.OcsaOCS0503Q01GrdOCS0503ListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsaOCS0503U01GrdOCS0503ListRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsaOCS0503U01GrdOCS0503ListResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class OcsaOCS0503U01GrdOCS0503ListHandler 
	extends ScreenHandler<OcsaServiceProto.OcsaOCS0503U01GrdOCS0503ListRequest, OcsaServiceProto.OcsaOCS0503U01GrdOCS0503ListResponse> {
		     
    @Resource
    private Ocs0503Repository ocs0503Repository;
    
    @Override
    @Transactional(readOnly = true)
    public OcsaOCS0503U01GrdOCS0503ListResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OcsaOCS0503U01GrdOCS0503ListRequest request) throws Exception {
             OcsaServiceProto.OcsaOCS0503U01GrdOCS0503ListResponse.Builder response = OcsaServiceProto.OcsaOCS0503U01GrdOCS0503ListResponse.newBuilder();	
			List<OcsaOCS0503Q01GrdOCS0503ListInfo> listItem = ocs0503Repository.getOcsaOCS0503Q01GrdOCS0503ListInfo(getHospitalCode(vertx, sessionId), 
            		 request.getReqDate(),request.getFBunho(),request.getConsultDoctor());
             
             if (listItem != null && !listItem.isEmpty()) {
                 for (OcsaOCS0503Q01GrdOCS0503ListInfo item : listItem) {
                	 OcsaModelProto.OcsaOCS0503U01GrdOCS0503ListInfo.Builder info = OcsaModelProto.OcsaOCS0503U01GrdOCS0503ListInfo.newBuilder();
                	if (!StringUtils.isEmpty(item.getBunho())) {
                		info.setBunho(item.getBunho());
                	}
                	if (item.getReqDate() != null) {
                		info.setReqDate(DateUtil.toString(item.getReqDate(), DateUtil.PATTERN_YYMMDD));
                	}
                	if (!StringUtils.isEmpty(item.getReqGwa())) {
                		info.setReqGwa(item.getReqGwa());
                	}
                	if (!StringUtils.isEmpty(item.getReqDoctor())) {
                		info.setReqDoctor(item.getReqDoctor());
                	}
                	if (item.getPkocs0503() != null) {
                		info.setPkocs0503(String.format("%.0f",item.getPkocs0503()));
                	}
                	if (!StringUtils.isEmpty(item.getConsultGwa())) {
                		info.setConsultGwa(item.getConsultGwa());
                	}
                	if (!StringUtils.isEmpty(item.getConsultDoctor())) {
                		info.setConsultDoctor(item.getConsultDoctor());
                	}
                	if (!StringUtils.isEmpty(item.getWangjinYn())) {
                		info.setWangjinYn(item.getWangjinYn());
                	}
                	if (!StringUtils.isEmpty(item.getSangCode1())) {
                		info.setSangCode1(item.getSangCode1());
                	}
                	if (!StringUtils.isEmpty(item.getSangName1())) {
                		info.setSangName1(item.getSangName1());
                	}
                	if (!StringUtils.isEmpty(item.getSangCode2())) {
                		info.setSangCode2(item.getSangCode2());
                	}
                	if (!StringUtils.isEmpty(item.getSangName2())) {
                		info.setSangName2(item.getSangName2());
                	}
                	if (!StringUtils.isEmpty(item.getSangCode3())) {
                		info.setSangCode3(item.getSangCode3());
                	}
                	if (!StringUtils.isEmpty(item.getSangName3())) {
                		info.setSangName3(item.getSangName3());
                	}
                	if (!StringUtils.isEmpty(item.getConsultSangName())) {
                		info.setConsultSangName(item.getConsultSangName());
                	}
                	if (!StringUtils.isEmpty(item.getReqRemark())) {
                		info.setReqRemark(item.getReqRemark());
                	}
                	if (item.getAppDate() != null) {
                		info.setAppDate(DateUtil.toString(item.getAppDate(), DateUtil.PATTERN_YYMMDD));
                	}
                	if (!StringUtils.isEmpty(item.getAnswer())) {
                		info.setAnswer(item.getAnswer());
                	}
                	if (!StringUtils.isEmpty(item.getInOutGubun())) {
                		info.setInOutGubun(item.getInOutGubun());
                	}
                	if (item.getConsultFkout1001() != null) {
                		info.setConsultFkout1001(String.format("%.0f",item.getConsultFkout1001()));
                	}
                	if (item.getFkinp1001() != null) {
                		info.setFkinp1001(String.format("%.0f",item.getFkinp1001()));
                	}
                	if (!StringUtils.isEmpty(item.getPrintYn())) {
                		info.setPrintYn(item.getPrintYn());
                	}
                	if (!StringUtils.isEmpty(item.getEmerGubun())) {
                		info.setEmerGubun(item.getEmerGubun());
                	}
                	if (!StringUtils.isEmpty(item.getRealJinryoDate())) {
                		info.setRealJinryoDate(item.getRealJinryoDate());
                	}
                	if (!StringUtils.isEmpty(item.getResultArriveDate())) {
                		info.setResultArriveDate(item.getResultArriveDate());
                	}
                	if (!StringUtils.isEmpty(item.getConfirmYn())) {
                		info.setConfirmYn(item.getConfirmYn());
                	}
                	if (!StringUtils.isEmpty(item.getAnswerEndYn())) {
                		info.setAnswerEndYn(item.getAnswerEndYn());
                	}
                	if (item.getJinryoPreDate() != null) {
                		info.setJinryoPreDate(DateUtil.toString(item.getJinryoPreDate(), DateUtil.PATTERN_YYMMDD));
                	}
                	if (!StringUtils.isEmpty(item.getAmpmGubun())) {
                		info.setAmpmGubun(item.getAmpmGubun());
                	}
                	if (!StringUtils.isEmpty(item.getReqEndYn())) {
                		info.setReqEndYn(item.getReqEndYn());
                	}
                	if (!StringUtils.isEmpty(item.getDisplayYn())) {
                		info.setDisplayYn(item.getDisplayYn());
                	}
                	if (!StringUtils.isEmpty(item.getSuname())) {
                		info.setSuname(item.getSuname());
                	}
                	if (!StringUtils.isEmpty(item.getSex())) {
                		info.setSex(item.getSex());
                	}
                	if (item.getAge() != null) {
                		info.setAge(item.getAge().toString());
                	}
                	if (!StringUtils.isEmpty(item.getConsultGwaName())) {
                		info.setConsultGwaName(item.getConsultGwaName());
                	}
                	if (!StringUtils.isEmpty(item.getConsultDoctorName())) {
                		info.setConsultDoctorName(item.getConsultDoctorName());
                	}
                	if (!StringUtils.isEmpty(item.getReqGwaName())) {
                		info.setReqGwaName(item.getReqGwaName());
                	}
                	if (!StringUtils.isEmpty(item.getReqDoctorName())) {
                		info.setReqDoctorName(item.getReqDoctorName());
                	}
                	if (!StringUtils.isEmpty(item.getOldAnswerEndYn())) {
                		info.setOldAnswerEndYn(item.getOldAnswerEndYn());
                	}
                	response.addGridListItem(info);	
                 }
             }
             return response.build();
    }

}
