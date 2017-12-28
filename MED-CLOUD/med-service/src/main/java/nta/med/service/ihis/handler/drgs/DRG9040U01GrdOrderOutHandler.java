package nta.med.service.ihis.handler.drgs;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.drg.Drg2010Repository;
import nta.med.data.model.ihis.drgs.DRG9040U01GrdOrderOutInfo;
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
public class DRG9040U01GrdOrderOutHandler extends ScreenHandler<DrgsServiceProto.DRG9040U01GrdOrderOutRequest, DrgsServiceProto.DRG9040U01GrdOrderOutResponse> {
    private static final Log LOGGER = LogFactory.getLog(DRG9040U01GrdOrderOutHandler.class);
    @Resource
    private Drg2010Repository drg2010Repository;

    @Override
    @Transactional(readOnly = true)
    public DrgsServiceProto.DRG9040U01GrdOrderOutResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DRG9040U01GrdOrderOutRequest request) throws Exception {
        DrgsServiceProto.DRG9040U01GrdOrderOutResponse.Builder response = DrgsServiceProto.DRG9040U01GrdOrderOutResponse.newBuilder();
        List<DRG9040U01GrdOrderOutInfo> list = drg2010Repository.getDRG9040U01GrdOrderOutInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),
        		request.getBunho(), request.getFromDate(), request.getToDate());
        if (!CollectionUtils.isEmpty(list)) {
            for (DRG9040U01GrdOrderOutInfo item : list) {
                DrgsModelProto.DRG9040U01GrdOrderOutInfo.Builder info = DrgsModelProto.DRG9040U01GrdOrderOutInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addGrdOrderOutInfo(info);
            }
        }
        return response.build();
    }
}
