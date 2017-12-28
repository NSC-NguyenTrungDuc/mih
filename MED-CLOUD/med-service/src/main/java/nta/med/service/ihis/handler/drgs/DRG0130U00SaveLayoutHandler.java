package nta.med.service.ihis.handler.drgs;

import nta.med.core.domain.drg.Drg0130;
import nta.med.core.glossary.DataRowState;
import nta.med.data.dao.medi.drg.Drg0130Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.DrgsModelProto.DRG0130U00SaveLayoutInfo;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import java.util.Date;

@Service
@Scope("prototype")
@Transactional
public class DRG0130U00SaveLayoutHandler extends ScreenHandler<DrgsServiceProto.DRG0130U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {
    private static final Log LOGGER = LogFactory.getLog(DRG0130U00SaveLayoutHandler.class);
    @Resource
    private Drg0130Repository drg0130Repository;

    @Override
    public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DRG0130U00SaveLayoutRequest request) throws Exception {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        Integer result = null;
        String hospitalCode = getHospitalCode(vertx, sessionId);
        String language = getLanguage(vertx, sessionId);
        for (DRG0130U00SaveLayoutInfo info : request.getSaveLayoutItemList()) {
            if (DataRowState.ADDED.getValue().equals(info.getRowState())) {
                Drg0130 drg0130 = new Drg0130();
                drg0130.setCautionCode(info.getCautionCode());
                drg0130.setCautionName(info.getCautionName());
                drg0130.setCautionName2(info.getCautionName2());
                drg0130.setJobType(info.getJobType());
                drg0130.setSysDate(new Date());
                drg0130.setSysId(request.getUserId());
                drg0130.setHospCode(hospitalCode);
                drg0130.setLanguage(language);
                drg0130Repository.save(drg0130);
                result = 1;
            } else if (DataRowState.MODIFIED.getValue().equals(info.getRowState())) {
                result = drg0130Repository.updateDrgsDRG0130U00Drg0130(info.getCautionName(), info.getCautionName2(),
                        info.getJobType(), request.getUserId(),
                        info.getCautionCode(),
                        hospitalCode, language);
            } else if (DataRowState.DELETED.getValue().equals(info.getRowState())) {
                result = drg0130Repository.deleteDrgsDRG0130U00Drg0130(info.getCautionCode(), hospitalCode, language);
            }
        }
        response.setResult(result != null && result > 0);
        return response.build();
    }
}