package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs2004Repository;
import nta.med.data.model.ihis.inps.CommonProcResultInfo;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2004U00proCreateJisiRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2004U00proCreateJisiResponse;

@Service
@Scope("prototype")
public class OCS2004U00proCreateJisiHandler extends
		ScreenHandler<OcsiServiceProto.OCS2004U00proCreateJisiRequest, OcsiServiceProto.OCS2004U00proCreateJisiResponse> {

	@Resource
	private Ocs2004Repository ocs2004Repository;
		
	@Override
	@Transactional
	public OCS2004U00proCreateJisiResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2004U00proCreateJisiRequest request) throws Exception {
		OcsiServiceProto.OCS2004U00proCreateJisiResponse.Builder response = OcsiServiceProto.OCS2004U00proCreateJisiResponse.newBuilder();
		
		CommonProcResultInfo info = ocs2004Repository.callPrOcsiAutoCreateJisi(getHospitalCode(vertx, sessionId)
				, CommonUtils.parseDouble(request.getFkinp1001())
				, request.getBunho()
				, request.getInputGubun()
				, request.getInputId()
				, request.getInputGwa()
				, request.getInputDoctor()
				, DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD)
				, request.getOrderTime());
		
		response.setResultCnt(info.getStrResult1());
		response.setFlag(info.getStrResult2());
		return response.build();
	}

}
