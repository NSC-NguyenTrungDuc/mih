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
public class XRT0101U00LayDupDHandler extends ScreenHandler<XrtsServiceProto.XRT0101U00LayDupDRequest, XrtsServiceProto.XRT0101U00LayDupResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT0101U00LayDupDHandler.class);
    @Resource
    private Xrt0102Repository xrt0102Repository;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.XRT0101U00LayDupResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT0101U00LayDupDRequest request) throws Exception {
        XrtsServiceProto.XRT0101U00LayDupResponse.Builder response = XrtsServiceProto.XRT0101U00LayDupResponse.newBuilder();
        //get getYValueLayDupD
        String getYValueLayDupD = xrt0102Repository.getYValueLayDupD(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getCodeType(), request.getCode());
        if (!StringUtils.isEmpty(getYValueLayDupD)) {
            response.setResult(getYValueLayDupD);
        }
        return response.build();
    }
}