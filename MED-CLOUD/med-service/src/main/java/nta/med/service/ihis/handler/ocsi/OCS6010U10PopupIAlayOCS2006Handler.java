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
import nta.med.data.model.ihis.ocsi.OCS6010U10PopupIAlayOCS2006Info;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupIAlayOCS2006Request;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupIAlayOCS2006Response;

@Service
@Scope("prototype")
public class OCS6010U10PopupIAlayOCS2006Handler extends ScreenHandler<OcsiServiceProto.OCS6010U10PopupIAlayOCS2006Request, OcsiServiceProto.OCS6010U10PopupIAlayOCS2006Response> {
	@Resource
	private Ocs2005Repository ocs2005Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS6010U10PopupIAlayOCS2006Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10PopupIAlayOCS2006Request request) throws Exception {
		
		OcsiServiceProto.OCS6010U10PopupIAlayOCS2006Response.Builder response = OcsiServiceProto.OCS6010U10PopupIAlayOCS2006Response.newBuilder();
		String hospCode = request.getHospCode();
		String language = getLanguage(vertx, sessionId);
		
		String pkocs2005 = request.getPkocs2005();
		
        List<OCS6010U10PopupIAlayOCS2006Info> listInfo = ocs2005Repository.getOCS6010U10PopupIAlayOCS2006(hospCode, pkocs2005);
		if (!CollectionUtils.isEmpty(listInfo)) {
			for (OCS6010U10PopupIAlayOCS2006Info item : listInfo) {
				OcsiModelProto.OCS6010U10PopupIAlayOCS2006Info.Builder info = OcsiModelProto.OCS6010U10PopupIAlayOCS2006Info.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addLayItem(info);
			}
		}
        return response.build();
	}

}
