package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003Q02GetCodeNameGwaRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003Q02GetCodeNameGwaResponse;

@Service
@Scope("prototype")
public class OCS2003Q02GetCodeNameGwaHandler extends
		ScreenHandler<OcsiServiceProto.OCS2003Q02GetCodeNameGwaRequest, OcsiServiceProto.OCS2003Q02GetCodeNameGwaResponse> {
	@Resource
	private Ocs2003Repository ocs2003Repository;
	
	@Override
	@Transactional
	public OCS2003Q02GetCodeNameGwaResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003Q02GetCodeNameGwaRequest request) throws Exception {
		
		OcsiServiceProto.OCS2003Q02GetCodeNameGwaResponse.Builder response = OcsiServiceProto.OCS2003Q02GetCodeNameGwaResponse.newBuilder();
		String result = ocs2003Repository.getOCS2003Q02GetCodeNameGwaInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getCode(), "Y", "1");
		if (!StringUtils.isEmpty(result)) {
			CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
			info.setDataValue(result);
			response.setGwaItem(info);
		}
		return response.build();
	}

}
