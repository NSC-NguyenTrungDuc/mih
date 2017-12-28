package nta.med.service.ihis.handler.xrts;

import nta.med.data.dao.medi.xrt.Xrt0123Repository;
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
public class XRT0123U00LayDupDHandler extends ScreenHandler<XrtsServiceProto.XRT0123U00LayDupDRequest, XrtsServiceProto.XRT0123U00LayDupDResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT0123U00LayDupDHandler.class);
    @Resource
    private Xrt0123Repository xrt0123Repository;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.XRT0123U00LayDupDResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT0123U00LayDupDRequest request) throws Exception {
        XrtsServiceProto.XRT0123U00LayDupDResponse.Builder response = XrtsServiceProto.XRT0123U00LayDupDResponse.newBuilder();
        String exist = xrt0123Repository.checkExistByXrayGubunAndBuwiCode(getHospitalCode(vertx, sessionId), request.getXrayGubun(), request.getBuwiCode());
        if (!StringUtils.isEmpty(exist)) {
            response.setYnValue(exist);
        }
        return response.build();
    }
}