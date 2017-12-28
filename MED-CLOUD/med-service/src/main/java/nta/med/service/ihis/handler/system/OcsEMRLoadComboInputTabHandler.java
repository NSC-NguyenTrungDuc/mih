package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.OcsEMRLoadComboInputTabRequest;
import nta.med.service.ihis.proto.SystemServiceProto.OcsEMRLoadComboInputTabResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class OcsEMRLoadComboInputTabHandler extends ScreenHandler<SystemServiceProto.OcsEMRLoadComboInputTabRequest, SystemServiceProto.OcsEMRLoadComboInputTabResponse> {
	private static final Log LOGGER = LogFactory.getLog(OcsEMRLoadComboInputTabHandler.class);
	@Resource
	private Ocs0132Repository ocs0132Repository;
	
	@Override
	@Transactional(readOnly = true)
	public OcsEMRLoadComboInputTabResponse handle(Vertx vertx, String clientId,
		String sessionId, long contextId, OcsEMRLoadComboInputTabRequest request)
		throws Exception {
		SystemServiceProto.OcsEMRLoadComboInputTabResponse.Builder response = SystemServiceProto.OcsEMRLoadComboInputTabResponse.newBuilder();
		String hospitalCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		List<ComboListItemInfo> listInfo = ocs0132Repository.getOcsoOCS1003P01GetGubunInfo(hospitalCode,  "%", "INPUT_TAB", language);
		if (!CollectionUtils.isEmpty(listInfo)) {
			for (ComboListItemInfo info : listInfo) {
				CommonModelProto.ComboListItemInfo.Builder builder = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(info, builder, getLanguage(vertx, sessionId));
	            response.addCboItem(builder);
			}
		}
		return response.build();
	}
}

