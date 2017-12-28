package nta.med.service.ihis.handler.drgs;

import nta.med.core.utils.CommonUtils;
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
public class DrgsDRG5100P01CheckJubsuHandler extends ScreenHandler<DrgsServiceProto.DrgsDRG5100P01CheckJubsuRequest, DrgsServiceProto.DrgsDRG5100P01CheckJubsuResponse> {
	private static final Log LOG = LogFactory.getLog(DrgsDRG5100P01CheckJubsuHandler.class);
	@Resource
	private Drg2010Repository drg2010Repository;

    @Override
    @Transactional(readOnly = true)
    public DrgsServiceProto.DrgsDRG5100P01CheckJubsuResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DrgsDRG5100P01CheckJubsuRequest request) throws Exception {
        Double drgBunho = CommonUtils.parseDouble(request.getDrgBunho());
        String result = drg2010Repository.checkDrgsDRG5100P01CheckJubsu(getHospitalCode(vertx, sessionId), request.getOrderDate(), drgBunho);
        DrgsServiceProto.DrgsDRG5100P01CheckJubsuResponse.Builder response = DrgsServiceProto.DrgsDRG5100P01CheckJubsuResponse.newBuilder();
        if (!StringUtils.isEmpty(result)) {
            response.setResult(result);
        }
        return response.build();
    }
}
