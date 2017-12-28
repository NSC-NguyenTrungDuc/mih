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
import nta.med.data.dao.medi.ocs.Ocs2006Repository;
import nta.med.data.model.ihis.ocsi.OCS6010U10PopupTAgrdOCS2006Info;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupTAgrdOCS2006Request;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupTAgrdOCS2006Response;

@Service
@Scope("prototype")
public class OCS6010U10PopupTAgrdOCS2006Handler extends ScreenHandler<OcsiServiceProto.OCS6010U10PopupTAgrdOCS2006Request, OcsiServiceProto.OCS6010U10PopupTAgrdOCS2006Response>{
	@Resource
	private Ocs2006Repository ocs2006Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS6010U10PopupTAgrdOCS2006Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10PopupTAgrdOCS2006Request request) throws Exception {
		OcsiServiceProto.OCS6010U10PopupTAgrdOCS2006Response.Builder respose = OcsiServiceProto.OCS6010U10PopupTAgrdOCS2006Response.newBuilder();
		List<OCS6010U10PopupTAgrdOCS2006Info> list = ocs2006Repository.getOCS6010U10PopupTAgrdOCS2006Info(getHospitalCode(vertx, sessionId), request.getOrderDate(), request.getFkocs2005(), request.getPkSeq());
		if (!CollectionUtils.isEmpty(list)) {
			for (OCS6010U10PopupTAgrdOCS2006Info item : list) {
				OcsiModelProto.OCS6010U10PopupTAgrdOCS2006Info.Builder info = OcsiModelProto.OCS6010U10PopupTAgrdOCS2006Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				respose.addGrdMasterItem(info);
			}
		}
		return respose.build();
	}

}
