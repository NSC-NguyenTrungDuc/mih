package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U00getCodeNameRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U00getCodeNameResponse;

@Service
@Scope("prototype")
public class OCS2005U00getCodeNameHandler extends ScreenHandler<OcsiServiceProto.OCS2005U00getCodeNameRequest, OcsiServiceProto.OCS2005U00getCodeNameResponse>{
	@Resource
	private Ocs0132Repository ocs0132Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS2005U00getCodeNameResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2005U00getCodeNameRequest request) throws Exception {
		OcsiServiceProto.OCS2005U00getCodeNameResponse.Builder response = OcsiServiceProto.OCS2005U00getCodeNameResponse.newBuilder();
		List<ComboListItemInfo> list = ocs0132Repository.getOcsoOCS1003P01GetGubunInfo(getHospitalCode(vertx, sessionId), request.getCode(), "ORD_DANUI", getLanguage(vertx, sessionId));
		if (!CollectionUtils.isEmpty(list)) {
			for (ComboListItemInfo item : list) {
				CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
				info.setDataValue(item.getCodeName());
				response.addCodeName(info);
			}
		}
		return response.build();
	}

}
