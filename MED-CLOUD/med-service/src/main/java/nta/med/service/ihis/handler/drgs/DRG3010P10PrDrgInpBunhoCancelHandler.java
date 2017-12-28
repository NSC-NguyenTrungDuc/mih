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
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10PrDrgInpBunhoCancelRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class DRG3010P10PrDrgInpBunhoCancelHandler extends
		ScreenHandler<DrgsServiceProto.DRG3010P10PrDrgInpBunhoCancelRequest, SystemServiceProto.UpdateResponse> {

	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DRG3010P10PrDrgInpBunhoCancelRequest request) throws Exception {
		
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		
		String err = inp1001Repository.callPrDrgInpDrgBunhoCancel(hospCode
				, DateUtil.toDate(request.getJubsuDate(), DateUtil.PATTERN_YYMMDD)
				, CommonUtils.parseDouble(request.getDrgBunho())
				, getUserId(vertx, sessionId));
		
		response.setMsg(err == null ? "" : err);
		response.setResult(true);
		return response.build();
	}
}