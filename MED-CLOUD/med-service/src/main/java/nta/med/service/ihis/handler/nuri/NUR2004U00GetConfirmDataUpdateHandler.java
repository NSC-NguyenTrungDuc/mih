	package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U00GetConfirmDataUpdateRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class NUR2004U00GetConfirmDataUpdateHandler extends
		ScreenHandler<NuriServiceProto.NUR2004U00GetConfirmDataUpdateRequest, SystemServiceProto.UpdateResponse> {

	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2004U00GetConfirmDataUpdateRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		
		inp1001Repository.updateInp1001InNUR2004U00(request.getUpdId()
				, request.getToGwa().trim()
				, request.getToDoctor()
				, request.getToResident()
				, request.getToHoCode1()
				, request.getToHoDong1()
				, request.getToBedNo()
				, request.getToBedNo2()
				, request.getToHoCode2()
				, request.getToHoDong2()
				, request.getToHoGrade1()
				, request.getToHoGrade2()
				, request.getToKaikeiHodong()
				, request.getToKaikeiHocode()
				, getHospitalCode(vertx, sessionId)
				, CommonUtils.parseDouble(request.getFkinp1001()));
		
		response.setResult(true);
		return response.build();
	}

}
