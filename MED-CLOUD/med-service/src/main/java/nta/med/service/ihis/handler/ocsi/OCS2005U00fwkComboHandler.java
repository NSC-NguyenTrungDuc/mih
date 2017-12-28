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
import nta.med.data.dao.medi.drg.Drg0120Repository;
import nta.med.data.dao.medi.ocs.Ocs0108Repository;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U00fwkComboRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

@Service
@Scope("prototype")
public class OCS2005U00fwkComboHandler extends ScreenHandler<OcsiServiceProto.OCS2005U00fwkComboRequest, SystemServiceProto.ComboResponse>{
	@Resource
	private Ocs0108Repository ocs0108Repository;
	@Resource
	private Drg0120Repository drg0120Repository;
	@Resource
	private Ocs0132Repository ocs0132Repository;
	
	@Override
	@Transactional(readOnly=true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2005U00fwkComboRequest request) throws Exception {
		SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();
		List<ComboListItemInfo> list;
		String nameControl = request.getNameControl();
		String hospCode =  getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		if ("ord_danui_name".equals(nameControl)) 
			list = ocs0108Repository.getGetDefaultOrdDanuiInfo(hospCode, language, request.getHangmogCode());
		else if ("bogyong_code".equals(nameControl))
			list = drg0120Repository.getOCS2005U00fwkCombo(hospCode, request.getFind());
		else
			list = ocs0132Repository.getOCS2005U00fwkCombo(hospCode, language, "JUSA", request.getFind());
		
		if (!CollectionUtils.isEmpty(list)) {
			for (ComboListItemInfo item : list) {
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addComboItem(info);
			}
		}
		return response.build();
	}

}
