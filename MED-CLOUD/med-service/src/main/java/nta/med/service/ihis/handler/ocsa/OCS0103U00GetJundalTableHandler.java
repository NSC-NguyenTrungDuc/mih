package nta.med.service.ihis.handler.ocsa;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.data.dao.medi.ocs.Ocs0128Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U00GetJundalTableRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U00StringResponse;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U00GetJundalTableHandler extends ScreenHandler<OcsaServiceProto.OCS0103U00GetJundalTableRequest, OcsaServiceProto.OCS0103U00StringResponse> {                     
	
	private static final Log LOGGER = LogFactory.getLog(OCS0103U00GetJundalTableHandler.class);                                    
	
	@Resource                                                                                                       
	private Ocs0128Repository ocs0128Repository;                                                                    
	                  
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, OcsaServiceProto.OCS0103U00GetJundalTableRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override      
	@Transactional(readOnly = true)
	public OCS0103U00StringResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0103U00GetJundalTableRequest request) throws Exception {                                                                  
      	   	OcsaServiceProto.OCS0103U00StringResponse.Builder response = OcsaServiceProto.OCS0103U00StringResponse.newBuilder();                      
			String result = ocs0128Repository.getOCS0103U00GetJundalTable(request.getHospCode(),request.getJundalPart(),request.getStartDate(),request.getIoGubun());
			if(!StringUtils.isEmpty(result)){
				response.setResStr(result);
			}
		return response.build();
	}                                                                                                                                                   
}