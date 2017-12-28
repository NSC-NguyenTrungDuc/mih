package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inp.Inp2004Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U00CheckBeforeUpdateRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class NUR2004U00CheckBeforeUpdateHandler
		extends ScreenHandler<NuriServiceProto.NUR2004U00CheckBeforeUpdateRequest, SystemServiceProto.StringResponse> {

	@Resource
	private Inp2004Repository inp2004Repository;

	@Override
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2004U00CheckBeforeUpdateRequest request) throws Exception {

		String hospCode = getHospitalCode(vertx, sessionId);
		Double fkinp1001 = CommonUtils.parseDouble(request.getFkinp1001());
		Double transCnt = CommonUtils.parseDouble(request.getTransCnt());
		String toHoDong1 = request.getToHoDong1();
		String toHoCode1 = request.getToHoCode1();
		String toGwa = request.getToGwa();
		String toDoctor = request.getToDoctor();
		String toBedNo = request.getToBedNo();
		
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		String strData = inp2004Repository.getNUR2004U00CheckBeforeUpdate(hospCode, fkinp1001, transCnt, toHoDong1, toHoCode1, toGwa, toDoctor, toBedNo);

		response.setResult(strData);
		return response.build();
	}
}
