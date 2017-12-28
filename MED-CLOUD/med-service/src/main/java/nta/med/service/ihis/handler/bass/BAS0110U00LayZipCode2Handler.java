package nta.med.service.ihis.handler.bass;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0123Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0110U00LayZipCode2Request;
import nta.med.service.ihis.proto.BassServiceProto.BAS0110U00LayZipCode2Response;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class BAS0110U00LayZipCode2Handler extends ScreenHandler<BassServiceProto.BAS0110U00LayZipCode2Request, BassServiceProto.BAS0110U00LayZipCode2Response> {                             
	private static final Log LOGGER = LogFactory.getLog(BAS0110U00LayZipCode2Handler.class);                                        
	@Resource                                                                                                       
	private Bas0123Repository bas0123Repository;                                                                    
	                                                                                                                
	@Override  
	@Transactional(readOnly = true)
	public BAS0110U00LayZipCode2Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			BAS0110U00LayZipCode2Request request) throws Exception {                                                                   
  	   	BassServiceProto.BAS0110U00LayZipCode2Response.Builder response = BassServiceProto.BAS0110U00LayZipCode2Response.newBuilder();                      
		String result = bas0123Repository.getBAS0110U00LayZipCode2Info(request.getZipCode1(), request.getZipCode2());
		if(!StringUtils.isEmpty(result)){
			response.setZipName(result);
		}
		return response.build();
	}
}