package nta.med.service.ihis.handler.xrts;

import nta.med.core.domain.xrt.Xrt0102;
import nta.med.data.dao.medi.xrt.Xrt0102Repository;
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
public class XRT0123U00grdMCodeHandler extends ScreenHandler<XrtsServiceProto.XRT0123U00grdMCodeRequest, XrtsServiceProto.XRT0123U00grdMCodeResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT0123U00grdMCodeHandler.class);
    @Resource
    private Xrt0102Repository xrt0102Repository;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.XRT0123U00grdMCodeResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT0123U00grdMCodeRequest request) throws Exception {
        XrtsServiceProto.XRT0123U00grdMCodeResponse.Builder response = XrtsServiceProto.XRT0123U00grdMCodeResponse.newBuilder();
        List<Xrt0102> listMCode = xrt0102Repository.getByCodeTypeAndCode(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), "X1", request.getXrayGubun());
        if (!CollectionUtils.isEmpty(listMCode)) {
            for (Xrt0102 item : listMCode) {
                CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
                if (!StringUtils.isEmpty(item.getCode())) {
                    info.setCode(item.getCode());
                }
                if (!StringUtils.isEmpty(item.getCodeName())) {
                    info.setCodeName(item.getCodeName());
                }
                response.addListGrd(info);
            }
        }
        return response.build();
    }
}