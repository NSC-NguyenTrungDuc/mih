package nta.med.service.ihis.handler.system;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.OBFnOcsIsGeneralYnRequest;
import nta.med.service.ihis.proto.SystemServiceProto.OBFnOcsIsGeneralYnResponse;

import org.apache.commons.lang3.StringUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OBFnOcsIsGeneralYnHandler 
	extends ScreenHandler <SystemServiceProto.OBFnOcsIsGeneralYnRequest, SystemServiceProto.OBFnOcsIsGeneralYnResponse> {                     
	@Resource                                                                                                       
	private Ocs0103Repository ocs0103Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public OBFnOcsIsGeneralYnResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, OBFnOcsIsGeneralYnRequest request)
			throws Exception {                                                                 
      	   	SystemServiceProto.OBFnOcsIsGeneralYnResponse.Builder response = SystemServiceProto.OBFnOcsIsGeneralYnResponse.newBuilder();                      
		String name = ocs0103Repository.fnOcsIsGeneralYn(getHospitalCode(vertx, sessionId), request.getHangmogCode());
		if(!StringUtils.isEmpty(name)) {
			response.setResult(name);
		}
		return response.build();
	}
}