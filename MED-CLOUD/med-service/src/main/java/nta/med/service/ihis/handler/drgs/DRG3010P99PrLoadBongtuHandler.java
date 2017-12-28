package nta.med.service.ihis.handler.drgs;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.drg.Drg3020Repository;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

@Service
@Scope("prototype")
public class DRG3010P99PrLoadBongtuHandler extends ScreenHandler<DrgsServiceProto.DRG3010P99PrLoadBongtuRequest, SystemServiceProto.StringResponse>{
	
	@Resource
	private Drg3020Repository drg3020Repository;
	
	@Override
    @Transactional
	public SystemServiceProto.StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DrgsServiceProto.DRG3010P99PrLoadBongtuRequest request) throws Exception{
		
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String bunho = request.getBunho();
		if(bunho == "")
			bunho = "%";
		
		String result = drg3020Repository.callPrDrgLoadBongtuSer(hospCode, request.getMagamDate(), request.getMagamGubun(), bunho, request.getMagamDept(), request.getUpdId());
		response.setResult(result);
		
		return response.build();
	}
}