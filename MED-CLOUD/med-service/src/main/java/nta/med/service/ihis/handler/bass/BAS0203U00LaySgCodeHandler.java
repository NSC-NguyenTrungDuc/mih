package nta.med.service.ihis.handler.bass;

import javax.annotation.Resource;

import nta.med.data.dao.medi.cpl.Cpl0108Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0203U00LaySgCodeRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0203U00LaySgCodeResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class BAS0203U00LaySgCodeHandler extends ScreenHandler<BassServiceProto.BAS0203U00LaySgCodeRequest, BassServiceProto.BAS0203U00LaySgCodeResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(BAS0203U00LaySgCodeHandler.class);                                    
	@Resource                                                                                                       
	private Cpl0108Repository cpl0108Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional
	public BAS0203U00LaySgCodeResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, BAS0203U00LaySgCodeRequest request)
					throws Exception {
  	   	BassServiceProto.BAS0203U00LaySgCodeResponse.Builder response = BassServiceProto.BAS0203U00LaySgCodeResponse.newBuilder();                      
  	   	return response.build();
	}                                                                                                                 
}