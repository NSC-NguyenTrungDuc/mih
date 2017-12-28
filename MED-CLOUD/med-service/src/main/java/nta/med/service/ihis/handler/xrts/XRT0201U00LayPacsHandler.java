package nta.med.service.ihis.handler.xrts;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.xrt.Xrt0001Repository;
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
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

import java.util.List;

@Service
@Scope("prototype")
public class XRT0201U00LayPacsHandler extends ScreenHandler<XrtsServiceProto.XRT0201U00LayPacsRequest, XrtsServiceProto.XRT0201U00LayPacsResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT0201U00LayPacsHandler.class);
    @Resource
    private Xrt0102Repository xrt0102Repository;
    @Resource
    private Xrt0001Repository xrt0001Repository;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.XRT0201U00LayPacsResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT0201U00LayPacsRequest request) throws Exception {
        XrtsServiceProto.XRT0201U00LayPacsResponse.Builder response = XrtsServiceProto.XRT0201U00LayPacsResponse.newBuilder();
        String hospitalCode = getHospitalCode(vertx, sessionId);
        String language = getLanguage(vertx, sessionId);
        // layPacsInfo
        List<XRT0000Q00LayPacsInfoListItemInfo> listLayPacsInfo = xrt0102Repository.getXRT0000Q00LayPacsInfo(hospitalCode, "PACS_INFO", language, false);
        if (!CollectionUtils.isEmpty(listLayPacsInfo)) {
            for (XRT0000Q00LayPacsInfoListItemInfo item : listLayPacsInfo) {
                XrtsModelProto.XRT0000Q00LayPacsInfoListItemInfo.Builder info = XrtsModelProto.XRT0000Q00LayPacsInfoListItemInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addLayPacsItemInfo(info);
            }
        }

        // modalityCode

        String modality = xrt0001Repository.getXRT0000Q00GetModalityCode(hospitalCode, request.getHangmogCode());
        if (!StringUtils.isEmpty(modality)) {
            response.setModality(modality);
        }
        return response.build();
    }
}