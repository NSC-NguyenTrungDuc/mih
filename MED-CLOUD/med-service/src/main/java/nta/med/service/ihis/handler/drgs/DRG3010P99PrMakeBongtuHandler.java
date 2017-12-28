package nta.med.service.ihis.handler.drgs;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.drg.Drg3010Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.DrgsServiceProto;

@Service
@Scope("prototype")
public class DRG3010P99PrMakeBongtuHandler extends ScreenHandler<DrgsServiceProto.DRG3010P99PrMakeBongtuRequest, DrgsServiceProto.DRG3010P99PrMakeBongtuResponse>{
	
	@Resource
	private Drg3010Repository drg3010Repository;
	
	@Override
    @Transactional
	public DrgsServiceProto.DRG3010P99PrMakeBongtuResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DrgsServiceProto.DRG3010P99PrMakeBongtuRequest request) throws Exception{
		
		DrgsServiceProto.DRG3010P99PrMakeBongtuResponse.Builder response = DrgsServiceProto.DRG3010P99PrMakeBongtuResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		
		ComboListItemInfo result = drg3010Repository.callPrMakeBongtuInp(hospCode, request.getJubsuDate(), request.getBunho(), request.getHopeDate(), request.getHopeTime(),
				request.getGwa(), request.getDoctor(), request.getJusaYn(), request.getChulgoBuseo(), request.getUserId());
		
		response.setDrgBunho(result.getCode());
		response.setErr(result.getCodeName());
		
		return response.build();
	}
}