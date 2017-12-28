package nta.med.service.ihis.handler.adma;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm0200Repository;
import nta.med.data.model.ihis.adma.ADM401UGrdSysItemInfo;
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
public class ADM401UGrdSysHandler extends ScreenHandler<AdmaServiceProto.ADM401UGrdSysRequest, AdmaServiceProto.ADM401UGrdSysResponse> {
    private static final Log LOGGER = LogFactory.getLog(ADM401UGrdSysHandler.class);
    @Resource
    private Adm0200Repository adm0200Repository;

    @Override
    @Transactional(readOnly = true)
    public AdmaServiceProto.ADM401UGrdSysResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.ADM401UGrdSysRequest request) throws Exception {
        AdmaServiceProto.ADM401UGrdSysResponse.Builder response = AdmaServiceProto.ADM401UGrdSysResponse.newBuilder();
        List<ADM401UGrdSysItemInfo> list = adm0200Repository.getADM401UGrdSysItemInfo(getLanguage(vertx, sessionId), request.getGrpId());
        if (!CollectionUtils.isEmpty(list)) {
            for (ADM401UGrdSysItemInfo item : list) {
                AdmaModelProto.ADM401UGrdSysItemInfo.Builder info = AdmaModelProto.ADM401UGrdSysItemInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addGrdSysItemInfo(info);
            }
        }
        return response.build();
    }
}
