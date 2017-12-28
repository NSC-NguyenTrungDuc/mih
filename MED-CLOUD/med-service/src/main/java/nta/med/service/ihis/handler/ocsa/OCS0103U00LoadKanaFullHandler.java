package nta.med.service.ihis.handler.ocsa;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.annotation.Route;
import nta.med.data.dao.medi.adm.Adm0000Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U00LoadKanaFullRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U00StringResponse;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U00LoadKanaFullHandler extends ScreenHandler<OcsaServiceProto.OCS0103U00LoadKanaFullRequest, OcsaServiceProto.OCS0103U00StringResponse> {                     
	
	private static final Log LOGGER = LogFactory.getLog(OCS0103U00LoadKanaFullHandler.class);                                    
	
	@Resource                                                                                                       
	private Adm0000Repository adm0000Repository;                                                                    
	                                                                                                                
	@Override    
	@Transactional(readOnly = true)
	@Route(global = true)
	public OCS0103U00StringResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0103U00LoadKanaFullRequest request) throws Exception {                                                                   
  	   	OcsaServiceProto.OCS0103U00StringResponse.Builder response = OcsaServiceProto.OCS0103U00StringResponse.newBuilder();                      
		String result = adm0000Repository.callFnAdmConvertKanaFull(request.getHospCode(),request.getText());
		if(!StringUtils.isEmpty(result)){
			response.setResStr(result);
		}
		return response.build();
	}                                                                                                                                                   

}