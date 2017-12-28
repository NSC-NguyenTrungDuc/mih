package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0801Repository;
import nta.med.data.model.ihis.ocsa.OCS0801U00GrdOCS0801ListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0801U00GrdOCS0801Request;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0801U00GrdOCS0801Response;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0801U00GrdOCS0801Handler
	extends ScreenHandler<OcsaServiceProto.OCS0801U00GrdOCS0801Request, OcsaServiceProto.OCS0801U00GrdOCS0801Response> {                     
	@Resource                                                                                                       
	private Ocs0801Repository ocs0801Repository;                                                                    
	                                                                                                                
	@Override   
	@Transactional(readOnly = true)
	public OCS0801U00GrdOCS0801Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0801U00GrdOCS0801Request request) throws Exception {                                                                  
  	   	OcsaServiceProto.OCS0801U00GrdOCS0801Response.Builder response = OcsaServiceProto.OCS0801U00GrdOCS0801Response.newBuilder();                      
		List<OCS0801U00GrdOCS0801ListItemInfo> list = ocs0801Repository.getOCS0801U00GrdOCS0801ListItem(getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(list)){
			for(OCS0801U00GrdOCS0801ListItemInfo item : list){
				OcsaModelProto.OCS0801U00GrdOCS0801ListItemInfo.Builder info = OcsaModelProto.OCS0801U00GrdOCS0801ListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addListItemInfo(info);
			}
		}
		return response.build();
	}
}