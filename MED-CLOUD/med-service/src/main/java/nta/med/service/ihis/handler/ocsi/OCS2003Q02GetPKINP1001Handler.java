package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003Q02GetPKINP1001Request;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003Q02GetPKINP1001Response;

@Service
@Scope("prototype")
public class OCS2003Q02GetPKINP1001Handler extends
		ScreenHandler<OcsiServiceProto.OCS2003Q02GetPKINP1001Request, OcsiServiceProto.OCS2003Q02GetPKINP1001Response> {
	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Override
	@Transactional
	public OCS2003Q02GetPKINP1001Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003Q02GetPKINP1001Request request) throws Exception {
		
		OcsiServiceProto.OCS2003Q02GetPKINP1001Response.Builder response = OcsiServiceProto.OCS2003Q02GetPKINP1001Response.newBuilder();
		Double result = inp1001Repository.getListPkinp1001(getHospitalCode(vertx, sessionId), request.getBunho());
		if (result != null) {
			CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
			info.setDataValue(CommonUtils.parseString(result));
			response.setPkiItem(info);
		}
		return response.build();
	}

}
