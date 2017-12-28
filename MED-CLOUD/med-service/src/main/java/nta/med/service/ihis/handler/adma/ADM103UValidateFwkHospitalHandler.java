package nta.med.service.ihis.handler.adma;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.annotation.Route;
import nta.med.core.glossary.UserRole;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.AdmaServiceProto;

@Service
@Scope("prototype")
public class ADM103UValidateFwkHospitalHandler extends
		ScreenHandler<AdmaServiceProto.ADM103UValidateFwkHospitalRequest, AdmaServiceProto.ADM103UValidateFwkHospitalResponse> {

	private static final Log LOGGER = LogFactory.getLog(ADM103UValidateFwkHospitalHandler.class);

	@Resource
	private Bas0001Repository bas0001Repository;

	@Override
	@Transactional(readOnly = true)
	@Route(global = true)
	public AdmaServiceProto.ADM103UValidateFwkHospitalResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, AdmaServiceProto.ADM103UValidateFwkHospitalRequest request) throws Exception {
		
		AdmaServiceProto.ADM103UValidateFwkHospitalResponse.Builder response = AdmaServiceProto.ADM103UValidateFwkHospitalResponse.newBuilder();
		
		String language = "";
		
		if (!UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			language = getLanguage(vertx, sessionId);
		}
		
		List<ComboListItemInfo> list = bas0001Repository.getAdm103UHospitalInfo(request.getHospCode(), language);
		if (!CollectionUtils.isEmpty(list)) {
			if (!StringUtils.isEmpty(list.get(0).getCodeName())) {
				response.setHospName(list.get(0).getCodeName());
			}
		}
		
		return response.build();
	}
}