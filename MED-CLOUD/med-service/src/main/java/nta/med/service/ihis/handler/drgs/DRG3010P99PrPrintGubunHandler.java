package nta.med.service.ihis.handler.drgs;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.drg.Drg3010Repository;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

@Service
@Scope("prototype")
public class DRG3010P99PrPrintGubunHandler extends ScreenHandler<DrgsServiceProto.DRG3010P99PrPrintGubunRequest, SystemServiceProto.StringResponse>{
	
	@Resource
	private Drg3010Repository drg3010Repository;
	
	@Override
    @Transactional
	public SystemServiceProto.StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DrgsServiceProto.DRG3010P99PrPrintGubunRequest request) throws Exception{
	
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		
		String result = drg3010Repository.callPrDrgLoadPrintGubun(hospCode, request.getDrgBunho(), request.getJubsuDate(), request.getPrintGubun());
		
		response.setResult(result);
		
		return response.build();
	}
}