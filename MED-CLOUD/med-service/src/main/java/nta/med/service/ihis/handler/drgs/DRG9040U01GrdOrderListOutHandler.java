package nta.med.service.ihis.handler.drgs;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.drg.Drg2010Repository;
import nta.med.data.model.ihis.drgs.DRG9040U01GrdOrderListOutInfo;
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
public class DRG9040U01GrdOrderListOutHandler extends ScreenHandler<DrgsServiceProto.DRG9040U01GrdOrderListOutRequest, DrgsServiceProto.DRG9040U01GrdOrderListOutResponse> {
    private static final Log LOGGER = LogFactory.getLog(DRG9040U01GrdOrderListOutHandler.class);
    @Resource
    private Drg2010Repository drg2010Repository;

    @Override
    @Transactional(readOnly = true)
    public DrgsServiceProto.DRG9040U01GrdOrderListOutResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DRG9040U01GrdOrderListOutRequest request) throws Exception {
        DrgsServiceProto.DRG9040U01GrdOrderListOutResponse.Builder response = DrgsServiceProto.DRG9040U01GrdOrderListOutResponse.newBuilder();
        List<DRG9040U01GrdOrderListOutInfo> list = drg2010Repository.getDRG9040U01GrdOrderListOutInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getOrderDate(), request.getDrgBunho(), request.getBunho());
        if (!CollectionUtils.isEmpty(list)) {
            for (DRG9040U01GrdOrderListOutInfo item : list) {
                DrgsModelProto.DRG9040U01GrdOrderListOutInfo.Builder info = DrgsModelProto.DRG9040U01GrdOrderListOutInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addGrdOrderListOutInfo(info);
            }
        }
        return response.build();
    }
}
