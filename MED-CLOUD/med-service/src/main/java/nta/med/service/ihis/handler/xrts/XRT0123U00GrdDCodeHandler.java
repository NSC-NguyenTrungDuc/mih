package nta.med.service.ihis.handler.xrts;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.xrt.Xrt0122Repository;
import nta.med.data.dao.medi.xrt.Xrt0123Repository;
import nta.med.data.model.ihis.xrts.XRT0123U00GrdDCodeItemInfo;
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
public class XRT0123U00GrdDCodeHandler extends ScreenHandler<XrtsServiceProto.XRT0123U00GrdDCodeRequest, XrtsServiceProto.XRT0123U00GrdDCodeResponse> {
    private static final Log LOG = LogFactory.getLog(XRT0123U00GrdDCodeHandler.class);
    @Resource
    private Xrt0123Repository xrt0123Repository;
    @Resource
    private Xrt0122Repository xrt0122Repository;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.XRT0123U00GrdDCodeResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT0123U00GrdDCodeRequest request) throws Exception {
        XrtsServiceProto.XRT0123U00GrdDCodeResponse.Builder response = XrtsServiceProto.XRT0123U00GrdDCodeResponse.newBuilder();
        List<XRT0123U00GrdDCodeItemInfo> listItem = xrt0122Repository.getXRT0123U00GrdDCodeItemInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getXrayGubun(), request.getBuwiCode());
        if (!CollectionUtils.isEmpty(listItem)) {
            for (XRT0123U00GrdDCodeItemInfo item : listItem) {
                XrtsModelProto.XRT0123U00GrdDCodeItemInfo.Builder info = XrtsModelProto.XRT0123U00GrdDCodeItemInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addListInfo(info);
            }
        }
        return response.build();
    }
}
