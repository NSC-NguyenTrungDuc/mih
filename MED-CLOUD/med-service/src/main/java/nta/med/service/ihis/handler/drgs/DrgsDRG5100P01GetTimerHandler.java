package nta.med.service.ihis.handler.drgs;

import nta.med.data.dao.medi.drg.Drg9043Repository;
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
public class DrgsDRG5100P01GetTimerHandler extends ScreenHandler<DrgsServiceProto.DrgsDRG5100P01GetTimerRequest, DrgsServiceProto.DrgsDRG5100P01GetTimerResponse> {
	private static final Log LOG = LogFactory.getLog(DrgsDRG5100P01GetTimerHandler.class);
	@Resource
	private Drg9043Repository drg9043Repository;

    @Override
    @Transactional(readOnly = true)
    public DrgsServiceProto.DrgsDRG5100P01GetTimerResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DrgsDRG5100P01GetTimerRequest request) throws Exception {
        String result = drg9043Repository.checkDrgsDRG5100P01GetTimer(request.getCurrentDate(), getHospitalCode(vertx, sessionId));
        DrgsServiceProto.DrgsDRG5100P01GetTimerResponse.Builder response = DrgsServiceProto.DrgsDRG5100P01GetTimerResponse.newBuilder();
        if (!StringUtils.isEmpty(result)) {
            response.setResult(result);
        }
        return response.build();
    }
}
