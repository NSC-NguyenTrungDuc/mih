package nta.med.service.ihis.handler.xrts;

import nta.med.data.dao.medi.out.Out0106Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.XrtsModelProto;
import nta.med.service.ihis.proto.XrtsServiceProto;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

import java.util.List;

@Service
@Scope("prototype")
public class XRT1002U00LayOrderDateHandler extends ScreenHandler<XrtsServiceProto.XRT1002U00LayOrderDateRequest, XrtsServiceProto.XRT1002U00LayOrderDateResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT1002U00LayOrderDateHandler.class);
    @Resource
    private Out0106Repository out0106Repository;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.XRT1002U00LayOrderDateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT1002U00LayOrderDateRequest request) throws Exception {
        XrtsServiceProto.XRT1002U00LayOrderDateResponse.Builder response = XrtsServiceProto.XRT1002U00LayOrderDateResponse.newBuilder();
        List<String> listItem = out0106Repository.getXRT1002U00LayOrderDate(getHospitalCode(vertx, sessionId), "XRT", request.getBunho());
        if (!CollectionUtils.isEmpty(listItem)) {
            for (String item : listItem) {
                XrtsModelProto.XRT1002U00LayOrderDateInfo.Builder info = XrtsModelProto.XRT1002U00LayOrderDateInfo.newBuilder();
                info.setOrderDate(item);
                response.addLayOrderDateItem(info);
            }
        }
        return response.build();
    }
}