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
import nta.med.data.dao.medi.drg.Drg3010Repository;
import nta.med.data.model.ihis.ocsi.OCS2003U03getJusaInfo;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003U03getRemarkRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003U03getRemarkResponse;

@Service
@Scope("prototype")
public class OCS2003U03getRemarkHandler extends ScreenHandler<OcsiServiceProto.OCS2003U03getRemarkRequest, OcsiServiceProto.OCS2003U03getRemarkResponse>{
	@Resource
	private Drg3010Repository drg3010Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS2003U03getRemarkResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003U03getRemarkRequest request) throws Exception {
		OcsiServiceProto.OCS2003U03getRemarkResponse.Builder response = OcsiServiceProto.OCS2003U03getRemarkResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		List<OCS2003U03getJusaInfo> list = drg3010Repository.getOCS2003U03getJusaInfo(hospCode, language, request.getSerialText(), request.getJubsuDate(), request.getDrgBunho(), true);
		if (!CollectionUtils.isEmpty(list)) {
			for (OCS2003U03getJusaInfo item : list) {
				OcsiModelProto.OCS2003U03getRemarkInfo.Builder info = OcsiModelProto.OCS2003U03getRemarkInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				info.setDataGubun("B");
			}
		}
		return response.build();
	}

}
