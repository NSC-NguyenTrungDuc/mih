package nta.med.service.ihis.handler.nuri;

import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.nur.Nur9001Repository;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR9001U00Nur9001dataCheckHandler extends ScreenHandler<NuriServiceProto.NUR9001U00Nur9001dataCheckRequest, SystemServiceProto.StringResponse> {
	
	@Resource
	private Nur9001Repository nur9001Repository;
	
	@Override
	@Transactional(readOnly = true)
	public SystemServiceProto.StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR9001U00Nur9001dataCheckRequest request) throws Exception {
				
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		
		response.setResult(nur9001Repository.getNUR9001U00Nur9001dataCheck(getHospitalCode(vertx, sessionId), CommonUtils.parseDouble(request.getPknur9001())));
		
		return response.build();
	}
}
