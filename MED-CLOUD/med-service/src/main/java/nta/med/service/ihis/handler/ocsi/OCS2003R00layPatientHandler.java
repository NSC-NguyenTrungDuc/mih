package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.data.model.ihis.inps.OCS2003R00layPatientInfo;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003R00layPatientRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003R00layPatientResponse;

@Service
@Scope("prototype")
public class OCS2003R00layPatientHandler extends ScreenHandler<OcsiServiceProto.OCS2003R00layPatientRequest, OcsiServiceProto.OCS2003R00layPatientResponse>{
	@Resource
	private Ocs2003Repository ocs2003Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS2003R00layPatientResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003R00layPatientRequest request) throws Exception {
		OcsiServiceProto.OCS2003R00layPatientResponse.Builder response = OcsiServiceProto.OCS2003R00layPatientResponse.newBuilder();
		Double fkinp1001 = CommonUtils.parseDouble(request.getFkinp1001());
		List<OCS2003R00layPatientInfo> layPatient = ocs2003Repository.getOCS2003R00layPatientInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), 
				request.getGwa(), request.getDoctor(), request.getInputGubun(), request.getBunho(), fkinp1001, request.getOrderDate());
		if(!CollectionUtils.isEmpty(layPatient)){
			for(OCS2003R00layPatientInfo item : layPatient){
				OcsiModelProto.OCS2003R00layPatientInfo.Builder info = OcsiModelProto.OCS2003R00layPatientInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addLayPatient(info);
			}
		}
		return response.build();
	}

}
