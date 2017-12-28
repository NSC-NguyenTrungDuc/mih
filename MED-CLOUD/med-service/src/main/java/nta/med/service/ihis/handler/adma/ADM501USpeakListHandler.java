package nta.med.service.ihis.handler.adma;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm0002Repository;
import nta.med.data.model.ihis.adma.Adm501UListItemInfo;
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
public class ADM501USpeakListHandler extends ScreenHandler<AdmaServiceProto.ADM501USpeakListRequest, AdmaServiceProto.ADM501UListResponse> {
    private static final Log LOGGER = LogFactory.getLog(ADM501USpeakListHandler.class);
    @Resource
    private Adm0002Repository adm0002Repository;

    @Override
    @Transactional(readOnly = true)
    public AdmaServiceProto.ADM501UListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.ADM501USpeakListRequest request) throws Exception {
        AdmaServiceProto.ADM501UListResponse.Builder response = AdmaServiceProto.ADM501UListResponse.newBuilder();
        List<Adm501UListItemInfo> listItem = adm0002Repository.getAdm501UListItem(request.getMsgGubun(), request.getSearchMsg(), "else");
        if (!CollectionUtils.isEmpty(listItem)) {
            for (Adm501UListItemInfo item : listItem) {
                AdmaModelProto.ADM501UListItemInfo.Builder info = AdmaModelProto.ADM501UListItemInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addListItemInfo(info);
            }
        }
        return response.build();
    }
}