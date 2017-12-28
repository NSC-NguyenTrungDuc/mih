package nta.med.service.ihis.handler.drgs;

import nta.med.data.dao.medi.drg.Drg0130Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.DrgsServiceProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

@Service
@Scope("prototype")
public class DrgsDRG0130U00CautionCodeHandler extends ScreenHandler<DrgsServiceProto.DrgsDRG0130U00CautionCodeRequest, DrgsServiceProto.DrgsDRG0130U00CautionCodeResponse> {
    private static final Log LOGGER = LogFactory.getLog(DrgsDRG0130U00CautionCodeHandler.class);
    @Resource
    private Drg0130Repository drg0130Repository;

    @Override
    @Transactional(readOnly = true)
    public DrgsServiceProto.DrgsDRG0130U00CautionCodeResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DrgsDRG0130U00CautionCodeRequest request) throws Exception {
        DrgsServiceProto.DrgsDRG0130U00CautionCodeResponse.Builder response = DrgsServiceProto.DrgsDRG0130U00CautionCodeResponse.newBuilder();
        String result = drg0130Repository.getDrgsDRG0130U00CautionCode(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getCautionCode());
        if (result != null && !result.isEmpty()) {
            response.setCautionCode(result);
        }
        return response.build();
    }
}
