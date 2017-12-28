package nta.med.service.ihis.handler.adma;

import nta.med.core.common.annotation.Route;
import nta.med.core.domain.fabric.FabricGroup;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.fabric.FabricGroupRepository;
import nta.med.service.ihis.proto.AdmaModelProto;
import nta.med.service.ihis.proto.AdmaServiceProto;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.List;

/**
 * @author dainguyen.
 */
@Service
@Scope("prototype")
public class Adms2016U00GetMaintainanceSettingHandler extends ScreenHandler<AdmaServiceProto.Adms2016U00GetMaintainanceSettingRequest, AdmaServiceProto.Adms2016U00GetMaintainanceSettingResponse> {

    @Resource
    private FabricGroupRepository fabricGroupRepository;

    @Override
    @Transactional(readOnly = true)
    @Route(global = true)
    public AdmaServiceProto.Adms2016U00GetMaintainanceSettingResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.Adms2016U00GetMaintainanceSettingRequest request) throws Exception {
        AdmaServiceProto.Adms2016U00GetMaintainanceSettingResponse.Builder response = AdmaServiceProto.Adms2016U00GetMaintainanceSettingResponse.newBuilder();

        List<FabricGroup> groups = fabricGroupRepository.findAll();
        for (FabricGroup fg : groups) {
            AdmaModelProto.MaintainanceSettingInfo.Builder item = AdmaModelProto.MaintainanceSettingInfo.newBuilder()
                    .setHospGroupCd(fg.getHospGroupCd())
                    .setHospGroupName(fg.getHospGroupName())
                    .setMaintenanceMode(fg.getMaintenanceMode() == null ? 0 : fg.getMaintenanceMode().intValue());
            response.addMaintainanceSettings(item);
        }

        return response.build();
    }
}
