package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0110U00GrdNUR0115FindClickRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class NUR0110U00GrdNUR0115FindClickHandler extends
		ScreenHandler<NuriServiceProto.NUR0110U00GrdNUR0115FindClickRequest, SystemServiceProto.StringResponse> {

	@Resource
	private Ocs0103Repository ocs0103Repository;
	
	@Override
	@Transactional(readOnly = true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0110U00GrdNUR0115FindClickRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		String rs = ocs0103Repository.getOCS2005U00checkInputControl(getHospitalCode(vertx, sessionId), request.getHangmogCode());
		
		response.setResult(rs == null ? "" : rs);
		return response.build();
	}

}
