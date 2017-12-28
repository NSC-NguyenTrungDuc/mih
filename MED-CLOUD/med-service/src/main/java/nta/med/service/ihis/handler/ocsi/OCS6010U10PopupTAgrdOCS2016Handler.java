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
import nta.med.data.dao.medi.ocs.Ocs2016Repository;
import nta.med.data.model.ihis.ocsi.OCS6010U10PopupTAgrdOCS2016Info;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupTAgrdOCS2016Request;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupTAgrdOCS2016Response;

@Service
@Scope("prototype")
public class OCS6010U10PopupTAgrdOCS2016Handler extends
		ScreenHandler<OcsiServiceProto.OCS6010U10PopupTAgrdOCS2016Request, OcsiServiceProto.OCS6010U10PopupTAgrdOCS2016Response> {
	@Resource
	private Ocs2016Repository ocs2016Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS6010U10PopupTAgrdOCS2016Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10PopupTAgrdOCS2016Request request) throws Exception {
		OcsiServiceProto.OCS6010U10PopupTAgrdOCS2016Response.Builder response = OcsiServiceProto.OCS6010U10PopupTAgrdOCS2016Response.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		String offset = request.getOffset();
        Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
		List<OCS6010U10PopupTAgrdOCS2016Info> list = ocs2016Repository.getOCS6010U10PopupTAgrdOCS2016Info(hospCode, request.getFkocs2015(), startNum, CommonUtils.parseInteger(offset));
		if (!CollectionUtils.isEmpty(list)) {
			for (OCS6010U10PopupTAgrdOCS2016Info item : list) {
				OcsiModelProto.OCS6010U10PopupTAgrdOCS2016Info.Builder info = OcsiModelProto.OCS6010U10PopupTAgrdOCS2016Info.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addGrdMasterItem(info);
			}
		}
		return response.build();
	}
	
}	
