package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs2016Repository;
import nta.med.data.model.ihis.ocsi.OCS6010U10PopupILgrdOCS2016Info;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupILgrdOCS2016Request;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupILgrdOCS2016Response;

@Service
@Scope("prototype")
public class OCS6010U10PopupILgrdOCS2016Handler extends
		ScreenHandler<OcsiServiceProto.OCS6010U10PopupILgrdOCS2016Request, OcsiServiceProto.OCS6010U10PopupILgrdOCS2016Response> {

	@Resource
	private Ocs2016Repository ocs2016Repository;
	
	@Override
	public OCS6010U10PopupILgrdOCS2016Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10PopupILgrdOCS2016Request request) throws Exception {
		
		OcsiServiceProto.OCS6010U10PopupILgrdOCS2016Response.Builder response = OcsiServiceProto.OCS6010U10PopupILgrdOCS2016Response.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<OCS6010U10PopupILgrdOCS2016Info> infos = ocs2016Repository.getOCS6010U10PopupILgrdOCS2016Info(hospCode, request.getBunho(), request.getLimit7());
		if(CollectionUtils.isEmpty(infos)){
			return response.build();
		}
		
		for (OCS6010U10PopupILgrdOCS2016Info info : infos) {
			OcsiModelProto.OCS6010U10PopupILgrdOCS2016Info.Builder pInfo = OcsiModelProto.OCS6010U10PopupILgrdOCS2016Info.newBuilder();
			BeanUtils.copyProperties(info, pInfo, language);
			response.addGrdMasterItem(pInfo);
		}
		
		return response.build();
	}

}
