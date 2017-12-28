package nta.med.service.ihis.handler.system;

import javax.annotation.Resource;

import nta.med.data.dao.medi.nur.Nur1016Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ExistAllergyDataRequest;
import nta.med.service.ihis.proto.SystemServiceProto.ExistAllergyDataResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class ExistAllergyDataHandler
	extends ScreenHandler<SystemServiceProto.ExistAllergyDataRequest, SystemServiceProto.ExistAllergyDataResponse> {                     
	@Resource                                                                                                       
	private Nur1016Repository nur1016Repository;
	
	@Override
	@Transactional(readOnly = true)
	public ExistAllergyDataResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, ExistAllergyDataRequest request)
			throws Exception {                                                                  
  	   	SystemServiceProto.ExistAllergyDataResponse.Builder response = SystemServiceProto.ExistAllergyDataResponse.newBuilder();
		Integer result = nur1016Repository.checkExistAllergyData(getHospitalCode(vertx, sessionId), request.getBunho());
		if(result != null){
			response.setCntValue(result.toString());
		}
		return response.build();
	}
}
