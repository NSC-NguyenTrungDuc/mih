package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs2015Repository;
import nta.med.data.model.ihis.ocsi.OCS6010U10PopupTAProcDAOTInfo;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupTAProcDAOTRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupTAProcDAOTResponse;

@Service
@Scope("prototype")
@Transactional
public class OCS6010U10PopupTAProcDAOTHandler extends
		ScreenHandler<OcsiServiceProto.OCS6010U10PopupTAProcDAOTRequest, OcsiServiceProto.OCS6010U10PopupTAProcDAOTResponse> {
	@Resource
	private Ocs2015Repository ocs2015Repository;
	
	@Override
	public OCS6010U10PopupTAProcDAOTResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10PopupTAProcDAOTRequest request) throws Exception {
		OcsiServiceProto.OCS6010U10PopupTAProcDAOTResponse.Builder response = OcsiServiceProto.OCS6010U10PopupTAProcDAOTResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		OCS6010U10PopupTAProcDAOTInfo item = ocs2015Repository.callPrOcsDirectActOrderTreat(hospCode, language
						, request.getBunho()
						, request.getFkinp1001()
						, request.getOrderDate()
						, request.getInputGubun()
						, request.getPkocs2015()
						, request.getActingDate()
						, request.getUserId());
		if (item != null) {
			OcsiModelProto.OCS6010U10PopupTAProcDAOTInfo.Builder info =  OcsiModelProto.OCS6010U10PopupTAProcDAOTInfo.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			response.setProcItem(info);
		}
		return response.build();
	}

}
