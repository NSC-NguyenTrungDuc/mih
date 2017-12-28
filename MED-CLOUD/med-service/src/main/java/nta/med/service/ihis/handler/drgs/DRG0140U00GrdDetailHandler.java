package nta.med.service.ihis.handler.drgs;

import nta.med.core.domain.drg.Drg0141;
import nta.med.data.dao.medi.drg.Drg0141Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.DrgsModelProto;
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
public class DRG0140U00GrdDetailHandler extends ScreenHandler<DrgsServiceProto.DRG0140U00GrdDetailRequest, DrgsServiceProto.DRG0140U00GrdDetailResponse> {
    private static final Log LOGGER = LogFactory.getLog(DRG0140U00GrdDetailHandler.class);
    @Resource
    private Drg0141Repository drg0141Repository;

    @Override
    @Transactional(readOnly = true)
    public DrgsServiceProto.DRG0140U00GrdDetailResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DRG0140U00GrdDetailRequest request) throws Exception {
        DrgsServiceProto.DRG0140U00GrdDetailResponse.Builder response = DrgsServiceProto.DRG0140U00GrdDetailResponse.newBuilder();
        List<Drg0141> listDrg0141 = drg0141Repository.getByCode(getHospitalCode(vertx, sessionId), request.getCode(), getLanguage(vertx, sessionId));
        if (!CollectionUtils.isEmpty(listDrg0141)) {
            for (Drg0141 item : listDrg0141) {
                DrgsModelProto.DRG0140U00GrdDetailInfo.Builder info = DrgsModelProto.DRG0140U00GrdDetailInfo.newBuilder();
                if (!StringUtils.isEmpty(item.getCode())) {
                    info.setCode(item.getCode());
                }
                if (!StringUtils.isEmpty(item.getCode1())) {
                    info.setCode1(item.getCode1());
                }
                if (!StringUtils.isEmpty(item.getCodeName1())) {
                    info.setCodeName1(item.getCodeName1());
                }
                response.addGrdDetailItem(info);
            }
        }
        return response.build();
    }
}