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
import nta.med.data.model.ihis.ocsi.OCS6010U10frmARActinggrdOCS2015Info;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10frmARActinggrdOCS2015Request;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10frmARActinggrdOCS2015Response;

@Service
@Scope("prototype")
public class OCS6010U10frmARActinggrdOCS2015Handler extends
		ScreenHandler<OcsiServiceProto.OCS6010U10frmARActinggrdOCS2015Request, OcsiServiceProto.OCS6010U10frmARActinggrdOCS2015Response> {

	@Resource
	private Ocs6010Repository ocs6010Repository;
	
	@Override
	@Transactional(readOnly = true)
	public OCS6010U10frmARActinggrdOCS2015Response handle(Vertx vertx, String clientId, String sessionId,
			long contextId, OCS6010U10frmARActinggrdOCS2015Request request) throws Exception {
		
		OcsiServiceProto.OCS6010U10frmARActinggrdOCS2015Response.Builder response = OcsiServiceProto.OCS6010U10frmARActinggrdOCS2015Response.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<OCS6010U10frmARActinggrdOCS2015Info> infos = ocs6010Repository.getOCS6010U10frmARActinggrdOCS2015Info(hospCode
				, request.getBunho()
				, CommonUtils.parseDouble(request.getFkinp1001())
				, CommonUtils.parseDouble(request.getFkocs2005())
				, request.getLimit7()
				, request.getKijunDate());
		
		if(CollectionUtils.isEmpty(infos)){
			return response.build();
		}
		
		for (OCS6010U10frmARActinggrdOCS2015Info info : infos) {
			OcsiModelProto.OCS6010U10frmARActinggrdOCS2015Info.Builder pInfo = OcsiModelProto.OCS6010U10frmARActinggrdOCS2015Info.newBuilder();
			BeanUtils.copyProperties(info, pInfo, language);
			response.addItems(pInfo);
		}
		
		return response.build();
	}

}
