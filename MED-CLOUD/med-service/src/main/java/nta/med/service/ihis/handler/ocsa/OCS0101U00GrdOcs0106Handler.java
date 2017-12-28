package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0106Repository;
import nta.med.data.model.ihis.ocsa.OCS0101U00GrdOcs0106ListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0101U00GrdOcs0106Request;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0101U00GrdOcs0106Response;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0101U00GrdOcs0106Handler extends ScreenHandler<OcsaServiceProto.OCS0101U00GrdOcs0106Request, OcsaServiceProto.OCS0101U00GrdOcs0106Response> {                             
	private static final Log LOGGER = LogFactory.getLog(OCS0101U00GrdOcs0106Handler.class);                                        
	@Resource                                                                                                       
	private Ocs0106Repository ocs0106Repository;                                                                    
	                                                                                                                
	@Override         
	@Transactional(readOnly = true)
	public OCS0101U00GrdOcs0106Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0101U00GrdOcs0106Request request) throws Exception {                                                                   
  	   	OcsaServiceProto.OCS0101U00GrdOcs0106Response.Builder response = OcsaServiceProto.OCS0101U00GrdOcs0106Response.newBuilder();                      
		List<OCS0101U00GrdOcs0106ListItemInfo> listResult = ocs0106Repository.getOCS0101U00GrdOcs0106ListItem(request.getHospCode(), request.getSlipCode());
		if(!CollectionUtils.isEmpty(listResult)){
			for(OCS0101U00GrdOcs0106ListItemInfo item : listResult){
				OcsaModelProto.OCS0101U00GrdOcs0106ListItemInfo.Builder info = OcsaModelProto.OCS0101U00GrdOcs0106ListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addListOcs0106(info);
			}
		}
		return response.build();
	}
}