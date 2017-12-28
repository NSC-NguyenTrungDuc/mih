package nta.med.service.ihis.handler.invs;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.InvsServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

/**
 * @author DEV-TiepNM
 */
public class INV6000U00UserLstHandler  extends ScreenHandler<InvsServiceProto.INV6000U00UserLstRequest, SystemServiceProto.UpdateResponse> {

    @Resource

    @Override
    public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, InvsServiceProto.INV6000U00UserLstRequest request) throws Exception {
        return null;
    }
}
