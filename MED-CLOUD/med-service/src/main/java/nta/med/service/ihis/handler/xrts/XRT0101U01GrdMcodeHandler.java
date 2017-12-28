package nta.med.service.ihis.handler.xrts;

import nta.med.core.domain.xrt.Xrt0101;
import nta.med.data.dao.medi.xrt.Xrt0101Repository;
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
public class XRT0101U01GrdMcodeHandler extends ScreenHandler<XrtsServiceProto.XRT0101U01GrdMcodeRequest, XrtsServiceProto.XRT0101U01GrdMcodeResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT0101U01GrdMcodeHandler.class);
    @Resource
    private Xrt0101Repository xrt0101Repository;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.XRT0101U01GrdMcodeResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT0101U01GrdMcodeRequest request) throws Exception {
        XrtsServiceProto.XRT0101U01GrdMcodeResponse.Builder response = XrtsServiceProto.XRT0101U01GrdMcodeResponse.newBuilder();
        List<Xrt0101> listItem = xrt0101Repository.getXRT0101U01Object("%" + request.getCodeType() + "%", getLanguage(vertx, sessionId));
        if (!CollectionUtils.isEmpty(listItem)) {
            for (Xrt0101 item : listItem) {
                XrtsModelProto.XRT0101U01GrdMcodeListItemInfo.Builder info = XrtsModelProto.XRT0101U01GrdMcodeListItemInfo.newBuilder();
                if (!StringUtils.isEmpty(item.getAdminGubun())) {
                    info.setAdminGubun(item.getAdminGubun());
                }
                if (!StringUtils.isEmpty(item.getCodeType())) {
                    info.setCodeType(item.getCodeType());
                }
                if (!StringUtils.isEmpty(item.getCodeTypeName())) {
                    info.setCodeTypeName(item.getCodeTypeName());
                }

                response.addGrdList(info);
            }
        }
        return response.build();
    }
}