package nta.med.service.ihis.handler.xrts;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.xrt.Xrt0102Repository;
import nta.med.data.model.ihis.xrts.XRT0000Q00LayPacsInfoListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.XrtsModelProto;
import nta.med.service.ihis.proto.XrtsServiceProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.List;

@Transactional
@Service
@Scope("prototype")
public class XRT0000Q00LayPacsInfoHandler extends ScreenHandler<XrtsServiceProto.XRT0000Q00LayPacsInfoRequest, XrtsServiceProto.XRT0000Q00LayPacsInfoResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT0000Q00LayPacsInfoHandler.class);
    @Resource
    private Xrt0102Repository xrt0102Repository;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.XRT0000Q00LayPacsInfoResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT0000Q00LayPacsInfoRequest request) throws Exception {
        XrtsServiceProto.XRT0000Q00LayPacsInfoResponse.Builder response = XrtsServiceProto.XRT0000Q00LayPacsInfoResponse.newBuilder();
        List<XRT0000Q00LayPacsInfoListItemInfo> listLayPacs = xrt0102Repository.getXRT0000Q00LayPacsInfo(getHospitalCode(vertx, sessionId), request.getCodeType(), getLanguage(vertx, sessionId), false);
        if (listLayPacs != null && !listLayPacs.isEmpty()) {
            for (XRT0000Q00LayPacsInfoListItemInfo item : listLayPacs) {
                XrtsModelProto.XRT0000Q00LayPacsInfoListItemInfo.Builder info = XrtsModelProto.XRT0000Q00LayPacsInfoListItemInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addLayPacsInfoList(info);
            }
        }
        return response.build();
    }
}
