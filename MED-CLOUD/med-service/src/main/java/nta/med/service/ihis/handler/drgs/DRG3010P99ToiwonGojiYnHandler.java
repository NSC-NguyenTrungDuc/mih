package nta.med.service.ihis.handler.drgs;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

@Service
@Scope("prototype")
public class DRG3010P99ToiwonGojiYnHandler extends ScreenHandler<DrgsServiceProto.DRG3010P99ToiwonGojiYnRequest, SystemServiceProto.StringResponse>{
	
	@Resource
	private Ocs2003Repository ocs2003Repository;
	
	@Override
    @Transactional(readOnly = true)
	public SystemServiceProto.StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DrgsServiceProto.DRG3010P99ToiwonGojiYnRequest request) throws Exception{
	
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		
		String result = ocs2003Repository.getDRG3010P99ToiwonGojiYn(hospCode, CommonUtils.parseDouble(request.getFkocs2003()));
		
		response.setResult(result);
		
		return response.build();
	}
}