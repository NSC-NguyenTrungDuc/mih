package nta.med.service.ihis.handler.drgs;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.drg.Drg5010Repository;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

@Service
@Scope("prototype")
public class DRG3010P99PrDrg5010Handler extends ScreenHandler<DrgsServiceProto.DRG3010P99PrDrg5010Request, SystemServiceProto.StringResponse>{
	
	@Resource
	private Drg5010Repository drg5010Repository;
	
	@Override
    @Transactional
	public SystemServiceProto.StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DrgsServiceProto.DRG3010P99PrDrg5010Request request) throws Exception{
	
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		
		Double result = drg5010Repository.callPrJihDrgDrg5010Insert(hospCode, DateUtil.toDate(request.getJubsuDate(), DateUtil.PATTERN_YYMMDD), request.getDrgBunho(),
				request.getDataDubun(), request.getInOutGubun(), request.getBunho(), CommonUtils.parseInteger(request.getFk()));
		
		response.setResult(CommonUtils.parseString(result));
		return response.build();
	}
}