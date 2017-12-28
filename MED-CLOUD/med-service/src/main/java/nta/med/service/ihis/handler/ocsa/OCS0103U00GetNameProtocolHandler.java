package nta.med.service.ihis.handler.ocsa;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.data.dao.medi.clis.ClisProtocolRepository;
import nta.med.data.model.ihis.clis.CLIS2015U03ProtocolListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U00GetNameProtocolRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U00GetNameProtocolResponse;

@Service
@Scope("prototype")
public class OCS0103U00GetNameProtocolHandler extends ScreenHandler<OCS0103U00GetNameProtocolRequest, OCS0103U00GetNameProtocolResponse>{

	@Resource
	private ClisProtocolRepository clisProtocolRepository;
	
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, OCS0103U00GetNameProtocolRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override
	@Transactional(readOnly = true)
	public OCS0103U00GetNameProtocolResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0103U00GetNameProtocolRequest request) throws Exception {
		OCS0103U00GetNameProtocolResponse.Builder response = OCS0103U00GetNameProtocolResponse.newBuilder();
		CLIS2015U03ProtocolListInfo result = clisProtocolRepository.getOCS0103U00GetNameProtocolInfo(request.getHospCode(), request.getProtocolCode());
		if(result != null){
			if(!StringUtils.isEmpty(result.getProtocolName())){
				response.setProtocolName(result.getProtocolName());
			}
		}
		return response.build();
	}

}
