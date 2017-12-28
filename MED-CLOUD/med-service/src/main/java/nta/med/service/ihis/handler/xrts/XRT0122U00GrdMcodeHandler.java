package nta.med.service.ihis.handler.xrts;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.xrt.Xrt0121Repository;
import nta.med.data.model.ihis.xrts.XRT0122U00GrdMcodeInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.XrtsModelProto;
import nta.med.service.ihis.proto.XrtsServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

import java.util.List;

@Service
@Scope("prototype")
public class XRT0122U00GrdMcodeHandler extends ScreenHandler<XrtsServiceProto.XRT0122U00GrdMcodeRequest, XrtsServiceProto.XRT0122U00GrdMcodeResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT0122U00GrdMcodeHandler.class);
    @Resource
    private Xrt0121Repository xrt0121Repository;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.XRT0122U00GrdMcodeResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT0122U00GrdMcodeRequest request) throws Exception {
        XrtsServiceProto.XRT0122U00GrdMcodeResponse.Builder response = XrtsServiceProto.XRT0122U00GrdMcodeResponse.newBuilder();
        List<XRT0122U00GrdMcodeInfo> listResult = xrt0121Repository.getInitializeItem(getHospitalCode(vertx, sessionId), request.getBuwiBunryu(), getLanguage(vertx, sessionId));
        if (!CollectionUtils.isEmpty(listResult)) {
            for (XRT0122U00GrdMcodeInfo item : listResult) {
                XrtsModelProto.XRT0122U00GrdMcodeInfo.Builder info = XrtsModelProto.XRT0122U00GrdMcodeInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addMcodeItem(info);
            }
        }
        return response.build();
    }
}