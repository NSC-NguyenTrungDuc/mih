package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.ocs.Ocs2015Repository;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10frmARActingSeqOCS2015Request;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class OCS6010U10frmARActingSeqOCS2015Handler extends ScreenHandler<OcsiServiceProto.OCS6010U10frmARActingSeqOCS2015Request, SystemServiceProto.StringResponse> {
	@Resource
	private Ocs2015Repository ocs2015Repository;
	
	@Override
	@Transactional(readOnly=true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10frmARActingSeqOCS2015Request request) throws Exception {
		
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		
		String bunho = request.getFBunho();
		String fkinp1001 = request.getFFkinp1001();
		String orderDate = request.getFOrderDate();
		String inputGubun = request.getFInputGubun();
		String pkSeq = request.getFPkSeq();
		
		Double seq = ocs2015Repository.getOCS6010U10frmARActingSeqOCS2015(hospCode, bunho, fkinp1001, orderDate, inputGubun, pkSeq);
		response.setResult(seq == null ? "" : String.valueOf(seq));
		return response.build();
	}

}
