package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs6010Repository;
import nta.med.data.model.ihis.inps.CommonProcResultInfo;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PrOcsPlanDirectConvRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PrOcsPlanDirectConvResponse;

@Service
@Scope("prototype")
public class OCS6010U10PrOcsPlanDirectConvHandler extends
		ScreenHandler<OcsiServiceProto.OCS6010U10PrOcsPlanDirectConvRequest, OcsiServiceProto.OCS6010U10PrOcsPlanDirectConvResponse> {

	private static final Log LOGGER = LogFactory.getLog(OCS6010U10PrOcsPlanDirectConvHandler.class);
	
	@Resource
	private Ocs6010Repository ocs6010Repository;

	@Override
	public OCS6010U10PrOcsPlanDirectConvResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10PrOcsPlanDirectConvRequest request) throws Exception {
		OcsiServiceProto.OCS6010U10PrOcsPlanDirectConvResponse.Builder response = OcsiServiceProto.OCS6010U10PrOcsPlanDirectConvResponse
				.newBuilder();

		CommonProcResultInfo info = ocs6010Repository.callPrOcsPlanDirectConvert(getHospitalCode(vertx, sessionId),
				CommonUtils.parseDouble(request.getIPkocs6015()),
				DateUtil.toDate(request.getIAppDate(), DateUtil.PATTERN_YYMMDD), request.getIUserId());

		LOGGER.info(String.format("Execute PR_OCS_PLAN_DIRECT_CONVERT: hosp_code = %s, Pkocs2005 = %s, PkSeq = %s, Err = %s", getHospitalCode(vertx, sessionId), info.getStrResult1(), info.getStrResult2(), info.getStrResult3()));
		
		response.setIoPkocs2005(info.getStrResult1());
		response.setIoPkSeq(info.getStrResult2());
		response.setIoErr(info.getStrResult3());
		
		return response.build();
	}

}
