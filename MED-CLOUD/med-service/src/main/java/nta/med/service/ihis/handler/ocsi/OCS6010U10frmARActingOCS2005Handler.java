package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs2016Repository;
import nta.med.data.dao.medi.ocs.Ocs6010Repository;
import nta.med.data.model.ihis.ocsi.OCS6010U10frmARActingOCS2005Info;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10frmARActingOCS2005Request;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10frmARActingOCS2005Response;

@Service
@Scope("prototype")
public class OCS6010U10frmARActingOCS2005Handler extends
		ScreenHandler<OcsiServiceProto.OCS6010U10frmARActingOCS2005Request, OcsiServiceProto.OCS6010U10frmARActingOCS2005Response> {

	@Resource
	private Ocs6010Repository ocs6010Repository;
	
	@Resource
	private Ocs2016Repository ocs2016Repository;
	
	@Override
	@Transactional(readOnly = true)
	public OCS6010U10frmARActingOCS2005Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10frmARActingOCS2005Request request) throws Exception {
		OcsiServiceProto.OCS6010U10frmARActingOCS2005Response.Builder response = OcsiServiceProto.OCS6010U10frmARActingOCS2005Response.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<OCS6010U10frmARActingOCS2005Info> infos = ocs6010Repository.getOCS6010U10frmARActingOCS2005Info(hospCode
				, CommonUtils.parseDouble(request.getFFkocs2005())
				, DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD));
		
		if(CollectionUtils.isEmpty(infos)){
			return response.build();
		}
		
		for (OCS6010U10frmARActingOCS2005Info info : infos) {
			OcsiModelProto.OCS6010U10frmARActingOCS2005Info.Builder pInfo = OcsiModelProto.OCS6010U10frmARActingOCS2005Info.newBuilder();
			BeanUtils.copyProperties(info, pInfo, language);
			response.addResList(pInfo);
		}
		
		// get sequence
		String seq = ocs2016Repository.getOCS6010U10frmARActingSeqOCS2016(hospCode, CommonUtils.parseDouble(request.getFkocs2015()));
		response.setSeq(seq == null ? "" : seq);
		
		return response.build();
	}

}
