package nta.med.service.ihis.handler.xrts;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.xrt.Xrt0001Repository;
import nta.med.data.model.ihis.xrts.XRT1002U00DsvXrayGubunInfo;
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
public class XRT1002U00DsvXrayGubunHandler extends ScreenHandler<XrtsServiceProto.XRT1002U00DsvXrayGubunRequest, XrtsServiceProto.XRT1002U00DsvXrayGubunResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT1002U00DsvXrayGubunHandler.class);
    @Resource
    private Xrt0001Repository xrt0001Repository;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.XRT1002U00DsvXrayGubunResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT1002U00DsvXrayGubunRequest request) throws Exception {
        XrtsServiceProto.XRT1002U00DsvXrayGubunResponse.Builder response = XrtsServiceProto.XRT1002U00DsvXrayGubunResponse.newBuilder();
        List<XRT1002U00DsvXrayGubunInfo> listXray = xrt0001Repository.getXRT1002U00DsvXrayGubunInfo(getHospitalCode(vertx, sessionId), request.getCode());
        if (!CollectionUtils.isEmpty(listXray)) {
            for (XRT1002U00DsvXrayGubunInfo item : listXray) {
                XrtsModelProto.XRT1002U00DsvXrayGubunInfo.Builder info = XrtsModelProto.XRT1002U00DsvXrayGubunInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addXrayGubunItem(info);
            }
        }
        return response.build();
    }
}