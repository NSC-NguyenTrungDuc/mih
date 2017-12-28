package nta.med.service.ihis.handler.xrts;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.xrt.Xrt0122Repository;
import nta.med.data.model.ihis.xrts.XRT0122Q00GrdDCodeListItemInfo;
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
public class Xrt0122Q00GrdDCodeHandler extends ScreenHandler<XrtsServiceProto.Xrt0122Q00GrdDCodeRequest, XrtsServiceProto.Xrt0122Q00GrdDCodeResponse> {
    private static final Log LOGGER = LogFactory.getLog(Xrt0122Q00GrdDCodeHandler.class);
    @Resource
    private Xrt0122Repository xrt0122Repository;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.Xrt0122Q00GrdDCodeResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.Xrt0122Q00GrdDCodeRequest request) throws Exception {
        XrtsServiceProto.Xrt0122Q00GrdDCodeResponse.Builder response = XrtsServiceProto.Xrt0122Q00GrdDCodeResponse.newBuilder();
        List<XRT0122Q00GrdDCodeListItemInfo> listGrd = xrt0122Repository.getXRT0122Q00GrdDCodeListItemInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),
                request.getBuwiBunryu(), request.getFlag(), request.getBuwiCode(), request.getBuwiName());
        if (!CollectionUtils.isEmpty(listGrd)) {
            for (XRT0122Q00GrdDCodeListItemInfo item : listGrd) {
                XrtsModelProto.Xrt0122Q00GrdDCodeListItemInfo.Builder info = XrtsModelProto.Xrt0122Q00GrdDCodeListItemInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addInfoList(info);
            }
        }
        return response.build();
    }
}