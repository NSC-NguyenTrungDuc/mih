package nta.med.service.ihis.handler.adma;

import javax.annotation.Resource;

import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.common.annotation.Route;
import nta.med.core.glossary.UserRole;
import nta.med.data.dao.medi.adm.Adm0100Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.AdmaServiceProto;

@Service                                                                                                          
@Scope("prototype")
public class ADM101UGetGrpNmHandler extends ScreenHandler<AdmaServiceProto.ADM101UGetGrpNmRequest, AdmaServiceProto.ADM101UGetGrpNmResponse> {

	private static final Log LOGGER = LogFactory.getLog(ADM101UGetGrpNmHandler.class);
	
	@Resource                                                                                                       
	private Adm0100Repository adm0100Repository;
	
	@Override
	public boolean isAuthorized(Vertx vertx, String sessionId){

		return UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId));
	}
	
	@Override
	@Transactional(readOnly = true)
	@Route(global = true)
	public AdmaServiceProto.ADM101UGetGrpNmResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.ADM101UGetGrpNmRequest request) throws Exception{
		AdmaServiceProto.ADM101UGetGrpNmResponse.Builder response = AdmaServiceProto.ADM101UGetGrpNmResponse.newBuilder();
		String result = adm0100Repository.getADM101UGrpNmButton1(getLanguage(vertx, sessionId));
		if(!StringUtils.isEmpty(result)){
			response.setGrpNm(result);
		}
		
		return response.build();
	}
}
