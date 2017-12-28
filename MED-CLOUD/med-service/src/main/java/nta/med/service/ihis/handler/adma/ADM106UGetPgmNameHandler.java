package nta.med.service.ihis.handler.adma;

import nta.med.core.glossary.UserRole;
import nta.med.data.dao.medi.adm.Adm0300Repository;
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
public class ADM106UGetPgmNameHandler extends ScreenHandler<AdmaServiceProto.ADM106UGetPgmNameRequest, AdmaServiceProto.ADM106UGetPgmNameResponse> {
    private static final Log LOGGER = LogFactory.getLog(ADM106UGetPgmNameHandler.class);
    @Resource
    private Adm0300Repository adm0300Repository;
    @Override
    public boolean isAuthorized(Vertx vertx, String sessionId){

        return UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId));
    }
    @Override
    @Transactional(readOnly = true)
    public AdmaServiceProto.ADM106UGetPgmNameResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.ADM106UGetPgmNameRequest request) throws Exception {
        AdmaServiceProto.ADM106UGetPgmNameResponse.Builder response = AdmaServiceProto.ADM106UGetPgmNameResponse.newBuilder();
        String result = adm0300Repository.getAdm106UGrdMenuListItem(request.getPgmId(), getLanguage(vertx, sessionId));
        if (!StringUtils.isEmpty(result)) {
            response.setPgmNm(result);
        }
        return response.build();
    }
}