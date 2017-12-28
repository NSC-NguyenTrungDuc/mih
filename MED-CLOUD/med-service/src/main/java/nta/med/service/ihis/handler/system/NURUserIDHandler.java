package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.NURUserIDRequest;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class NURUserIDHandler
		extends ScreenHandler<SystemServiceProto.NURUserIDRequest, SystemServiceProto.StringResponse> {

	@Resource
	private Adm3200Repository adm3200Repository;

	@Override
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NURUserIDRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		List<String> lstUser = adm3200Repository.getNurUserId(getHospitalCode(vertx, sessionId), request.getId());
		String userName = CollectionUtils.isEmpty(lstUser) ? "" : lstUser.get(0);
		response.setResult(userName);

		return response.build();
	}

}
