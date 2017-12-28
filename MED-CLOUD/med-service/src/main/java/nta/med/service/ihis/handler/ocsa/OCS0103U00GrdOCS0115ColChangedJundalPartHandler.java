package nta.med.service.ihis.handler.ocsa;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U00GrdOCS0115ColChangedJundalPartRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U00StringResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U00GrdOCS0115ColChangedJundalPartHandler extends ScreenHandler<OcsaServiceProto.OCS0103U00GrdOCS0115ColChangedJundalPartRequest, OcsaServiceProto.OCS0103U00StringResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0103U00GrdOCS0115ColChangedJundalPartHandler.class);                                    
	@Resource                                                                                                       
	private Bas0260Repository bas0260Repository;                                                                    
	                                                                                                                
	@Override             
	@Transactional(readOnly = true)
	public OCS0103U00StringResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0103U00GrdOCS0115ColChangedJundalPartRequest request)
			throws Exception {                                                                 
  	   	OcsaServiceProto.OCS0103U00StringResponse.Builder response = OcsaServiceProto.OCS0103U00StringResponse.newBuilder();                      
		String result = bas0260Repository.getOCS0103U00GrdOCS0115ColChangedJundalPart(request.getHospCode(), getLanguage(vertx, sessionId),request.getGwa());
		if(!StringUtils.isEmpty(result)){
			response.setResStr(result);
		}
		
		return response.build();
	}                                                                                                                                                   

}