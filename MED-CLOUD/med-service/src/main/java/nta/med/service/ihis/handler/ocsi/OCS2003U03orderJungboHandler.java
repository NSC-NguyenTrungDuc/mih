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
import nta.med.data.model.ihis.ocsi.OCS2003U03orderJungboInfo;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003U03orderJungboRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003U03orderJungboResponse;

@Service
@Scope("prototype")
public class OCS2003U03orderJungboHandler extends ScreenHandler<OcsiServiceProto.OCS2003U03orderJungboRequest, OcsiServiceProto.OCS2003U03orderJungboResponse>{
	@Resource
	private Drg3010Repository drg3010Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS2003U03orderJungboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003U03orderJungboRequest request) throws Exception {
		OcsiServiceProto.OCS2003U03orderJungboResponse.Builder response = OcsiServiceProto.OCS2003U03orderJungboResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		List<OCS2003U03orderJungboInfo> list = drg3010Repository.getOCS2003U03orderJungboInfo(hospCode, language, request.getJubsuDate(), request.getDrgBunho());
		if (!CollectionUtils.isEmpty(list)) {
			for (OCS2003U03orderJungboInfo item : list) {
				OcsiModelProto.OCS2003U03orderJungboInfo.Builder info = OcsiModelProto.OCS2003U03orderJungboInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addListOrderjungbo(info);
			}
		}
		
		return response.build();
	}

}
