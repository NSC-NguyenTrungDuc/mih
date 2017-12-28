package nta.med.service.ihis.handler.clis;

import java.math.BigInteger;

import javax.annotation.Resource;

import nta.med.data.dao.medi.clis.ClisProtocolRepository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.ClisServiceProto.CLIS2015U09CheckSmoCodeOnDeleteRequest;
import nta.med.service.ihis.proto.ClisServiceProto.CLIS2015U09CheckSmoCodeOnDeleteResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;


@Service
@Scope("prototype")
public class CLIS2015U09CheckSmoCodeOnDeleteHandler extends ScreenHandler<CLIS2015U09CheckSmoCodeOnDeleteRequest, CLIS2015U09CheckSmoCodeOnDeleteResponse>{
	
	@Resource
	private ClisProtocolRepository clisProtocolRepository;
	
	@Override
	@Transactional(readOnly = true)
	public CLIS2015U09CheckSmoCodeOnDeleteResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CLIS2015U09CheckSmoCodeOnDeleteRequest request) throws Exception {
		CLIS2015U09CheckSmoCodeOnDeleteResponse.Builder response = CLIS2015U09CheckSmoCodeOnDeleteResponse.newBuilder();
		BigInteger result =  clisProtocolRepository.getClis2015U09CheckSmoCodeOnDelete(getHospitalCode(vertx, sessionId), request.getClisSmoId());
		if(result != null){
			response.setCnt(result.toString());
		}
		return response.build();
	}

}
