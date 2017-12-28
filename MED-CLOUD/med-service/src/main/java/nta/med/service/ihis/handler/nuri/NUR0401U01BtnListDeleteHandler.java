package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.nur.Nur0401Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0401U01BtnListDeleteRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class NUR0401U01BtnListDeleteHandler
		extends ScreenHandler<NuriServiceProto.NUR0401U01BtnListDeleteRequest, SystemServiceProto.UpdateResponse> {

	@Resource
	private Nur0401Repository nur0401Repository;
	
	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0401U01BtnListDeleteRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		
		nur0401Repository.updateValdByHospCodeNurPlanBunryu(request.getUpdId(), "N", getHospitalCode(vertx, sessionId),
				request.getNurPlanBunryu());
		
		response.setResult(true);
		return response.build();
	}

}
