package nta.med.service.ihis.handler.adma;

import nta.med.core.glossary.UserRole;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm0300Repository;
import nta.med.data.model.ihis.adma.Adm106UMakeQueryListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.AdmaModelProto;
import nta.med.service.ihis.proto.AdmaServiceProto;

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
public class ADM106UMakeQueryListItemHandler extends ScreenHandler<AdmaServiceProto.ADM106UMakeQueryListItemRequest, AdmaServiceProto.ADM106UMakeQueryListItemResponse> {
    private static final Log LOGGER = LogFactory.getLog(ADM106UMakeQueryListItemHandler.class);
    @Resource
    private Adm0300Repository adm0300Repository;
    @Override
    public boolean isAuthorized(Vertx vertx, String sessionId){

        return UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId));
    }
    @Override
    @Transactional(readOnly = true)
    public AdmaServiceProto.ADM106UMakeQueryListItemResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.ADM106UMakeQueryListItemRequest request) throws Exception {
        AdmaServiceProto.ADM106UMakeQueryListItemResponse.Builder response = AdmaServiceProto.ADM106UMakeQueryListItemResponse.newBuilder();
        List<Adm106UMakeQueryListItemInfo> list = adm0300Repository.getAdm106UMakeQueryListItem(getHospitalCode(vertx, sessionId), request.getSysId(),
                request.getUpperMenu(), getLanguage(vertx, sessionId), getUserRole(vertx, sessionId));
        if (!CollectionUtils.isEmpty(list)) {
            for (Adm106UMakeQueryListItemInfo item : list) {
                AdmaModelProto.ADM106UMakeQueryListItemInfo.Builder info = AdmaModelProto.ADM106UMakeQueryListItemInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addListInfo(info);
            }
        }
        return response.build();
    }
}