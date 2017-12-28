package nta.med.service.ihis.handler.ocsa;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0801Repository;
import nta.med.data.dao.medi.ocs.Ocs0802Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0801U00GetCodeNameRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0801U00GetCodeNameResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0801U00GetCodeNameHandler
	extends ScreenHandler<OcsaServiceProto.OCS0801U00GetCodeNameRequest, OcsaServiceProto.OCS0801U00GetCodeNameResponse> {                     
	@Resource                                                                                                       
	private Ocs0801Repository ocs0801Repository;      
	@Resource                                                                                                       
	private Ocs0802Repository ocs0802Repository;          
	                                                                                                                
	@Override              
	@Transactional(readOnly = true)
	public OCS0801U00GetCodeNameResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0801U00GetCodeNameRequest request) throws Exception {                                                                  
  	   	OcsaServiceProto.OCS0801U00GetCodeNameResponse.Builder response = OcsaServiceProto.OCS0801U00GetCodeNameResponse.newBuilder();  
  	   	String hospCode = getHospitalCode(vertx, sessionId);
  	   	String language = getLanguage(vertx, sessionId);
		String codeName = "";
		if(request.getCodeMode().equalsIgnoreCase("pat_status")){
			codeName = ocs0801Repository.getOCS0801getCodeNameOcs0801(request.getCode(), language);
		}else if(request.getCodeMode().equalsIgnoreCase("pat_status_code")){
			codeName = ocs0802Repository.getOCS0801U00GetCodeNameOcs0802(hospCode, request.getCode(), request.getPatStatus(), language);
		}
		if(!StringUtils.isEmpty(codeName)){
			response.setCodeName(codeName);
		}
		return response.build();
	}

}