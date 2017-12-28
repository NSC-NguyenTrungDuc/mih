package nta.med.service.ihis.handler.phys;

import javax.annotation.Resource;

import nta.med.data.dao.medi.CommonRepository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PhysServiceProto;
import nta.med.service.ihis.proto.PhysServiceProto.PHY8002U01GetScan001SeqRequest;
import nta.med.service.ihis.proto.PhysServiceProto.PHY8002U01GetScan001SeqResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class PHY8002U01GetScan001SeqHandler
	extends ScreenHandler<PhysServiceProto.PHY8002U01GetScan001SeqRequest, PhysServiceProto.PHY8002U01GetScan001SeqResponse> {                     
	@Resource                                                                                                       
	private CommonRepository commonRepository;                                                                    
	                                                                                                                
	@Override
	@Transactional
	public PHY8002U01GetScan001SeqResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			PHY8002U01GetScan001SeqRequest request) throws Exception {                                                                 
  	   	PhysServiceProto.PHY8002U01GetScan001SeqResponse.Builder response = PhysServiceProto.PHY8002U01GetScan001SeqResponse.newBuilder();                      
		String result = commonRepository.getNextVal("SCAN001_SEQ");
		if(!StringUtils.isEmpty(result)){
			response.setSeq(result);
		}
		return response.build();
	}

}