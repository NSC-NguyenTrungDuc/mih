package nta.med.service.ihis.handler.system;

import javax.annotation.Resource;

import nta.med.data.dao.medi.drg.Drg0202Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.OBCheckSpecialDrugForPatientRequest;
import nta.med.service.ihis.proto.SystemServiceProto.OBCheckSpecialDrugForPatientResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OBCheckSpecialDrugForPatientHandler
	extends ScreenHandler<SystemServiceProto.OBCheckSpecialDrugForPatientRequest, SystemServiceProto.OBCheckSpecialDrugForPatientResponse> {                     
	@Resource                                                                                                       
	private Drg0202Repository drg0202Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public OBCheckSpecialDrugForPatientResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OBCheckSpecialDrugForPatientRequest request) throws Exception {                                                              
      	   	SystemServiceProto.OBCheckSpecialDrugForPatientResponse.Builder response = SystemServiceProto.OBCheckSpecialDrugForPatientResponse.newBuilder();                      
		String checkSpecial=drg0202Repository.getOBCheckSpecialDrugForPatient(getHospitalCode(vertx, sessionId),request.getHangmogCode(),request.getBunho());
		if(!StringUtils.isEmpty(checkSpecial)){
			response.setResult(checkSpecial);
		}
		return response.build();
	}
}