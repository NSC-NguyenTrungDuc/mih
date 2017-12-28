package nta.med.service.ihis.handler.xrts;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.xrt.Xrt0001Repository;
import nta.med.data.model.ihis.xrts.XRT9001R03Lay9003RListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.XrtsModelProto;
import nta.med.service.ihis.proto.XrtsServiceProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.List;

@Transactional
@Service
@Scope("prototype")
public class XRT9001R03Lay9003RHandler extends ScreenHandler<XrtsServiceProto.XRT9001R03Lay9003RRequest, XrtsServiceProto.XRT9001R03Lay9003RResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT9001R03Lay9003RHandler.class);
    @Resource
    private Xrt0001Repository xrt0001Repository;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.XRT9001R03Lay9003RResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT9001R03Lay9003RRequest request) throws Exception {
        XrtsServiceProto.XRT9001R03Lay9003RResponse.Builder response = XrtsServiceProto.XRT9001R03Lay9003RResponse.newBuilder();
        List<XRT9001R03Lay9003RListItemInfo> listLay9003 = xrt0001Repository.getXRT9001R03Lay9003RListItemInfo(getHospitalCode(vertx, sessionId), request.getDate());
        if (listLay9003 != null && !listLay9003.isEmpty()) {
            for (XRT9001R03Lay9003RListItemInfo item : listLay9003) {
                XrtsModelProto.XRT9001R03Lay9003RListItemInfo.Builder info = XrtsModelProto.XRT9001R03Lay9003RListItemInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addLay9003RList(info);
            }
        }
        return response.build();
    }
}
