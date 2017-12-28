package nta.med.service.ihis.handler.cpls;
import javax.annotation.Resource;

import nta.med.data.dao.medi.cpl.Cpl2090Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U00ExecuteGetYValueRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U00ExecuteGetYValueResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CPL3020U00ExecuteGetYValueHandler extends ScreenHandler<CplsServiceProto.CPL3020U00ExecuteGetYValueRequest, CplsServiceProto.CPL3020U00ExecuteGetYValueResponse> {
	@Resource
	private Cpl2090Repository cpl2090Repository;
	
	@Override
	@Transactional(readOnly = true)
	public CPL3020U00ExecuteGetYValueResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CPL3020U00ExecuteGetYValueRequest request) throws Exception {
        CplsServiceProto.CPL3020U00ExecuteGetYValueResponse.Builder response = CplsServiceProto.CPL3020U00ExecuteGetYValueResponse.newBuilder();
    	String result = cpl2090Repository.getCPL3020U00ExecuteGetYValue(getHospitalCode(vertx, sessionId), request.getJundalGubun(), request.getSpecimenSer());
    	if(result != null && !result.isEmpty()){
    		response.setYValue(result);
    	}
    	return response.build();
	}
}
