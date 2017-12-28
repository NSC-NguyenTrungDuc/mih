package nta.med.service.ihis.handler.xrts;

import nta.med.data.dao.medi.xrt.Xrt0121Repository;
import nta.med.data.model.ihis.xrts.XRT0122U00GrdMcodeInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
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
public class Xrt0122Q00GrdMCodeHandler extends ScreenHandler<XrtsServiceProto.Xrt0122Q00GrdMCodeRequest, XrtsServiceProto.Xrt0122Q00GrdMCodeResponse> {
    private static final Log LOGGER = LogFactory.getLog(Xrt0122Q00GrdMCodeHandler.class);
    @Resource
    private Xrt0121Repository xrt0121Repository;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.Xrt0122Q00GrdMCodeResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.Xrt0122Q00GrdMCodeRequest request) throws Exception {
        XrtsServiceProto.Xrt0122Q00GrdMCodeResponse.Builder response = XrtsServiceProto.Xrt0122Q00GrdMCodeResponse.newBuilder();
        List<XRT0122U00GrdMcodeInfo> listGrd = xrt0121Repository.getInitializeItem(getHospitalCode(vertx, sessionId), request.getBuwiBunryu(), getLanguage(vertx, sessionId));
        if (!CollectionUtils.isEmpty(listGrd)) {
            for (XRT0122U00GrdMcodeInfo item : listGrd) {
                CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
                if (!StringUtils.isEmpty(item.getBuwiBunryu())) {
                    info.setCode(item.getBuwiBunryu());
                }
                if (!StringUtils.isEmpty(item.getBuwiBunryuName())) {
                    info.setCodeName(item.getBuwiBunryuName());
                }
                response.addInfoList(info);
            }
        }
        return response.build();
    }
}