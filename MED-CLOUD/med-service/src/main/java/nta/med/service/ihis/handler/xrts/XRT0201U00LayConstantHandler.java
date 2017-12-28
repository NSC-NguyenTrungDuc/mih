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
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

import java.util.List;

@Service
@Scope("prototype")
public class XRT0201U00LayConstantHandler extends ScreenHandler<XrtsServiceProto.XRT0201U00LayConstantRequest, XrtsServiceProto.XRT0201U00LayConstantResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT0201U00LayConstantHandler.class);
    @Resource
    private Xrt0102Repository xrt0102Repository;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.XRT0201U00LayConstantResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT0201U00LayConstantRequest request) throws Exception {
        XrtsServiceProto.XRT0201U00LayConstantResponse.Builder response = XrtsServiceProto.XRT0201U00LayConstantResponse.newBuilder();
        String hospitalCode = getHospitalCode(vertx, sessionId);
        String language = getLanguage(vertx, sessionId);
        List<XRT0000Q00LayPacsInfoListItemInfo> list = xrt0102Repository.getXRT0000Q00LayPacsInfo(hospitalCode, "XRT_CONSTANT", language, true);
        if (!CollectionUtils.isEmpty(list)) {
            for (XRT0000Q00LayPacsInfoListItemInfo item : list) {
                XrtsModelProto.XRT0000Q00LayPacsInfoListItemInfo.Builder info = XrtsModelProto.XRT0000Q00LayPacsInfoListItemInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addLayConstantItemInfo(info);
                if (item.getCodeName().equalsIgnoreCase("btn_autoAlarm_yn")) {
                    List<XRT0000Q00LayPacsInfoListItemInfo> listConstantInfo = xrt0102Repository.getXRT0000Q00LayPacsInfo(hospitalCode, "XRT_ALARM", language, true);
                    if (!CollectionUtils.isEmpty(listConstantInfo)) {
                        for (XRT0000Q00LayPacsInfoListItemInfo obj : listConstantInfo) {
                            if (obj.getCode().equalsIgnoreCase("XRT")) {
                                response.setAlarmFilePathXrt(obj.getCodeValue());
                            }
                            if (obj.getCode().equalsIgnoreCase("XRT_EM")) {
                                response.setAlarmFilePathXrtEm(obj.getCodeValue());
                            }
                        }
                    }
                }
            }
        }
        return response.build();
    }
}