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
import nta.med.data.dao.medi.ocs.Ocs2015Repository;
import nta.med.data.model.ihis.ocsi.OCS6010U10PopupIAgrdOCS2015Info;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupIAgrdOCS2015Request;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupIAgrdOCS2015Response;

@Service
@Scope("prototype")
public class OCS6010U10PopupIAgrdOCS2015Handler extends
		ScreenHandler<OcsiServiceProto.OCS6010U10PopupIAgrdOCS2015Request, OcsiServiceProto.OCS6010U10PopupIAgrdOCS2015Response> {

	@Resource
	private Ocs2015Repository ocs2015Repository;

	@Override
	@Transactional(readOnly=true)
	public OCS6010U10PopupIAgrdOCS2015Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10PopupIAgrdOCS2015Request request) throws Exception {
		
		OcsiServiceProto.OCS6010U10PopupIAgrdOCS2015Response.Builder response = OcsiServiceProto.OCS6010U10PopupIAgrdOCS2015Response.newBuilder();
		String hospCode = request.getHospCode();
		
		String bunho = request.getBunho();
		String fkinp1001 = request.getFkinp1001();
		String orderDate = request.getOrderDate();
		String inputGubun = request.getInputGubun();
		String pkSeq = request.getPkSeq();
		String actDate = request.getActDate();
		String offset = request.getOffset();
		String pageNumber = request.getPageNumber();
		
		List<OCS6010U10PopupIAgrdOCS2015Info> listInfo = ocs2015Repository.getOCS6010U10PopupIAgrdOCS2015(hospCode, bunho, fkinp1001, orderDate, inputGubun, pkSeq, actDate, offset, pageNumber);
		
		if (!CollectionUtils.isEmpty(listInfo)) {
			for (OCS6010U10PopupIAgrdOCS2015Info item : listInfo) {
				OcsiModelProto.OCS6010U10PopupIAgrdOCS2015Info.Builder info = OcsiModelProto.OCS6010U10PopupIAgrdOCS2015Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdMasterItem(info);
			}
		}
		return response.build();
	}

}
