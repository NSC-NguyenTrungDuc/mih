package nta.med.service.ihis.handler.drgs;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

@Service
@Scope("prototype")
public class DRG3010P99PrBunhoCancelHandler extends ScreenHandler<DrgsServiceProto.DRG3010P99PrBunhoCancelRequest, SystemServiceProto.StringResponse>{
	
	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Override
    @Transactional
	public SystemServiceProto.StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DrgsServiceProto.DRG3010P99PrBunhoCancelRequest request) throws Exception{
		
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		
		String result = inp1001Repository.callPrDrgInpDrgBunhoCancel(hospCode, DateUtil.toDate(request.getJubsuDate(), DateUtil.PATTERN_YYMMDD),
				CommonUtils.parseDouble(request.getDrgBunho()), request.getUserId());
		
		response.setResult(result);
		
		return response.build();
	}
}