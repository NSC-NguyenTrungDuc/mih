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
import nta.med.data.dao.medi.ocs.Ocs2015Repository;
import nta.med.data.model.ihis.ocsi.OCS6010U10OrderInfoCaseDfltInfo;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10OrderInfoCaseDfltRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10OrderInfoCaseDfltResponse;

@Service
@Scope("prototype")
public class OCS6010U10OrderInfoCaseDfltHandler extends
		ScreenHandler<OcsiServiceProto.OCS6010U10OrderInfoCaseDfltRequest, OcsiServiceProto.OCS6010U10OrderInfoCaseDfltResponse> {
	@Resource
	private Ocs2015Repository ocs2015Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS6010U10OrderInfoCaseDfltResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10OrderInfoCaseDfltRequest request) throws Exception {
		OcsiServiceProto.OCS6010U10OrderInfoCaseDfltResponse.Builder response = OcsiServiceProto.OCS6010U10OrderInfoCaseDfltResponse.newBuilder();
		List<OCS6010U10OrderInfoCaseDfltInfo> list = ocs2015Repository.getOCS6010U10OrderInfoCaseDfltInfo(getHospitalCode(vertx, sessionId), request.getBunho(), request.getFkinp1001(), request.getInputGubun(), request.getPkSeq(), request.getActDate());
		if (!CollectionUtils.isEmpty(list)) {
			for (OCS6010U10OrderInfoCaseDfltInfo item : list) {
				OcsiModelProto.OCS6010U10OrderInfoCaseDfltInfo.Builder info = OcsiModelProto.OCS6010U10OrderInfoCaseDfltInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addResList(info);
			}
		}
		return response.build();
	}

}