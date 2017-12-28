package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0250Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U01PRBASBAS0250REFRESHRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class NUR2004U01PRBASBAS0250REFRESHHandler extends
		ScreenHandler<NuriServiceProto.NUR2004U01PRBASBAS0250REFRESHRequest, SystemServiceProto.UpdateResponse> {
	
	@Resource
	private Bas0250Repository bas0250Repository;

	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2004U01PRBASBAS0250REFRESHRequest request) throws Exception {
		
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		
		bas0250Repository.callPrBas2050Refresh(hospCode, request.getHoDong());
		response.setResult(true);
		
		return response.build();
	}

}
