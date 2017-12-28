package nta.med.service.ihis.handler.ocsa;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0130Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0203U00GetOCSCOMUserIDRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0203U00GetOCSCOMUserIDResponse;

import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class OCS0203U00GetOCSCOMUserIDHandler extends ScreenHandler<OcsaServiceProto.OCS0203U00GetOCSCOMUserIDRequest, OcsaServiceProto.OCS0203U00GetOCSCOMUserIDResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0203U00GetOCSCOMUserIDHandler.class);                                    
	@Resource                                                                                                       
	private Ocs0130Repository ocs0130Repository;                                                                    
	                                                                                                                
	@Override                 
	@Transactional(readOnly = true)
	public OCS0203U00GetOCSCOMUserIDResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
		OCS0203U00GetOCSCOMUserIDRequest request) throws Exception {
  	   	OcsaServiceProto.OCS0203U00GetOCSCOMUserIDResponse.Builder response = OcsaServiceProto.OCS0203U00GetOCSCOMUserIDResponse.newBuilder();                      
		String result = ocs0130Repository.getOcsComUserId(getHospitalCode(vertx, sessionId), request.getUserGubun(), request.getUserId());
		if(!StringUtils.isEmpty(result)){
			response.setResult(result);
		}
		return response.build();
	}
}
