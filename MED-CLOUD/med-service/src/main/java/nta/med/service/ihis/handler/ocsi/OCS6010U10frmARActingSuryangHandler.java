package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.ocs.Ocs2006Repository;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10frmARActingSuryangRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class OCS6010U10frmARActingSuryangHandler extends ScreenHandler<OcsiServiceProto.OCS6010U10frmARActingSuryangRequest, SystemServiceProto.StringResponse> {
	@Resource
	private Ocs2006Repository ocs2006Repository;
	
	@Override
	@Transactional(readOnly=true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10frmARActingSuryangRequest request) throws Exception {
		
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		
		String fkocs2005 = request.getFFkocs2005();
		
		String strData = ocs2006Repository.getOCS6010U10frmARActingSuryang(hospCode, fkocs2005);
		response.setResult(StringUtils.isEmpty(strData) ? "" : strData);
		return response.build();
	}

}
