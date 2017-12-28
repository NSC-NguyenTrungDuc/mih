package nta.med.service.ihis.handler.xrts;

import javax.annotation.Resource;

import nta.med.data.dao.medi.xrt.Xrt0101Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.XrtsServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class XRT0101U00LayDupMHandler extends ScreenHandler<XrtsServiceProto.XRT0101U00LayDupMRequest, XrtsServiceProto.XRT0101U00LayDupResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT0101U00LayDupMHandler.class);
    @Resource
    private Xrt0101Repository xrt0101Repositoty;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.XRT0101U00LayDupResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT0101U00LayDupMRequest request) throws Exception {
        XrtsServiceProto.XRT0101U00LayDupResponse.Builder response = XrtsServiceProto.XRT0101U00LayDupResponse.newBuilder();
        //get getYValueLayDupM
        String getYValueLayDupM = xrt0101Repositoty.getYValueLayDupM(request.getCodeType(), getLanguage(vertx, sessionId));
        if (!StringUtils.isEmpty(getYValueLayDupM)) {
            response.setResult(getYValueLayDupM);
        }
        return response.build();
    }
}