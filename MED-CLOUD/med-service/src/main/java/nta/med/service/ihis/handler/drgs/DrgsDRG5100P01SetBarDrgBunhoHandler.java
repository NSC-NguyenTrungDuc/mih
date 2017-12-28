package nta.med.service.ihis.handler.drgs;

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
public class DrgsDRG5100P01SetBarDrgBunhoHandler extends ScreenHandler<DrgsServiceProto.DrgsDRG5100P01SetBarDrgBunhoRequest, DrgsServiceProto.DrgsDRG5100P01SetBarDrgBunhoResponse> {
    private static final Log LOG = LogFactory.getLog(DrgsDRG5100P01SetBarDrgBunhoHandler.class);
    @Resource
    private Drg2010Repository drg2010Repository;

    @Override
    public boolean isValid(DrgsServiceProto.DrgsDRG5100P01SetBarDrgBunhoRequest request, Vertx vertx, String clientId, String sessionId) {
        if (!StringUtils.isEmpty(request.getJubsuDate()) && DateUtil.toDate(request.getJubsuDate(), DateUtil.PATTERN_YYMMDD) == null) {
            return false;
        }
        return true;
    }

    @Override
    @Transactional(readOnly = true)
    public DrgsServiceProto.DrgsDRG5100P01SetBarDrgBunhoResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DrgsDRG5100P01SetBarDrgBunhoRequest request) throws Exception {
        String result = drg2010Repository.getDrgsDRG5100P01SetBarDrgBunho(getHospitalCode(vertx, sessionId), request.getJubsuDate(), request.getDrgBunho());
        DrgsServiceProto.DrgsDRG5100P01SetBarDrgBunhoResponse.Builder response = DrgsServiceProto.DrgsDRG5100P01SetBarDrgBunhoResponse.newBuilder();
        if (!StringUtils.isEmpty(result)) {
            response.setBarDrgBunho(result);
        }
        return response.build();
    }
}
