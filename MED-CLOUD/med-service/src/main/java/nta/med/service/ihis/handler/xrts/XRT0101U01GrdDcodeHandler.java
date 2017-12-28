package nta.med.service.ihis.handler.xrts;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.xrt.Xrt0102Repository;
import nta.med.data.model.ihis.xrts.XRT0101U00GrdDcodeInfo;
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
public class XRT0101U01GrdDcodeHandler extends ScreenHandler<XrtsServiceProto.XRT0101U01GrdDcodeRequest, XrtsServiceProto.XRT0101U01GrdDcodeResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT0101U01GrdDcodeHandler.class);
    @Resource
    private Xrt0102Repository xrt0102Repository;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.XRT0101U01GrdDcodeResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT0101U01GrdDcodeRequest request) throws Exception {
        XrtsServiceProto.XRT0101U01GrdDcodeResponse.Builder response = XrtsServiceProto.XRT0101U01GrdDcodeResponse.newBuilder();
        List<XRT0101U00GrdDcodeInfo> listItem = xrt0102Repository.getXRT0101U00GrdDCodeListItemInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getCodeType());
        if (!CollectionUtils.isEmpty(listItem)) {
            for (XRT0101U00GrdDcodeInfo item : listItem) {
                XrtsModelProto.XRT0101U01GrdDcodeListItemInfo.Builder info = XrtsModelProto.XRT0101U01GrdDcodeListItemInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addGrdList(info);
            }
        }
        return response.build();
    }
}