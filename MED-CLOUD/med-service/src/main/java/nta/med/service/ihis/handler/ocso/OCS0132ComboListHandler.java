package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class OCS0132ComboListHandler extends ScreenHandler<OcsoServiceProto.OCS0132ComboListRequest, SystemServiceProto.ComboListByCodeTypeResponse> {
	private static final Log LOGGER = LogFactory.getLog(OCS0132ComboListHandler.class);

	@Resource
	private Ocs0132Repository ocs0132Repository;
	
	@Override
	@Transactional(readOnly = true)
	public SystemServiceProto.ComboListByCodeTypeResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OCS0132ComboListRequest request) throws Exception {
		SystemServiceProto.ComboListByCodeTypeResponse.Builder response = SystemServiceProto.ComboListByCodeTypeResponse.newBuilder();
		List<ComboListItemInfo> listObject = ocs0132Repository.getOCS0132ComboList(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getCodeType());
		if (listObject != null && !listObject.isEmpty()) {
			for (ComboListItemInfo obj : listObject) {
				CommonModelProto.ComboListItemInfo.Builder itemBuilder =  CommonModelProto.ComboListItemInfo.newBuilder();
				if (!StringUtils.isEmpty(obj.getCode())) {
					itemBuilder.setCode(obj.getCode());
				}
				if (!StringUtils.isEmpty(obj.getCodeName())) {
					itemBuilder.setCodeName(obj.getCodeName());
				}
				response.addComboListItem(itemBuilder);
			}
		}
		return response.build();
	}
}
