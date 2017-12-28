package nta.med.service.ihis.handler.xrts;

import nta.med.data.dao.medi.xrt.Xrt0102Repository;
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
public class Xrt0122Q00LayCodeNameHandler extends ScreenHandler<XrtsServiceProto.Xrt0122Q00LayCodeNameRequest, XrtsServiceProto.Xrt0122Q00LayCodeNameResponse> {
    private static final Log LOGGER = LogFactory.getLog(Xrt0122Q00LayCodeNameHandler.class);
    @Resource
    private Xrt0102Repository xrt0102Repository;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.Xrt0122Q00LayCodeNameResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.Xrt0122Q00LayCodeNameRequest request) throws Exception {
        XrtsServiceProto.Xrt0122Q00LayCodeNameResponse.Builder response = XrtsServiceProto.Xrt0122Q00LayCodeNameResponse.newBuilder();
        String codeName = xrt0102Repository.getCodeNameFromXRT0102(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getCode());
        if (!StringUtils.isEmpty(codeName)) {
            response.setCodeName(codeName);
        }
        return response.build();
    }
}