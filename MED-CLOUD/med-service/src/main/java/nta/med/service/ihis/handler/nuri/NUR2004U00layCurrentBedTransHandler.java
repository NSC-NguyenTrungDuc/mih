
package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inp.Inp2004Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U00layCurrentBedTransRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class NUR2004U00layCurrentBedTransHandler
		extends ScreenHandler<NuriServiceProto.NUR2004U00layCurrentBedTransRequest, SystemServiceProto.StringResponse> {

	@Resource
	private Inp2004Repository inp2004Repository;
	
	@Override
	@Transactional(readOnly = true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2004U00layCurrentBedTransRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		
		String cnt = inp2004Repository.getNUR2004U00getOldTransCnt(getHospitalCode(vertx, sessionId)
				, request.getBunho()
				, CommonUtils.parseDouble(request.getPkinp1001()));
		
		response.setResult(cnt);
		return response.build();
	}

	
}
