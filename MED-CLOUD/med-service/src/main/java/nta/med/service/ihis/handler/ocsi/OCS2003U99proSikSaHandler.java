package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.ocs.Ocs2005Repository;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003U99proSikSaRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003U99proSikSaResponse;

@Service
@Scope("prototype")
public class OCS2003U99proSikSaHandler extends ScreenHandler<OcsiServiceProto.OCS2003U99proSikSaRequest, OcsiServiceProto.OCS2003U99proSikSaResponse>{
	@Resource
	private Ocs2005Repository ocs2005Repository;
	
	@Override
	@Transactional
	public OCS2003U99proSikSaResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003U99proSikSaRequest request) throws Exception {
		OcsiServiceProto.OCS2003U99proSikSaResponse.Builder response = OcsiServiceProto.OCS2003U99proSikSaResponse.newBuilder();
		String result = ocs2005Repository.callPrOcsCreateStopSiksa(request.getStopFromDate(), 
																request.getStopFromBld(), 
																request.getStopToDate(), 
																request.getStopToBld(), 
																request.getBunho(), 
																getHospitalCode(vertx, sessionId), 
																request.getFkinp1001(), 
																request.getUpdId(), 
																request.getCommentGubun(), 
																request.getIudGubun(), 
																request.getIpwonDate());
		if (!StringUtils.isEmpty(result))
			response.setFlag(result);
		return response.build();
	}

}
