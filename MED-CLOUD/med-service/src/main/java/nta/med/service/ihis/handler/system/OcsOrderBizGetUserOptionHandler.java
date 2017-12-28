package nta.med.service.ihis.handler.system;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0150Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.OcsOrderBizGetUserOptionRequest;
import nta.med.service.ihis.proto.SystemServiceProto.OcsOrderBizGetUserOptionResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")   
public class OcsOrderBizGetUserOptionHandler extends ScreenHandler<SystemServiceProto.OcsOrderBizGetUserOptionRequest, SystemServiceProto.OcsOrderBizGetUserOptionResponse> {                     
	@Resource                                                                                                       
	private Ocs0150Repository ocs0150Repository;  
	
	@Override
	@Transactional(readOnly = true)
	public OcsOrderBizGetUserOptionResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OcsOrderBizGetUserOptionRequest request) throws Exception {                                                                   
  	   	SystemServiceProto.OcsOrderBizGetUserOptionResponse.Builder response = SystemServiceProto.OcsOrderBizGetUserOptionResponse.newBuilder();                      
		//  optional GetUserOptionInfo user_opt_info = 1;
		String  userOpt = ocs0150Repository.getOcsOrderBizGetUserOptionInfo(getHospitalCode(vertx, sessionId),request.getDoctor(),
			request.getGwa(),request.getKeyword(),request.getIoGubun());
		if(!StringUtils.isEmpty(userOpt)){
			response.setResult(userOpt);
		}
		return response.build();
	}
}
