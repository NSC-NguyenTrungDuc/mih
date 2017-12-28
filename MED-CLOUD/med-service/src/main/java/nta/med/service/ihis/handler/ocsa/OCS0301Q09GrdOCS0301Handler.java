package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0300Repository;
import nta.med.data.model.ihis.ocsa.OCS0301Q09GrdOCS0301Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0301Q09GrdOCS0301Request;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0301Q09GrdOCS0301Response;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0301Q09GrdOCS0301Handler
	extends ScreenHandler<OcsaServiceProto.OCS0301Q09GrdOCS0301Request, OcsaServiceProto.OCS0301Q09GrdOCS0301Response> {                     
	@Resource                                                                                                       
	private Ocs0300Repository ocs0300Repository;                                                                    
	                                                                                                                
	@Override    
	@Transactional(readOnly = true)
	public OCS0301Q09GrdOCS0301Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0301Q09GrdOCS0301Request request) throws Exception {                                                              
  	   	OcsaServiceProto.OCS0301Q09GrdOCS0301Response.Builder response = OcsaServiceProto.OCS0301Q09GrdOCS0301Response.newBuilder();                      
		List<OCS0301Q09GrdOCS0301Info> listGrd=ocs0300Repository.getOCS0301Q09GrdOCS0301(getHospitalCode(vertx, sessionId),getLanguage(vertx, sessionId),
				request.getMemb(),request.getYaksokCode(),request.getInputTab());
		if(!CollectionUtils.isEmpty(listGrd)){
			for(OCS0301Q09GrdOCS0301Info item:listGrd){
				OcsaModelProto.OCS0301Q09GrdOCS0301Info.Builder info =OcsaModelProto.OCS0301Q09GrdOCS0301Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addDrgOcs0301Item(info);
			}
		}
		return response.build();
	}

}