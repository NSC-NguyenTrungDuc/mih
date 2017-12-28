package nta.med.service.ihis.handler.ocsa;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.nut.Nut0001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U19GetFkOcsRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U19GetFkOcsResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U19GetFkOcsHandler
	extends ScreenHandler<OcsaServiceProto.OCS0103U19GetFkOcsRequest, OcsaServiceProto.OCS0103U19GetFkOcsResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0103U19GetFkOcsHandler.class);                                    
	@Resource                                                                                                       
	private Nut0001Repository nut0001Repository;                                                                    
	                                                                                                                
	@Override             
	@Transactional(readOnly = true)
	public OCS0103U19GetFkOcsResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, OCS0103U19GetFkOcsRequest request)
			throws Exception {                                                                
  	   	OcsaServiceProto.OCS0103U19GetFkOcsResponse.Builder response = OcsaServiceProto.OCS0103U19GetFkOcsResponse.newBuilder();                      
		Double result = nut0001Repository.getOCS0103U19GetFkOcsInfo(getHospitalCode(vertx, sessionId), CommonUtils.parseDouble(request.getPkocskey()));
		if(result != null){
			response.setResult(result.toString());
		}
		return response.build();
	}

}