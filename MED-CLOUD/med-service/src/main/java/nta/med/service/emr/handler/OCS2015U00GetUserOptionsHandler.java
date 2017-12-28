package nta.med.service.emr.handler;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0150Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.emr.proto.EmrServiceProto;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")     
public class OCS2015U00GetUserOptionsHandler extends ScreenHandler<EmrServiceProto.OCS2015U00GetUserOptionsRequest, EmrServiceProto.OCS2015U00GetUserOptionsResponse> {
	@Resource                                                                                                       
	private Ocs0150Repository ocs0150Repository;

	@Override
	@Transactional(readOnly = true)
	public EmrServiceProto.OCS2015U00GetUserOptionsResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, EmrServiceProto.OCS2015U00GetUserOptionsRequest request) throws Exception {
		EmrServiceProto.OCS2015U00GetUserOptionsResponse.Builder response = EmrServiceProto.OCS2015U00GetUserOptionsResponse.newBuilder();
		//
		String allergyPopYn = ocs0150Repository.getOcsOrderBizGetUserOptionInfo(getHospitalCode(vertx, sessionId),request.getUserId(),
				request.getGwa(), "ALLERGY_POP_YN", request.getIoGubun());
		if(!StringUtils.isEmpty(allergyPopYn)){
			response.setAllergyPopYn(allergyPopYn);
		}
		//
		String specialwritePopYn = ocs0150Repository.getOcsOrderBizGetUserOptionInfo(getHospitalCode(vertx, sessionId),request.getUserId(),
				request.getGwa(), "SPECIALWRITE_POP_YN", request.getIoGubun());
		if(!StringUtils.isEmpty(specialwritePopYn)){
			response.setSpecialwritePopYn(specialwritePopYn);
		}
		//
		String sameNameCheckYn = ocs0150Repository.getOcsOrderBizGetUserOptionInfo(getHospitalCode(vertx, sessionId),request.getUserId(),
				request.getGwa(), "SAME_NAME_CHECK_YN", request.getIoGubun());
		if(!StringUtils.isEmpty(sameNameCheckYn)){
			response.setSameNameCheckYn(sameNameCheckYn);
		}
		//
		String vitalsignsPopYn = ocs0150Repository.getOcsOrderBizGetUserOptionInfo(getHospitalCode(vertx, sessionId),request.getUserId(),
				request.getGwa(), "VITALSIGNS_POP_YN", request.getIoGubun());
		if(!StringUtils.isEmpty(vitalsignsPopYn)){
			response.setVitalsignsPopYn(vitalsignsPopYn);
		}
		//
		String emrPopYn = ocs0150Repository.getOcsOrderBizGetUserOptionInfo(getHospitalCode(vertx, sessionId),request.getUserId(),
				request.getGwa(), "EMR_POP_YN", request.getIoGubun());
		if(!StringUtils.isEmpty(emrPopYn)){
			response.setEmrPopYn(emrPopYn);
		}
		//
		String orderLabelPrtYn = ocs0150Repository.getOcsOrderBizGetUserOptionInfo(getHospitalCode(vertx, sessionId),request.getUserId(),
				request.getGwa(), "ORDER_LABEL_PRT_YN", request.getIoGubun());
		if(!StringUtils.isEmpty(orderLabelPrtYn)){
			response.setOrderLabelPrtYn(orderLabelPrtYn);
		}
		
		//
		String potionDrugYn = ocs0150Repository.getOcsOrderBizGetUserOptionInfo(getHospitalCode(vertx, sessionId),request.getUserId(),
				request.getGwa(), "POTION_DRUG_YN", request.getIoGubun());
		if(!StringUtils.isEmpty(potionDrugYn)){
			response.setPotionDrugOrder(potionDrugYn);
		}
		
		//
		String diseaseUnregisteredYn = ocs0150Repository.getOcsOrderBizGetUserOptionInfo(getHospitalCode(vertx, sessionId),request.getUserId(),
				request.getGwa(), "DISEASE_UNREGISTERED_YN", request.getIoGubun());
		if(!StringUtils.isEmpty(diseaseUnregisteredYn)){
			response.setDiseaseNameUnregistered(diseaseUnregisteredYn);
		}
		
		//
		String infectionPopYn = ocs0150Repository.getOcsOrderBizGetUserOptionInfo(getHospitalCode(vertx, sessionId),request.getUserId(),
				request.getGwa(), "INFECTION_POP_YN", request.getIoGubun());
		if(!StringUtils.isEmpty(infectionPopYn)){
			response.setInfection(infectionPopYn);
		}
		
		return response.build();
		
	}

}
