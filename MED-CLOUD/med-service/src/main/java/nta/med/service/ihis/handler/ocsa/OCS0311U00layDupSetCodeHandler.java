package nta.med.service.ihis.handler.ocsa;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0312Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0311U00layDupSetCodeRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0311U00layDupSetCodeResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")    
@Transactional
public class OCS0311U00layDupSetCodeHandler
	extends ScreenHandler<OcsaServiceProto.OCS0311U00layDupSetCodeRequest, OcsaServiceProto.OCS0311U00layDupSetCodeResponse> {                             
	@Resource                                                                                                       
	private Ocs0312Repository ocs0312Repository;                                                                    
	                                                                                                                
	@Override    
	@Transactional(readOnly = true)
	public OCS0311U00layDupSetCodeResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0311U00layDupSetCodeRequest request) throws Exception {                                                                 
		OcsaServiceProto.OCS0311U00layDupSetCodeResponse.Builder response=OcsaServiceProto.OCS0311U00layDupSetCodeResponse.newBuilder();
		String result = ocs0312Repository.getOCS0311U00layDupSetCode(getHospitalCode(vertx, sessionId),request.getSetPart(),request.getHangmogCode(),request.getSetCode());
		if(!StringUtils.isEmpty(result)){
			response.setLayDupSetCode(result);
		}
		return response.build();
	}
}                                                                                                                 
