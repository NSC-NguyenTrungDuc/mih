package nta.med.service.ihis.handler.drgs;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.drg.Drg3060Repository;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

@Service
@Scope("prototype")
public class DRG3010P99PrMakeDrg3060Handler extends ScreenHandler<DrgsServiceProto.DRG3010P99PrMakeDrg3060Request, SystemServiceProto.StringResponse>{
	
	@Resource
	private Drg3060Repository drg3060Repository;
	
	@Override
    @Transactional
	public SystemServiceProto.StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DrgsServiceProto.DRG3010P99PrMakeDrg3060Request request) throws Exception{
		
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		
		String result = drg3060Repository.callPrDrgMakeDrg3060(hospCode, request.getUserId(), CommonUtils.parseDouble(request.getFkocs2003()), request.getBoryuYn());
		
		response.setResult(result);
	
		return response.build();
	}
}