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
public class XRT0101U00GrdDcodeHandler extends ScreenHandler<XrtsServiceProto.XRT0101U00GrdDcodeRequest, XrtsServiceProto.XRT0101U00GrdDcodeResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT0101U00GrdDcodeHandler.class);
    @Resource
    private Xrt0102Repository xrt0102Repository;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.XRT0101U00GrdDcodeResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT0101U00GrdDcodeRequest request) throws Exception {
        XrtsServiceProto.XRT0101U00GrdDcodeResponse.Builder response = XrtsServiceProto.XRT0101U00GrdDcodeResponse.newBuilder();
        //list GrdD Code
        List<XRT0101U00GrdDcodeInfo> listGrdDCode = xrt0102Repository.getXRT0101U00GrdDCodeListItemInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getCodeType());
        if (!CollectionUtils.isEmpty(listGrdDCode)) {
            for (XRT0101U00GrdDcodeInfo item : listGrdDCode) {
                XrtsModelProto.XRT0101U00GrdDcodeInfo.Builder info = XrtsModelProto.XRT0101U00GrdDcodeInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                if (item.getSeq() != null) {
                    info.setSeq(String.format("%.0f", item.getSeq()));
                }
                response.addDcodeItem(info);
            }
        }
        return response.build();
    }
}