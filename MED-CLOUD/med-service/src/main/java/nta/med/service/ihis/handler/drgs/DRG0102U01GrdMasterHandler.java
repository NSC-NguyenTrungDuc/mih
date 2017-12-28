package nta.med.service.ihis.handler.drgs;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.inv.Inv0101Repository;
import nta.med.data.model.ihis.drgs.Drg0102U01GrdMasterItemInfo;
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
public class DRG0102U01GrdMasterHandler extends ScreenHandler<DrgsServiceProto.DRG0102U01GrdMasterRequest, DrgsServiceProto.DRG0102U01GrdMasterResponse> {
    private static final Log LOGGER = LogFactory.getLog(DRG0102U01GrdMasterHandler.class);
    @Resource
    private Inv0101Repository inv0101Repository;

    @Override
    @Transactional(readOnly = true)
    public DrgsServiceProto.DRG0102U01GrdMasterResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DRG0102U01GrdMasterRequest request) throws Exception {
        DrgsServiceProto.DRG0102U01GrdMasterResponse.Builder response = DrgsServiceProto.DRG0102U01GrdMasterResponse.newBuilder();
        List<Drg0102U01GrdMasterItemInfo> list = inv0101Repository.getDrg0102U01GrdMasterListItem(request.getCodeType(), request.getCodeTypeName(), getLanguage(vertx, sessionId));
        if (!CollectionUtils.isEmpty(list)) {
            for (Drg0102U01GrdMasterItemInfo item : list) {
                DrgsModelProto.DRG0102U01GrdMasterItemInfo.Builder info = DrgsModelProto.DRG0102U01GrdMasterItemInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addGrdMasterItemInfo(info);
            }
        }
        return response.build();
    }
}