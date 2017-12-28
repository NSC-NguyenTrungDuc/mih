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
public class XRT0122U00LayDupMHandler extends ScreenHandler<XrtsServiceProto.XRT0122U00LayDupMRequest, XrtsServiceProto.XRT0122U00LayDupResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT0122U00LayDupMHandler.class);
    @Resource
    private Xrt0121Repository xrt0121Repository;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.XRT0122U00LayDupResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT0122U00LayDupMRequest request) throws Exception {
        XrtsServiceProto.XRT0122U00LayDupResponse.Builder response = XrtsServiceProto.XRT0122U00LayDupResponse.newBuilder();
        String result = xrt0121Repository.getXRT0122U00LayDupM(getHospitalCode(vertx, sessionId), request.getBuwiBunryu(), getLanguage(vertx, sessionId));
        if (!StringUtils.isEmpty(result)) {
            response.setDupYn(result);
        }
        return response.build();
    }
}
