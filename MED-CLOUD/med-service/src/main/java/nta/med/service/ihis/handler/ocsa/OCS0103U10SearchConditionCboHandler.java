package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U10SearchConditionCboRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U10SearchConditionCboResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U10SearchConditionCboHandler 
	extends ScreenHandler<OcsaServiceProto.OCS0103U10SearchConditionCboRequest, OcsaServiceProto.OCS0103U10SearchConditionCboResponse> {
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;                                                                    
	                                                                                                                
	@Override  
	@Transactional(readOnly = true)
	public OCS0103U10SearchConditionCboResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0103U10SearchConditionCboRequest request) throws Exception {                                                                  
  	   	OcsaServiceProto.OCS0103U10SearchConditionCboResponse.Builder response = OcsaServiceProto.OCS0103U10SearchConditionCboResponse.newBuilder();                      
		List<ComboListItemInfo> listSearch=ocs0132Repository.getOCS0103U10SearchConditionCbo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),"SEARCH_GUBUN");
		if(!CollectionUtils.isEmpty(listSearch)){
			for(ComboListItemInfo item :listSearch){
				CommonModelProto.ComboListItemInfo.Builder info =CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addCboSearchConditionItem(info);
			}
		}
		
		return response.build();
	}

}