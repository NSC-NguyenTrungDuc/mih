package nta.med.service.ihis.handler.xrts;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.xrt.Xrt0101Repository;
import nta.med.data.model.ihis.xrts.XRT0101U00GrdMcodeInfo;
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

@Service
@Scope("prototype")
public class XRT0101U00GrdMcodeHandler extends ScreenHandler<XrtsServiceProto.XRT0101U00GrdMcodeRequest, XrtsServiceProto.XRT0101U00GrdMcodeResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT0101U00GrdMcodeHandler.class);
    @Resource
    private Xrt0101Repository xrt0101Repositoty;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.XRT0101U00GrdMcodeResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT0101U00GrdMcodeRequest request) throws Exception {
        XrtsServiceProto.XRT0101U00GrdMcodeResponse.Builder response = XrtsServiceProto.XRT0101U00GrdMcodeResponse.newBuilder();
        //list GrdM Code
        List<XRT0101U00GrdMcodeInfo> listGrdMCode = xrt0101Repositoty.getXRT0101U00GrdMCodeListItemInfo(getHospitalCode(vertx, sessionId), request.getCodeType(), getLanguage(vertx, sessionId));
        if (!CollectionUtils.isEmpty(listGrdMCode)) {
            for (XRT0101U00GrdMcodeInfo item : listGrdMCode) {
                XrtsModelProto.XRT0101U00GrdMcodeInfo.Builder info = XrtsModelProto.XRT0101U00GrdMcodeInfo.newBuilder();
                if (!StringUtils.isEmpty(item.getCodeType())) {
                    info.setCodeType(item.getCodeType());
                }
                if (!StringUtils.isEmpty(item.getCodeTypeName())) {
                    info.setCodeTypeName(item.getCodeTypeName());
                }
                response.addMcodeItem(info);
            }
        }
        return response.build();
    }
}