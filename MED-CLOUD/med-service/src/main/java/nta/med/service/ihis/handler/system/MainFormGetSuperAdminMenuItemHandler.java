package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm0100Repository;
import nta.med.data.model.ihis.system.MainFormGetMainMenuItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.MainFormGetSuperAdminMenuItemRequest;
import nta.med.service.ihis.proto.SystemServiceProto.MainFormGetSuperAdminMenuItemResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class MainFormGetSuperAdminMenuItemHandler extends ScreenHandler<SystemServiceProto.MainFormGetSuperAdminMenuItemRequest, SystemServiceProto.MainFormGetSuperAdminMenuItemResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(MainFormGetSuperAdminMenuItemHandler.class);                                    
	@Resource                                                                                                       
	private Adm0100Repository adm0100Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public MainFormGetSuperAdminMenuItemResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			MainFormGetSuperAdminMenuItemRequest request) throws Exception {
      	   	SystemServiceProto.MainFormGetSuperAdminMenuItemResponse.Builder response = SystemServiceProto.MainFormGetSuperAdminMenuItemResponse.newBuilder();                      
			List<MainFormGetMainMenuItemInfo> listMainMenu = adm0100Repository.getMainFormGetSuperAdminMenuItem(getLanguage(vertx, sessionId), request.getUserId(), "N");
			if(!CollectionUtils.isEmpty(listMainMenu)){
				for(MainFormGetMainMenuItemInfo item : listMainMenu){
					SystemModelProto.MainFormGetMainMenuItemInfo.Builder info = SystemModelProto.MainFormGetMainMenuItemInfo.newBuilder();
					BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					response.addMenuItem(info);
				}
			}
		return response.build();
	}                                                                                                                 
}