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
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U01PRINPUPDATEJENGWARequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class NUR2004U01PRINPUPDATEJENGWAHandler
		extends ScreenHandler<NuriServiceProto.NUR2004U01PRINPUPDATEJENGWARequest, SystemServiceProto.UpdateResponse> {
	
	@Resource
	private Inp2004Repository inp2004Repository;

	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2004U01PRINPUPDATEJENGWARequest request) throws Exception {
		
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		
		String result = inp2004Repository.callProcInpUpadateJengwa(hospCode, request.getIudGubun(), request.getUserId(), CommonUtils.parseDouble(request.getPkinp1001()),
				request.getIpwonType(), request.getBunho(), request.getOrderDate(), request.getTransTime(), request.getToHoCode1(), request.getToHoDong1(),
				request.getToHoGrade1(), request.getToHoCode2(), request.getToHoDong2(), request.getToHoGrade2(), request.getToBedNo());
		
		response.setResult(true);
		response.setMsg(result);
		
		return response.build();
	}

}
