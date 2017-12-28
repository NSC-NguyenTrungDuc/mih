package nta.med.service.ihis.handler.xrts;

import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.XrtsServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

@Service
@Scope("prototype")
public class XRT0201U00OcsCommonHandler extends ScreenHandler<XrtsServiceProto.XRT0201U00OcsCommonRequest, XrtsServiceProto.XRT0201U00OcsCommonResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT0201U00OcsCommonHandler.class);
    @Resource
    private Adm3200Repository adm3200Repository;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.XRT0201U00OcsCommonResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT0201U00OcsCommonRequest request) throws Exception {
        XrtsServiceProto.XRT0201U00OcsCommonResponse.Builder response = XrtsServiceProto.XRT0201U00OcsCommonResponse.newBuilder();
        String result = adm3200Repository.getCPL3020U00LayCommon(getHospitalCode(vertx, sessionId), "XRT", request.getUserId());
        if (!StringUtils.isEmpty(result)) {
            CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
            info.setDataValue(result);
            response.addUserNameItemInfo(info);
        }
        return response.build();
    }
}