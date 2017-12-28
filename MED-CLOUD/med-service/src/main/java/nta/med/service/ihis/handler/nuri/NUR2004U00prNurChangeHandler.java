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
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U00prNurChangeRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U00prNurChangeResponse;

@Service
@Scope("prototype")
public class NUR2004U00prNurChangeHandler extends
		ScreenHandler<NuriServiceProto.NUR2004U00prNurChangeRequest, NuriServiceProto.NUR2004U00prNurChangeResponse> {

	@Resource
	private Inp2004Repository inp2004Repository;

	@Override
	@Transactional
	public NUR2004U00prNurChangeResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2004U00prNurChangeRequest request) throws Exception {
		NuriServiceProto.NUR2004U00prNurChangeResponse.Builder response = NuriServiceProto.NUR2004U00prNurChangeResponse
				.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String result = inp2004Repository.callPrNurChangeGwaHodong(hospCode,
				CommonUtils.parseDouble(request.getFkinp1001()), request.getBunho(), request.getOrderDate(),
				request.getUserId());

		response.setErr(result);
		return response.build();
	}

}
