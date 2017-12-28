package nta.med.service.ihis.handler.adma;

import javax.annotation.Resource;

import nta.med.core.common.annotation.Route;
import nta.med.core.glossary.UserRole;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.AdmaServiceProto;
import nta.med.service.ihis.proto.AdmaServiceProto.Adm107UFbxHospCodeDataValidatingRequest;
import nta.med.service.ihis.proto.AdmaServiceProto.Adm107UFbxHospCodeDataValidatingResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class Adm107UFbxHospCodeDataValidatingHandler extends
		ScreenHandler<AdmaServiceProto.Adm107UFbxHospCodeDataValidatingRequest, AdmaServiceProto.Adm107UFbxHospCodeDataValidatingResponse> {

	private static final Log LOGGER = LogFactory.getLog(Adm107UFbxHospCodeDataValidatingHandler.class);

	@Resource
	private Bas0001Repository bas0001Repository;

	@Override
	@Transactional(readOnly = true)
	@Route(global = true)
	public Adm107UFbxHospCodeDataValidatingResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, Adm107UFbxHospCodeDataValidatingRequest request) throws Exception {
		AdmaServiceProto.Adm107UFbxHospCodeDataValidatingResponse.Builder response = AdmaServiceProto.Adm107UFbxHospCodeDataValidatingResponse.newBuilder();

		String language = "";
		if (!UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			language = getLanguage(vertx, sessionId);
		}
		
		String yoyangName = bas0001Repository.getBas0001YoYangName(request.getHospCode(), language);
		if (!StringUtils.isEmpty(yoyangName)) {
			response.setYoyangName(yoyangName);
		}
		
		return response.build();
	}
}