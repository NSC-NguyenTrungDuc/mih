package nta.med.service.ihis.handler.xrts;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0108Repository;
import nta.med.data.model.ihis.ocso.OCSACTGetFindWorkerInfo;
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
public class XRT0201U00FwkOrdDanuiNameHandler extends ScreenHandler<XrtsServiceProto.XRT0201U00FwkOrdDanuiNameRequest, XrtsServiceProto.XRT0201U00FwkOrdDanuiResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT0201U00FwkOrdDanuiNameHandler.class);
    @Resource
    private Ocs0108Repository ocs0108Repository;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.XRT0201U00FwkOrdDanuiResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT0201U00FwkOrdDanuiNameRequest request) throws Exception {
        XrtsServiceProto.XRT0201U00FwkOrdDanuiResponse.Builder response = XrtsServiceProto.XRT0201U00FwkOrdDanuiResponse.newBuilder();
        List<OCSACTGetFindWorkerInfo> list = ocs0108Repository.getOCSACTGetFindWorkerInfoCaseOrdDanuiName(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getHangmogCode());
        if (!CollectionUtils.isEmpty(list)) {
            for (OCSACTGetFindWorkerInfo item : list) {
                XrtsModelProto.XRT0201U00FwkOrdDanuiItemInfo.Builder info = XrtsModelProto.XRT0201U00FwkOrdDanuiItemInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                if(!StringUtils.isEmpty(item.getCodeName())){
                	info.setOrdDanuiName(item.getCodeName());
                }
                response.addFwkOrdDanuiItemInfo(info);
            }
        }
        return response.build();
    }
}