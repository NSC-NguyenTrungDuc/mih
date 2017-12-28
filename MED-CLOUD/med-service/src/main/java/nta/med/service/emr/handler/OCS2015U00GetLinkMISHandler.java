package nta.med.service.emr.handler;

import java.util.concurrent.TimeUnit;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

import nta.med.common.remoting.rpc.message.RpcMessageParser;
import nta.med.common.util.concurrent.future.FutureEx;
import nta.med.core.config.Configuration;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.emr.proto.EmrServiceProto;
import nta.med.service.emr.proto.EmrServiceProto.OCS2015U00GetLinkMISRequest;
import nta.med.service.emr.proto.EmrServiceProto.OCS2015U00GetLinkMISResponse;
import nta.med.service.ihis.proto.SystemServiceProto;

@Service
@Scope("prototype")
public class OCS2015U00GetLinkMISHandler extends ScreenHandler<EmrServiceProto.OCS2015U00GetLinkMISRequest, EmrServiceProto.OCS2015U00GetLinkMISResponse>{
	
	@Resource
    private Configuration configuration;
	
	private static final Log LOGGER = LogFactory.getLog(OCS2015U00GetLinkMISHandler.class);
	private RpcMessageParser parser = new RpcMessageParser(SystemServiceProto.class);
	
	@Override
	public OCS2015U00GetLinkMISResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2015U00GetLinkMISRequest request) throws Exception {
		
		EmrServiceProto.OCS2015U00GetLinkMISResponse.Builder response = EmrServiceProto.OCS2015U00GetLinkMISResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = getUserId(vertx, sessionId);
				
		SystemServiceProto.GetMisTokenRequest.Builder rq = SystemServiceProto.GetMisTokenRequest.newBuilder();
		rq.setId(System.currentTimeMillis());
		rq.setHospCode(hospCode);
		rq.setUserId(userId);
		
		LOGGER.info("OCS2015U00GetLinkMISHandler: hosp_code = " + hospCode + ", user_id = " + userId);
		FutureEx<SystemServiceProto.GetMisTokenResponse> res = send(vertx, parser, rq.build(), hospCode);
		SystemServiceProto.GetMisTokenResponse r = res.get(30, TimeUnit.SECONDS);
		if(r == null){
			LOGGER.info("OCS2015U00GetLinkMISHandler: Get token fail ");
		} else {
			LOGGER.info("OCS2015U00GetLinkMISHandler: token =  " + r.getToken());
		}
		
		response.setToken(r != null ? r.getToken() : "");
		return response.build();
	}
	
}
