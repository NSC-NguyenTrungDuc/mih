package nta.med.service.ihis.handler.adma;

import nta.med.core.glossary.UserRole;
import nta.med.data.dao.medi.adm.Adm0200Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.AdmaServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

@Service
@Scope("prototype")
public class ADM106UGetSysNameHandler extends ScreenHandler<AdmaServiceProto.ADM106UGetSysNameRequest, AdmaServiceProto.ADM106UGetSysNameResponse> {
    private static final Log LOGGER = LogFactory.getLog(ADM106UGetSysNameHandler.class);
    @Resource
    private Adm0200Repository adm0200Repository;
    @Override
    public boolean isAuthorized(Vertx vertx, String sessionId){

        return UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId));
    }
    @Override
    @Transactional(readOnly = true)
    public AdmaServiceProto.ADM106UGetSysNameResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.ADM106UGetSysNameRequest request) throws Exception {
        AdmaServiceProto.ADM106UGetSysNameResponse.Builder response = AdmaServiceProto.ADM106UGetSysNameResponse.newBuilder();
        String result = adm0200Repository.getAdm106UFbxSysIdItem(request.getSysId(), getLanguage(vertx, sessionId));
        if (!StringUtils.isEmpty(result)) {
            response.setSysNm(result);
        }
        return response.build();
    }
}