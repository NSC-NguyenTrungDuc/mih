package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0250Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR1010Q00ChangeHosilCheck3Handler extends ScreenHandler<NuriServiceProto.NUR1010Q00ChangeHosilCheck3Request, SystemServiceProto.StringResponse> {   
	
	@Resource                                   
	private Bas0250Repository bas0250Repository;

	@Override
	@Transactional(readOnly = true)
	public SystemServiceProto.StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR1010Q00ChangeHosilCheck3Request request) throws Exception {
				
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		
		response.setResult(bas0250Repository.checkNUR1010Q00isExistBas2050(getHospitalCode(vertx, sessionId), request.getFromHoCode(), request.getFromHoDong()));
		
		return response.build();
	}
}
