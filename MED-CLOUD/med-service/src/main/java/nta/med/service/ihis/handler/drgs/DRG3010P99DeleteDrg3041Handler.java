package nta.med.service.ihis.handler.drgs;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.drg.Drg3041Repository;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

@Service
@Scope("prototype")
public class DRG3010P99DeleteDrg3041Handler extends ScreenHandler<DrgsServiceProto.DRG3010P99DeleteDrg3041Request, SystemServiceProto.UpdateResponse>{
	
	@Resource
	private Drg3041Repository drg3041Repository;
	
	@Override
    @Transactional
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DrgsServiceProto.DRG3010P99DeleteDrg3041Request request) throws Exception{
		
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		
		boolean result = true;
		if(drg3041Repository.drg3010P99DeleteDrg3041(hospCode, request.getJubsuDate(), CommonUtils.parseDouble(request.getDrgBunho())) <= 0)
			result = false;
		
		response.setResult(result);
		return response.build();
	}
}