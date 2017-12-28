package nta.med.service.ihis.handler.drgs;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;
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
public class DRG0201U00CbxActorHandler extends ScreenHandler<DrgsServiceProto.DRG0201U00CbxActorRequest, DrgsServiceProto.DRG0201U00CbxActorResponse> {
    private static final Log LOGGER = LogFactory.getLog(DRG0201U00CbxActorHandler.class);
    @Resource
    private Adm3200Repository adm3200Repository;

    @Override
    @Transactional(readOnly = true)
    public DrgsServiceProto.DRG0201U00CbxActorResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DRG0201U00CbxActorRequest request) throws Exception {
        DrgsServiceProto.DRG0201U00CbxActorResponse.Builder response = DrgsServiceProto.DRG0201U00CbxActorResponse.newBuilder();
        List<ComboListItemInfo> listCbx = adm3200Repository.getDRG0201U00CbxActor(getHospitalCode(vertx, sessionId), "DRG", true);
        if (!CollectionUtils.isEmpty(listCbx)) {
            for (ComboListItemInfo item : listCbx) {
                CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addCbxActorItem(info);
            }
        }
        return response.build();
    }
}