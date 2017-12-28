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
import nta.med.data.dao.medi.ocs.Ocs0102Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0101U00Grd0102CheckDataRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0101U00Grd0102CheckDataResponse;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0101U00Grd0102CheckDataHandler extends ScreenHandler<OcsaServiceProto.OCS0101U00Grd0102CheckDataRequest, OcsaServiceProto.OCS0101U00Grd0102CheckDataResponse>{                             
	
	private static final Log LOGGER = LogFactory.getLog(OCS0101U00Grd0102CheckDataHandler.class);                                        
	
	@Resource                                                                                                       
	private Ocs0102Repository ocs0102Repository;                                                                    
	
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, OcsaServiceProto.OCS0101U00Grd0102CheckDataRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override      
	@Transactional(readOnly = true)
	public OCS0101U00Grd0102CheckDataResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0101U00Grd0102CheckDataRequest request) throws Exception {                                                                  
  	   	OcsaServiceProto.OCS0101U00Grd0102CheckDataResponse.Builder response = OcsaServiceProto.OCS0101U00Grd0102CheckDataResponse.newBuilder();                      
		String result = ocs0102Repository.getOCS0101U00Grd0102CheckData(request.getHospCode(), request.getValue(), getLanguage(vertx, sessionId));
		if(!StringUtils.isEmpty(result)){
			response.setChkResult(result);
		}
		return response.build();
	}

}