package nta.med.service.ihis.handler.drgs;

import nta.med.data.dao.medi.drg.Drg0140Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.DrgsModelProto.DRG0140U00GrdColumnChangedInfo;
import nta.med.service.ihis.proto.DrgsServiceProto;
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
public class DRG0140U00GrdMasterColumnChangedHandler extends ScreenHandler<DrgsServiceProto.DRG0140U00GrdMasterColumnChangedRequest, DrgsServiceProto.DRG0140U00GrdColumnChangedResponse> {
    private static final Log LOGGER = LogFactory.getLog(DRG0140U00GrdMasterColumnChangedHandler.class);
    @Resource
    private Drg0140Repository drg0140Repository;

    @Override
    @Transactional(readOnly = true)
    public DrgsServiceProto.DRG0140U00GrdColumnChangedResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DRG0140U00GrdMasterColumnChangedRequest request) throws Exception {
        DrgsServiceProto.DRG0140U00GrdColumnChangedResponse.Builder response = DrgsServiceProto.DRG0140U00GrdColumnChangedResponse.newBuilder();
        boolean result = false;
        for (DRG0140U00GrdColumnChangedInfo info : request.getGmcItemList()) {
            String relVal = drg0140Repository.getCodebyCodeAndHosp(getHospitalCode(vertx, sessionId), info.getCode(), getLanguage(vertx, sessionId));
            if (!StringUtils.isEmpty(relVal) && relVal.equalsIgnoreCase(request.getChangedValue())) {
                result = true;
                break;
            }
        }
        response.setResult(result);
        return response.build();
    }
}