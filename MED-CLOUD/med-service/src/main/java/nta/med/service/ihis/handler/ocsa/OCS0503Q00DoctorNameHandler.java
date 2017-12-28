package nta.med.service.ihis.handler.ocsa;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0503Q00DoctorNameRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0503Q00DoctorNameResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0503Q00DoctorNameHandler 
	extends ScreenHandler<OcsaServiceProto.OCS0503Q00DoctorNameRequest, OcsaServiceProto.OCS0503Q00DoctorNameResponse> {                     
	@Resource                                                                                                       
	private Bas0270Repository bas0270Repository;                                                                    
	                                                                                                                
	@Override       
	@Transactional(readOnly = true)
	public OCS0503Q00DoctorNameResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0503Q00DoctorNameRequest request) throws Exception {                                                                   
  	   	OcsaServiceProto.OCS0503Q00DoctorNameResponse.Builder response = OcsaServiceProto.OCS0503Q00DoctorNameResponse.newBuilder();                      
		String result = bas0270Repository.getOcsaOCS0503Q00DoctorNameList(getHospitalCode(vertx, sessionId), request.getGwa(), request.getDoctorCode());
		if(!StringUtils.isEmpty(result)){
			response.setDoctorName(result);
		}
		return response.build();
	}

}