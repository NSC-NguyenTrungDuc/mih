package nta.med.service.ihis.handler.xrts;

import javax.annotation.Resource;

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

@Transactional
@Service
@Scope("prototype")
public class XRT0000Q00GetModalityCodeHandler extends ScreenHandler<XrtsServiceProto.XRT0000Q00GetModalityCodeRequest, XrtsServiceProto.XRT0000Q00GetModalityCodeResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT0000Q00GetModalityCodeHandler.class);
    @Resource
    private Xrt0001Repository xrt0001repository;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.XRT0000Q00GetModalityCodeResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT0000Q00GetModalityCodeRequest request) throws Exception {
        XrtsServiceProto.XRT0000Q00GetModalityCodeResponse.Builder response = XrtsServiceProto.XRT0000Q00GetModalityCodeResponse.newBuilder();
        String result = xrt0001repository.getXRT0000Q00GetModalityCode(getHospitalCode(vertx, sessionId), request.getHangmogCode());
        if (!StringUtils.isEmpty(result)) {
            response.setModality(result);
        }
        return response.build();
    }
}
