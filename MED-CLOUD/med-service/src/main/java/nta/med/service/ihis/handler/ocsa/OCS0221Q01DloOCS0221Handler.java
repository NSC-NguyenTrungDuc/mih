package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.ocsa.OCS0221Q01DloOCS0221Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0221Q01DloOCS0221Request;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0221Q01DloOCS0221Response;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0221Q01DloOCS0221Handler
	extends ScreenHandler<OcsaServiceProto.OCS0221Q01DloOCS0221Request, OcsaServiceProto.OCS0221Q01DloOCS0221Response> {                     
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;                                                                    
	                                                                                                                
	@Override            
	@Transactional(readOnly = true)
	public OCS0221Q01DloOCS0221Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0221Q01DloOCS0221Request request) throws Exception {                                                                   
  	   	OcsaServiceProto.OCS0221Q01DloOCS0221Response.Builder response = OcsaServiceProto.OCS0221Q01DloOCS0221Response.newBuilder();                      
		List<OCS0221Q01DloOCS0221Info> list = ocs0132Repository.getOCS0221Q01DloOCS0221Info(getHospitalCode(vertx, sessionId), 
				request.getCategoryGubun(), request.getMemb(), getLanguage(vertx, sessionId));
		if (!CollectionUtils.isEmpty(list)) {
			for (OCS0221Q01DloOCS0221Info item:list) {
				OcsaModelProto.OCS0221Q01DloOCS0221Info.Builder info = OcsaModelProto.OCS0221Q01DloOCS0221Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addDloOCS0221Info(info);
			}
		}
		return response.build();
	}
}