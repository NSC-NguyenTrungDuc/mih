package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0803U00CreateComboRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0803U00CreateComboResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0803U00CreateComboHandler
	extends ScreenHandler<OcsaServiceProto.OCS0803U00CreateComboRequest, OcsaServiceProto.OCS0803U00CreateComboResponse> {                     
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;                                                                    
	                                                                                                                
	@Override                
	@Transactional(readOnly = true)
	public OCS0803U00CreateComboResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0803U00CreateComboRequest request) throws Exception {                                                                   
  	   	OcsaServiceProto.OCS0803U00CreateComboResponse.Builder response = OcsaServiceProto.OCS0803U00CreateComboResponse.newBuilder();                      
		List<ComboListItemInfo> listCreateCombo=ocs0132Repository.getOCS0803U00CreateCombo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listCreateCombo)){
			for(ComboListItemInfo item: listCreateCombo){
				CommonModelProto.ComboListItemInfo.Builder info= CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addComboListItem(info);
			}
		}
		return response.build();
	}

}