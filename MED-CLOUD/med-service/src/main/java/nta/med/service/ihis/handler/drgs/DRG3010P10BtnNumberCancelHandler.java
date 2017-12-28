package nta.med.service.ihis.handler.drgs;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.drg.Drg3041Repository;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10BtnNumberCancelRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class DRG3010P10BtnNumberCancelHandler
		extends ScreenHandler<DrgsServiceProto.DRG3010P10BtnNumberCancelRequest, SystemServiceProto.UpdateResponse> {

	@Resource
	private Drg3041Repository drg3041Repository;
	
	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DRG3010P10BtnNumberCancelRequest request) throws Exception {
		
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		
		int rowDeleted = drg3041Repository.deleteByHospCodeJubsuDateDrgBunho(getHospitalCode(vertx, sessionId)
				, DateUtil.toDate(request.getJubsuDate(), DateUtil.PATTERN_YYMMDD)
				, CommonUtils.parseDouble(request.getDrgBunho()));
		
		response.setResult(rowDeleted > 0);
		return response.build();
	}

}
