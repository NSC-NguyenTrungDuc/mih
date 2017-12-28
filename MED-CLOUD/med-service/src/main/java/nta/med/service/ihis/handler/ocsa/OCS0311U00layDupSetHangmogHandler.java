package nta.med.service.ihis.handler.ocsa;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0313Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0311U00layDupSetHangmogRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0311U00layDupSetHangmogResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")  
@Transactional
public class OCS0311U00layDupSetHangmogHandler
	extends ScreenHandler<OcsaServiceProto.OCS0311U00layDupSetHangmogRequest, OcsaServiceProto.OCS0311U00layDupSetHangmogResponse> {                             
	@Resource                                                                                                       
	private Ocs0313Repository ocs0313Repository;                                                                    
	                                                                                                                
	@Override  
	@Transactional(readOnly = true)
	public OCS0311U00layDupSetHangmogResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0311U00layDupSetHangmogRequest request) throws Exception {                                                                 
		OcsaServiceProto.OCS0311U00layDupSetHangmogResponse.Builder response=OcsaServiceProto.OCS0311U00layDupSetHangmogResponse.newBuilder();
		String result = ocs0313Repository.getOCS0311U00layDupSetHangmogRequest(getHospitalCode(vertx, sessionId),request.getSetPart(),request.getHangmogCode(),request.getSetCode(),request.getSetValueHangmogCode());
		if(!StringUtils.isEmpty(result)){
			response.setLayDupSetHangmog(result);
		}
		return response.build();
	}

}                                                                                                                 
