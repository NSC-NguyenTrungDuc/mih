package nta.med.service.ihis.handler.ocsa;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0301Q09IsDoctorRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0301Q09IsDoctorResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0301Q09IsDoctorHandler
	extends ScreenHandler<OcsaServiceProto.OCS0301Q09IsDoctorRequest, OcsaServiceProto.OCS0301Q09IsDoctorResponse> {                     
	@Resource                                                                                                       
	private Bas0270Repository bas0270Repository;                                                                    
	                                                                                                                
	@Override             
	@Transactional(readOnly = true)
	public OCS0301Q09IsDoctorResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, OCS0301Q09IsDoctorRequest request)
			throws Exception {                                                                   
  	   	OcsaServiceProto.OCS0301Q09IsDoctorResponse.Builder response = OcsaServiceProto.OCS0301Q09IsDoctorResponse.newBuilder();                      
		String result =bas0270Repository.getOCS0301Q09IsDoctor(getHospitalCode(vertx, sessionId),request.getDoctor());
		if(!StringUtils.isEmpty(result)){
			response.setResult(result);
		}
		return response.build();
	}

}