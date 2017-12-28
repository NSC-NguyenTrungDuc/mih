package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs2005Repository;
import nta.med.data.model.ihis.ocsi.OCS2004U00layOCS2006Info;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2004U00layOCS2006Request;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2004U00layOCS2006Response;

@Service
@Scope("prototype")
public class OCS2004U00layOCS2006Handler extends ScreenHandler<OcsiServiceProto.OCS2004U00layOCS2006Request, OcsiServiceProto.OCS2004U00layOCS2006Response> {
	@Resource
	private Ocs2005Repository ocs2005Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS2004U00layOCS2006Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2004U00layOCS2006Request request) throws Exception {
		
		OcsiServiceProto.OCS2004U00layOCS2006Response.Builder response = OcsiServiceProto.OCS2004U00layOCS2006Response.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		String bunho = request.getBunho();
		String fkinp1001 = request.getFkinp1001();
		String orderDate = request.getOrderDate();
		String pkSeq = request.getPkSeq();
		
		List<OCS2004U00layOCS2006Info> listInfo = ocs2005Repository.getOCS2004U00layOCS2006(hospCode, bunho, fkinp1001, orderDate, pkSeq);
		if (!CollectionUtils.isEmpty(listInfo)) {
			for (OCS2004U00layOCS2006Info item : listInfo) {
				OcsiModelProto.OCS2004U00layOCS2006Info.Builder info = OcsiModelProto.OCS2004U00layOCS2006Info.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addLay2006(info);
			}
		}

		return response.build();
	}

}
