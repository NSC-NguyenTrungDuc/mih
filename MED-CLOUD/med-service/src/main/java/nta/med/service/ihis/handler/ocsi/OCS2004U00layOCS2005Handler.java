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
import nta.med.data.dao.medi.ocs.Ocs2005Repository;
import nta.med.data.model.ihis.ocsi.OCS2004U00layOCS2005Info;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2004U00layOCS2005Request;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2004U00layOCS2005Response;

@Service
@Scope("prototype")
public class OCS2004U00layOCS2005Handler extends ScreenHandler<OcsiServiceProto.OCS2004U00layOCS2005Request, OcsiServiceProto.OCS2004U00layOCS2005Response> {
	@Resource
	private Ocs2005Repository ocs2005Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS2004U00layOCS2005Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2004U00layOCS2005Request request) throws Exception {
		
		OcsiServiceProto.OCS2004U00layOCS2005Response.Builder response = OcsiServiceProto.OCS2004U00layOCS2005Response.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		String bunho = request.getBunho();
		String fkinp1001 = request.getFkinp1001();
		String orderDate = request.getOrderDate();
		
		List<OCS2004U00layOCS2005Info> listInfo = ocs2005Repository.getOCS2004U00layOCS2005(hospCode, language, bunho, fkinp1001, orderDate);
		if (!CollectionUtils.isEmpty(listInfo)) {
			for (OCS2004U00layOCS2005Info item : listInfo) {
				OcsiModelProto.OCS2004U00layOCS2005Info.Builder info = OcsiModelProto.OCS2004U00layOCS2005Info.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addLay2005(info);
			}
		}
			
		return response.build();
	}

}
