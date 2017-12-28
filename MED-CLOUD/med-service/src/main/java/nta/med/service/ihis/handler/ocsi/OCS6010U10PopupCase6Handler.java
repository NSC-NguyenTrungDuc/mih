package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.ocs.Ocs2005;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs2005Repository;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupCase6Request;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class OCS6010U10PopupCase6Handler
		extends ScreenHandler<OcsiServiceProto.OCS6010U10PopupCase6Request, SystemServiceProto.StringResponse> {

	@Resource
	private Ocs2005Repository ocs2005Repository;
	
	@Override
	@Transactional
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10PopupCase6Request request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		
		List<Ocs2005> listOcs2005 = ocs2005Repository.findByHospCodeOrderDateFkocs6015(getHospitalCode(vertx, sessionId)
				, DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD)
				, CommonUtils.parseDouble(request.getPkocs6015()));
		
		String strRes = CollectionUtils.isEmpty(listOcs2005) ? "Y" : "N";
		response.setResult(strRes);
		
		return response.build();
	}
}
