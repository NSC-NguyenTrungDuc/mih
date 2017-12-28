package nta.med.service.ihis.handler.drgs;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.drg.Drg3041Repository;
import nta.med.data.model.ihis.drgs.PrDrgMakeBarCodeResultInfo;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

@Service
@Scope("prototype")
public class DRG3010P99PrMakeBarcodeHandler extends ScreenHandler<DrgsServiceProto.DRG3010P99PrMakeBarcodeRequest, SystemServiceProto.UpdateResponse>{
	
	@Resource
	private Drg3041Repository drg3041Repository;
	
	@Override
    @Transactional
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DrgsServiceProto.DRG3010P99PrMakeBarcodeRequest request) throws Exception{
	
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		
		PrDrgMakeBarCodeResultInfo result = drg3041Repository.callPrDrgMakeBarCode(hospCode, request.getBarcodeNo(), request.getIudGubun(),
				request.getUserId(), DateUtil.toDate(request.getDate(), DateUtil.PATTERN_YYMMDD), request.getUserGubun(), request.getBunho());
		
		response.setResult(true);
		return response.build();
	}
}