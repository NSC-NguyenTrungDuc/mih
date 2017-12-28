package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.adm.Adm3200Repository;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR1010U00DamdangNurseHandler extends ScreenHandler<NuriServiceProto.NUR1010U00DamdangNurseRequest, SystemServiceProto.StringResponse> {   
	
	@Resource
	private Adm3200Repository adm3200Repository;

	@Override
	@Transactional(readOnly = true)
	public SystemServiceProto.StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR1010U00DamdangNurseRequest request) throws Exception {
				
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		
		response.setResult(adm3200Repository.getNUR1010U00DamdangNurse(getHospitalCode(vertx, sessionId), request.getCode()));
		
		return response.build();
	}
}
