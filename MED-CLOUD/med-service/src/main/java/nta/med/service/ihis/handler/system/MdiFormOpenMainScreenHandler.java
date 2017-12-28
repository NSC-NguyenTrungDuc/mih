package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm0500Repository;
import nta.med.data.model.ihis.system.MdiFormMainMenuItemInfo;
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
public class MdiFormOpenMainScreenHandler extends ScreenHandler<SystemServiceProto.MdiFormOpenMainScreenRequest, SystemServiceProto.MdiFormOpenMainScreenResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(MdiFormOpenMainScreenHandler.class);              
	
	@Resource
	private Adm0500Repository adm0500Repository;                                                                   
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public SystemServiceProto.MdiFormOpenMainScreenResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			SystemServiceProto.MdiFormOpenMainScreenRequest request) throws Exception {
		SystemServiceProto.MdiFormOpenMainScreenResponse.Builder response = SystemServiceProto.MdiFormOpenMainScreenResponse.newBuilder();
    	List<MdiFormMainMenuItemInfo> listMainMenuInfo = adm0500Repository.getMdiFormMainMenuItemInfo(request.getSystemId(), getHospitalCode(vertx, sessionId));
    	
    	if (!CollectionUtils.isEmpty(listMainMenuInfo)) {
			for (MdiFormMainMenuItemInfo item : listMainMenuInfo) {
				SystemModelProto.MdiFormOpenMainScreenInfo.Builder builder = SystemModelProto.MdiFormOpenMainScreenInfo.newBuilder();
				BeanUtils.copyProperties(item, builder, getLanguage(vertx, sessionId));
				response.addMainScreenItem(builder);
			}
    	}
    	
		return response.build();
	}                                                                                                                 
}