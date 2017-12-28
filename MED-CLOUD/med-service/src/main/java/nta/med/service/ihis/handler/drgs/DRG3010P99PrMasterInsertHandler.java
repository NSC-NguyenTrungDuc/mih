package nta.med.service.ihis.handler.drgs;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.ifs.Ifs7301Repository;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

@Service
@Scope("prototype")
public class DRG3010P99PrMasterInsertHandler extends ScreenHandler<DrgsServiceProto.DRG3010P99PrMasterInsertRequest, SystemServiceProto.StringResponse>{
	
	@Resource
	private Ifs7301Repository ifs7301Repository;
	
	@Override
    @Transactional
	public SystemServiceProto.StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DrgsServiceProto.DRG3010P99PrMasterInsertRequest request) throws Exception{
	
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		
		String result = ifs7301Repository.callPrDrgMasterInsert(hospCode, request.getJubsuDate(), request.getDrgBunho(),
						request.getDataDubun(), request.getInOutGubun(), request.getBunho(), request.getFk());
		
		response.setResult(result);
		
		return response.build();
	}
}