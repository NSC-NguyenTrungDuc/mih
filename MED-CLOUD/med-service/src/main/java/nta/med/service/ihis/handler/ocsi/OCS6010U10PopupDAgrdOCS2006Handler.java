package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs2006Repository;
import nta.med.data.model.ihis.ocsi.OCS6010U10PopupDAgrdOCS2006Info;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupDAgrdOCS2006Request;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupDAgrdOCS2006Response;

@Service
@Scope("prototype")
public class OCS6010U10PopupDAgrdOCS2006Handler extends
		ScreenHandler<OcsiServiceProto.OCS6010U10PopupDAgrdOCS2006Request, OcsiServiceProto.OCS6010U10PopupDAgrdOCS2006Response> {

	@Resource
	private Ocs2006Repository ocs2006Repository;
	
	@Override
	public OCS6010U10PopupDAgrdOCS2006Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10PopupDAgrdOCS2006Request request) throws Exception {
		
		OcsiServiceProto.OCS6010U10PopupDAgrdOCS2006Response.Builder response = OcsiServiceProto.OCS6010U10PopupDAgrdOCS2006Response.newBuilder();
		String hospCode = request.getHospCode();
		String language = getLanguage(vertx, sessionId);
		
		String fkocs2005 = request.getFkocs2005();
		String orderDate = request.getOrderDate();
		String pkSeq = request.getPkSeq();
		
		List<OCS6010U10PopupDAgrdOCS2006Info> listInfo = ocs2006Repository.getOCS6010U10PopupDAgrdOCS2006(hospCode, fkocs2005, orderDate, pkSeq);
		
		if(CollectionUtils.isEmpty(listInfo)){
			return response.build();
		}
		
		for (OCS6010U10PopupDAgrdOCS2006Info item : listInfo) {
			OcsiModelProto.OCS6010U10PopupDAgrdOCS2006Info.Builder info = OcsiModelProto.OCS6010U10PopupDAgrdOCS2006Info.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			response.addGrdMasterItem(info);
		}
		
		return response.build();
	}

}
