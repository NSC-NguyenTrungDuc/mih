package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.model.ihis.ocsa.OCS0113U00GrdOCS0103ListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0113U00GrdOCS0103Request;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0113U00GrdOCS0103Response;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0113U00GrdOCS0103Handler
	extends ScreenHandler<OcsaServiceProto.OCS0113U00GrdOCS0103Request, OcsaServiceProto.OCS0113U00GrdOCS0103Response> {                             
	private static final Log LOGGER = LogFactory.getLog(OCS0113U00GrdOCS0103Handler.class);                                        
	@Resource                                                                                                       
	private Ocs0103Repository  ocs0103Repository;                                                                    
	                                                                                                                
	@Override  
	@Transactional(readOnly = true)
	public OCS0113U00GrdOCS0103Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0113U00GrdOCS0103Request request) throws Exception {                                                             
  	   	OcsaServiceProto.OCS0113U00GrdOCS0103Response.Builder response = OcsaServiceProto.OCS0113U00GrdOCS0103Response.newBuilder();                      
		List<OCS0113U00GrdOCS0103ListItemInfo> listResult = ocs0103Repository.getOCS0113U00GrdOcs0103ListItem(getHospitalCode(vertx, sessionId),
				request.getSlipCode()+"%", "%"+request.getHangmogNameInx()+"%");
		if(!CollectionUtils.isEmpty(listResult)){
			for(OCS0113U00GrdOCS0103ListItemInfo item : listResult){
				OcsaModelProto.OCS0113U00GrdOCS0103ListItemInfo.Builder info = OcsaModelProto.OCS0113U00GrdOCS0103ListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addListGrd(info);
			}
		}
		return response.build();
	}
}