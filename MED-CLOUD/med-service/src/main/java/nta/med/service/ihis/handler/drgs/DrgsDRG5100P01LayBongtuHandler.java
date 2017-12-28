package nta.med.service.ihis.handler.drgs;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.drg.Drg0120Repository;
import nta.med.data.model.ihis.drgs.DrgsDRG5100P01BongtuInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;
import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.List;

@Service
@Scope("prototype")
public class DrgsDRG5100P01LayBongtuHandler extends ScreenHandler<DrgsServiceProto.DrgsDRG5100P01LayBongtuRequest, DrgsServiceProto.DrgsDRG5100P01LayBongtuResponse> {
    private static final Log LOG = LogFactory.getLog(DrgsDRG5100P01LayBongtuHandler.class);

    @Resource
    private Drg0120Repository drg0120Repository;

    @Override
    @Transactional(readOnly = true)
    public DrgsServiceProto.DrgsDRG5100P01LayBongtuResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DrgsDRG5100P01LayBongtuRequest request) throws Exception {
        DrgsServiceProto.DrgsDRG5100P01LayBongtuResponse.Builder response = DrgsServiceProto.DrgsDRG5100P01LayBongtuResponse.newBuilder();
        List<DrgsModelProto.DrgsDRG5100P01OrderListItemInfo> listDrgsDRG5100P01OrderListItemInfo = request.getGridOrderItemList();
        if (!CollectionUtils.isEmpty(listDrgsDRG5100P01OrderListItemInfo)) {
            for (DrgsModelProto.DrgsDRG5100P01OrderListItemInfo orderInfo : listDrgsDRG5100P01OrderListItemInfo) {
                DrgsDRG5100P01BongtuInfo resultObject = drg0120Repository.getDrgsDRG5100P01BongtuInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),
                        orderInfo.getJubsuDate(), orderInfo.getActDate(), orderInfo.getBogyongCode(), orderInfo.getFkocs1003());
                DrgsModelProto.DrgsDRG5100P01LayBongtuInfo.Builder info = DrgsModelProto.DrgsDRG5100P01LayBongtuInfo.newBuilder();
                BeanUtils.copyProperties(resultObject, info, getLanguage(vertx, sessionId));

                response.addLayBongtuItem(info);
            }
        }
        return response.build();
    }
}
