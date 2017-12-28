package nta.med.service.ihis.handler.nuri;

import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.inp.Inp1001Repository;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR1001U00DtpBirthValidateHandler extends ScreenHandler<NuriServiceProto.NUR1001U00DtpBirthValidateRequest, SystemServiceProto.StringResponse> {

	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Override
	@Transactional(readOnly = true)
	public SystemServiceProto.StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR1001U00DtpBirthValidateRequest request) throws Exception {
				
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		
		response.setResult(inp1001Repository.getAgeByBirth(request.getBirth()));
		
		return response.build();
	}
}
