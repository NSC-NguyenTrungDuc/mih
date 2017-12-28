package nta.med.service.ihis.handler.phys;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PhysServiceProto;
import nta.med.service.ihis.proto.PhysServiceProto.PHY2001U04GetServerIPRequest;
import nta.med.service.ihis.proto.PhysServiceProto.PHY2001U04StringResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class PHY2001U04GetServerIPHandler
	extends ScreenHandler<PhysServiceProto.PHY2001U04GetServerIPRequest, PhysServiceProto.PHY2001U04StringResponse> {                     
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;                                                                    
	                                                                                                                
	@Override 
	@Transactional(readOnly=true)
	public PHY2001U04StringResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			PHY2001U04GetServerIPRequest request) throws Exception {                                                                  
  	   	 PhysServiceProto.PHY2001U04StringResponse.Builder response = PhysServiceProto.PHY2001U04StringResponse.newBuilder();                      
		 List<String> listCodeName = ocs0132Repository.getOCS0132CodeNameList(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), "SERVER_IP", request.getCode(), false);
		 if(!CollectionUtils.isEmpty(listCodeName) && !StringUtils.isEmpty(listCodeName.get(0))){
			 response.setResStr(listCodeName.get(0));
		 }
		 return response.build();
	}

}