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
import nta.med.data.dao.medi.nur.Nur0113Repository;
import nta.med.data.model.ihis.ocsi.OCS6010U10PopupTAgrdNUR0114Info;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupTAgrdNUR0114Request;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupTAgrdNUR0114Response;

@Service
@Scope("prototype")
public class OCS6010U10PopupTAgrdNUR0114Handler extends
		ScreenHandler<OcsiServiceProto.OCS6010U10PopupTAgrdNUR0114Request, OcsiServiceProto.OCS6010U10PopupTAgrdNUR0114Response> {
	@Resource
	private Nur0113Repository nur0113Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS6010U10PopupTAgrdNUR0114Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10PopupTAgrdNUR0114Request request) throws Exception {
		OcsiServiceProto.OCS6010U10PopupTAgrdNUR0114Response.Builder response = OcsiServiceProto.OCS6010U10PopupTAgrdNUR0114Response.newBuilder();
		List<OCS6010U10PopupTAgrdNUR0114Info> list = nur0113Repository.getOCS6010U10PopupTAgrdNUR0114Info(getHospitalCode(vertx, sessionId), request.getDirectGubun(), request.getDirectCode(), "Y");
		if (!CollectionUtils.isEmpty(list)) {
			for (OCS6010U10PopupTAgrdNUR0114Info item : list) {
				OcsiModelProto.OCS6010U10PopupTAgrdNUR0114Info.Builder info = OcsiModelProto.OCS6010U10PopupTAgrdNUR0114Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdMasterItem(info);
			}
		}
		return response.build();
	}

	
}
