package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.adm.Adm0100Repository;
import nta.med.data.model.ihis.system.MainMenuInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemModelProto.MainMenuItemInfo;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.MainMenuRequest;
import nta.med.service.ihis.proto.SystemServiceProto.MainMenuResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class MainMenuHandler
	extends ScreenHandler<SystemServiceProto.MainMenuRequest, SystemServiceProto.MainMenuResponse>{
    @Resource
    private Adm0100Repository adm0100Repository;

    @Override
    @Transactional(readOnly = true)
    public MainMenuResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, MainMenuRequest request)
			throws Exception {
        List<MainMenuInfo> listMenuInfo = adm0100Repository.generateMainMenu(request.getMsgUserYn(), request.getAdminUserYn(), getLanguage(vertx, sessionId));
        MainMenuResponse.Builder response = MainMenuResponse.newBuilder();
        //TODO check with client if not use remove
        //response.setSessionId(sessionId);
        if (listMenuInfo != null && !listMenuInfo.isEmpty()) {
            for (MainMenuInfo item : listMenuInfo) {
                MainMenuItemInfo.Builder menuItemInfo = MainMenuItemInfo.newBuilder();
                menuItemInfo.setGroupId(item.getGroupId());
                menuItemInfo.setGroupName(item.getGroupName());
                menuItemInfo.setSystemId(item.getSystemId());
                menuItemInfo.setSystemName(item.getSystemName());
                if (!StringUtils.isEmpty(item.getDisplayGroupId())) {
                    menuItemInfo.setDisplayGroupId(item.getDisplayGroupId());
                }
                if (!StringUtils.isEmpty(item.getDisplayGroupName())) {
                    menuItemInfo.setDisplayGroupName(item.getDisplayGroupName());
                }
                if (!StringUtils.isEmpty(item.getDescription())) {
                    menuItemInfo.setDescription(item.getDescription());
                }
                response.addMenuItem(menuItemInfo);
            }
        }
        return response.build();
    }
}
