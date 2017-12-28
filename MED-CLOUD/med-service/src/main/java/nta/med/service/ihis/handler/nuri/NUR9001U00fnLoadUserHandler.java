package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.adm.Adm3211Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

@Service                                                                                                          
@Scope("prototype")
public class NUR9001U00fnLoadUserHandler extends ScreenHandler<NuriServiceProto.NUR9001U00fnLoadUserRequest, SystemServiceProto.StringResponse> {   
	
	@Resource
	private Adm3211Repository adm3211Repository;
	
	@Override
	@Transactional(readOnly = true)
	public SystemServiceProto.StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR9001U00fnLoadUserRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		
		String rs = adm3211Repository.callFnAdmLoadUserNm(getHospitalCode(vertx, sessionId), request.getRecordUser(),
				DateUtil.toDate(request.getDate(), DateUtil.PATTERN_YYMMDD));
		
		response.setResult(rs);
		return response.build();
	}
}
