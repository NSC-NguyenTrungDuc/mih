package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0115Repository;
import nta.med.data.model.ihis.ocsa.OCS0103U00GrdOCS0115Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U00GrdOCS0115Request;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U00GrdOCS0115Response;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U00GrdOCS0115Handler extends 
ScreenHandler<OcsaServiceProto.OCS0103U00GrdOCS0115Request, OcsaServiceProto.OCS0103U00GrdOCS0115Response> {                     
	
	private static final Log LOGGER = LogFactory.getLog(OCS0103U00GrdOCS0115Handler.class);                                    
	
	@Resource                                                                                                       
	private Ocs0115Repository ocs0115Repository;                                                                    
	
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, OcsaServiceProto.OCS0103U00GrdOCS0115Request request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId)) && !StringUtils.isEmpty(request.getHospCode())) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override    
	@Transactional(readOnly = true)
	public OCS0103U00GrdOCS0115Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0103U00GrdOCS0115Request request) throws Exception {                                                                   
  	   	OcsaServiceProto.OCS0103U00GrdOCS0115Response.Builder response = OcsaServiceProto.OCS0103U00GrdOCS0115Response.newBuilder();                      
		List<OCS0103U00GrdOCS0115Info> listGrd = ocs0115Repository.getOCS0103U00GrdOCS0115Info(request.getHospCode(), getLanguage(vertx, sessionId),request.getHangmogCode(),request.getHangmogStartDate());
		if(!CollectionUtils.isEmpty(listGrd)){
			for(OCS0103U00GrdOCS0115Info item : listGrd){
				OcsaModelProto.OCS0103U00GrdOCS0115Info.Builder info = OcsaModelProto.OCS0103U00GrdOCS0115Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdOcs115Item(info);
			}
		}
		return response.build();
	}  
	
	@Override
	public OCS0103U00GrdOCS0115Response postHandle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS0103U00GrdOCS0115Request request, OCS0103U00GrdOCS0115Response response) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId)) && !StringUtils.isEmpty(request.getHospCode())) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup("NTA",
					getLanguage(vertx, sessionId), "", 1));
		}
		
		return response;
	}
}