package nta.med.service.ihis.handler.xrts;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.out.Out0106Repository;
import nta.med.data.model.ihis.xrts.XRT1002U00GrdCommentInfo;
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
public class XRT1002U00GrdComment2Handler extends ScreenHandler<XrtsServiceProto.XRT1002U00GrdComment2Request, XrtsServiceProto.XRT1002U00GrdComment2Response> {
    private static final Log LOGGER = LogFactory.getLog(XRT1002U00GrdComment2Handler.class);
    @Resource
    private Out0106Repository out0106Repository;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.XRT1002U00GrdComment2Response handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT1002U00GrdComment2Request request) throws Exception {
        XrtsServiceProto.XRT1002U00GrdComment2Response.Builder response = XrtsServiceProto.XRT1002U00GrdComment2Response.newBuilder();
        List<XRT1002U00GrdCommentInfo> listComment = out0106Repository.getXRT1002U00GrdComment(getHospitalCode(vertx, sessionId), request.getBunho(), "P", "XRT");
        if (!CollectionUtils.isEmpty(listComment)) {
            for (XRT1002U00GrdCommentInfo item : listComment) {
                XrtsModelProto.XRT1002U00GrdCommentInfo.Builder info = XrtsModelProto.XRT1002U00GrdCommentInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addGrdCommentItem(info);
            }

        }
        return response.build();
    }
}