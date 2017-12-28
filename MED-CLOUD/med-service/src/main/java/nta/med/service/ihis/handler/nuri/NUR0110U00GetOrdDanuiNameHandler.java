package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.ocs.Ocs2016Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0110U00GetOrdDanuiNameRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class NUR0110U00GetOrdDanuiNameHandler
		extends ScreenHandler<NuriServiceProto.NUR0110U00GetOrdDanuiNameRequest, SystemServiceProto.StringResponse> {

	@Resource
	private Ocs2016Repository ocs2016Repository;

	@Override
	@Transactional(readOnly = true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0110U00GetOrdDanuiNameRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		String rs = ocs2016Repository.getOrdDanuiName(getHospitalCode(vertx, sessionId), request.getOrdDanui());

		response.setResult(rs);
		return response.build();
	}

}
