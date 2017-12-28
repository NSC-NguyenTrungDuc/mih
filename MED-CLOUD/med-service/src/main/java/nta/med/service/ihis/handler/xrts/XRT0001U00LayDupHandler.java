package nta.med.service.ihis.handler.xrts;

import nta.med.data.dao.medi.xrt.Xrt0001Repository;
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
public class XRT0001U00LayDupHandler extends ScreenHandler<XrtsServiceProto.XRT0001U00LayDupRequest, XrtsServiceProto.XRT0001U00LayDupResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT0001U00LayDupHandler.class);
    @Resource
    private Xrt0001Repository xrt0001Repository;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.XRT0001U00LayDupResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT0001U00LayDupRequest request) throws Exception {
        XrtsServiceProto.XRT0001U00LayDupResponse.Builder response = XrtsServiceProto.XRT0001U00LayDupResponse.newBuilder();
        //get y_value_layDup
        String getYValueLayDup = xrt0001Repository.getYValueLayDupXRT0001U00Initialize(getHospitalCode(vertx, sessionId), request.getXrayCode());
        if (!StringUtils.isEmpty(getYValueLayDup)) {
            response.setResult(getYValueLayDup);
        }
        return response.build();
    }
}