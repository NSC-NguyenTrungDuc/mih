package nta.med.service.ihis.handler.xrts;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.model.ihis.xrts.XRT0201U00GrdOrderItemInfo;
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
public class XRT0201U00GrdOrderHandler extends ScreenHandler<XrtsServiceProto.XRT0201U00GrdOrderRequest, XrtsServiceProto.XRT0201U00GrdOrderResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT0201U00GrdOrderHandler.class);
    @Resource
    private Ocs0103Repository ocs0103Repository;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.XRT0201U00GrdOrderResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT0201U00GrdOrderRequest request) throws Exception {
        XrtsServiceProto.XRT0201U00GrdOrderResponse.Builder response = XrtsServiceProto.XRT0201U00GrdOrderResponse.newBuilder();
        List<XRT0201U00GrdOrderItemInfo> list = ocs0103Repository.getXRT0201U00GrdOrderItem(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getIoGubun(),
                request.getActGubun(), request.getReserYn(), DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD),
                DateUtil.toDate(request.getFromDate(), DateUtil.PATTERN_YYMMDD), DateUtil.toDate(request.getToDate(), DateUtil.PATTERN_YYMMDD),
                request.getNaewonKey(), request.getEmergency(), request.getJundalTableCode(), request.getJundalPart(), request.getBunho(), request.getDoctor());
        if (!CollectionUtils.isEmpty(list)) {
            for (XRT0201U00GrdOrderItemInfo item : list) {
                XrtsModelProto.XRT0201U00GrdOrderItemInfo.Builder info = XrtsModelProto.XRT0201U00GrdOrderItemInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                info.setSunabSuryang(CommonUtils.parseString(item.getSunabSuryang()));
                response.addGrdOrderItemInfo(info);
            }
        }
        return response.build();
    }
}