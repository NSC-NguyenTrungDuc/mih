package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.data.dao.medi.ocs.Ocs0208Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsaOCS0208U00LoadBogyongNameFromOcsRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsaOCS0208U00LoadBogyongNameFromOcsResponse;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OcsaOCS0208U00LoadBogyongNameFromOcsHandler
	extends ScreenHandler<OcsaServiceProto.OcsaOCS0208U00LoadBogyongNameFromOcsRequest, OcsaServiceProto.OcsaOCS0208U00LoadBogyongNameFromOcsResponse> {                     
	@Resource                                                                                                       
	private Ocs0208Repository ocs0208Repository;                                                                    
	
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, OcsaOCS0208U00LoadBogyongNameFromOcsRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override       
	@Transactional(readOnly = true)
	public OcsaOCS0208U00LoadBogyongNameFromOcsResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OcsaOCS0208U00LoadBogyongNameFromOcsRequest request)
			throws Exception {                                                                  
  	   	OcsaServiceProto.OcsaOCS0208U00LoadBogyongNameFromOcsResponse.Builder response = OcsaServiceProto.OcsaOCS0208U00LoadBogyongNameFromOcsResponse.newBuilder();                      
		List<String> listBogyongCode = ocs0208Repository.getBogyongNameOcsaOCS0208U00CommonData(request.getHospCode(), request.getDoctor(), request.getCode());
		if(!CollectionUtils.isEmpty(listBogyongCode)){
        	String bogYoungName=listBogyongCode.get(0);
        	if(!StringUtils.isEmpty(bogYoungName)){
        		response.setBogyongName(bogYoungName);
        	}
        }
		return response.build();
	}                                                                                                                                                   

}