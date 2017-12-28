package nta.med.service.ihis.handler.xrts;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.xrt.Xrt0122Repository;
import nta.med.data.model.ihis.xrts.XRT0122U00GrdDcodeInfo;
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
public class XRT0122U00GrdDcodeHandler extends ScreenHandler<XrtsServiceProto.XRT0122U00GrdDcodeRequest, XrtsServiceProto.XRT0122U00GrdDcodeResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT0122U00GrdDcodeHandler.class);
    @Resource
    private Xrt0122Repository xrt0122Repository;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.XRT0122U00GrdDcodeResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT0122U00GrdDcodeRequest request) throws Exception {
        XrtsServiceProto.XRT0122U00GrdDcodeResponse.Builder response = XrtsServiceProto.XRT0122U00GrdDcodeResponse.newBuilder();
        List<XRT0122U00GrdDcodeInfo> listResult = xrt0122Repository.getXRT0122U00grdDCodeInitInfo(getHospitalCode(vertx, sessionId), request.getBuwiBunryu(), request.getBuwiCode(), request.getBuwiName(), request.getFlag(), getLanguage(vertx, sessionId));
        if (!CollectionUtils.isEmpty(listResult)) {
            for (XRT0122U00GrdDcodeInfo item : listResult) {
                XrtsModelProto.XRT0122U00GrdDcodeInfo.Builder info = XrtsModelProto.XRT0122U00GrdDcodeInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addDcodeItem(info);
            }
        }
        return response.build();
    }
}