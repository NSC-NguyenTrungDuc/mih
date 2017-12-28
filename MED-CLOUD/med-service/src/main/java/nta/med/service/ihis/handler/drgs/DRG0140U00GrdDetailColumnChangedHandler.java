package nta.med.service.ihis.handler.drgs;

import nta.med.data.dao.medi.drg.Drg0141Repository;
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
public class DRG0140U00GrdDetailColumnChangedHandler extends ScreenHandler<DrgsServiceProto.DRG0140U00GrdDetailColumnChangedRequest, DrgsServiceProto.DRG0140U00GrdColumnChangedResponse> {
    private static final Log LOGGER = LogFactory.getLog(DRG0140U00GrdDetailColumnChangedHandler.class);
    @Resource
    private Drg0141Repository drg0141Repository;

    @Override
    @Transactional(readOnly = true)
    public DrgsServiceProto.DRG0140U00GrdColumnChangedResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DRG0140U00GrdDetailColumnChangedRequest request) throws Exception {
        DrgsServiceProto.DRG0140U00GrdColumnChangedResponse.Builder response = DrgsServiceProto.DRG0140U00GrdColumnChangedResponse.newBuilder();
        boolean result = false;
        for (DRG0140U00GrdColumnChangedInfo info : request.getGdcItemList()) {
            String relVal = drg0141Repository.getCode1ByCodeAndCode1(getHospitalCode(vertx, sessionId), info.getCode(), info.getCode1(), getLanguage(vertx, sessionId));
            if (!StringUtils.isEmpty(relVal) && relVal.equalsIgnoreCase(request.getChangedValue())) {
                result = true;
                break;
            }
        }
        response.setResult(result);
        return response.build();
    }
}