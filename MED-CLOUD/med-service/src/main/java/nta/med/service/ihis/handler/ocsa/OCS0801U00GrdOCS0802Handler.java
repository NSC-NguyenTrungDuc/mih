package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0802Repository;
import nta.med.data.model.ihis.ocso.OCS0801U00GrdOCS0802ListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0801U00GrdOCS0802Request;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0801U00GrdOCS0802Response;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0801U00GrdOCS0802Handler
	extends ScreenHandler<OcsaServiceProto.OCS0801U00GrdOCS0802Request, OcsaServiceProto.OCS0801U00GrdOCS0802Response> {                     
	@Resource                                                                                                       
	private Ocs0802Repository ocs0802Repository;                                                                    
	                                                                                                                
	@Override          
	@Transactional(readOnly = true)
	public OCS0801U00GrdOCS0802Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0801U00GrdOCS0802Request request) throws Exception {                                                                   
  	   	OcsaServiceProto.OCS0801U00GrdOCS0802Response.Builder response = OcsaServiceProto.OCS0801U00GrdOCS0802Response.newBuilder();                      
		List<OCS0801U00GrdOCS0802ListItemInfo> list = ocs0802Repository.getOCS0801U00GrdOCS0802ListItem(getHospitalCode(vertx, sessionId),
				request.getPatStatus(), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(list)){
			for(OCS0801U00GrdOCS0802ListItemInfo item : list){
				OcsaModelProto.OCS0801U00GrdOCS0802ListItemInfo.Builder info = OcsaModelProto.OCS0801U00GrdOCS0802ListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addListInfo(info);
			}
		}
		return response.build();
	}

}