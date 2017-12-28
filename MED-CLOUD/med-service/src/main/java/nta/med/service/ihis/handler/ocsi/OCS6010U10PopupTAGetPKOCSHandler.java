package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.ocs.Ocs2016Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupTAGetPKOCSRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupTAGetPKOCSResponse;

@Service
@Scope("prototype")
@Transactional
public class OCS6010U10PopupTAGetPKOCSHandler extends
		ScreenHandler<OcsiServiceProto.OCS6010U10PopupTAGetPKOCSRequest, OcsiServiceProto.OCS6010U10PopupTAGetPKOCSResponse> {
	@Resource
	private Ocs2016Repository ocs2016Repository;
	@Resource
	private CommonRepository commonRepository;
	
	@Override
	public OCS6010U10PopupTAGetPKOCSResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10PopupTAGetPKOCSRequest request) throws Exception {
		OcsiServiceProto.OCS6010U10PopupTAGetPKOCSResponse.Builder response = OcsiServiceProto.OCS6010U10PopupTAGetPKOCSResponse.newBuilder();
		String nextVal = null ;
		if ("2015".equals(request.getOcsgubun()))
			nextVal = commonRepository.getNextVal("OCS2015_SEQ");
		else if ("2016".equals(request.getOcsgubun()))
			nextVal = commonRepository.getNextVal("OCS2016_SEQ");
		
		if (!StringUtils.isEmpty(nextVal)) {
			CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
			info.setDataValue(nextVal);
			response.setPkocsItem(info);
		}
		return response.build();
	}

}
