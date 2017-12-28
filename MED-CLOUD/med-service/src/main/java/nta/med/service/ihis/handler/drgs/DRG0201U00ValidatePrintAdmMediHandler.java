package nta.med.service.ihis.handler.drgs;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.DrgsServiceProto;
import org.apache.commons.collections.CollectionUtils;
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
public class DRG0201U00ValidatePrintAdmMediHandler extends ScreenHandler<DrgsServiceProto.DRG0201U00ValidatePrintAdmMediRequest, DrgsServiceProto.DRG0201U00ValidatePrintAdmMediResponse> {
    private static final Log LOG = LogFactory.getLog(DRG0201U00ValidatePrintAdmMediHandler.class);
    @Resource
    private Ocs1003Repository ocs1003Repository;

    @Override
    public boolean isValid(DrgsServiceProto.DRG0201U00ValidatePrintAdmMediRequest request, Vertx vertx, String clientId, String sessionId) {
        if (!StringUtils.isEmpty(request.getJubsuDate()) && DateUtil.toDate(request.getJubsuDate(), DateUtil.PATTERN_YYMMDD) == null) {
            return false;
        }
        return true;
    }

    @Override
    @Transactional(readOnly = true)
    public DrgsServiceProto.DRG0201U00ValidatePrintAdmMediResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DRG0201U00ValidatePrintAdmMediRequest request) throws Exception {
        DrgsServiceProto.DRG0201U00ValidatePrintAdmMediResponse.Builder response = DrgsServiceProto.DRG0201U00ValidatePrintAdmMediResponse.newBuilder();
        List<String> listObject = ocs1003Repository.validatePrintAdmMediRequest(getHospitalCode(vertx, sessionId), request.getJubsuDate(), request.getDrgBunho(), request.getBunho(), "");
        if (!CollectionUtils.isEmpty(listObject)) {
            for (String item : listObject) {
                if ("C".equalsIgnoreCase(item) || "D".equalsIgnoreCase(item)) {
                    response.setCheckDrg("Y");
                }
                if ("B".equalsIgnoreCase(item)) {
                    response.setCheckInj("Y");
                }
            }
        }
        return response.build();
    }
}
