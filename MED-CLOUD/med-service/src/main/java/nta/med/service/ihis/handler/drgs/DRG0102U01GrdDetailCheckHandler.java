package nta.med.service.ihis.handler.drgs;

import nta.med.data.dao.medi.inv.Inv0102Repository;
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
public class DRG0102U01GrdDetailCheckHandler extends ScreenHandler<DrgsServiceProto.DRG0102U01GrdDetailCheckRequest, DrgsServiceProto.DRG0102U01GrdCheckResponse> {
    private static final Log LOGGER = LogFactory.getLog(DRG0102U01GrdDetailCheckHandler.class);
    @Resource
    private Inv0102Repository inv0102Repository;

    @Override
    @Transactional(readOnly = true)
    public DrgsServiceProto.DRG0102U01GrdCheckResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DRG0102U01GrdDetailCheckRequest request) throws Exception {
        DrgsServiceProto.DRG0102U01GrdCheckResponse.Builder response = DrgsServiceProto.DRG0102U01GrdCheckResponse.newBuilder();
        String result = inv0102Repository.checkDrg0102U01GrdDetail(getHospitalCode(vertx, sessionId), request.getCodeType(), request.getCode(), getLanguage(vertx, sessionId));
        if (!StringUtils.isEmpty(result)) {
            response.setResult(result);
        }
        return response.build();
    }
}