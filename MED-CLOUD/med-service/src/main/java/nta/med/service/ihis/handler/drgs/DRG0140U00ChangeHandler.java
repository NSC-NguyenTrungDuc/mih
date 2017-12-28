package nta.med.service.ihis.handler.drgs;

import nta.med.core.domain.drg.Drg0140;
import nta.med.core.domain.drg.Drg0141;
import nta.med.core.glossary.DataRowState;
import nta.med.data.dao.medi.drg.Drg0140Repository;
import nta.med.data.dao.medi.drg.Drg0141Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
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
public class DRG0140U00ChangeHandler extends ScreenHandler<DrgsServiceProto.DRG0140U00ChangeRequest, SystemServiceProto.UpdateResponse> {
    private static final Log LOG = LogFactory.getLog(DRG0140U00ChangeHandler.class);
    @Resource
    private Drg0140Repository drg0140Repository;
    @Resource
    private Drg0141Repository drg0141Repository;

    @Override
    public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DRG0140U00ChangeRequest request) throws Exception {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        String hospitalCode = getHospitalCode(vertx, sessionId);
        String language = getLanguage(vertx, sessionId);
        switch (Integer.valueOf(request.getCallerId())) {
            case 1:
                processDrg0140(request, hospitalCode, language);
                break;
            case 2:
                processDrg0141(request, hospitalCode, language);
                break;
        }
        response.setResult(true);
        return response.build();
    }

    private void processDrg0140(DrgsServiceProto.DRG0140U00ChangeRequest request, String hospitalCode, String language) {
        if (DataRowState.ADDED.getValue().equals(request.getRowState())) {
            insertDrg0140(request, hospitalCode, language);
        } else if (DataRowState.MODIFIED.getValue().equals(request.getRowState())) {
            drg0140Repository.updateDrg0140ByCode(request.getUserId(), new Date(), request.getCodeName(), request.getCode(), hospitalCode, language);
        } else if (DataRowState.DELETED.getValue().equals(request.getRowState())) {
            drg0140Repository.deleteDrg0140ByCode(request.getCode(), hospitalCode, language);
        }
    }

    private void processDrg0141(DrgsServiceProto.DRG0140U00ChangeRequest request, String hospitalCode, String language) {
        if (DataRowState.ADDED.getValue().equals(request.getRowState())) {
            insertDrg0141(request, hospitalCode, language);
        } else if (DataRowState.MODIFIED.getValue().equals(request.getRowState())) {
            drg0141Repository.updateDrg0141ByCode(request.getUserId(), new Date(), request.getCodeName1(), request.getCode(), request.getCode1(), hospitalCode, language);
        } else if (DataRowState.DELETED.getValue().equals(request.getRowState())) {
            drg0141Repository.deleteDrg0141ByCode(request.getCode(), request.getCode1(), hospitalCode, language);
        }
    }

    private void insertDrg0140(DrgsServiceProto.DRG0140U00ChangeRequest request, String hospitalCode, String language) {
        Drg0140 drg0140 = new Drg0140();
        drg0140.setSysDate(new Date());
        drg0140.setSysId(request.getUserId());
        drg0140.setCode(request.getCode());
        drg0140.setCodeName(request.getCodeName());
        drg0140.setHospCode(hospitalCode);
        drg0140.setLanguage(language);
        drg0140Repository.save(drg0140);
    }

    private void insertDrg0141(DrgsServiceProto.DRG0140U00ChangeRequest request, String hospitalCode, String language) {
        Drg0141 drg0141 = new Drg0141();
        drg0141.setSysDate(new Date());
        drg0141.setSysId(request.getUserId());
        drg0141.setCode(request.getCode());
        drg0141.setCode1(request.getCode1());
        drg0141.setCodeName1(request.getCodeName1());
        drg0141.setHospCode(hospitalCode);
        drg0141.setLanguage(language);
        drg0141Repository.save(drg0141);
    }
}
