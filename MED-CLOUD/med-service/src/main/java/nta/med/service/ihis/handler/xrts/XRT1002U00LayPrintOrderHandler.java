package nta.med.service.ihis.handler.xrts;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.xrt.Xrt0001Repository;
import nta.med.data.model.ihis.xrts.XRT1002U00LayPrintOrderInfo;
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
public class XRT1002U00LayPrintOrderHandler extends ScreenHandler<XrtsServiceProto.XRT1002U00LayPrintOrderRequest, XrtsServiceProto.XRT1002U00LayPrintOrderResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT1002U00LayPrintOrderHandler.class);
    @Resource
    private Xrt0001Repository xrt0001Repository;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.XRT1002U00LayPrintOrderResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT1002U00LayPrintOrderRequest request) throws Exception {
        XrtsServiceProto.XRT1002U00LayPrintOrderResponse.Builder response = XrtsServiceProto.XRT1002U00LayPrintOrderResponse.newBuilder();
        Double pkocs = CommonUtils.parseDouble(request.getPkocs());
        List<XRT1002U00LayPrintOrderInfo> listItem = xrt0001Repository.getXRT1002U00LayPrintOrderInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getOrderDate(), request.getGwa(), request.getInOutGubun(), pkocs);
        if (!CollectionUtils.isEmpty(listItem)) {
            for (XRT1002U00LayPrintOrderInfo item : listItem) {
                XrtsModelProto.XRT1002U00LayPrintOrderInfo.Builder info = XrtsModelProto.XRT1002U00LayPrintOrderInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addLayPrintOrderItem(info);
            }
        }
        return response.build();
    }
}