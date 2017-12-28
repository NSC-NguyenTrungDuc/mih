package nta.med.service.ihis.handler.system;

import nta.med.core.common.annotation.Route;
import nta.med.core.domain.bas.Bas0001;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemServiceProto;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

/**
 * @author DEV-TiepNM
 */
@Service
@Scope("prototype")
public class OrcaLoginHandler extends ScreenHandler<SystemServiceProto.OrcaLoginRequest, SystemServiceProto.OrcaLoginResponse> {

    @Autowired
    Bas0001Repository bas0001Repository;


    @Override
    @Route(global = true)
    @Transactional
    public SystemServiceProto.OrcaLoginResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, SystemServiceProto.OrcaLoginRequest request) throws Exception {

        Bas0001 bas0001 = bas0001Repository.findOne(5L);
        SystemServiceProto.OrcaLoginResponse.Builder orcaLoginResponse =  SystemServiceProto.OrcaLoginResponse.newBuilder();
        if(bas0001 != null)
        {
            setSessionInfo(vertx, sessionId,
                    SessionUserInfo.setSessionUserInfoByUserGroup(bas0001.getHospCode(), bas0001.getLanguage(), "", 1, ""));
            orcaLoginResponse.setHospCode(bas0001.getHospCode());
        }
        return orcaLoginResponse.build();
    }
}
