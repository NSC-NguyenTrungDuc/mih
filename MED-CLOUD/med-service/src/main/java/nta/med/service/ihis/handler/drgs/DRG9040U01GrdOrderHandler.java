package nta.med.service.ihis.handler.drgs;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.drg.Drg3010Repository;
import nta.med.data.model.ihis.drgs.DRG9040U01GrdOrderInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.List;

@Service
@Scope("prototype")
public class DRG9040U01GrdOrderHandler extends ScreenHandler<DrgsServiceProto.DRG9040U01GrdOrderRequest, DrgsServiceProto.DRG9040U01GrdOrderResponse> {
    private static final Log LOGGER = LogFactory.getLog(DRG9040U01GrdOrderHandler.class);
    @Resource
    private Drg3010Repository drg3010Repository;

    @Override
    @Transactional(readOnly = true)
    public DrgsServiceProto.DRG9040U01GrdOrderResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DRG9040U01GrdOrderRequest request) throws Exception {
        DrgsServiceProto.DRG9040U01GrdOrderResponse.Builder response = DrgsServiceProto.DRG9040U01GrdOrderResponse.newBuilder();
        List<DRG9040U01GrdOrderInfo> list = drg3010Repository.getDRG9040U01GrdOrderInfo(getHospitalCode(vertx, sessionId), request.getBunho(), request.getFromDate(), request.getToDate());
        if (!CollectionUtils.isEmpty(list)) {
            for (DRG9040U01GrdOrderInfo item : list) {
                DrgsModelProto.DRG9040U01GrdOrderInfo.Builder info = DrgsModelProto.DRG9040U01GrdOrderInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addGrdOrderInfo(info);
            }
        }
        return response.build();
    }
}
