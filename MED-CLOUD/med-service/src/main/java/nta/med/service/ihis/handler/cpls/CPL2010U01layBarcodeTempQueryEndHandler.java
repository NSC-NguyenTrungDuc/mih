package nta.med.service.ihis.handler.cpls;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U01layBarcodeTempQueryEndRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class CPL2010U01layBarcodeTempQueryEndHandler extends
		ScreenHandler<CplsServiceProto.CPL2010U01layBarcodeTempQueryEndRequest, SystemServiceProto.UpdateResponse> {
	
	@Resource
	private Cpl2010Repository cpl2010Repository;
	
	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			CPL2010U01layBarcodeTempQueryEndRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		
		cpl2010Repository.updateCpl2010LayBarcodeTempQueryEnd(getHospitalCode(vertx, sessionId), request.getJubsuDate(), request.getBunho()); 
		
		response.setResult(true);
		return response.build();
	}

}
