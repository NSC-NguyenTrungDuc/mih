package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003Q02CheckDrgInjNoActOrderRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003Q02CheckDrgInjNoActOrderResponse;

@Service
@Scope("prototype")
public class OCS2003Q02CheckDrgInjNoActOrderHandler extends
		ScreenHandler<OcsiServiceProto.OCS2003Q02CheckDrgInjNoActOrderRequest, OcsiServiceProto.OCS2003Q02CheckDrgInjNoActOrderResponse> {

	@Resource
	private Ocs2003Repository ocs2003Repository;
	
	@Override
	@Transactional
	public OCS2003Q02CheckDrgInjNoActOrderResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, OCS2003Q02CheckDrgInjNoActOrderRequest request) throws Exception {

		OcsiServiceProto.OCS2003Q02CheckDrgInjNoActOrderResponse.Builder response = OcsiServiceProto.OCS2003Q02CheckDrgInjNoActOrderResponse
				.newBuilder();
		
		String strChk = ocs2003Repository.checkOcsIsYetBannabOrder(getHospitalCode(vertx, sessionId), request.getBunho(), request.getKijunDate());
		CommonModelProto.DataStringListItemInfo.Builder pInfo = CommonModelProto.DataStringListItemInfo.newBuilder().setDataValue(strChk);
		
		response.setCmdItem(pInfo);
		return response.build();
	}

}
