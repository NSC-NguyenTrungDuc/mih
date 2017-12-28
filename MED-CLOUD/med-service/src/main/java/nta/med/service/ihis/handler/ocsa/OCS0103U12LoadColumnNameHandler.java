package nta.med.service.ihis.handler.ocsa;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.helper.OrderBizHelper;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U12LoadColumnNameRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U12LoadColumnNameResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U12LoadColumnNameHandler
	extends ScreenHandler<OcsaServiceProto.OCS0103U12LoadColumnNameRequest, OcsaServiceProto.OCS0103U12LoadColumnNameResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(OCS0103U12LoadColumnNameHandler.class);                                                                                                         
	                                                                                                                
	@Override             
	@Transactional(readOnly = true)
	public OCS0103U12LoadColumnNameResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0103U12LoadColumnNameRequest request) throws Exception {                                                                   
  	   	OcsaServiceProto.OCS0103U12LoadColumnNameResponse.Builder response = OcsaServiceProto.OCS0103U12LoadColumnNameResponse.newBuilder();                      
		String result = OrderBizHelper.getLoadColumnCodeName(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getCode());
		if(!StringUtils.isEmpty(result)){
			response.setCodeName(result);
		}
		return response.build();
	}

}