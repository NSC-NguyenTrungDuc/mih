package nta.med.service.ihis.handler.clis;

import javax.annotation.Resource;

import nta.med.data.dao.medi.clis.ClisSmoRepository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.ClisServiceProto.CLIS2015U09CheckSmoCodeRequest;
import nta.med.service.ihis.proto.ClisServiceProto.CLIS2015U09CheckSmoCodeResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;


@Service
@Scope("prototype")
public class Clis2015U09CheckSmoCodeHandler extends ScreenHandler<CLIS2015U09CheckSmoCodeRequest, CLIS2015U09CheckSmoCodeResponse>{
	@Resource
	private ClisSmoRepository clisSmoRepository;
	
	@Override
	@Transactional(readOnly = true)
	public CLIS2015U09CheckSmoCodeResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CLIS2015U09CheckSmoCodeRequest request) throws Exception {
		CLIS2015U09CheckSmoCodeResponse.Builder response = CLIS2015U09CheckSmoCodeResponse.newBuilder();
		String result = clisSmoRepository.getClis2015U09CheckSmoCodeInfo(getHospitalCode(vertx, sessionId), request.getSmoCode());
		if(!StringUtils.isEmpty(result)){
			response.setCnt(result);
		}
		return response.build();
	}

}
