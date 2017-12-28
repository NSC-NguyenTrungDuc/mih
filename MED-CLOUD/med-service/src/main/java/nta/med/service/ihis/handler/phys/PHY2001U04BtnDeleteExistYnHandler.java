package nta.med.service.ihis.handler.phys;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PhysServiceProto;
import nta.med.service.ihis.proto.PhysServiceProto.PHY2001U04BtnDeleteExistYnRequest;
import nta.med.service.ihis.proto.PhysServiceProto.PHY2001U04StringResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class PHY2001U04BtnDeleteExistYnHandler
	extends ScreenHandler<PhysServiceProto.PHY2001U04BtnDeleteExistYnRequest, PhysServiceProto.PHY2001U04StringResponse> {                     
	@Resource                                                                                                       
	private Out1001Repository out1001Repository;                                                                    
	                                                                                                                
	@Override     
	@Transactional(readOnly=true)
	public PHY2001U04StringResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			PHY2001U04BtnDeleteExistYnRequest request) throws Exception {                                                                  
  	   	PhysServiceProto.PHY2001U04StringResponse.Builder response = PhysServiceProto.PHY2001U04StringResponse.newBuilder();                      
		Double pkout1001 = CommonUtils.parseDouble(request.getPkout1001());
		String getY = out1001Repository.getCheckY(getHospitalCode(vertx, sessionId), pkout1001);
		if(!StringUtils.isEmpty(getY)){
			response.setResStr(getY);
		}
		return response.build();
	}
}