package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import nta.med.data.dao.medi.inp.Inp2004Repository;
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
public class NUR1010Q00ChangeHosilCheck4Handler extends ScreenHandler<NuriServiceProto.NUR1010Q00ChangeHosilCheck4Request, SystemServiceProto.StringResponse> {   
	
	@Resource                                   
	private Inp2004Repository inp2004Repository;

	@Override
	@Transactional(readOnly = true)
	public SystemServiceProto.StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR1010Q00ChangeHosilCheck4Request request) throws Exception {
				
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		
		response.setResult(inp2004Repository.getNUR1010Q00ChangeHosilCheck4(hospCode, CommonUtils.parseDouble(request.getFromFkinp1001())));
		
		return response.build();
	}
}
