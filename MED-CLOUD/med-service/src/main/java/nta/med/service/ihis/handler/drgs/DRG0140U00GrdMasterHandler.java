package nta.med.service.ihis.handler.drgs;

import nta.med.core.domain.drg.Drg0140;
import nta.med.data.dao.medi.drg.Drg0140Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.List;

@Service
@Scope("prototype")
public class DRG0140U00GrdMasterHandler extends ScreenHandler<DrgsServiceProto.DRG0140U00GrdMasterRequest, DrgsServiceProto.DRG0140U00GrdMasterResponse> {
    private static final Log LOGGER = LogFactory.getLog(DRG0140U00GrdMasterHandler.class);
    @Resource
    private Drg0140Repository drg0140Repository;

    @Override
    @Transactional(readOnly = true)
    public DrgsServiceProto.DRG0140U00GrdMasterResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DRG0140U00GrdMasterRequest request) throws Exception {
        DrgsServiceProto.DRG0140U00GrdMasterResponse.Builder response = DrgsServiceProto.DRG0140U00GrdMasterResponse.newBuilder();
        List<Drg0140> listDrg0140 = drg0140Repository.findByCode(getHospitalCode(vertx, sessionId), request.getCode() + "%", getLanguage(vertx, sessionId));
        if (!CollectionUtils.isEmpty(listDrg0140)) {
            for (Drg0140 item : listDrg0140) {
                CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
                if (!StringUtils.isEmpty(item.getCode())) {
                    info.setCode(item.getCode());
                }
                if (!StringUtils.isEmpty(item.getCodeName())) {
                    info.setCodeName(item.getCodeName());
                }
                response.addGrdMasterItem(info);
            }
        }
        return response.build();
    }
}