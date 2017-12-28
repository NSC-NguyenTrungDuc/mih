package nta.med.service.ihis.handler.adma;

import nta.med.core.common.annotation.Route;
import nta.med.core.domain.fabric.FabricGroup;
import nta.med.core.glossary.AdministrationNotice;
import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.fabric.FabricGroupRepository;
import nta.med.service.ihis.proto.AdmaModelProto;
import nta.med.service.ihis.proto.AdmaServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.math.BigDecimal;
import java.util.List;

/**
 * @author dainguyen.
 */
@Service
@Scope("prototype")
public class Adms2016U00SaveMaintainanceSettingHandler extends ScreenHandler<AdmaServiceProto.Adms2016U00SaveMaintainanceSettingRequest, SystemServiceProto.UpdateResponse>{

    @Resource
    private FabricGroupRepository fabricGroupRepository;

    @Transactional
    @Override
    @Route(global = true)
    public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.Adms2016U00SaveMaintainanceSettingRequest request) throws Exception {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder().setResult(false);

        if(request.getMaintainanceSettingsCount() > 0) {
            List<FabricGroup> fabricGroups = fabricGroupRepository.findAll();
            for(AdmaModelProto.MaintainanceSettingInfo item : request.getMaintainanceSettingsList()) {
                for (FabricGroup fg : fabricGroups) {
                    if(item.getHospGroupCd().equals(fg.getHospGroupCd())) {
                        fg.setMaintenanceMode(new BigDecimal(item.getMaintenanceMode()));
                        if(fg.getHospGroupCd().equalsIgnoreCase("ALL")) {
                            vertx.eventBus().publish(AdministrationNotice.MAINTAINANCE_WHOLE_SYSTEM_NOTICE.getAddress(), item.getMaintenanceMode());
                        }
                    }
                }
            }
            fabricGroupRepository.save(fabricGroups);
            vertx.eventBus().publish(AdministrationNotice.MAINTAINANCE_NOTICE.getAddress(), request.toByteArray());
        }

        response.setResult(true);
        return response.build();
    }

    @Override
    public boolean isAuthorized(Vertx vertx, String sessionId) {
        return UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId));
    }
}
