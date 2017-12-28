package nta.med.service.ihis.handler.xrts;

import nta.med.data.dao.medi.xrt.Xrt0101Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.XrtsServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

@Service
@Scope("prototype")
public class XRT0101U01LayDupMHandler extends ScreenHandler<XrtsServiceProto.XRT0101U01LayDupMRequest, XrtsServiceProto.XRT0101U01LayDupMResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT0101U01LayDupMHandler.class);
    @Resource
    private Xrt0101Repository xrt0101Repository;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.XRT0101U01LayDupMResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT0101U01LayDupMRequest request) throws Exception {
        XrtsServiceProto.XRT0101U01LayDupMResponse.Builder response = XrtsServiceProto.XRT0101U01LayDupMResponse.newBuilder();
        String str = xrt0101Repository.getYValueLayDupM(request.getCodeType(), getLanguage(vertx, sessionId));
        response.setYValue(str);
        return response.build();
    }
}