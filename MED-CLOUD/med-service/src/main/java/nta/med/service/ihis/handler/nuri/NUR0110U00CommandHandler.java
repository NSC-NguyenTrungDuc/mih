package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.cht.Cht0118Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0110U00CommandRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class NUR0110U00CommandHandler
		extends ScreenHandler<NuriServiceProto.NUR0110U00CommandRequest, SystemServiceProto.StringResponse> {

	@Resource
	private Cht0118Repository cht0118Repository;

	@Override
	@Transactional(readOnly = true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0110U00CommandRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();

		String rs = cht0118Repository.getOCS2005U00BuwiName(getHospitalCode(vertx, sessionId), request.getBuwiCode());
		response.setResult(rs == null ? "" : rs);

		return response.build();
	}

}
