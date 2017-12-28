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
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;
import nta.med.service.ihis.proto.SystemServiceProto.UserNameRequest;

@Service
@Scope("prototype")
public class UserNameHandler extends ScreenHandler <SystemServiceProto.UserNameRequest, SystemServiceProto.StringResponse> {
	@Resource
    private Adm3200Repository adm3200Repository;

	@Override
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			UserNameRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		
		List<String> listString = adm3200Repository.getUserNameByUserId(getHospitalCode(vertx, sessionId), request.getUserId());
		response.setResult(CollectionUtils.isEmpty(listString) ? "" : listString.get(0));
	    return response.build();
	}
}
