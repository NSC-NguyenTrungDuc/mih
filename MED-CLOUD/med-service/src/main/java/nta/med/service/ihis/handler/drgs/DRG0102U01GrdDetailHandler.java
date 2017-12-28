package nta.med.service.ihis.handler.drgs;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.inv.Inv0102Repository;
import nta.med.data.model.ihis.drgs.Drg0102U01GrdDetailItemInfo;
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
public class DRG0102U01GrdDetailHandler extends ScreenHandler<DrgsServiceProto.DRG0102U01GrdDetailRequest, DrgsServiceProto.DRG0102U01GrdDetailResponse> {
    private static final Log LOGGER = LogFactory.getLog(DRG0102U01GrdDetailHandler.class);
    @Resource
    private Inv0102Repository inv0102Repository;

    @Override
    @Transactional(readOnly = true)
    public DrgsServiceProto.DRG0102U01GrdDetailResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DRG0102U01GrdDetailRequest request) throws Exception {
        DrgsServiceProto.DRG0102U01GrdDetailResponse.Builder response = DrgsServiceProto.DRG0102U01GrdDetailResponse.newBuilder();
        List<Drg0102U01GrdDetailItemInfo> list = inv0102Repository.getDrg0102U01GrdDetailListItem(getHospitalCode(vertx, sessionId), request.getCodeType(), getLanguage(vertx, sessionId));
        if (!CollectionUtils.isEmpty(list)) {
            for (Drg0102U01GrdDetailItemInfo item : list) {
                DrgsModelProto.DRG0102U01GrdDetailItemInfo.Builder info = DrgsModelProto.DRG0102U01GrdDetailItemInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addGrdDetailItemInfo(info);
            }
        }
        return response.build();
    }
}