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
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.data.model.ihis.ocsi.OCS6010U10OrderInfoCaseOcsInfo;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10OrderInfoCaseOcsRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10OrderInfoCaseOcsResponse;

@Service
@Scope("prototype")
public class OCS6010U10OrderInfoCaseOcsHandler extends
		ScreenHandler<OcsiServiceProto.OCS6010U10OrderInfoCaseOcsRequest, OcsiServiceProto.OCS6010U10OrderInfoCaseOcsResponse> {
	@Resource
	private Ocs2003Repository ocs2003Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS6010U10OrderInfoCaseOcsResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10OrderInfoCaseOcsRequest request) throws Exception {
		OcsiServiceProto.OCS6010U10OrderInfoCaseOcsResponse.Builder response = OcsiServiceProto.OCS6010U10OrderInfoCaseOcsResponse.newBuilder();
		List<OCS6010U10OrderInfoCaseOcsInfo> list = ocs2003Repository.getOCS6010U10OrderInfoCaseOcsInfo(getHospitalCode(vertx, sessionId), request.getPk());
		if (!CollectionUtils.isEmpty(list)) {
			for (OCS6010U10OrderInfoCaseOcsInfo item : list) {
				OcsiModelProto.OCS6010U10OrderInfoCaseOcsInfo.Builder info = OcsiModelProto.OCS6010U10OrderInfoCaseOcsInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addResList(info);
			}
		}
		return response.build();
	}

}
