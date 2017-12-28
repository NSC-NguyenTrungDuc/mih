package nta.med.service.ihis.handler.ocsa;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0204Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsaOCS0204U00SangGubunNameRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsaOCS0204U00SangGubunNameResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OcsaOCS0204U00SangGubunNameHandler
	extends ScreenHandler<OcsaServiceProto.OcsaOCS0204U00SangGubunNameRequest, OcsaServiceProto.OcsaOCS0204U00SangGubunNameResponse> {                     
	@Resource                                                                                                       
	private Ocs0204Repository ocs0204Repository;                                                                    
	                                                                                                                
	@Override           
	@Transactional(readOnly = true)
	public OcsaOCS0204U00SangGubunNameResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OcsaOCS0204U00SangGubunNameRequest request) throws Exception {                                                                
  	   	OcsaServiceProto.OcsaOCS0204U00SangGubunNameResponse.Builder response = OcsaServiceProto.OcsaOCS0204U00SangGubunNameResponse.newBuilder();                      
		String sangGubunName = ocs0204Repository.getSangGubunNameOcsaOCS0204U00CommonData(getHospitalCode(vertx, sessionId), request.getMemb(), request.getCode(), getLanguage(vertx, sessionId));
        if(!StringUtils.isEmpty(sangGubunName)){
        	response.setSangGubunName(sangGubunName);
        }
        return response.build();
	}
}