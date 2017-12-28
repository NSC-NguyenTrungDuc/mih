package nta.med.service.ihis.handler.adma;

import nta.med.core.common.annotation.Route;
import nta.med.core.domain.adm.Adm0100;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm0100Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.AdmaServiceProto;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.lang.StringUtils;
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
public class ADM401UGrdGrpHandler extends ScreenHandler<AdmaServiceProto.ADM401UGrdGrpRequest, SystemServiceProto.ComboResponse> {
    private static final Log LOGGER = LogFactory.getLog(ADM401UGrdGrpHandler.class);

    @Resource
    private Adm0100Repository adm0100Repository;

    @Override
    @Route(global = true)
    @Transactional(readOnly = true)
    public SystemServiceProto.ComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.ADM401UGrdGrpRequest request) throws Exception {
        SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();
        List<Adm0100> list = adm0100Repository.getADM401UGrdGrp(getLanguage(vertx, sessionId));
        if (!CollectionUtils.isEmpty(list)) {
            for (Adm0100 item : list) {
                CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
                if (!StringUtils.isEmpty(item.getGrpId())) {
                    info.setCode(item.getGrpId());
                }
                if (!StringUtils.isEmpty(item.getGrpNm())) {
                    info.setCodeName(item.getGrpNm());
                }
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addComboItem(info);
            }
        }
        return response.build();
    }
}
