package nta.med.service.ihis.handler.adma;

import nta.med.core.glossary.UserRole;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm0200Repository;
import nta.med.data.dao.medi.adm.Adm108UTvwSystemListItemInfo;
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
public class ADM108UTvwSystemListHandler extends ScreenHandler<AdmaServiceProto.ADM108UTvwSystemListRequest, AdmaServiceProto.ADM108UTvwSystemListResponse> {
    private static final Log LOGGER = LogFactory.getLog(ADM108UTvwSystemListHandler.class);
    
    @Resource
    private Adm0200Repository adm0200Repository;
    
    @Override
    public boolean isAuthorized(Vertx vertx, String sessionId){

		return UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))
				|| UserRole.NORMAL_ADMIN.getValue().equals(getUserRole(vertx, sessionId));
    }
    
    @Override
    @Transactional(readOnly = true)
    public AdmaServiceProto.ADM108UTvwSystemListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.ADM108UTvwSystemListRequest request) throws Exception {
        AdmaServiceProto.ADM108UTvwSystemListResponse.Builder response = AdmaServiceProto.ADM108UTvwSystemListResponse.newBuilder();

        List<Adm108UTvwSystemListItemInfo> list = adm0200Repository.getAdm108UTvwSystemListItem(getLanguage(vertx, sessionId), request.getPgmId());
        if (!CollectionUtils.isEmpty(list)) {
            for (Adm108UTvwSystemListItemInfo item : list) {
                AdmaModelProto.ADM108UTvwSystemListItemInfo.Builder info = AdmaModelProto.ADM108UTvwSystemListItemInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addTvwSystemListItemInfo(info);
            }
        }
        
        return response.build();
    }
}