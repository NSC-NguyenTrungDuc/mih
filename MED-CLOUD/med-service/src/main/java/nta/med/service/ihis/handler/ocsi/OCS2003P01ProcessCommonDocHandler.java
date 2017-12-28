package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs0503Repository;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003P01ProcessCommonDocRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class OCS2003P01ProcessCommonDocHandler extends ScreenHandler<OcsiServiceProto.OCS2003P01ProcessCommonDocRequest, SystemServiceProto.UpdateResponse>{
	@Resource
	private Ocs0503Repository ocs0503Repository;
	
	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003P01ProcessCommonDocRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		if (ocs0503Repository.updateOCS0503OCS2003P01ProcessCommonDoc(getHospitalCode(vertx, sessionId), CommonUtils.parseDouble(request.getPkocs0503()), "UPD_REC_", request.getDoctor())> 0)
			response.setResult(true);
		else response.setResult(false);
		return response.build();
	}

}
