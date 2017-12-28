package nta.med.service.ihis.handler.xrts;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.xrt.Xrt0001Repository;
import nta.med.data.model.ihis.xrts.XRT0001U00GrdXRTInfo;
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

@Service
@Scope("prototype")
public class XRT0001U00GrdXRTHandler extends ScreenHandler<XrtsServiceProto.XRT0001U00GrdXRTRequest, XrtsServiceProto.XRT0001U00GrdXRTResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT0001U00GrdXRTHandler.class);
    @Resource
    private Xrt0001Repository xrt0001Repository;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.XRT0001U00GrdXRTResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT0001U00GrdXRTRequest request) throws Exception {
        XrtsServiceProto.XRT0001U00GrdXRTResponse.Builder response = XrtsServiceProto.XRT0001U00GrdXRTResponse.newBuilder();
        //get grdXRT_list
        List<XRT0001U00GrdXRTInfo> listGrdXrt = xrt0001Repository.getXRT0001U00GrdXRTListItemInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getTxtParam(), request.getXrayGubun(), request.getSpecialYn());
        if (listGrdXrt != null && !listGrdXrt.isEmpty()) {
            for (XRT0001U00GrdXRTInfo item : listGrdXrt) {
                XrtsModelProto.XRT0001U00GrdXRTInfo.Builder info = XrtsModelProto.XRT0001U00GrdXRTInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addGrdXrtItem(info);
            }
        }
        return response.build();
    }
}