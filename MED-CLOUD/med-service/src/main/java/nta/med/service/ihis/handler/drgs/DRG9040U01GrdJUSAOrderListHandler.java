package nta.med.service.ihis.handler.drgs;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.drg.Drg3010Repository;
import nta.med.data.model.ihis.drgs.DRG9040U01GrdJUSAOrderListInfo;
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
public class DRG9040U01GrdJUSAOrderListHandler extends ScreenHandler<DrgsServiceProto.DRG9040U01GrdJUSAOrderListRequest, DrgsServiceProto.DRG9040U01GrdJUSAOrderListResponse> {
    private static final Log LOGGER = LogFactory.getLog(DRG9040U01GrdJUSAOrderListHandler.class);
    @Resource
    private Drg3010Repository drg3010Repository;

    @Override
    @Transactional(readOnly = true)
    public DrgsServiceProto.DRG9040U01GrdJUSAOrderListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DRG9040U01GrdJUSAOrderListRequest request) throws Exception {
        DrgsServiceProto.DRG9040U01GrdJUSAOrderListResponse.Builder response = DrgsServiceProto.DRG9040U01GrdJUSAOrderListResponse.newBuilder();
        List<DRG9040U01GrdJUSAOrderListInfo> list = drg3010Repository.getDRG9040U01GrdJUSAOrderListInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getJubsuDate(), request.getDrgBunho(), request.getMagamBunryu());
        if (!CollectionUtils.isEmpty(list)) {
            for (DRG9040U01GrdJUSAOrderListInfo item : list) {
                DrgsModelProto.DRG9040U01GrdJUSAOrderListInfo.Builder info = DrgsModelProto.DRG9040U01GrdJUSAOrderListInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addGrdOrderListInfo(info);
            }
        }
        return response.build();
    }
}
