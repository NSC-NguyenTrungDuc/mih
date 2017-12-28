package nta.med.service.ihis.handler.cpls;
import javax.annotation.Resource;

import nta.med.data.dao.medi.cpl.Cpl2007Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U00PrCplCalInsertBaseResultRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class CPL3020U00PrCplCalInsertBaseResultHandler extends ScreenHandler <CplsServiceProto.CPL3020U00PrCplCalInsertBaseResultRequest, SystemServiceProto.UpdateResponse> {
	@Resource
	private Cpl2007Repository cpl2007Repository;
	
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CPL3020U00PrCplCalInsertBaseResultRequest request) throws Exception {
	    SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String result = cpl2007Repository.callPrCplCalInsertBaseResult(getHospitalCode(vertx, sessionId), request.getSpecimenSer(), request.getHangmogCode(),
				request.getResult(), "");
		if(result != null && !result.isEmpty()){
			response.setResult(true);
		}else{
			response.setResult(false);
		}
		return response.build();
	}
}
