package nta.med.service.ihis.handler.ocsi;

import java.util.Date;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.data.model.ihis.inps.OCS2003Q02BatchDeleteProcessInfo;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003Q02BatchDeleteProcessRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003Q02BatchDeleteProcessResponse;

@Service
@Scope("prototype")
public class OCS2003Q02BatchDeleteProcessHandler extends
		ScreenHandler<OcsiServiceProto.OCS2003Q02BatchDeleteProcessRequest, OcsiServiceProto.OCS2003Q02BatchDeleteProcessResponse> {

	@Resource
	private Ocs2003Repository ocs2003Repository;
	
	@Override
	@Transactional
	public OCS2003Q02BatchDeleteProcessResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003Q02BatchDeleteProcessRequest request) throws Exception {
		
		OcsiServiceProto.OCS2003Q02BatchDeleteProcessResponse.Builder response = OcsiServiceProto.OCS2003Q02BatchDeleteProcessResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		Double pkInp1001 = CommonUtils.parseDouble(request.getPkinp1001());
		Date deleteDate = DateUtil.toDate(request.getDeleteDate(), DateUtil.PATTERN_YYMMDD);
		OCS2003Q02BatchDeleteProcessInfo info = ocs2003Repository.callPrOcsiBatchDeleteOrder(hospCode, pkInp1001, deleteDate);
		OcsiModelProto.OCS2003Q02BatchDeleteProcessInfo.Builder pInfo = OcsiModelProto.OCS2003Q02BatchDeleteProcessInfo.newBuilder();
		BeanUtils.copyProperties(info, pInfo, getLanguage(vertx, sessionId));
		
		response.setProItem(pInfo);
		return response.build();
	}
}
