package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm0100Repository;
import nta.med.data.model.ihis.system.MainFormGetMainMenuItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.MainFormGetAdminMenuItemRequest;
import nta.med.service.ihis.proto.SystemServiceProto.MainFormGetAdminMenuItemResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class MainFormGetAdminMenuItemHandler extends ScreenHandler<SystemServiceProto.MainFormGetAdminMenuItemRequest, SystemServiceProto.MainFormGetAdminMenuItemResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(MainFormGetAdminMenuItemHandler.class);                                    
	@Resource                                                                                                       
	private Adm0100Repository adm0100Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public MainFormGetAdminMenuItemResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			MainFormGetAdminMenuItemRequest request) throws Exception {
  	   	SystemServiceProto.MainFormGetAdminMenuItemResponse.Builder response = SystemServiceProto.MainFormGetAdminMenuItemResponse.newBuilder();                      
		List<MainFormGetMainMenuItemInfo> listMainMenu = adm0100Repository.getMainFormGetAdminMenuItem(request.getHospCode(), getLanguage(vertx, sessionId), request.getUserId(), "N");
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