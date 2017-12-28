package nta.med.service.ihis.handler.phys;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PhysServiceProto;
import nta.med.service.ihis.proto.PhysServiceProto.PHY8002U01PHY1000U00ScreenOpenRequest;
import nta.med.service.ihis.proto.PhysServiceProto.PHY8002U01PHY1000U00ScreenOpenResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class PHY8002U01PHY1000U00ScreenOpenHandler
	extends ScreenHandler<PhysServiceProto.PHY8002U01PHY1000U00ScreenOpenRequest, PhysServiceProto.PHY8002U01PHY1000U00ScreenOpenResponse> {                     
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;                                                                    
	                                                                                                                
	@Override       
	@Transactional(readOnly=true)
	public PHY8002U01PHY1000U00ScreenOpenResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			PHY8002U01PHY1000U00ScreenOpenRequest request) throws Exception {                                                                 
  	   	PhysServiceProto.PHY8002U01PHY1000U00ScreenOpenResponse.Builder response = PhysServiceProto.PHY8002U01PHY1000U00ScreenOpenResponse.newBuilder();                      
		List<String> result = ocs0132Repository.getCodeNameByCodeAndCodeType(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), "RESULT_PATH", "PATH");
		if(!StringUtils.isEmpty(result)){
			response.setCodeName(result.get(0));
		}
		return response.build();
	}
}