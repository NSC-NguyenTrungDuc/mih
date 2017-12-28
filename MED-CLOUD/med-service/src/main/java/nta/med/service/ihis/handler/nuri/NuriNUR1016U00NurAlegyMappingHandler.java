package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import nta.med.data.dao.medi.nur.Nur1016Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuriServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class NuriNUR1016U00NurAlegyMappingHandler extends ScreenHandler<NuriServiceProto.NuriNUR1016U00NurAlegyMappingRequest, NuriServiceProto.NuriNUR1016U00NurAlegyMappingResponse> {
	private static final Log LOG = LogFactory.getLog(NuriNUR1016U00NurAlegyMappingHandler.class);
	
	@Resource
	private Nur1016Repository nur1016Repository;

	@Override
	@Transactional
	public NuriServiceProto.NuriNUR1016U00NurAlegyMappingResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuriServiceProto.NuriNUR1016U00NurAlegyMappingRequest request) throws Exception {
		 NuriServiceProto.NuriNUR1016U00NurAlegyMappingResponse.Builder response = NuriServiceProto.NuriNUR1016U00NurAlegyMappingResponse.newBuilder();
		 String result = nur1016Repository.callNuriNUR1016U00NurAlegyMapping(getHospitalCode(vertx, sessionId), request.getBunho(), request.getTableId(), request.getUserId());
		 if(!StringUtils.isEmpty(result)){
			 response.setResult(result);
		 }
		return response.build();
	}
}
