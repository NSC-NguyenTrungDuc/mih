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
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U00layComboRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

@Service
@Scope("prototype")
public class OCS2005U00layComboHandler extends ScreenHandler<OcsiServiceProto.OCS2005U00layComboRequest, SystemServiceProto.ComboResponse>{
	@Resource
	private Ocs0132Repository ocs0132Repository;
	
	@Override
	@Transactional(readOnly=true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2005U00layComboRequest request) throws Exception {
		SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();
		List<ComboListItemInfo> list ;
		if ("dv_time".equals(request.getCodeType())) 
			list = ocs0132Repository.getOCS0132ComboList(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), "DV_TIME");
		else 
			list = ocs0132Repository.getOCS0132ComboList(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), "JUSA_SPD_GUBUN");
		if (!CollectionUtils.isEmpty(list)) {
			for (ComboListItemInfo item : list) {
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addComboItem(info);
			}
		}
		return response.build();
	}

}
