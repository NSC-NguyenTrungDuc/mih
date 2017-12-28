package nta.med.service.ihis.handler.drgs;

import nta.med.core.domain.drg.Drg0140;
import nta.med.core.domain.drg.Drg0141;
import nta.med.core.glossary.DataRowState;
import nta.med.data.dao.medi.drg.Drg0140Repository;
import nta.med.data.dao.medi.drg.Drg0141Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.DrgsModelProto.DRG0140U00SaveLayoutInfo;
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
public class DRG0140U00SaveLayoutHandler extends ScreenHandler<DrgsServiceProto.DRG0140U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {
    private static final Log LOGGER = LogFactory.getLog(DRG0140U00SaveLayoutHandler.class);
    @Resource
    private Drg0141Repository drg0141Repository;
    @Resource
    private Drg0140Repository drg0140Repository;

    @Override
    public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DRG0140U00SaveLayoutRequest request) throws Exception {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        Integer result = null;
        String hospitalCode = getHospitalCode(vertx, sessionId);
        String language = getLanguage(vertx, sessionId);
        for (DRG0140U00SaveLayoutInfo info : request.getSaveLayoutItemList()) {
            switch (Integer.valueOf(info.getCallerId())) {
                case 1:
                    processDrg0140(info, request.getUserId(), hospitalCode, language);
                    result = 1;
                    break;
                case 2:
                    processDrg0141(info, request.getUserId(), hospitalCode, language);
                    result = 1;
                    break;
            }
        }
        response.setResult(result != null && result > 0);
        return response.build();
    }

    private void processDrg0140(DRG0140U00SaveLayoutInfo info, String userId, String hospitalCode, String language) {
        if (DataRowState.ADDED.getValue().equals(info.getRowState())) {
            insertDrg0140(info, userId, hospitalCode, language);
        } else if (DataRowState.MODIFIED.getValue().equals(info.getRowState())) {
            drg0140Repository.updateDrg0140ByCode(userId, new Date(), info.getCodeName(), info.getCode(), hospitalCode, language);
        } else if (DataRowState.DELETED.getValue().equals(info.getRowState())) {
            drg0140Repository.deleteDrg0140ByCode(info.getCode(), hospitalCode, language);
        }
    }

    private void processDrg0141(DRG0140U00SaveLayoutInfo info, String userId, String hospitalCode, String language) {
        if (DataRowState.ADDED.getValue().equals(info.getRowState())) {
            insertDrg0141(info, userId, hospitalCode, language);
        } else if (DataRowState.MODIFIED.getValue().equals(info.getRowState())) {
            drg0141Repository.updateDrg0141ByCode(userId, new Date(), info.getCodeName1(), info.getCode(), info.getCode1(), hospitalCode, language);
        } else if (DataRowState.DELETED.getValue().equals(info.getRowState())) {
            drg0141Repository.deleteDrg0141ByCode(info.getCode(), info.getCode1(), hospitalCode, language);
        }
    }

    private void insertDrg0140(DRG0140U00SaveLayoutInfo info, String userId, String hospitalCode, String language) {
        Drg0140 drg0140 = new Drg0140();
        drg0140.setSysDate(new Date());
        drg0140.setSysId(userId);
        drg0140.setCode(info.getCode());
        drg0140.setCodeName(info.getCodeName());
        drg0140.setHospCode(hospitalCode);
        drg0140.setLanguage(language);
        drg0140Repository.save(drg0140);
    }

    private void insertDrg0141(DRG0140U00SaveLayoutInfo info, String userId, String hospitalCode, String language) {
        Drg0141 drg0141 = new Drg0141();
        drg0141.setSysDate(new Date());
        drg0141.setSysId(userId);
        drg0141.setCode(info.getCode());
        drg0141.setCode1(info.getCode1());
        drg0141.setCodeName1(info.getCodeName1());
        drg0141.setHospCode(hospitalCode);
        drg0141.setLanguage(language);
        drg0141Repository.save(drg0141);
    }
}