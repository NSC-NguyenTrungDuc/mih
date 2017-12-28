package nta.med.service.ihis.handler.xrts;

import nta.med.data.dao.medi.xrt.Xrt0121Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.XrtsServiceProto;

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
public class Xrt0122Q00LayDupMHandler extends ScreenHandler<XrtsServiceProto.Xrt0122Q00LayDupMRequest, XrtsServiceProto.Xrt0122Q00LayDupMResponse> {
    private static final Log LOGGER = LogFactory.getLog(Xrt0122Q00LayDupMHandler.class);
    @Resource
    private Xrt0121Repository xrt0121Repository;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.Xrt0122Q00LayDupMResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.Xrt0122Q00LayDupMRequest request) throws Exception {
        XrtsServiceProto.Xrt0122Q00LayDupMResponse.Builder response = XrtsServiceProto.Xrt0122Q00LayDupMResponse.newBuilder();
        String getY = xrt0121Repository.getXRT0122U00LayDupM(getHospitalCode(vertx, sessionId), request.getBuwiBunryu(), getLanguage(vertx, sessionId));
        if (!StringUtils.isEmpty(getY)) {
            response.setYValue(getY);
        }
        return response.build();
    }
}