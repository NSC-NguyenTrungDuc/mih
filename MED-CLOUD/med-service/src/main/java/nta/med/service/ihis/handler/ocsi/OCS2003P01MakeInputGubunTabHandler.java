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
import nta.med.service.ihis.proto.OcsiModelProto.OCS6010U10LoadDetailDataInfo;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003P01MakeInputGubunTabRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

@Service
@Scope("prototype")
public class OCS2003P01MakeInputGubunTabHandler extends ScreenHandler<OcsiServiceProto.OCS2003P01MakeInputGubunTabRequest, SystemServiceProto.ComboResponse>{
	@Resource
	private Ocs0132Repository ocs0132Repository;
	
	@Override
	@Transactional(readOnly=true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003P01MakeInputGubunTabRequest request) throws Exception {
		SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();
		String fCase = request.getFCase();
		List<ComboListItemInfo> list;
		if ("1".equals(fCase)) 
			list = ocs0132Repository.getOCS2003P01MakeInputGubunTabRequest(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), "D%", "INPUT_GUBUN", true);
		else if ("2".equals(fCase))
			list = ocs0132Repository.getOCS2003P01MakeInputGubunTabRequest(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), "NR", "INPUT_GUBUN", false);
		else 
			list = ocs0132Repository.getOCS2003P01MakeInputGubunTabRequest(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getInputGubun(), "INPUT_GUBUN", false);
		
		if (!CollectionUtils.isEmpty(list)) {
			for (ComboListItemInfo item : list) {
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				info.setCode(item.getCode());
				info.setCodeName(item.getCodeName());
				response.addComboItem(info);
			}
		}
		
		return response.build();
	}

}
