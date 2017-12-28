package nta.med.service.ihis.handler.drgs;


import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ifs.Ifs7303Repository;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

@Service
@Scope("prototype")
public class DRG3010P99PrJihInjIfsProcHandler extends ScreenHandler<DrgsServiceProto.DRG3010P99PrJihInjIfsProcRequest, SystemServiceProto.StringResponse>{
	
	@Resource
	private Ifs7303Repository ifs7303Repository;
	
    @Override
    @Transactional
	public SystemServiceProto.StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DrgsServiceProto.DRG3010P99PrJihInjIfsProcRequest request) throws Exception{		

		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		
		String result = ifs7303Repository.callPrJihInjIfsProc(hospCode, request.getIoGubun(),CommonUtils.parseDouble(request.getFkdrg()), request.getUserId());
		
		response.setResult(result);
		
		return response.build();
	}

}
