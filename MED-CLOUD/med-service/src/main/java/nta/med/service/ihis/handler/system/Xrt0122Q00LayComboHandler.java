package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.xrt.Xrt0102Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;
import nta.med.service.ihis.proto.SystemServiceProto.Xrt0122Q00LayComboRequest;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class Xrt0122Q00LayComboHandler extends ScreenHandler <SystemServiceProto.Xrt0122Q00LayComboRequest, SystemServiceProto.ComboResponse> {                     
	@Resource                                                                                                       
	private Xrt0102Repository xrt0102Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, Xrt0122Q00LayComboRequest request) throws Exception {                                                                   
  	   	SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();                      
		List<ComboListItemInfo>  listCombo =  xrt0102Repository.getComboListItemInfoFromXRT0102(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listCombo)){
			for(ComboListItemInfo item : listCombo){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addComboItem(info);
			}
		}
		return response.build();
	}
}