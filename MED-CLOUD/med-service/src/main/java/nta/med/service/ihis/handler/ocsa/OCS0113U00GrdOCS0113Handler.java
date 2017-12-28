package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0113Repository;
import nta.med.data.model.ihis.ocsa.OCS0113U00GrdOCS0113ListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0113U00GrdOCS0113Request;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0113U00GrdOCS0113Response;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0113U00GrdOCS0113Handler
	extends ScreenHandler<OcsaServiceProto.OCS0113U00GrdOCS0113Request, OcsaServiceProto.OCS0113U00GrdOCS0113Response> {                             
	private static final Log LOGGER = LogFactory.getLog(OCS0113U00GrdOCS0113Handler.class);                                        
	@Resource                                                                                                       
	private Ocs0113Repository  ocs0113Repository;                                                                    
	                                                                                                                
	@Override               
	@Transactional(readOnly = true)
	public OCS0113U00GrdOCS0113Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0113U00GrdOCS0113Request request) throws Exception {                                                                
  	   	OcsaServiceProto.OCS0113U00GrdOCS0113Response.Builder response = OcsaServiceProto.OCS0113U00GrdOCS0113Response.newBuilder();                      
		List<OCS0113U00GrdOCS0113ListItemInfo> listResult = ocs0113Repository.getOCS0113U00GrdOCS0113ListItem(getHospitalCode(vertx, sessionId), request.getHangmogCode());
		if(!CollectionUtils.isEmpty(listResult)){
			for(OCS0113U00GrdOCS0113ListItemInfo item : listResult){
				OcsaModelProto.OCS0113U00GrdOCS0113ListItemInfo.Builder info = OcsaModelProto.OCS0113U00GrdOCS0113ListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addListGrd(info);
			}
		}
		return response.build();
	}

}