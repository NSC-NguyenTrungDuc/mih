package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.ocs.Ocs2005Repository;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U00JisiOrderGubunRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U00JisiOrderGubunResponse;

@Service
@Scope("prototype")
public class OCS2005U00JisiOrderGubunHandler extends ScreenHandler<OcsiServiceProto.OCS2005U00JisiOrderGubunRequest, OcsiServiceProto.OCS2005U00JisiOrderGubunResponse>{
	@Resource
	private Ocs2005Repository ocs2005Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS2005U00JisiOrderGubunResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2005U00JisiOrderGubunRequest request) throws Exception {
		OcsiServiceProto.OCS2005U00JisiOrderGubunResponse.Builder response = OcsiServiceProto.OCS2005U00JisiOrderGubunResponse.newBuilder();
		String result = ocs2005Repository.callFnOcsiGEetJisiOrderGubun(getHospitalCode(vertx, sessionId), request.getNurGrCode(), request.getNurMdCode());
		if (!StringUtils.isEmpty(result))
			response.setJisiOrderGubun(result);
		return response.build();
	}

}
