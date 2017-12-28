package nta.med.service.ihis.handler.xrts;

import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
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
public class XRT0201U00MentHandler extends ScreenHandler<XrtsServiceProto.XRT0201U00MentRequest, XrtsServiceProto.XRT0201U00MentResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT0201U00MentHandler.class);
    @Resource
    private Ocs0132Repository ocs0132Repository;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.XRT0201U00MentResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT0201U00MentRequest request) throws Exception {
        XrtsServiceProto.XRT0201U00MentResponse.Builder response = XrtsServiceProto.XRT0201U00MentResponse.newBuilder();
        List<String> list = ocs0132Repository.getMintByCodeAndCodeType(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), "OCS_ACT_SYSTEM", "OCS_ACT_PART_01");
        if (!CollectionUtils.isEmpty(list)) {
            response.setMent(list.get(0));
        }
        return response.build();
    }
}