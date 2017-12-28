package nta.med.kcck.api.socket.handler.system;

import javax.annotation.Resource;

import org.springframework.stereotype.Component;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.kcck.api.rpc.service.system.SystemApiService;
import nta.med.service.ihis.proto.SystemServiceProto;

@Component("getMisTokenHandler")
public class GetMisTokenHandler extends ScreenHandler<SystemServiceProto.GetMisTokenRequest, SystemServiceProto.GetMisTokenResponse>{

	@Resource
	private SystemApiService systemApiService;
	
	@Override
	public SystemServiceProto.GetMisTokenResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			SystemServiceProto.GetMisTokenRequest request) throws Exception {
		
		nta.med.kcck.api.rpc.proto.SystemServiceProto.GetMisTokenResponse res = systemApiService.getMisToken(toApiRequest(request));
		SystemServiceProto.GetMisTokenResponse.Builder r = SystemServiceProto.GetMisTokenResponse.newBuilder();
		
		r.setToken(res.getToken());
		r.setId(res.getId());
		return r.build();
	}
	
	private nta.med.kcck.api.rpc.proto.SystemServiceProto.GetMisTokenRequest toApiRequest(SystemServiceProto.GetMisTokenRequest request){
		nta.med.kcck.api.rpc.proto.SystemServiceProto.GetMisTokenRequest.Builder r = nta.med.kcck.api.rpc.proto.SystemServiceProto.GetMisTokenRequest.newBuilder();
		r.setId(request.getId()).setHospCode(request.getHospCode()).setUserId(request.getUserId());
		return r.build();
	}
	
}
