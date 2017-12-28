package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inp.Inp2004Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U00CheckAfterHogradeRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class NUR2004U00CheckAfterHogradeHandler
		extends ScreenHandler<NuriServiceProto.NUR2004U00CheckAfterHogradeRequest, SystemServiceProto.StringResponse> {

	@Resource
	private Inp2004Repository inp2004Repository;

	@Override
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2004U00CheckAfterHogradeRequest request) throws Exception {

		String hospCode = getHospitalCode(vertx, sessionId);
		String bunho = request.getBunho();
		Double fkinp1001 = CommonUtils.parseDouble(request.getFkinp1001());
		String date = request.getDate();
		
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		String strData = inp2004Repository.getNUR2004U00CheckAfterHograde(hospCode, bunho, fkinp1001, date);

		response.setResult(strData);
		return response.build();
	}
}
