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
public class DrgsDRG5100P01MinFKOCS1003Handler extends ScreenHandler<DrgsServiceProto.DrgsDRG5100P01MinFKOCS1003Request, DrgsServiceProto.DrgsDRG5100P01MinFKOCS1003Response> {
	private static final Log LOG = LogFactory.getLog(DrgsDRG5100P01MinFKOCS1003Handler.class);
	@Resource
	private Drg2010Repository drg2010Repository;

    @Override
    @Transactional(readOnly = true)
    public DrgsServiceProto.DrgsDRG5100P01MinFKOCS1003Response handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DrgsDRG5100P01MinFKOCS1003Request request) throws Exception {
        Double drgBunho = CommonUtils.parseDouble(request.getDrgBunho());
        String result = drg2010Repository.getDrgsDRG5100P01MinFKOCS1003(getHospitalCode(vertx, sessionId), request.getJubsuDate(), drgBunho);
        DrgsServiceProto.DrgsDRG5100P01MinFKOCS1003Response.Builder response = DrgsServiceProto.DrgsDRG5100P01MinFKOCS1003Response.newBuilder();
        if (!StringUtils.isEmpty(result)) {
            response.setResult(result);
        }
        return response.build();
    }
}
