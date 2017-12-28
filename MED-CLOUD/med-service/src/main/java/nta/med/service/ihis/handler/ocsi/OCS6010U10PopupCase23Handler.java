package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs2015Repository;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupCase23Request;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class OCS6010U10PopupCase23Handler extends ScreenHandler<OcsiServiceProto.OCS6010U10PopupCase23Request, SystemServiceProto.UpdateResponse>{

	@Resource
	private Ocs2015Repository ocs2015Repository;
	
	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10PopupCase23Request request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		
		int rowDeleted = ocs2015Repository.deleteOcs2015InOCS6010U10( getHospitalCode(vertx, sessionId)
																	, request.getBunho()
																	, CommonUtils.parseDouble(request.getFkinp1001())
																	, DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD)
																	, request.getInputGubun()
																	, CommonUtils.parseDouble(request.getPkSeq())
																	, DateUtil.toDate(request.getActDate(), DateUtil.PATTERN_YYMMDD)
																	, request.getSiksaCode());		
		
		response.setResult(rowDeleted > 0);
		return response.build();
	}

	
}
