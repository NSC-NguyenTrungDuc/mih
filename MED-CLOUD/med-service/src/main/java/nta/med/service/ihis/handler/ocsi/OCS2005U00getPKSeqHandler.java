package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs2005Repository;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U00getPKSeqRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U00getPKSeqResponse;

@Service
@Scope("prototype")
public class OCS2005U00getPKSeqHandler extends ScreenHandler<OcsiServiceProto.OCS2005U00getPKSeqRequest, OcsiServiceProto.OCS2005U00getPKSeqResponse>{
	@Resource
	private Ocs2005Repository ocs2005Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS2005U00getPKSeqResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2005U00getPKSeqRequest request) throws Exception {
		OcsiServiceProto.OCS2005U00getPKSeqResponse.Builder response = OcsiServiceProto.OCS2005U00getPKSeqResponse.newBuilder();
		Double maxSeq = ocs2005Repository.getOCS2005U00getPKSeq(getHospitalCode(vertx, sessionId), request.getBunho(), request.getFkinp1001(), request.getOrderDate());
		if (maxSeq != null)
			response.setPkSeq(CommonUtils.parseString(maxSeq));
		return response.build();
	}

}
