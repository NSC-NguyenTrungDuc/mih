package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.ocs.Ocs2005Repository;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2004U00getPKSeqRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2004U00getPKSeqResponse;

@Service
@Scope("prototype")
public class OCS2004U00getPKSeqHandler extends ScreenHandler<OcsiServiceProto.OCS2004U00getPKSeqRequest, OcsiServiceProto.OCS2004U00getPKSeqResponse> {
	@Resource
	private Ocs2005Repository ocs2005Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS2004U00getPKSeqResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2004U00getPKSeqRequest request) throws Exception {
		
		OcsiServiceProto.OCS2004U00getPKSeqResponse.Builder response = OcsiServiceProto.OCS2004U00getPKSeqResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String bunho = request.getBunho();
		String fkinp1001 = request.getFkinp1001();
		String orderDate = request.getOrderDate();
		
		String tabinputGubun = request.getTabinputGubun();

		String strDate = ocs2005Repository.getOCS2004U00getPKSeq(hospCode, bunho, fkinp1001, orderDate, tabinputGubun);
		strDate = StringUtils.isEmpty(strDate) ? "" : strDate;
		
		if (!StringUtils.isEmpty(strDate)) {
			response.setPkSeq(strDate);
		}
			
		return response.build();
	}

}
