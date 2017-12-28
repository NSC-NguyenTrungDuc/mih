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
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.model.ihis.ocsi.OCS6010U10LoadIpwonLstInfo;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10LoadIpwonLstRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10LoadIpwonLstResponse;

@Service
@Scope("prototype")
public class OCS6010U10LoadIpwonLstHandler extends
		ScreenHandler<OcsiServiceProto.OCS6010U10LoadIpwonLstRequest, OcsiServiceProto.OCS6010U10LoadIpwonLstResponse> {
	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Override
	@Transactional(readOnly = true)
	public OCS6010U10LoadIpwonLstResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10LoadIpwonLstRequest request) throws Exception {
		OcsiServiceProto.OCS6010U10LoadIpwonLstResponse.Builder response = OcsiServiceProto.OCS6010U10LoadIpwonLstResponse.newBuilder();
		List<OCS6010U10LoadIpwonLstInfo> list = inp1001Repository.getOCS6010U10LoadIpwonLstInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getBunho());
		if (!CollectionUtils.isEmpty(list)) {
			for (OCS6010U10LoadIpwonLstInfo item : list) {
				OcsiModelProto.OCS6010U10LoadIpwonLstInfo.Builder info = OcsiModelProto.OCS6010U10LoadIpwonLstInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addLayList(info);
			}
		}
		return response.build();
	}

}
