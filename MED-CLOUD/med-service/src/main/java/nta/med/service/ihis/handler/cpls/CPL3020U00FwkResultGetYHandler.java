package nta.med.service.ihis.handler.cpls;
import javax.annotation.Resource;

import nta.med.data.dao.medi.cpl.Cpl0155Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U00FwkResultGetYRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U00FwkResultGetYResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;


@Service
@Scope("prototype")
public class CPL3020U00FwkResultGetYHandler extends ScreenHandler<CplsServiceProto.CPL3020U00FwkResultGetYRequest, CplsServiceProto.CPL3020U00FwkResultGetYResponse> {
	@Resource
	private Cpl0155Repository cpl0155Repository;

	
	@Override
	@Transactional(readOnly = true)
	public CPL3020U00FwkResultGetYResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CPL3020U00FwkResultGetYRequest request) throws Exception {
        CplsServiceProto.CPL3020U00FwkResultGetYResponse.Builder response = CplsServiceProto.CPL3020U00FwkResultGetYResponse.newBuilder();
    	String result = cpl0155Repository.getCPL3020U00FwkResultGetY(getHospitalCode(vertx, sessionId), request.getResultForm());
    	if(result != null && !result.isEmpty()){
    		response.setYValue(result);
    	}
    	return response.build();
	}
}
	
