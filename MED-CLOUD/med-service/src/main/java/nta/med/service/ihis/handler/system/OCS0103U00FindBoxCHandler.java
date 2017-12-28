package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.drg.Drg0120Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;
import nta.med.service.ihis.proto.SystemServiceProto.OCS0103U00FindBoxCRequest;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U00FindBoxCHandler extends ScreenHandler <SystemServiceProto.OCS0103U00FindBoxCRequest, SystemServiceProto.ComboResponse> {                     
	
	@Resource                                                                                                       
	private Drg0120Repository drg0120Repository;                                                                    
	
	@Override
	@Transactional(readOnly = true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, OCS0103U00FindBoxCRequest request) throws Exception {                                                                   
  	   	SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();                      
		List<ComboListItemInfo> listCombo = drg0120Repository.getOCS0103U00ComboListItemInfo(request.getHospCode(), false, getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listCombo)){
			for(ComboListItemInfo item : listCombo){
				CommonModelProto.ComboListItemInfo.Builder info  = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addComboItem(info);
			}
		}	
		return response.build();
	}                                                                                                                                                   
}