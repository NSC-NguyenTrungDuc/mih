package nta.med.service.ihis.handler.drgs;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.drg.Drg3010Repository;
import nta.med.service.ihis.proto.DrgsServiceProto;

@Service
@Scope("prototype")
public class DRG3010P99getBarDrgBunhoHandler extends ScreenHandler<DrgsServiceProto.DRG3010P99getBarDrgBunhoRequest, DrgsServiceProto.DRG3010P99getBarDrgBunhoResponse>{
	
	@Resource
	private Drg3010Repository drg3010Repository;
	
	@Override
    @Transactional(readOnly = true)
	public DrgsServiceProto.DRG3010P99getBarDrgBunhoResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DrgsServiceProto.DRG3010P99getBarDrgBunhoRequest request) throws Exception{
	
		DrgsServiceProto.DRG3010P99getBarDrgBunhoResponse.Builder response = DrgsServiceProto.DRG3010P99getBarDrgBunhoResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		String result = drg3010Repository.DRG3010P99getBarDrgBunho(hospCode, request.getJubsuDate(), CommonUtils.parseDouble(request.getDrgBunho()));
		
		response.setBarDrgBunho(result);		
		return response.build();
	}
}