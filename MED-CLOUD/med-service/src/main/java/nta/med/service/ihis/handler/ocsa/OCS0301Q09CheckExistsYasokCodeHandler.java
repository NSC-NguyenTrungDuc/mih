package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0301Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0301Q09CheckExistsYasokCodeRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0301Q09CheckExistsYasokCodeResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0301Q09CheckExistsYasokCodeHandler
	extends ScreenHandler<OcsaServiceProto.OCS0301Q09CheckExistsYasokCodeRequest, OcsaServiceProto.OCS0301Q09CheckExistsYasokCodeResponse> {                     
	@Resource                                                                                                       
	private Ocs0301Repository ocs0301Repository;                                                                    
	                                                                                                                
	@Override    
	@Transactional(readOnly = true)
	public OCS0301Q09CheckExistsYasokCodeResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0301Q09CheckExistsYasokCodeRequest request) throws Exception {                                                                   
  	   	OcsaServiceProto.OCS0301Q09CheckExistsYasokCodeResponse.Builder response = OcsaServiceProto.OCS0301Q09CheckExistsYasokCodeResponse.newBuilder();                      
		List<String> checkExist=ocs0301Repository.getOCS0301Q09YasokCode(getHospitalCode(vertx, sessionId),request.getYaksokOpenId(),request.getYasokCode());
		if(!CollectionUtils.isEmpty(checkExist)){
			if(!StringUtils.isEmpty(checkExist.get(0))){
				response.setResult(checkExist.get(0));
			}
		}
		return response.build();
	}

}