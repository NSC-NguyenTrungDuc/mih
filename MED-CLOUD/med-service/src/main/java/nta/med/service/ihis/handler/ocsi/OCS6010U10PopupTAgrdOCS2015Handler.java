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
import nta.med.data.dao.medi.ocs.Ocs2015Repository;
import nta.med.data.model.ihis.ocsi.OCS6010U10PopupTAgrdOCS2015Info;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupTAgrdOCS2015Request;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupTAgrdOCS2015Response;

@Service
@Scope("prototype")
public class OCS6010U10PopupTAgrdOCS2015Handler extends
		ScreenHandler<OcsiServiceProto.OCS6010U10PopupTAgrdOCS2015Request, OcsiServiceProto.OCS6010U10PopupTAgrdOCS2015Response> {
	@Resource
	private Ocs2015Repository ocs2015Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS6010U10PopupTAgrdOCS2015Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10PopupTAgrdOCS2015Request request) throws Exception {
		OcsiServiceProto.OCS6010U10PopupTAgrdOCS2015Response.Builder response = OcsiServiceProto.OCS6010U10PopupTAgrdOCS2015Response.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		String offset = request.getOffset();
        Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
        List<OCS6010U10PopupTAgrdOCS2015Info> list = ocs2015Repository.getOCS6010U10PopupTAgrdOCS2015Info(hospCode
        									, request.getBunho()
        									, request.getFkinp1001()
        									, request.getOrderDate()
        									, request.getInputGubun()
        									, request.getPkSeq()
        									, request.getActDate()
        									, startNum
        									, CommonUtils.parseInteger(offset));
        if (!CollectionUtils.isEmpty(list)) {
        	for (OCS6010U10PopupTAgrdOCS2015Info item : list) {
        		OcsiModelProto.OCS6010U10PopupTAgrdOCS2015Info.Builder info = OcsiModelProto.OCS6010U10PopupTAgrdOCS2015Info.newBuilder();
        		BeanUtils.copyProperties(item, info, language);
        		response.addGrdMasterItem(info);
			}
        }
		return response.build();
	}

	
}
