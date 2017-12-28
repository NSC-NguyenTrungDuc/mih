package nta.med.service.ihis.handler.bass;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0230Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0203U00LayBunCodeRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0203U00StringResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class BAS0203U00LayBunCodeHandler extends ScreenHandler<BassServiceProto.BAS0203U00LayBunCodeRequest, BassServiceProto.BAS0203U00StringResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(BAS0203U00LayBunCodeHandler.class);                                    
	@Resource                                                                                                       
	private Bas0230Repository bas0230Repository;                                                                    
	                                                                                                                
	@Override      
	@Transactional(readOnly = true)
	public BAS0203U00StringResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			BAS0203U00LayBunCodeRequest request) throws Exception {
  	   	BassServiceProto.BAS0203U00StringResponse.Builder response = BassServiceProto.BAS0203U00StringResponse.newBuilder();                      
		String result = bas0230Repository.getBAS0203U00LayBunCode(request.getHospCode(), getLanguage(vertx, sessionId), request.getCode());
		if(!StringUtils.isEmpty(result)){
			response.setResStr(result);
		}
		return response.build();
	}                                                                                                                 
}