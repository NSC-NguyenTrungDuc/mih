package nta.med.service.ihis.handler.xrts;

import nta.med.data.dao.medi.xrt.Xrt0122Repository;
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
public class Xrt0122Q00LayDupDHandler extends ScreenHandler<XrtsServiceProto.Xrt0122Q00LayDupDRequest, XrtsServiceProto.Xrt0122Q00LayDupDResponse> {
    private static final Log LOGGER = LogFactory.getLog(Xrt0122Q00LayDupDHandler.class);
    @Resource
    private Xrt0122Repository xrt0122Repository;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.Xrt0122Q00LayDupDResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.Xrt0122Q00LayDupDRequest request) throws Exception {
        XrtsServiceProto.Xrt0122Q00LayDupDResponse.Builder response = XrtsServiceProto.Xrt0122Q00LayDupDResponse.newBuilder();
        String result = xrt0122Repository.getXRT0122U00layDupD(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getBuwiBunryu(), request.getBuwiCode());
        if (!StringUtils.isEmpty(result)) {
            response.setYValue(result);
        }
        return response.build();
    }
}