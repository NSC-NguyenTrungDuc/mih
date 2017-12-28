package nta.med.service.ihis.handler.system;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.GetMainGwaDoctorCodeRequest;
import nta.med.service.ihis.proto.SystemServiceProto.GetMainGwaDoctorCodeResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class GetMainGwaDoctorCodeHandler
	extends ScreenHandler<SystemServiceProto.GetMainGwaDoctorCodeRequest, SystemServiceProto.GetMainGwaDoctorCodeResponse> {                     
	@Resource                                                                                                       
	private Bas0270Repository bas0270Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public GetMainGwaDoctorCodeResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			GetMainGwaDoctorCodeRequest request) throws Exception {                                                                 
  	   	SystemServiceProto.GetMainGwaDoctorCodeResponse.Builder response = SystemServiceProto.GetMainGwaDoctorCodeResponse.newBuilder();                      
		String gwaDoctor=bas0270Repository.getMainGwaDoctorCodeInfo(getHospitalCode(vertx, sessionId),request.getInputInfo().getMemb());
		if(!StringUtils.isEmpty(gwaDoctor)){
			response.setDoctor(gwaDoctor);
		}
		return response.build();
	}
}