package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.BASSCboInputGubunRequest;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class BASSCboInputGubunHandler 
	extends ScreenHandler<SystemServiceProto.BASSCboInputGubunRequest, SystemServiceProto.ComboResponse> {                             
	@Resource                                                                                                       
	private Ocs0132Repository  ocs0132Repository;                                                                       
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, BASSCboInputGubunRequest request) throws Exception {                                                                  
     	   	SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();                      
		List<ComboListItemInfo> listResult = ocs0132Repository.getOCS0103U10SearchConditionCbo(getHospitalCode(vertx, sessionId),
				getLanguage(vertx, sessionId),"INPUT_GUBUN", true);
		if(!CollectionUtils.isEmpty(listResult)){
			for(ComboListItemInfo item : listResult){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addComboItem(info);
			}
		}
		return response.build();
	}                                                                                                                                                   
}																																						
