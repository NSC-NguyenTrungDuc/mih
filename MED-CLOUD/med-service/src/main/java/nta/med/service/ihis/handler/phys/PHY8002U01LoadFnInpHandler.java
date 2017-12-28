package nta.med.service.ihis.handler.phys;

import javax.annotation.Resource;

import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PhysServiceProto;
import nta.med.service.ihis.proto.PhysServiceProto.PHY8002U01LoadFnInpRequest;
import nta.med.service.ihis.proto.PhysServiceProto.PHY8002U01LoadFnInpResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class PHY8002U01LoadFnInpHandler
	extends ScreenHandler<PhysServiceProto.PHY8002U01LoadFnInpRequest, PhysServiceProto.PHY8002U01LoadFnInpResponse> {                     
	@Resource                                                                                                       
	private Inp1001Repository inp1001Repository;                                                                    
	                                                                                                                
	@Override                       
	@Transactional(readOnly=true)
	public PHY8002U01LoadFnInpResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, PHY8002U01LoadFnInpRequest request)
			throws Exception {                                                                 
  	   	PhysServiceProto.PHY8002U01LoadFnInpResponse.Builder response = PhysServiceProto.PHY8002U01LoadFnInpResponse.newBuilder();  
  	   	String hospCode = getHospitalCode(vertx, sessionId);
		String jaewon = inp1001Repository.callFnInpLoadJaewonHoDong(hospCode, request.getBunho());
		if(!StringUtils.isEmpty(jaewon)){
			response.setValueJaewon(jaewon);
		}
		
		String last = inp1001Repository.callFnInpLoadLastIpwonDate(hospCode, request.getBunho());
		if(!StringUtils.isEmpty(last)){
			response.setValueLast(last);
		}
		return response.build();
	}
}