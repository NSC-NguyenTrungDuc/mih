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
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003U99cboReRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

@Service
@Scope("prototype")
public class OCS2003U99cboReHandler extends ScreenHandler<OcsiServiceProto.OCS2003U99cboReRequest, SystemServiceProto.ComboResponse>{
	@Resource
	private Bas0102Repository bas0102Repository;
	
	@Override
	@Transactional(readOnly=true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003U99cboReRequest request) throws Exception {
		SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();
		List<ComboListItemInfo> list = bas0102Repository.getCodeCodeNameListItemInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), "RESULT");
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