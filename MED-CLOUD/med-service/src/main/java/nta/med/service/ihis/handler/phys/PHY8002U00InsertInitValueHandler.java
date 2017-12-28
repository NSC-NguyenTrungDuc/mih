package nta.med.service.ihis.handler.phys;

import javax.annotation.Resource;

import nta.med.data.dao.medi.CommonRepository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PhysServiceProto;
import nta.med.service.ihis.proto.PhysServiceProto.PHY8002U00InsertInitValueRequest;
import nta.med.service.ihis.proto.PhysServiceProto.PHY8002U00InsertInitValueResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class PHY8002U00InsertInitValueHandler
	extends ScreenHandler<PhysServiceProto.PHY8002U00InsertInitValueRequest, PhysServiceProto.PHY8002U00InsertInitValueResponse> {                     
	@Resource                                                                                                       
	private CommonRepository commonRepository;                                                                    
	                                                                                                                
	@Override
	@Transactional
	public PHY8002U00InsertInitValueResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			PHY8002U00InsertInitValueRequest request) throws Exception {                                                                   
  	   	PhysServiceProto.PHY8002U00InsertInitValueResponse.Builder response = PhysServiceProto.PHY8002U00InsertInitValueResponse.newBuilder();                      
		String tChk = commonRepository.getNextVal("PHY8002_SEQ");
		if (!StringUtils.isEmpty(tChk)) {
			response.setTChk(tChk);
		}
		String scanChk = commonRepository.getNextVal("SCAN001_SEQ");
		if (!StringUtils.isEmpty(tChk)) {
			response.setRetVal(scanChk);
		} else {
			response.setRetVal("1");
		}
		return response.build();
	}
}