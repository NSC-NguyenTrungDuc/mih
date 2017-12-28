package nta.med.service.ihis.handler.system;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto.CheckPatientStatusRequestInfo;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.CheckPatientStatusRequest;
import nta.med.service.ihis.proto.SystemServiceProto.CheckPatientStatusResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class CheckPatientStatusHandler
	extends ScreenHandler<SystemServiceProto.CheckPatientStatusRequest, SystemServiceProto.CheckPatientStatusResponse> {                     
	@Resource                                                                                                       
	private Ocs0103Repository ocs0103Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public CheckPatientStatusResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, CheckPatientStatusRequest request)
			throws Exception {                                                                  
  	   	SystemServiceProto.CheckPatientStatusResponse.Builder response = SystemServiceProto.CheckPatientStatusResponse.newBuilder();                      
		CheckPatientStatusRequestInfo inputInfo = request.getInputInfo();
		if(inputInfo != null){
			String result = ocs0103Repository.callFnOcsCheckBreakPatStatus(getHospitalCode(vertx, sessionId), inputInfo.getBunho(), inputInfo.getHangmogCode());
			if(!StringUtils.isEmpty(result)){
				response.setResult(result);
			}
		}
		return response.build();
	}
}