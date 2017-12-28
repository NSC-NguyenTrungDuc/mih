package nta.med.service.ihis.handler.ocsa;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0311Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0311U00layDupHangmogCodeRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0311U00layDupHangmogCodeResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")   
@Transactional
public class OCS0311U00layDupHangmogCodeHandler
	extends ScreenHandler<OcsaServiceProto.OCS0311U00layDupHangmogCodeRequest, OcsaServiceProto.OCS0311U00layDupHangmogCodeResponse> {                             
	@Resource                                                                                                       
	private Ocs0311Repository ocs0311Repository;                                                                    
	                                                                                                                
	@Override          
	@Transactional(readOnly = true)
	public OCS0311U00layDupHangmogCodeResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0311U00layDupHangmogCodeRequest request) throws Exception {                                                                  
		OcsaServiceProto.OCS0311U00layDupHangmogCodeResponse.Builder response=OcsaServiceProto.OCS0311U00layDupHangmogCodeResponse.newBuilder();
		String result= ocs0311Repository.getOCS0311U00layDupHangmogCode(getHospitalCode(vertx, sessionId), request.getSetPart(), request.getHangmogCode());
		if(!StringUtils.isEmpty(result)){
			response.setLayDupHangmogCode(result);
		}
		return response.build();
	}

}                                                                                                                 
