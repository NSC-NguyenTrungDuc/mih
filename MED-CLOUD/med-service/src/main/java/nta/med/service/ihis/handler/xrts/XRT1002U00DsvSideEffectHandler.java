package nta.med.service.ihis.handler.xrts;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.xrt.Xrt1001Repository;
import nta.med.data.model.ihis.xrts.XRT1002U00DsvSideEffectInfo;
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
public class XRT1002U00DsvSideEffectHandler extends ScreenHandler<XrtsServiceProto.XRT1002U00DsvSideEffectRequest, XrtsServiceProto.XRT1002U00DsvSideEffectResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT1002U00DsvSideEffectHandler.class);
    @Resource
    private Xrt1001Repository xrt1001Repository;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.XRT1002U00DsvSideEffectResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT1002U00DsvSideEffectRequest request) throws Exception {
        XrtsServiceProto.XRT1002U00DsvSideEffectResponse.Builder response = XrtsServiceProto.XRT1002U00DsvSideEffectResponse.newBuilder();
        List<XRT1002U00DsvSideEffectInfo> listItem = xrt1001Repository.getXRT1002U00DsvSideEffectInfo(getHospitalCode(vertx, sessionId), request.getBunho());
        if (!CollectionUtils.isEmpty(listItem)) {
            for (XRT1002U00DsvSideEffectInfo item : listItem) {
                XrtsModelProto.XRT1002U00DsvSideEffectInfo.Builder info = XrtsModelProto.XRT1002U00DsvSideEffectInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addDsvSideEffectItem(info);
            }
        }
        return response.build();
    }
}