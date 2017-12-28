package nta.med.service.ihis.handler.xrts;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0801Repository;
import nta.med.data.model.ihis.xrts.XRT1002U00DsvLDOCS0801Info;
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
public class XRT1002U00DsvLDOCS0801Handler extends ScreenHandler<XrtsServiceProto.XRT1002U00DsvLDOCS0801Request, XrtsServiceProto.XRT1002U00DsvLDOCS0801Response> {
    private static final Log LOGGER = LogFactory.getLog(XRT1002U00DsvLDOCS0801Handler.class);
    @Resource
    private Ocs0801Repository ocs0801Repository;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.XRT1002U00DsvLDOCS0801Response handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT1002U00DsvLDOCS0801Request request) throws Exception {
        XrtsServiceProto.XRT1002U00DsvLDOCS0801Response.Builder response = XrtsServiceProto.XRT1002U00DsvLDOCS0801Response.newBuilder();
        List<XRT1002U00DsvLDOCS0801Info> listItem = ocs0801Repository.getXRT1002U00DsvLDOCS0801Info(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getHangmogCode());
        if (!CollectionUtils.isEmpty(listItem)) {
            for (XRT1002U00DsvLDOCS0801Info item : listItem) {
                XrtsModelProto.XRT1002U00DsvLDOCS0801Info.Builder info = XrtsModelProto.XRT1002U00DsvLDOCS0801Info.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addDsvLdItem(info);
            }
        }
        return response.build();
    }
}