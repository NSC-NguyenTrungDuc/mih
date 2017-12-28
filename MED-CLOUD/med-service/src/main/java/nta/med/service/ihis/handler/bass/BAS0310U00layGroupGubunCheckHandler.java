package nta.med.service.ihis.handler.bass;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.data.dao.medi.bas.Bas0312Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0310U00layGroupGubunCheckRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0310U00layGroupGubunCheckResponse;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class BAS0310U00layGroupGubunCheckHandler extends ScreenHandler<BassServiceProto.BAS0310U00layGroupGubunCheckRequest, BassServiceProto.BAS0310U00layGroupGubunCheckResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(BAS0310U00layGroupGubunCheckHandler.class);                                    
	@Resource                                                                                                       
	private Bas0312Repository bas0312Repository;                                                                    
	                                                                                                                
	@Override   
	@Transactional(readOnly = true)
	public BAS0310U00layGroupGubunCheckResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			BAS0310U00layGroupGubunCheckRequest request) throws Exception {
  	   	BassServiceProto.BAS0310U00layGroupGubunCheckResponse.Builder response = BassServiceProto.BAS0310U00layGroupGubunCheckResponse.newBuilder();                      
		Integer count = bas0312Repository.getCountBAS0312WhereHospCodeSgCode(request.getSgCode());
		response.setCount(count.toString()); 
		return response.build();
	}																																						
}