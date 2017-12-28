package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U10CboInputGubunRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U10CboInputGubunResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U10CboInputGubunHandler 
	extends ScreenHandler<OcsaServiceProto.OCS0103U10CboInputGubunRequest, OcsaServiceProto.OCS0103U10CboInputGubunResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0103U10CboInputGubunHandler.class);                                    
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;                                                                    
	                                                                                                                
	@Override                 
	@Transactional(readOnly = true)
	public OCS0103U10CboInputGubunResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0103U10CboInputGubunRequest request) throws Exception {                                                                
  	   	OcsaServiceProto.OCS0103U10CboInputGubunResponse.Builder response = OcsaServiceProto.OCS0103U10CboInputGubunResponse.newBuilder();                      
		List<ComboListItemInfo> listCboInput =ocs0132Repository.getOCS0103U10CboInputGubun(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listCboInput)){
			for(ComboListItemInfo item : listCboInput){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addCboGubunItem(info);
			}
		}
		return response.build();
	}

}