package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.ocs.Ocs0132;
import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboInputTabRequest;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class ComboInputTabHandler extends ScreenHandler<SystemServiceProto.ComboInputTabRequest, SystemServiceProto.ComboResponse> {                     
	
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;                                                                    
	
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, ComboInputTabRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override
	@Transactional(readOnly = true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, ComboInputTabRequest request) throws Exception {                                                                  
      	   	SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();                      
		List<Ocs0132> listItem = ocs0132Repository.getByCodeTypeOrderByCode(request.getHospCode(), getLanguage(vertx, sessionId), "INPUT_TAB");
		if(!CollectionUtils.isEmpty(listItem)) {
			for (Ocs0132 item : listItem) {
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				if(!StringUtils.isEmpty(item.getCode())) {
					info.setCode(item.getCode());
				}
				if(!StringUtils.isEmpty(item.getCodeName())) {
					info.setCodeName("[" + item.getCode() + "] " + item.getCodeName());
				}
				response.addComboItem(info);
			}
		}
		return response.build();
	}                                                                                                                                                   
}