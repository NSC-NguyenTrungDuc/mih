package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0223Repository;
import nta.med.data.model.ihis.ocsa.OCS0223U00GrdOCS0223Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0223U00GrdOCS0223Request;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0223U00GrdOCS0223Response;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0223U00GrdOCS0223Handler extends ScreenHandler<OcsaServiceProto.OCS0223U00GrdOCS0223Request, OcsaServiceProto.OCS0223U00GrdOCS0223Response> {                     
	
	@Resource                                                                                                       
	private Ocs0223Repository ocs0223Repository;                                                                    

	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, OCS0223U00GrdOCS0223Request request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override          
	@Transactional(readOnly = true)
	public OCS0223U00GrdOCS0223Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0223U00GrdOCS0223Request request) throws Exception {                                                                   
  	   	OcsaServiceProto.OCS0223U00GrdOCS0223Response.Builder response = OcsaServiceProto.OCS0223U00GrdOCS0223Response.newBuilder();                      
		List<OCS0223U00GrdOCS0223Info> listItem = ocs0223Repository.getOCS0223U00GrdOCS0223Info(request.getHospCode(), getLanguage(vertx, sessionId), request.getJundalPart());
		if (!CollectionUtils.isEmpty(listItem)) {
			for (OCS0223U00GrdOCS0223Info item : listItem) {
				OcsaModelProto.OCS0223U00GrdOCS0223Info.Builder info = OcsaModelProto.OCS0223U00GrdOCS0223Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addInfo(info);
			}
		}
		return response.build();
	}                                                                                                                                                   

}