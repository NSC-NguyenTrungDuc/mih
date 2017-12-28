package nta.med.service.ihis.handler.ocsa;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0130Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0204Q00GetOcsUserNameRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0204Q00GetOcsUserNameResponse;

import org.apache.commons.lang.StringUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")  
public class OCS0204Q00GetOcsUserNameHandler 
	extends ScreenHandler<OcsaServiceProto.OCS0204Q00GetOcsUserNameRequest, OcsaServiceProto.OCS0204Q00GetOcsUserNameResponse> {                     
	@Resource                                                                                                       
	private Ocs0130Repository ocs0130Repository;                                                                    
	                                                                                                                
	@Override                   
	@Transactional(readOnly = true)
	public OCS0204Q00GetOcsUserNameResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0204Q00GetOcsUserNameRequest request) throws Exception {                                                                
  	   	OcsaServiceProto.OCS0204Q00GetOcsUserNameResponse.Builder response = OcsaServiceProto.OCS0204Q00GetOcsUserNameResponse.newBuilder();                      
		String result = ocs0130Repository.getMembName(getHospitalCode(vertx, sessionId), request.getUserId());
		if(!StringUtils.isEmpty(result)){
			response.setMembName(result);
		}
		return response.build();
	}
}
