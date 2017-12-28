package nta.med.service.ihis.handler.adma;

import nta.med.core.common.annotation.Route;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.adm.Adm0400Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.AdmaServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

@Transactional
@Service
@Scope("prototype")
public class ADM401UUpdateHandler extends ScreenHandler<AdmaServiceProto.ADM401UUpdateRequest, SystemServiceProto.UpdateResponse> {
    private static final Log LOGGER = LogFactory.getLog(ADM401UUpdateHandler.class);

    @Resource
    private Adm0400Repository adm0400Repository;

    @Override
    @Route(global = true)
    public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.ADM401UUpdateRequest request) throws Exception {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        response.setResult(false);
        if (request.getHasVersion()) {
            adm0400Repository.updateADM401U(request.getAsmVer(), request.getAsmName());
        } else {
            Integer asmVer = CommonUtils.parseInteger(request.getAsmVer());
            if (asmVer != null) {
                asmVer = asmVer + 1;
                adm0400Repository.updateADM401U(asmVer.toString(), request.getAsmName());
            } else {
                adm0400Repository.updateADM401U("1", request.getAsmName());
            }
        }
        response.setResult(true);
        return response.build();
    }
}
