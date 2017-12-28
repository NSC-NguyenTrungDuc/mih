package nta.med.service.ihis.handler.drgs;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3041P06layHodongRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class DRG3041P06layHodongHandler
		extends ScreenHandler<DrgsServiceProto.DRG3041P06layHodongRequest, SystemServiceProto.StringResponse> {

	@Resource
	private Inp1001Repository inp1001Repository;

	@Override
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DRG3041P06layHodongRequest request) throws Exception {

		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		String hoDong = inp1001Repository.getHoDongByHospCodeAndBunho(getHospitalCode(vertx, sessionId), request.getBunho());

		response.setResult(hoDong);
		return response.build();
	}
}