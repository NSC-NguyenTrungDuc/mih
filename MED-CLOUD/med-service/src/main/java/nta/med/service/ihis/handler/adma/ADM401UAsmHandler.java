package nta.med.service.ihis.handler.adma;

import nta.med.core.domain.adm.Adm0400;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm0400Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.AdmaModelProto;
import nta.med.service.ihis.proto.AdmaServiceProto;

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
public class ADM401UAsmHandler extends ScreenHandler<AdmaServiceProto.ADM401UAsmRequest, AdmaServiceProto.ADM401UAsmResponse> {
    private static final Log LOGGER = LogFactory.getLog(ADM401UAsmHandler.class);

    @Resource
    private Adm0400Repository adm0400Repository;

    @Override
    @Transactional(readOnly = true)
    public AdmaServiceProto.ADM401UAsmResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.ADM401UAsmRequest request) throws Exception {
        AdmaServiceProto.ADM401UAsmResponse.Builder response = AdmaServiceProto.ADM401UAsmResponse.newBuilder();
        List<Adm0400> list = adm0400Repository.getADM401UGrdGrp(request.getAsmName());
        if (!CollectionUtils.isEmpty(list)) {
            for (Adm0400 item : list) {
                AdmaModelProto.ADM401UAsmItemInfo.Builder info = AdmaModelProto.ADM401UAsmItemInfo.newBuilder();
                if (!StringUtils.isEmpty(item.getGrpId())) {
                    info.setGrpId(item.getGrpId());
                }
                if (!StringUtils.isEmpty(item.getSysId())) {
                    info.setSysId(item.getSysId());
                }
                if (!StringUtils.isEmpty(item.getAsmType())) {
                    info.setAsmType(item.getAsmType());
                }
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addAsmItemInfo(info);
            }
        }
        return response.build();
    }
}
