package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0204Repository;
import nta.med.data.model.ihis.ocsa.Ocs0204Q00GrdOcs0204ListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0204Q00LayOCS0204Request;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0204Q00LayOCS0204Response;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")  
public class OCS0204Q00LayOCS0204Handler
	extends ScreenHandler<OcsaServiceProto.OCS0204Q00LayOCS0204Request, OcsaServiceProto.OCS0204Q00LayOCS0204Response> {                     
	@Resource                                                                                                       
	private Ocs0204Repository ocs0204Repository;                                                                    
	                                                                                                                
	@Override              
	@Transactional(readOnly = true)
	public OCS0204Q00LayOCS0204Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0204Q00LayOCS0204Request request) throws Exception {                                                                   
  	   	OcsaServiceProto.OCS0204Q00LayOCS0204Response.Builder response = OcsaServiceProto.OCS0204Q00LayOCS0204Response.newBuilder();                      
		List<Ocs0204Q00GrdOcs0204ListItemInfo> listGrd = ocs0204Repository.getOcs0204Q00GrdOcs0204ListItemInfo(getHospitalCode(vertx, sessionId), request.getMemb(), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listGrd)){
			for(Ocs0204Q00GrdOcs0204ListItemInfo item : listGrd){
				OcsaModelProto.Ocs0204Q00GrdOcs0204ListItemInfo.Builder info = OcsaModelProto.Ocs0204Q00GrdOcs0204ListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addLayOCS0204Info(info);
			}
		}
		return response.build();
	}
}
