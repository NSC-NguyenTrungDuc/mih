package nta.med.service.ihis.handler.xrts;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.xrt.Xrt0202Repository;
import nta.med.data.model.ihis.xrts.XRT7001Q01LayRadioHistoryListItemInfo;
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

@Transactional
@Service
@Scope("prototype")
public class XRT7001Q01LayRadioHistoryHandler extends ScreenHandler<XrtsServiceProto.XRT7001Q01LayRadioHistoryRequest, XrtsServiceProto.XRT7001Q01LayRadioHistoryResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT7001Q01LayRadioHistoryHandler.class);
    @Resource
    private Xrt0202Repository xrt0202Repository;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.XRT7001Q01LayRadioHistoryResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT7001Q01LayRadioHistoryRequest request) throws Exception {
        XrtsServiceProto.XRT7001Q01LayRadioHistoryResponse.Builder response = XrtsServiceProto.XRT7001Q01LayRadioHistoryResponse.newBuilder();
        List<XRT7001Q01LayRadioHistoryListItemInfo> listLayRadio = xrt0202Repository.getXRT7001Q01LayRadioHistoryListItemInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getBunho(), request.getPartCode());
        if (!CollectionUtils.isEmpty(listLayRadio)) {
            for (XRT7001Q01LayRadioHistoryListItemInfo item : listLayRadio) {
                XrtsModelProto.XRT7001Q01LayRadioHistoryListItemInfo.Builder info = XrtsModelProto.XRT7001Q01LayRadioHistoryListItemInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addLayRadioHistoryList(info);
            }
        }
        return response.build();
    }
}
