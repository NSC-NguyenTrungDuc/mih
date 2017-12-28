package nta.med.service.ihis.handler.ocsa;

import javax.annotation.Resource;

import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.data.dao.medi.ocs.Ocs0130Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0203U00GetOCSCOMUserNameRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0203U00GetOCSCOMUserNameResponse;

@Service                                                                                                          
@Scope("prototype")  
public class OCS0203U00GetOCSCOMUserNameHandler extends ScreenHandler<OcsaServiceProto.OCS0203U00GetOCSCOMUserNameRequest, OcsaServiceProto.OCS0203U00GetOCSCOMUserNameResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0203U00GetOCSCOMUserNameHandler.class);                                    
	
	@Resource                                                                                                       
	private Ocs0130Repository ocs0130Repository;                                                                    
	
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, OCS0203U00GetOCSCOMUserNameRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override            
	@Transactional(readOnly = true)
	public OCS0203U00GetOCSCOMUserNameResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0203U00GetOCSCOMUserNameRequest request) throws Exception {
  	   	OcsaServiceProto.OCS0203U00GetOCSCOMUserNameResponse.Builder response = OcsaServiceProto.OCS0203U00GetOCSCOMUserNameResponse.newBuilder();                      
		String result = ocs0130Repository.getMembName(request.getHospCode(), request.getUserId());
		if(!StringUtils.isEmpty(result)){
			response.setMembName(result);
		}
		return response.build();
	}
}
