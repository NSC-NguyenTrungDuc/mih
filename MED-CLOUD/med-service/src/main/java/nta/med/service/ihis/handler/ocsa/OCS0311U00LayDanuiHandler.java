package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0311U00LayDanuiRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0311U00LayDanuiResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0311U00LayDanuiHandler
	extends ScreenHandler<OcsaServiceProto.OCS0311U00LayDanuiRequest, OcsaServiceProto.OCS0311U00LayDanuiResponse>{                     
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;                                                                    
	                                                                                                                
	@Override                    
	@Transactional(readOnly = true)
	public OCS0311U00LayDanuiResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, OCS0311U00LayDanuiRequest request)
			throws Exception {                                                                 
  	   	OcsaServiceProto.OCS0311U00LayDanuiResponse.Builder response = OcsaServiceProto.OCS0311U00LayDanuiResponse.newBuilder();                      
		List<String> codeList = ocs0132Repository.getCodeNameByCodeAndCodeType(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), "ORD_DANUI", request.getCode());
		 if (!CollectionUtils.isEmpty(codeList) && !StringUtils.isEmpty(codeList.get(0))) {
			 response.setLayDanui(codeList.get(0));
		 }
		 return response.build();
	}

}