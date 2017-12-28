package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.annotation.Route;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0101Repository;
import nta.med.data.model.ihis.ocsa.OCS0101U00GrdOcs0101ListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0101U00GrdOcs0101InitRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0101U00GrdOcs0101InitResponse;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0101U00GrdOcs0101InitHandler extends ScreenHandler<OcsaServiceProto.OCS0101U00GrdOcs0101InitRequest, OcsaServiceProto.OCS0101U00GrdOcs0101InitResponse> {                             
	
	private static final Log LOGGER = LogFactory.getLog(OCS0101U00GrdOcs0101InitHandler.class);                                        
	
	@Resource                                                                                                       
	private Ocs0101Repository ocs0101Repository;                                                                    
	                                                                                                                
	@Override                         
	@Transactional(readOnly = true)
	@Route(global = true)
	public OCS0101U00GrdOcs0101InitResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0101U00GrdOcs0101InitRequest request) throws Exception {                                                                  
  	   	OcsaServiceProto.OCS0101U00GrdOcs0101InitResponse.Builder response = OcsaServiceProto.OCS0101U00GrdOcs0101InitResponse.newBuilder();                      
		List<OCS0101U00GrdOcs0101ListItemInfo> listResult = ocs0101Repository.getOCS0101U00ListItem(getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listResult)){
			for(OCS0101U00GrdOcs0101ListItemInfo item : listResult){
				OcsaModelProto.OCS0101U00GrdOcs0101ListItemInfo.Builder info = OcsaModelProto.OCS0101U00GrdOcs0101ListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addListGrd0Cs0101Init(info);
			}
		}
		return response.build();
	}

}