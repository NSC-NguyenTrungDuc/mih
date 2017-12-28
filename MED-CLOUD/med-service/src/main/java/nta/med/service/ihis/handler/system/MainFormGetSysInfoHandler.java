package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.glossary.UserRole;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm0100Repository;
import nta.med.data.model.ihis.system.MainFormGetMainMenuItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class MainFormGetSysInfoHandler extends ScreenHandler<SystemServiceProto.MainFormGetSysInfoRequest, SystemServiceProto.MainFormGetSysInfoResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(MainFormGetSysInfoHandler.class);                                    
	@Resource                                                                                                       
	private Adm0100Repository adm0100Repository;  
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public SystemServiceProto.MainFormGetSysInfoResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			SystemServiceProto.MainFormGetSysInfoRequest request) throws Exception {
		SystemServiceProto.MainFormGetSysInfoResponse.Builder response = SystemServiceProto.MainFormGetSysInfoResponse.newBuilder();
		List<MainFormGetMainMenuItemInfo> listMainMenu = null;
		if(UserRole.SUPER_ADMIN.getValue().equalsIgnoreCase(getUserRole(vertx, sessionId))){
			listMainMenu = adm0100Repository.getMainFormGetSuperAdminMenuItem(getLanguage(vertx, sessionId), request.getUserId(), "N");
		}else{
			 listMainMenu = adm0100Repository.getMainFormGetAdminMenuItem(request.getHospCode(), getLanguage(vertx, sessionId), request.getUserId(), "N");
			 if(CollectionUtils.isEmpty(listMainMenu)){
				 listMainMenu = adm0100Repository.getMainFormGetAdminMenuItem(request.getHospCode(), getLanguage(vertx, sessionId), request.getGroupId(), "N");
			 }
		}
		if(!CollectionUtils.isEmpty(listMainMenu)){
			for(MainFormGetMainMenuItemInfo item : listMainMenu){
				SystemModelProto.MainFormGetMainMenuItemInfo.Builder info = SystemModelProto.MainFormGetMainMenuItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addSysInfoItem(info);
			}
		}
		return response.build();
	}                                                                                                                 
}