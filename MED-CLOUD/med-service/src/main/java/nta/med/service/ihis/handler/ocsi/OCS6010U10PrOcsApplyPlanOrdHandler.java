package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs6010Repository;
import nta.med.data.model.ihis.inps.CommonProcResultInfo;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PrOcsApplyPlanOrdRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PrOcsApplyPlanOrdResponse;

@Service
@Scope("prototype")
public class OCS6010U10PrOcsApplyPlanOrdHandler extends
		ScreenHandler<OcsiServiceProto.OCS6010U10PrOcsApplyPlanOrdRequest, OcsiServiceProto.OCS6010U10PrOcsApplyPlanOrdResponse> {

	@Resource
	private Ocs6010Repository ocs6010Repository;
	
	@Override
	@Transactional
	public OCS6010U10PrOcsApplyPlanOrdResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10PrOcsApplyPlanOrdRequest request) throws Exception {
		OcsiServiceProto.OCS6010U10PrOcsApplyPlanOrdResponse.Builder response = OcsiServiceProto.OCS6010U10PrOcsApplyPlanOrdResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		CommonProcResultInfo info = ocs6010Repository.callPrOcsApplyPlanOrderGroup(hospCode
				, request.getBunho()
				, CommonUtils.parseDouble(request.getFkinp1001())
				, CommonUtils.parseDouble(request.getFkocs6010())
				, DateUtil.toDate(request.getPlanDate(), DateUtil.PATTERN_YYMMDD)
				, request.getInputGubun()
				, request.getOrderGubun()
				, request.getGroupSer()
				, request.getUserId());
		
		response.setMsg(info.getStrResult1());
		response.setFlag(info.getStrResult2());
		
		return response.build();
	}

}
