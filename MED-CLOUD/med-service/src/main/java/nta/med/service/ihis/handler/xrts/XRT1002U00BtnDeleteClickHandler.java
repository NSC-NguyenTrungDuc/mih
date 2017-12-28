package nta.med.service.ihis.handler.xrts;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.xrt.Xrt1002Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemServiceProto;
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
public class XRT1002U00BtnDeleteClickHandler extends ScreenHandler<XrtsServiceProto.XRT1002U00BtnDeleteClickRequest, SystemServiceProto.UpdateResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT1002U00BtnDeleteClickHandler.class);
    @Resource
    private Xrt1002Repository xrt1002Repository;

    @Override
    @Transactional
    public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT1002U00BtnDeleteClickRequest request) throws Exception {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        Double fkocs = CommonUtils.parseDouble(request.getFkocs());
        if (xrt1002Repository.deleteXRT1002U00BtnDeleteClick(getHospitalCode(vertx, sessionId), fkocs) > 0) {
            response.setResult(true);
        } else {
            response.setResult(false);
        }
        return response.build();
    }
}