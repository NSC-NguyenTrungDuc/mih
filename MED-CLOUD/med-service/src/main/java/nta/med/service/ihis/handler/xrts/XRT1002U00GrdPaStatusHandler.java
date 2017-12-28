package nta.med.service.ihis.handler.xrts;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs1801Repository;
import nta.med.data.model.ihis.xrts.XRT1002U00GrdPaStatusInfo;
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
public class XRT1002U00GrdPaStatusHandler extends ScreenHandler<XrtsServiceProto.XRT1002U00GrdPaStatusRequest, XrtsServiceProto.XRT1002U00GrdPaStatusResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT1002U00GrdPaStatusHandler.class);
    @Resource
    private Ocs1801Repository ocs1801Repository;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.XRT1002U00GrdPaStatusResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT1002U00GrdPaStatusRequest request) throws Exception {
        XrtsServiceProto.XRT1002U00GrdPaStatusResponse.Builder response = XrtsServiceProto.XRT1002U00GrdPaStatusResponse.newBuilder();
        List<XRT1002U00GrdPaStatusInfo> listItem = ocs1801Repository.getXRT1002U00GrdPaStatusInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getBunho(), request.getHangmogCode());
        if (!CollectionUtils.isEmpty(listItem)) {
            for (XRT1002U00GrdPaStatusInfo item : listItem) {
                XrtsModelProto.XRT1002U00GrdPaStatusInfo.Builder info = XrtsModelProto.XRT1002U00GrdPaStatusInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                if (item.getSeq() != null) {
                    info.setSeq(String.format("%.0f", item.getSeq()));
                }
                response.addGrdPaStatusItem(info);
            }
        }
        return response.build();
    }
}