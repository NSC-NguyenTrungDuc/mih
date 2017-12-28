package nta.med.service.ihis.handler.phys;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PhysServiceProto;
import nta.med.service.ihis.proto.PhysServiceProto.PHY2001U04LayDoctorNameRequest;
import nta.med.service.ihis.proto.PhysServiceProto.PHY2001U04StringResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class PHY2001U04LayDoctorNameHandler
	extends ScreenHandler<PhysServiceProto.PHY2001U04LayDoctorNameRequest, PhysServiceProto.PHY2001U04StringResponse> {                     
	@Resource                                                                                                       
	private Bas0270Repository bas0270Repository;                                                                    
	                                                                                                                
	@Override  
	@Transactional(readOnly=true)
	public PHY2001U04StringResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			PHY2001U04LayDoctorNameRequest request) throws Exception {                                                               
  	   	PhysServiceProto.PHY2001U04StringResponse.Builder response = PhysServiceProto.PHY2001U04StringResponse.newBuilder();                      
		List<String> listDoctor =  bas0270Repository.getNuroNUR2001U04DoctorName(getHospitalCode(vertx, sessionId), request.getDoctor(), request.getDate());
		if(!CollectionUtils.isEmpty(listDoctor)){
			String doctor = listDoctor.get(0);
			if(!StringUtils.isEmpty(doctor)){
				response.setResStr(doctor);
			}
		}
		return response.build();
	}
}