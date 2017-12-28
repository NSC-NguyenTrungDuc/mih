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
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U00ProcessUpdateRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class NUR2004U00ProcessUpdateHandler
		extends ScreenHandler<NuriServiceProto.NUR2004U00ProcessUpdateRequest, SystemServiceProto.UpdateResponse> {

	@Resource
	private Inp2004Repository inp2004Repository;

	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2004U00ProcessUpdateRequest request) throws Exception {

		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();

		String hospCode = getHospitalCode(vertx, sessionId);
		
		String userId = request.getUserId();
		String toGwa = request.getToGwa();
		String toHoDong1 = request.getToHoDong1();
		String toHoCode1 = request.getToHoCode1();
		String toHoGrade1 = request.getToHoGrade1();
		String toHoDong2 = request.getToHoCode2();
		String toHoCode2 = request.getToHoCode2();
		String toBedNo = request.getToBedNo();
		String toBedNo2 = request.getToBedNo2();
		String toKaikeiHodong = request.getToKaikeiHodong();
		String toKaikeiHocode = request.getToKaikeiHocode();
		Double fkinp1001 = CommonUtils.parseDouble(request.getFkinp1001());
		Double transCnt = CommonUtils.parseDouble(request.getTransCnt());
		String toDoctor = request.getToDoctor();
		
		if (inp2004Repository.updateNUR2004U00ProcessUpdate(userId, toGwa, toHoDong1, toHoCode1, toHoGrade1,
				toHoDong2, toHoCode2, toBedNo, toBedNo2, toKaikeiHodong, toKaikeiHocode, hospCode,
				fkinp1001, transCnt, toDoctor) <= 0) {
			response.setResult(false);
		}

		response.setResult(true);
		return response.build();
	}
}
