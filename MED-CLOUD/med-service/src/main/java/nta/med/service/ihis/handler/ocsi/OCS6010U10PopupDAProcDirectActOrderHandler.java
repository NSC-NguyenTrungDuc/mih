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
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupDAProcDirectActOrderRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupDAProcDirectActOrderResponse;

@Service
@Scope("prototype")
public class OCS6010U10PopupDAProcDirectActOrderHandler extends
		ScreenHandler<OcsiServiceProto.OCS6010U10PopupDAProcDirectActOrderRequest, OcsiServiceProto.OCS6010U10PopupDAProcDirectActOrderResponse> {

	@Resource
	private Ocs6010Repository ocs6010Repository;
	
	@Override
	@Transactional
	public OCS6010U10PopupDAProcDirectActOrderResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, OCS6010U10PopupDAProcDirectActOrderRequest request) throws Exception {
		OcsiServiceProto.OCS6010U10PopupDAProcDirectActOrderResponse.Builder response = OcsiServiceProto.OCS6010U10PopupDAProcDirectActOrderResponse.newBuilder();
		
		CommonProcResultInfo info = ocs6010Repository.callPrOcsDirectActOrder(getHospitalCode(vertx, sessionId)
				, request.getBunho()
				, CommonUtils.parseDouble(request.getFkinp1001())
				, DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD)
				, request.getInputGubun()
				, CommonUtils.parseDouble(request.getPkocs2015())
				, DateUtil.toDate(request.getActDate(), DateUtil.PATTERN_YYMMDD)
				, getUserId(vertx, sessionId));
		
		CommonModelProto.ComboListItemInfo.Builder pInfo = CommonModelProto.ComboListItemInfo.newBuilder()
				.setCode(info.getStrResult2())
				.setCodeName(info.getStrResult1());
		
		response.setProcItem(pInfo);
		return response.build();
	}
}
