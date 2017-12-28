package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.CboSearchConditionRequest;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class CboSearchConditionHandler extends ScreenHandler<OcsaServiceProto.CboSearchConditionRequest, OcsaServiceProto.CboSearchConditionResponse> {                     
	@Resource                                                                                                       
	private Ocs0132Repository  ocs0132Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public OcsaServiceProto.CboSearchConditionResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, CboSearchConditionRequest request) throws Exception {                                                                  
  	   	OcsaServiceProto.CboSearchConditionResponse.Builder response = OcsaServiceProto.CboSearchConditionResponse.newBuilder();                      
		List<ComboListItemInfo> list = ocs0132Repository.getInjsComboListItemInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), "SEARCH_GUBUN");
		if(!CollectionUtils.isEmpty(list)){
			for(ComboListItemInfo item : list){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addInfo1(info);
			}
		}
		return response.build();
	}

}