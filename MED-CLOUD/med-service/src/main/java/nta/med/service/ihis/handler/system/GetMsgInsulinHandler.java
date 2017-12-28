package nta.med.service.ihis.handler.system;

import javax.annotation.Resource;

import nta.med.data.dao.medi.nur.Nur0115Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.GetMsgInsulinRequest;
import nta.med.service.ihis.proto.SystemServiceProto.GetMsgInsulinResponse;

import org.apache.commons.lang.StringUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")  
public class GetMsgInsulinHandler 
	extends ScreenHandler<SystemServiceProto.GetMsgInsulinRequest, SystemServiceProto.GetMsgInsulinResponse> {                     
	@Resource                                                                                                       
	private Nur0115Repository nur0115Repository; 
	
	@Override
	@Transactional(readOnly = true)
	public GetMsgInsulinResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, GetMsgInsulinRequest request)
			throws Exception {                                                                 
  	   	SystemServiceProto.GetMsgInsulinResponse.Builder response = SystemServiceProto.GetMsgInsulinResponse.newBuilder();                      
		String result = nur0115Repository.getMsgInsulin(getHospitalCode(vertx, sessionId), request.getDirectGubun(), request.getHangmogCode());
		if(!StringUtils.isEmpty(result)){
			response.setResult(result);
		}
		return response.build();
	}
}
