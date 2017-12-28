package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.nur.Nur1014Repository;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR1014U00ValidationCheckHandler extends ScreenHandler<NuriServiceProto.NUR1014U00ValidationCheckRequest, SystemServiceProto.StringResponse> {   
	
	@Resource
	private Nur1014Repository nur1014Repository;

	@Override
	@Transactional(readOnly = true)
	public SystemServiceProto.StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR1014U00ValidationCheckRequest request) throws Exception {
				
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		
		response.setResult(nur1014Repository.getNUR1014U00ValidationCheck(hospCode, request.getBunho(), request.getOutDate(), request.getOutTime(),
				CommonUtils.parseDouble(request.getFkinp1001())));
		
		return response.build();
	}
}
