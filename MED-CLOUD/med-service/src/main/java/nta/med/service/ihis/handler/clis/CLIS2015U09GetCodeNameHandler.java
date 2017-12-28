package nta.med.service.ihis.handler.clis;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.ClisServiceProto.CLIS2015U09GetCodeNameRequest;
import nta.med.service.ihis.proto.ClisServiceProto.CLIS2015U09GetCodeNameResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CLIS2015U09GetCodeNameHandler extends ScreenHandler<CLIS2015U09GetCodeNameRequest, CLIS2015U09GetCodeNameResponse>{
	@Resource
	private Bas0102Repository bas0102Repository;
	
	@Override
	@Transactional(readOnly = true)
	public CLIS2015U09GetCodeNameResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CLIS2015U09GetCodeNameRequest request) throws Exception {
		CLIS2015U09GetCodeNameResponse.Builder response = CLIS2015U09GetCodeNameResponse.newBuilder();
		String result = bas0102Repository.getCodeNameByCodeTypeAndCode(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),
				"DODOBUHYEUN_NO", request.getCode());
		if(!StringUtils.isEmpty(result)){
			response.setCodeName(result);
		}
		
		return response.build();
	}

}
