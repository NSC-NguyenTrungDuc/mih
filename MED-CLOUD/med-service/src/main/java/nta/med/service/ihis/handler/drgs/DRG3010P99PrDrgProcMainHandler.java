package nta.med.service.ihis.handler.drgs;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.ifs.Ifs7301Repository;
import nta.med.data.model.ihis.system.TripleListItemInfo;
import nta.med.service.ihis.proto.DrgsServiceProto;

@Service
@Scope("prototype")
public class DRG3010P99PrDrgProcMainHandler extends ScreenHandler<DrgsServiceProto.DRG3010P99PrDrgProcMainRequest, DrgsServiceProto.DRG3010P99PrDrgProcMainResponse>{
	
	@Resource
	private Ifs7301Repository ifs7301Repository;
	
	@Override
    @Transactional
	public DrgsServiceProto.DRG3010P99PrDrgProcMainResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DrgsServiceProto.DRG3010P99PrDrgProcMainRequest request) throws Exception{
	
		DrgsServiceProto.DRG3010P99PrDrgProcMainResponse.Builder response = DrgsServiceProto.DRG3010P99PrDrgProcMainResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		
		TripleListItemInfo result = ifs7301Repository.callPrIfsDrgProcMain(hospCode, request.getIoGubun(), request.getMasterFk(), request.getSendYn());
		response.setCnt(result.getItem1());
		response.setFlag(result.getItem2());
		response.setMsg(result.getItem3());
		
		return response.build();
	}
}