package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003Q02BannabProcessRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003Q02BannabProcessResponse;

@Service
@Scope("prototype")
public class OCS2003Q02BannabProcessHandler extends
		ScreenHandler<OcsiServiceProto.OCS2003Q02BannabProcessRequest, OcsiServiceProto.OCS2003Q02BannabProcessResponse> {

	@Resource
	private Ocs2003Repository ocs2003Repository;
	
	@Override
	@Transactional
	public OCS2003Q02BannabProcessResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003Q02BannabProcessRequest request) throws Exception {

		OcsiServiceProto.OCS2003Q02BannabProcessResponse.Builder response = OcsiServiceProto.OCS2003Q02BannabProcessResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String strErr = ocs2003Repository.callPrOcsiProcessBannabNew(hospCode
				, request.getWorkGubun()
				, request.getBunho()
				, CommonUtils.parseDouble(request.getFkinp1001())
				, CommonUtils.parseDouble(request.getPkocs2003())
				, DateUtil.toDate(request.getStopDate(), DateUtil.PATTERN_YYMMDD)
				, DateUtil.toDate(request.getStopDate2(), DateUtil.PATTERN_YYMMDD)
				, request.getInputDoctor()
				, request.getUserId()
				, request.getGubun()
				, CommonUtils.parseDouble(request.getBannabDv())
				, request.getBogyongCodeReturn()
				, CommonUtils.parseDouble(request.getToiwonDrgDv())
				, request.getToiwonDrgBogyongCode());
		
		CommonModelProto.DataStringListItemInfo.Builder pInfo = CommonModelProto.DataStringListItemInfo.newBuilder().setDataValue(strErr);
		response.setProItem(pInfo);
		
		return response.build();
	}

}
