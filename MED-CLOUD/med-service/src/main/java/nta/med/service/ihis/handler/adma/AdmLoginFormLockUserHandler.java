package nta.med.service.ihis.handler.adma;

import java.math.BigDecimal;
import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.common.annotation.Route;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class AdmLoginFormLockUserHandler extends ScreenHandler<SystemServiceProto.AdmLoginFormLockUserRequest, SystemServiceProto.UpdateResponse> {
    
    @Resource
    private Adm3200Repository adm3200Repository;

    @Override
    @Route(global = false)
    public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, SystemServiceProto.AdmLoginFormLockUserRequest request) throws Exception {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        boolean result = adm3200Repository.updateLoginFlgByUserId(request.getUserId(), new Date(), BigDecimal.ZERO) > 0;
        response.setResult(result);
        return response.build();
    }
}
