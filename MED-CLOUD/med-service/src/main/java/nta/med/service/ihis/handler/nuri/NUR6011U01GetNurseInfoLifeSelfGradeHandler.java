package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import nta.med.data.dao.medi.nur.Nur1012Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR6011U01GetNurseInfoLifeSelfGradeHandler extends ScreenHandler<NuriServiceProto.NUR6011U01GetNurseInfoLifeSelfGradeRequest, SystemServiceProto.StringResponse> {   
	
	@Resource                                   
	private Nur1012Repository nur1012Repository;

	@Override
	@Transactional(readOnly = true)
	public SystemServiceProto.StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR6011U01GetNurseInfoLifeSelfGradeRequest request) throws Exception {
				
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		
		String result = nur1012Repository.getNUR6011U01GetNurseInfoLifeSelfGrade(hospCode, CommonUtils.parseDouble(request.getFkinp1001()), request.getJukyongDate());
		
		response.setResult(result);
		
		return response.build();
	}
}
