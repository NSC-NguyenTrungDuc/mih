package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;
import nta.med.data.model.ihis.ocsi.OCS2003U03getJusaInfo;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.drg.Drg3010Repository;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003U03getJusaRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003U03getJusaResponse;

@Service
@Scope("prototype")
public class OCS2003U03getJusaHandler extends ScreenHandler<OcsiServiceProto.OCS2003U03getJusaRequest, OcsiServiceProto.OCS2003U03getJusaResponse>{
	@Resource
	private Drg3010Repository drg3010Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS2003U03getJusaResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003U03getJusaRequest request) throws Exception {
		OcsiServiceProto.OCS2003U03getJusaResponse.Builder response = OcsiServiceProto.OCS2003U03getJusaResponse.newBuilder();
		String controlName = request.getControlName();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		List<OCS2003U03getJusaInfo> list;
		if ("jusa_serial".equals(controlName)) {
			list = drg3010Repository.getOCS2003U03getJusaInfo(hospCode, language, request.getSerialText(), request.getJubsuDate(), request.getDrgBunho(), false);
		} else {
			list = drg3010Repository.getOCS2003U03getJusaInfoExt(hospCode, language, request.getSerialV(), request.getFkocs2003());
		}
		
		if (!CollectionUtils.isEmpty(list)) {
			for (OCS2003U03getJusaInfo item : list) {
				OcsiModelProto.OCS2003U03getJusaInfo.Builder info = OcsiModelProto.OCS2003U03getJusaInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
			}
		} 
		return response.build();
	}

}
