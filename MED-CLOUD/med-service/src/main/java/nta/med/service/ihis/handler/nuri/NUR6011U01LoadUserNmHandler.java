package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import nta.med.data.dao.medi.adm.Adm3211Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR6011U01LoadUserNmHandler extends ScreenHandler<NuriServiceProto.NUR6011U01LoadUserNmRequest, SystemServiceProto.StringResponse> {   
	
	@Resource                                   
	private Adm3211Repository adm3211Repository;

	@Override
	@Transactional(readOnly = true)
	public SystemServiceProto.StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR6011U01LoadUserNmRequest request) throws Exception {
				
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		
		response.setResult(adm3211Repository.getNUR6011U01LoadUserNm(hospCode, request.getCode()));
		
		return response.build();
	}
}
