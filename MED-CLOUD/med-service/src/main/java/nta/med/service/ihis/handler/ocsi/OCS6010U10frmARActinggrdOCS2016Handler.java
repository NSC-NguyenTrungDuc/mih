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
import nta.med.data.dao.medi.ocs.Ocs6010Repository;
import nta.med.data.model.ihis.ocsi.OCS6010U10frmARActinggrdOCS2016Info;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10frmARActinggrdOCS2016Request;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10frmARActinggrdOCS2016Response;

@Service
@Scope("prototype")
public class OCS6010U10frmARActinggrdOCS2016Handler extends
		ScreenHandler<OcsiServiceProto.OCS6010U10frmARActinggrdOCS2016Request, OcsiServiceProto.OCS6010U10frmARActinggrdOCS2016Response> {

	@Resource
	private Ocs6010Repository ocs6010Repository;
	
	@Override
	@Transactional(readOnly = true)
	public OCS6010U10frmARActinggrdOCS2016Response handle(Vertx vertx, String clientId, String sessionId,
			long contextId, OCS6010U10frmARActinggrdOCS2016Request request) throws Exception {
		OcsiServiceProto.OCS6010U10frmARActinggrdOCS2016Response.Builder response = OcsiServiceProto.OCS6010U10frmARActinggrdOCS2016Response.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<OCS6010U10frmARActinggrdOCS2016Info> infos = ocs6010Repository.getOCS6010U10frmARActinggrdOCS2016Info(hospCode, CommonUtils.parseDouble(request.getFkocs2015()));
		if(CollectionUtils.isEmpty(infos)){
			return response.build();
		}
		
		for (OCS6010U10frmARActinggrdOCS2016Info info : infos) {
			OcsiModelProto.OCS6010U10frmARActinggrdOCS2016Info.Builder pInfo = OcsiModelProto.OCS6010U10frmARActinggrdOCS2016Info.newBuilder();
			BeanUtils.copyProperties(info, pInfo, language);
			response.addItems(pInfo);
		}
		
		return response.build();
	}

}
