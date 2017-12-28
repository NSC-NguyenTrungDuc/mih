package nta.med.service.emr.handler;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur7001Repository;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.nuri.NuriMeasurePhysicalConditionListItemInfo;
import nta.med.data.model.ihis.nuro.NuroManagePatient;
import nta.med.service.emr.proto.EmrServiceProto;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuroModelProto;
@Service                                                                                                          
@Scope("prototype")
public class OCS2015U00GetPatientInfoHandler extends ScreenHandler<EmrServiceProto.OCS2015U00GetPatientInfoRequest, EmrServiceProto.OCS2015U00GetPatientInfoResponse> {
	@Resource                                                                                                       
	private Out0101Repository out0101Repository;
	
	@Resource
	private Nur7001Repository nur7001Repository;

	@Override
	@Transactional(readOnly = true)
	public EmrServiceProto.OCS2015U00GetPatientInfoResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, EmrServiceProto.OCS2015U00GetPatientInfoRequest request) throws Exception {
		EmrServiceProto.OCS2015U00GetPatientInfoResponse.Builder response = EmrServiceProto.OCS2015U00GetPatientInfoResponse.newBuilder();
		List<NuroManagePatient> listManagePatientInfo = out0101Repository.getNuroManagePatientInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getBunho());
		if (listManagePatientInfo != null && !listManagePatientInfo.isEmpty()) {
			for (NuroManagePatient obj : listManagePatientInfo) {
				NuroModelProto.NuroManagePatientInfo.Builder managePatientInfoBuiler = NuroModelProto.NuroManagePatientInfo.newBuilder();
				BeanUtils.copyProperties(obj, managePatientInfoBuiler, getLanguage(vertx, sessionId));
				response.addManagePatInfo(managePatientInfoBuiler);
			}
		}
		
		List<NuriMeasurePhysicalConditionListItemInfo> listObject = nur7001Repository.getNuriMeasurePhysicalConditionListItemInfo(getHospitalCode(vertx, sessionId), request.getBunho());
        if (listObject != null && !listObject.isEmpty()) {
         	for(NuriMeasurePhysicalConditionListItemInfo item : listObject) {
         		NuriModelProto.NuriNUR7001U00MeasurePhysicalConditionListItemInfo.Builder info = NuriModelProto.NuriNUR7001U00MeasurePhysicalConditionListItemInfo.newBuilder();
         		if (!StringUtils.isEmpty(item.getBunho())){
         			info.setBunho(item.getBunho());
         		}
         		if (item.getMeasureDate() != null){
         			info.setMeasureDate(DateUtil.toString(item.getMeasureDate(), DateUtil.PATTERN_YYMMDD));
         		}
         		if (item.getSeq() != null){
         			info.setSeq(String.format("%.0f", item.getSeq()));
         		}
         		if (item.getHeight() != null){
         			info.setHeight(String.format("%.1f", item.getHeight()));
         		}
         		if (item.getWeight() != null){
         			info.setWeight(String.format("%.2f", item.getWeight()));
         		}
         		if (item.getBpFrom() != null){
         			info.setBpFrom(String.format("%.0f", item.getBpFrom()));
         		}
         		if (item.getBpTo() != null){
         			info.setBpTo(String.format("%.0f", item.getBpTo()));
         		}
         		if (item.getBodyHeat() != null){
         			info.setBodyHeat(String.format("%.1f", item.getBodyHeat()));
         		}
         		if (item.getPulse() != null){
         			info.setPulse(String.format("%.0f", item.getPulse()));
         		}
         		if (!StringUtils.isEmpty(item.getSuname())){
         			info.setSuname(item.getSuname());
         		}
         		if (item.getSpo2() != null){
         			info.setSpo2(String.format("%.0f", item.getSpo2()));
         		}
         		if (!StringUtils.isEmpty(item.getMeasureTime())){
         			info.setMeasureTime(item.getMeasureTime());
         		}
         		if (item.getBreath() != null){
         			info.setBreath(String.format("%.0f", item.getBreath()));
         		}
         		if (!StringUtils.isEmpty(item.getUpdId())){
         			info.setUpdId(item.getUpdId());
         		}
         		response.addPhyInfoItem(info);
         	}
         }
		return response.build();
	}

}
