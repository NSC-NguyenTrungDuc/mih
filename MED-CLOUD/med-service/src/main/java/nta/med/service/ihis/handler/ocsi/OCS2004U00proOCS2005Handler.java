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
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2004U00proOCS2005Request;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2004U00proOCS2005Response;

@Service
@Scope("prototype")
public class OCS2004U00proOCS2005Handler extends
		ScreenHandler<OcsiServiceProto.OCS2004U00proOCS2005Request, OcsiServiceProto.OCS2004U00proOCS2005Response> {

	@Resource
	private Ocs2004Repository ocs2004Repository;
	
	@Override
	@Transactional
	public OCS2004U00proOCS2005Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2004U00proOCS2005Request request) throws Exception {

		OcsiServiceProto.OCS2004U00proOCS2005Response.Builder response = OcsiServiceProto.OCS2004U00proOCS2005Response.newBuilder();
		
		CommonProcResultInfo info = ocs2004Repository.callPrOcsiOcs2005Dup(getHospitalCode(vertx, sessionId)
				, request.getIud()
				, request.getGubun()
				, request.getBunho()
				, CommonUtils.parseDouble(request.getFkinp1001())
				, DateUtil.toDate(request.getFromDate(), DateUtil.PATTERN_YYMMDD)
				, request.getFromTime()
				, DateUtil.toDate(request.getToDate(), DateUtil.PATTERN_YYMMDD)
				, request.getToTime()
				, request.getMemb()
				, CommonUtils.parseDouble(request.getPkocs2005()));
		
		response.setErr(info.getStrResult1());
		response.setMsg(info.getStrResult2());
		
		return response.build();
	}

}
