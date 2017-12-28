package nta.med.service.ihis.handler.xrts;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.xrt.Xrt0102Repository;
import nta.med.data.model.ihis.xrts.XRT1002U00LayCPLInfo;
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
public class XRT1002U00LayCPLHandler extends ScreenHandler<XrtsServiceProto.XRT1002U00LayCPLRequest, XrtsServiceProto.XRT1002U00LayCPLResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT1002U00LayCPLHandler.class);
    @Resource
    private Xrt0102Repository xrt0102Repository;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.XRT1002U00LayCPLResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT1002U00LayCPLRequest request) throws Exception {
        XrtsServiceProto.XRT1002U00LayCPLResponse.Builder response = XrtsServiceProto.XRT1002U00LayCPLResponse.newBuilder();
        List<XRT1002U00LayCPLInfo> listItem = xrt0102Repository.getXRT1002U00LayCPLInfo(getHospitalCode(vertx, sessionId), request.getBunho());
        if (!CollectionUtils.isEmpty(listItem)) {
            for (XRT1002U00LayCPLInfo item : listItem) {
                XrtsModelProto.XRT1002U00LayCPLInfo.Builder info = XrtsModelProto.XRT1002U00LayCPLInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addLayCplItem(info);
            }
        }
        return response.build();
    }
}