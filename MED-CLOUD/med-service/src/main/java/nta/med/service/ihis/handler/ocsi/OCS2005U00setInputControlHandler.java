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
import nta.med.data.dao.medi.ocs.Ocs0133Repository;
import nta.med.data.model.ihis.ocsi.OCS2005U00setInputControlInfo;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U00setInputControlRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U00setInputControlResponse;

@Service
@Scope("prototype")
public class OCS2005U00setInputControlHandler extends ScreenHandler<OcsiServiceProto.OCS2005U00setInputControlRequest, OcsiServiceProto.OCS2005U00setInputControlResponse>{
	@Resource
	private Ocs0133Repository ocs0133Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS2005U00setInputControlResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2005U00setInputControlRequest request) throws Exception {
		OcsiServiceProto.OCS2005U00setInputControlResponse.Builder response = OcsiServiceProto.OCS2005U00setInputControlResponse.newBuilder();
		List<OCS2005U00setInputControlInfo> list = ocs0133Repository.getOCS2005U00setInputControlInfo(getHospitalCode(vertx, sessionId), request.getInputControl());
		if (!CollectionUtils.isEmpty(list)) {
			for (OCS2005U00setInputControlInfo item : list) {
				OcsiModelProto.OCS2005U00setInputControlInfo.Builder info = OcsiModelProto.OCS2005U00setInputControlInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addListInput(info);
			}
		}
		return response.build();
	}

}
