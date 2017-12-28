package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboOrdDanuiRequest;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class ComboOrdDanuiHandler
	extends ScreenHandler<SystemServiceProto.ComboOrdDanuiRequest, SystemServiceProto.ComboResponse> {                     
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, ComboOrdDanuiRequest request) throws Exception {                                                                 
      	   	SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();                      
  	   	String language = getLanguage(vertx, sessionId);
		if(!request.getIsAll()){
			List<ComboListItemInfo> listComboOrdDanui=ocs0132Repository.getComboOrdDanui(request.getHospCode(), language);
			if(!CollectionUtils.isEmpty(listComboOrdDanui)){
				for(ComboListItemInfo item : listComboOrdDanui){
					CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
					BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					response.addComboItem(info);
				}
			}
		} else {
			CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
			info.setCode("000");
			info.setCodeName("");
			response.addComboItem(info);
			List<ComboListItemInfo> listComboOrdDanui=ocs0132Repository.getComboOrdDanui(request.getHospCode(), language);
			if(!CollectionUtils.isEmpty(listComboOrdDanui)){
				for(ComboListItemInfo item : listComboOrdDanui){
					info = CommonModelProto.ComboListItemInfo.newBuilder();
					BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					response.addComboItem(info);
				}
			}
		}
		return response.build();
	}                                                                                                                                                   
}