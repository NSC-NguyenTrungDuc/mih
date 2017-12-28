package nta.med.service.ihis.handler.adma;

import nta.med.core.glossary.UserRole;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm0300Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.AdmaServiceProto;
import nta.med.service.ihis.proto.CommonModelProto;

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
public class ADM106UFwkPgmIDHandler extends ScreenHandler<AdmaServiceProto.ADM106UFwkPgmIDRequest, AdmaServiceProto.ADM106UFwkPgmIDResponse> {
    private static final Log LOGGER = LogFactory.getLog(ADM106UFwkPgmIDHandler.class);
    @Resource
    private Adm0300Repository adm0300Repository;
    @Override
    public boolean isAuthorized(Vertx vertx, String sessionId){

        return UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId));
    }
    @Override
    @Transactional(readOnly = true)
    public AdmaServiceProto.ADM106UFwkPgmIDResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.ADM106UFwkPgmIDRequest request) throws Exception {
        AdmaServiceProto.ADM106UFwkPgmIDResponse.Builder response = AdmaServiceProto.ADM106UFwkPgmIDResponse.newBuilder();
        List<ComboListItemInfo> list = adm0300Repository.getAdm106UFwkPgmIdListItem(request.getPgmId(), getLanguage(vertx, sessionId));
        if (!CollectionUtils.isEmpty(list)) {
            for (ComboListItemInfo item : list) {
                CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addFwkList(info);
            }
        }
        return response.build();
    }
}