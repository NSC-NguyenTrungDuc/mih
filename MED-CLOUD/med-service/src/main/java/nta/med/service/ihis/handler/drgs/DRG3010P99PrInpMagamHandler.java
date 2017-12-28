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
public class DRG3010P99PrInpMagamHandler extends ScreenHandler<DrgsServiceProto.DRG3010P99PrInpMagamRequest, DrgsServiceProto.DRG3010P99PrInpMagamResponse>{
	
	@Resource
	private Drg3010Repository drg3010Repository;
	
	@Override
    @Transactional(rollbackFor = Exception.class)
	public DrgsServiceProto.DRG3010P99PrInpMagamResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DrgsServiceProto.DRG3010P99PrInpMagamRequest request) throws Exception{
	
		DrgsServiceProto.DRG3010P99PrInpMagamResponse.Builder response = DrgsServiceProto.DRG3010P99PrInpMagamResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		
		ComboListItemInfo result = drg3010Repository.callPrDrgInpMagamProc(hospCode, request.getProcGubun(), request.getJubsuDate(), request.getOrderDate(),
				request.getHopeDate(), request.getMagamGubun(), request.getMagamSer(), request.getBunho(), request.getDoctor(), request.getMagamUser());
		
		response.setDrgBunho(result.getCode());
		response.setErr(result.getCodeName());
		
		return response.build();
	}
}