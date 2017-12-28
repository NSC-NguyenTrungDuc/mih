package nta.med.service.ihis.handler.drgs;

import nta.med.data.dao.medi.inv.Inv0101Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
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
public class DRG0102U01GrdMasterCheckHandler extends ScreenHandler<DrgsServiceProto.DRG0102U01GrdMasterCheckRequest, DrgsServiceProto.DRG0102U01GrdCheckResponse> {
    private static final Log LOGGER = LogFactory.getLog(DRG0102U01GrdMasterCheckHandler.class);
    @Resource
    private Inv0101Repository inv0101Repository;

    @Override
    @Transactional(readOnly = true)
    public DrgsServiceProto.DRG0102U01GrdCheckResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DRG0102U01GrdMasterCheckRequest request) throws Exception {
        DrgsServiceProto.DRG0102U01GrdCheckResponse.Builder response = DrgsServiceProto.DRG0102U01GrdCheckResponse.newBuilder();
        String result = inv0101Repository.checkDRG0102U00GrdMasterGridColumnChanged(request.getCodeType(), getLanguage(vertx, sessionId));
        if (!StringUtils.isEmpty(result)) {
            response.setResult(result);
        }
        return response.build();
    }
}