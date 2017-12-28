package nta.med.service.ihis.handler.drgs;

import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.drg.Drg2010Repository;
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
public class DRG0201U00TxtDrgBunhoDataValidatingKeyPressHandler extends ScreenHandler<DrgsServiceProto.DRG0201U00TxtDrgBunhoDataValidatingKeyPressRequest, DrgsServiceProto.DRG0201U00TxtDrgBunhoDataValidatingKeyPressResponse> {
    private static final Log LOGGER = LogFactory.getLog(DRG0201U00TxtDrgBunhoDataValidatingKeyPressHandler.class);
    @Resource
    private Drg2010Repository drg2010Repository;

    @Override
    public boolean isValid(DrgsServiceProto.DRG0201U00TxtDrgBunhoDataValidatingKeyPressRequest request, Vertx vertx, String clientId, String sessionId) {
        if (!StringUtils.isEmpty(request.getJubsuDate()) && DateUtil.toDate(request.getJubsuDate(), DateUtil.PATTERN_YYMMDD) == null) {
            return false;
        }
        return true;
    }

    @Override
    @Transactional(readOnly = true)
    public DrgsServiceProto.DRG0201U00TxtDrgBunhoDataValidatingKeyPressResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DRG0201U00TxtDrgBunhoDataValidatingKeyPressRequest request) throws Exception {
        DrgsServiceProto.DRG0201U00TxtDrgBunhoDataValidatingKeyPressResponse.Builder response = DrgsServiceProto.DRG0201U00TxtDrgBunhoDataValidatingKeyPressResponse.newBuilder();
        List<String> listObject = drg2010Repository.getDRG0201U00GetPatientId(CommonUtils.parseDouble(request.getBunho()), request.getJubsuDate(), getHospitalCode(vertx, sessionId));
        if (!CollectionUtils.isEmpty(listObject)) {
            if (!StringUtils.isEmpty(listObject.get(0))) {
            }
            response.setResult(listObject.get(0));
        }

        return response.build();
    }
}