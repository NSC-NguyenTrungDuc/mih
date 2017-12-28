package nta.med.service.ihis.handler.ocsa;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0150Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsaOCS0150U00DeleteOCS0150Request;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class OcsaOCS0150U00DeleteOCS0150Handler
	extends ScreenHandler<OcsaServiceProto.OcsaOCS0150U00DeleteOCS0150Request, SystemServiceProto.UpdateResponse> {
	
    @Resource
    private Ocs0150Repository ocs0150Repository;
    
    @Override
    public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsaOCS0150U00DeleteOCS0150Request request) throws Exception {
			boolean result = deleteOcs0150(request, getHospitalCode(vertx, sessionId));
			SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
			response.setResult(result);
			return response.build();
	}
    private boolean deleteOcs0150(OcsaServiceProto.OcsaOCS0150U00DeleteOCS0150Request request, String hospCode) throws Exception {
		if(ocs0150Repository.deleteOcsaOCS0150U00DeleteOCS0150(request.getDoctor(), request.getGwa(), request.getIoGubun(), hospCode) > 0){
			return true;
		}
		return false;
	}
}
