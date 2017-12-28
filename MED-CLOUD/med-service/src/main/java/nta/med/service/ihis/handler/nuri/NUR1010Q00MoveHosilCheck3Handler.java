package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR1010Q00MoveHosilCheck3Handler extends ScreenHandler<NuriServiceProto.NUR1010Q00MoveHosilCheck3Request, SystemServiceProto.StringResponse> {   
	
	@Resource                                   
	private Inp1001Repository inp1001Repository;

	@Override
	@Transactional(readOnly = true)
	public SystemServiceProto.StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR1010Q00MoveHosilCheck3Request request) throws Exception {
				
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		
		String result = inp1001Repository.checkNUR1010Q00MoveHosilCheck3(hospCode, request.getToBedNo(), request.getToHoCode(), request.getToHoDong());
		
		response.setResult(result);
		
		return response.build();
	}
}