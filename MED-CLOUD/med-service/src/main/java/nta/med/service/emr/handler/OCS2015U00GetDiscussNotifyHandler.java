package nta.med.service.emr.handler;

import java.math.BigDecimal;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.ocs.Ocs0701Repository;
import nta.med.service.emr.proto.EmrServiceProto;
import nta.med.service.emr.proto.EmrServiceProto.OCS2015U00GetDiscussNotifyRequest;
import nta.med.service.emr.proto.EmrServiceProto.OCS2015U00GetDiscussNotifyResponse;

@Service
@Scope("prototype")
public class OCS2015U00GetDiscussNotifyHandler extends ScreenHandler<EmrServiceProto.OCS2015U00GetDiscussNotifyRequest, EmrServiceProto.OCS2015U00GetDiscussNotifyResponse>{

	@Resource
	private Ocs0701Repository ocs0701Repository;
	
	@Override
	public OCS2015U00GetDiscussNotifyResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2015U00GetDiscussNotifyRequest request) throws Exception {
		
		EmrServiceProto.OCS2015U00GetDiscussNotifyResponse.Builder response = EmrServiceProto.OCS2015U00GetDiscussNotifyResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String doctor = getUserId(vertx, sessionId);
		
		String consult = ocs0701Repository.countToNotofication(hospCode, doctor, new BigDecimal(1));
		String req = ocs0701Repository.countToNotofication(hospCode, doctor, new BigDecimal(2));
		
		response.setConsult(consult);
		response.setReq(req);
		
		return response.build();
	}
}
