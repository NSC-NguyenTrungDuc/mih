package nta.med.service.ihis.handler.xrts;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
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
public class XRT0201U00FwkActorHandler extends ScreenHandler<XrtsServiceProto.XRT0201U00FwkActorRequest, XrtsServiceProto.XRT0201U00FwkActorResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT0201U00FwkActorHandler.class);
    @Resource
    private Adm3200Repository adm3200Repository;

    @Override
    @Transactional(readOnly = true)
    public XrtsServiceProto.XRT0201U00FwkActorResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT0201U00FwkActorRequest request) throws Exception {
        XrtsServiceProto.XRT0201U00FwkActorResponse.Builder response = XrtsServiceProto.XRT0201U00FwkActorResponse.newBuilder();
        List<ComboListItemInfo> list = adm3200Repository.getFwkActorListItem(getHospitalCode(vertx, sessionId), "XRT", false);
        if (!CollectionUtils.isEmpty(list)) {
            for (ComboListItemInfo item : list) {
                CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addUserItemInfo(info);
            }
        }
        return response.build();
    }
}