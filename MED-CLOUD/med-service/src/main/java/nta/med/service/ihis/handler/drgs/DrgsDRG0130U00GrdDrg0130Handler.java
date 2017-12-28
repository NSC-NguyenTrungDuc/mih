package nta.med.service.ihis.handler.drgs;

import nta.med.data.dao.medi.drg.Drg0130Repository;
import nta.med.data.model.ihis.drgs.DrgsDRG0130U00GrdDrg0130ListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.List;

@Service
@Scope("prototype")
public class DrgsDRG0130U00GrdDrg0130Handler extends ScreenHandler<DrgsServiceProto.DrgsDRG0130U00GrdDrg0130Request, DrgsServiceProto.DrgsDRG0130U00GrdDrg0130Response> {
    private static final Log LOGGER = LogFactory.getLog(DrgsDRG0130U00GrdDrg0130Handler.class);
    @Resource
    private Drg0130Repository drg0130Repository;

    @Override
    @Transactional(readOnly = true)
    public DrgsServiceProto.DrgsDRG0130U00GrdDrg0130Response handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DrgsDRG0130U00GrdDrg0130Request request) throws Exception {
        DrgsServiceProto.DrgsDRG0130U00GrdDrg0130Response.Builder response = DrgsServiceProto.DrgsDRG0130U00GrdDrg0130Response.newBuilder();
        List<DrgsDRG0130U00GrdDrg0130ListItemInfo> listResult = drg0130Repository.getDrgsDRG0130U00GrdDrg0130ListItemInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), 
        		request.getCautionCode());
        if (listResult != null && !listResult.isEmpty()) {
            for (DrgsDRG0130U00GrdDrg0130ListItemInfo item : listResult) {
                DrgsModelProto.DrgsDRG0130U00GrdDrg0130ListItemInfo.Builder info = DrgsModelProto.DrgsDRG0130U00GrdDrg0130ListItemInfo.newBuilder();
                if (!StringUtils.isEmpty(item.getCautionCode())) {
                    info.setCautionCode(item.getCautionCode());
                }
                if (!StringUtils.isEmpty(item.getCautionName())) {
                    info.setCautionName(item.getCautionName());
                }
                if (!StringUtils.isEmpty(item.getCautionName2())) {
                    info.setCautionName2(item.getCautionName2());
                }
                if (!StringUtils.isEmpty(item.getJobType())) {
                    info.setJobType(item.getJobType());
                }
                response.addGrdDrg0130List(info);
            }
        }
        return response.build();
    }
}
