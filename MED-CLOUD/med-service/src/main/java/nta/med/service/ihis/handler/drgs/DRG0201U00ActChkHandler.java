package nta.med.service.ihis.handler.drgs;

import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.drg.Drg2010Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.DrgsServiceProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;


@Service
@Scope("prototype")
public class DRG0201U00ActChkHandler extends ScreenHandler<DrgsServiceProto.DRG0201U00ActChkRequest, DrgsServiceProto.DRG0201U00ActChkResponse> {
    private static final Log LOG = LogFactory.getLog(DRG0201U00ActChkHandler.class);
    @Resource
    private Drg2010Repository drg2010Repository;

    @Override
    public boolean isValid(DrgsServiceProto.DRG0201U00ActChkRequest request, Vertx vertx, String clientId, String sessionId) {
        if (!StringUtils.isEmpty(request.getOrderDate()) && DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD_BLANK) == null) {
            return false;
        }
        return true;
    }

    @Override
    @Transactional(readOnly = true)
    public DrgsServiceProto.DRG0201U00ActChkResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DRG0201U00ActChkRequest request) throws Exception {
        String actChk = null;
        DrgsServiceProto.DRG0201U00ActChkResponse.Builder response = DrgsServiceProto.DRG0201U00ActChkResponse.newBuilder();
        String hospitalCode = getHospitalCode(vertx, sessionId);
        String checkActing = drg2010Repository.checkActing(hospitalCode, request.getOrderDate(), CommonUtils.parseDouble(request.getDrgBunho()));
        if (StringUtils.isEmpty(checkActing)) {
            actChk = "Y";
        } else {
            actChk = checkActing;
        }
        String checkJubsuIlsi = drg2010Repository.checkJubsuIlsi(hospitalCode, request.getOrderDate(), CommonUtils.parseDouble(request.getDrgBunho()));
        if (!StringUtils.isEmpty(checkJubsuIlsi)) {
            actChk = checkJubsuIlsi;
        }
        response.setResult(actChk);
        return response.build();
    }
}
