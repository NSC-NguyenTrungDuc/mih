package nta.med.service.ihis.handler.adma;

import nta.med.core.common.annotation.Route;
import nta.med.core.domain.adm.Adm0400;
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
import java.util.Date;

@Transactional
@Service
@Scope("prototype")
public class ADM401UInsertHandler extends ScreenHandler<AdmaServiceProto.ADM401UInsertRequest, SystemServiceProto.UpdateResponse> {
    private static final Log LOGGER = LogFactory.getLog(ADM401UInsertHandler.class);

    @Resource
    private Adm0400Repository adm0400Repository;

    @Override
    @Route(global = true)
    public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.ADM401UInsertRequest request) throws Exception {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        response.setResult(false);
        if (request.getHasVersion()) {
            Adm0400 adm0400 = new Adm0400();
            adm0400.setAsmName(request.getAsmName());
            adm0400.setAsmType(request.getAsmType());
            adm0400.setGrpId(request.getGrpId());
            adm0400.setSysId(request.getSysId());
            adm0400.setAsmVer(request.getAsmVer());
            adm0400.setAsmEssVer(request.getAsmVer());
            adm0400.setAsmPath(request.getAsmPath());
            adm0400.setCrTime(new Date());
            adm0400.setCrMemb(request.getUserId());

            adm0400Repository.save(adm0400);
        } else {
            Adm0400 adm0400 = new Adm0400();
            adm0400.setAsmName(request.getAsmName());
            adm0400.setAsmType(request.getAsmType());
            adm0400.setGrpId(request.getGrpId());
            adm0400.setSysId(request.getSysId());
            adm0400.setAsmVer("1");
            adm0400.setAsmEssVer("1");
            adm0400.setAsmPath(request.getAsmPath());
            adm0400.setCrTime(new Date());
            adm0400.setCrMemb(request.getUserId());

            adm0400Repository.save(adm0400);
        }
        response.setResult(true);
        return response.build();
    }
}
