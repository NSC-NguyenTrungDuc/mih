package nta.med.service.ihis.handler.xrts;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.xrt.Xrt0102Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.XrtsServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class XRT1002U00GrdXrayMethodHandler extends ScreenHandler<XrtsServiceProto.XRT1002U00GrdXrayMethodRequest, SystemServiceProto.ComboResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT1002U00GrdXrayMethodHandler.class);
    @Resource
    private Xrt0102Repository xrt0102Repository;

    @Override
    @Transactional(readOnly = true)
    public SystemServiceProto.ComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT1002U00GrdXrayMethodRequest request) throws Exception {
        SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();
        List<ComboListItemInfo> listCombo = xrt0102Repository.getXRT1002U00GrdXrayMethod(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getCodeType());
        if (!CollectionUtils.isEmpty(listCombo)) {
            for (ComboListItemInfo item : listCombo) {
                CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addComboItem(info);
            }
        }
        return response.build();
    }
}