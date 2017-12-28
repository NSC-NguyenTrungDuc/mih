package nta.med.service.ihis.handler.ocsa;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0116Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0113U00GetCodeNameRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0113U00GetCodeNameResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0113U00GetCodeNameHandler 
	extends ScreenHandler<OcsaServiceProto.OCS0113U00GetCodeNameRequest, OcsaServiceProto.OCS0113U00GetCodeNameResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(OCS0113U00GetCodeNameHandler.class);                                        
	@Resource                                                                                                       
	private Ocs0116Repository  ocs0116Repository;                                                                    
	                                                                                                                
	@Override 
	@Transactional(readOnly = true)
	public OCS0113U00GetCodeNameResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0113U00GetCodeNameRequest request) throws Exception {                                                                   
  	   	OcsaServiceProto.OCS0113U00GetCodeNameResponse.Builder response = OcsaServiceProto.OCS0113U00GetCodeNameResponse.newBuilder();                      
		String result = ocs0116Repository.getOCS0116GetCodeNameByCode(request.getCode(),null);
		if(!StringUtils.isEmpty(result)){
			response.setSpecimenName(result);
		}
		return response.build();
	}
}