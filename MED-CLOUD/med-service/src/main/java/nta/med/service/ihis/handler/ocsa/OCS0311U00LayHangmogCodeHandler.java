package nta.med.service.ihis.handler.ocsa;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0311U00LayHangmogCodeRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0311U00LayHangmogCodeResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0311U00LayHangmogCodeHandler
	extends ScreenHandler<OcsaServiceProto.OCS0311U00LayHangmogCodeRequest, OcsaServiceProto.OCS0311U00LayHangmogCodeResponse> {                     
	@Resource                                                                                                       
	private Ocs0103Repository ocs0103Repository;                                                                    
	                                                                                                                
	@Override        
	@Transactional(readOnly = true)
	public OCS0311U00LayHangmogCodeResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0311U00LayHangmogCodeRequest request) throws Exception {                                                               
  	   	OcsaServiceProto.OCS0311U00LayHangmogCodeResponse.Builder response = OcsaServiceProto.OCS0311U00LayHangmogCodeResponse.newBuilder();                      
		String getLayHangmogCode = ocs0103Repository.getOCS0311U00InitializeLayHangmogCode(getHospitalCode(vertx, sessionId),request.getCode(),request.getCode2());
		if(!StringUtils.isEmpty(getLayHangmogCode)){
			 response.setHangmogCode(getLayHangmogCode);
		}
		return response.build();
	}

}