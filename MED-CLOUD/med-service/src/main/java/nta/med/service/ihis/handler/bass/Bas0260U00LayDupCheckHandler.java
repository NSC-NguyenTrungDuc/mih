package nta.med.service.ihis.handler.bass;

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
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.Bas0260U00LayDupCheckRequest;
import nta.med.service.ihis.proto.BassServiceProto.Bas0260U00LayDupCheckResponse;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class Bas0260U00LayDupCheckHandler extends ScreenHandler<BassServiceProto.Bas0260U00LayDupCheckRequest, BassServiceProto.Bas0260U00LayDupCheckResponse> {                             
	
	private static final Log LOGGER = LogFactory.getLog(Bas0260U00LayDupCheckHandler.class);                                        
	
	@Resource                                                                                                       
	private Bas0260Repository bas0260Repository;                                                                    
	
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, Bas0260U00LayDupCheckRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override        
	@Transactional(readOnly = true)
	public Bas0260U00LayDupCheckResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			Bas0260U00LayDupCheckRequest request) throws Exception {                                                                   
 	   	BassServiceProto.Bas0260U00LayDupCheckResponse.Builder response = BassServiceProto.Bas0260U00LayDupCheckResponse.newBuilder();                      
		String result = bas0260Repository.getBas0260U00LayDupCheck(request.getHospCode(), request.getCode(), request.getStartDate(), getLanguage(vertx, sessionId));
		if(!StringUtils.isEmpty(result)){
			response.setLayDupResult(result);
		}
		return null;
	}                                                                                                                                                   
}