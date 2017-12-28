package nta.med.service.ihis.handler.xrts;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.xrt.XRT0201U00GrdRadioListItemInfo;
import nta.med.data.dao.medi.xrt.Xrt0202Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.XrtsModelProto;
import nta.med.service.ihis.proto.XrtsServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

import java.util.List;

@Service
@Scope("prototype")
public class XRT0201U00GrdRadioListHandler extends ScreenHandler<XrtsServiceProto.XRT0201U00GrdRadioListRequest, XrtsServiceProto.XRT0201U00GrdRadioListResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT0201U00GrdRadioListHandler.class);
    @Resource
    private Xrt0202Repository xrt0202Repository;

    @Override
    public boolean isValid(XrtsServiceProto.XRT0201U00GrdRadioListRequest request, Vertx vertx, String clientId, String sessionId) {
        if (!StringUtils.isEmpty(request.getOrderDate()) && DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD) == null) {
           return false;
        }
        return true;
    }

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.XRT0201U00GrdRadioListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT0201U00GrdRadioListRequest request) throws Exception {
        XrtsServiceProto.XRT0201U00GrdRadioListResponse.Builder response = XrtsServiceProto.XRT0201U00GrdRadioListResponse.newBuilder();
        List<XRT0201U00GrdRadioListItemInfo> listGrd = xrt0202Repository.getXRT0201U00GrdRadioListItemInfo(getHospitalCode(vertx, sessionId), DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD),
                request.getBunho(), request.getInOutGubun());
        if (!CollectionUtils.isEmpty(listGrd)) {
            for (XRT0201U00GrdRadioListItemInfo item : listGrd) {
                XrtsModelProto.XRT0201U00GrdRadioListItemInfo.Builder info = XrtsModelProto.XRT0201U00GrdRadioListItemInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                if (item.getFkxrt0201() != null) {
                    info.setFkxrt0201(String.format("%.0f", item.getFkxrt0201()));
                }
                response.addGrdRadioListItemInfo(info);
            }
        }
        return response.build();
    }
}