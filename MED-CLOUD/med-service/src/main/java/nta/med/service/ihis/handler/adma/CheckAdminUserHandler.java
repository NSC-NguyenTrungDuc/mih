package nta.med.service.ihis.handler.adma;

import nta.med.core.glossary.MonitorKey;
import nta.med.core.infrastructure.MonitorLog;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.model.ihis.adma.CheckAdminUserInfo;
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
public class CheckAdminUserHandler extends ScreenHandler<AdmaServiceProto.CheckAdminUserRequest, AdmaServiceProto.CheckAdminUserResponse> {
    private static final Log LOGGER = LogFactory.getLog(CheckAdminUserHandler.class);
    @Resource
    private Adm3200Repository adm3200Repository;

    @Override
	@Transactional(readOnly = true)
    public AdmaServiceProto.CheckAdminUserResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.CheckAdminUserRequest request) throws Exception {
        AdmaServiceProto.CheckAdminUserResponse.Builder response = AdmaServiceProto.CheckAdminUserResponse.newBuilder();
        String userId = request.getUserId();
        List<CheckAdminUserInfo> listItem = adm3200Repository.getCheckAdminUserInfo(userId);
        if (!CollectionUtils.isEmpty(listItem)) {
            for (CheckAdminUserInfo item : listItem) {
                AdmaModelProto.CheckAdminUserInfo.Builder builder = AdmaModelProto.CheckAdminUserInfo.newBuilder();
                BeanUtils.copyProperties(item, builder, getLanguage(vertx, sessionId));
                //TODO remove when change to new way to get session
//                if(UserGroup.isSupperAdmin(item.getUserGroup(), item.getHospCode()))
//                {
//                    setUserRole(vertx, sessionId, UserRole.SUPER_ADMIN.getValue());
//                }

//                setHospitalCode(vertx, sessionId, item.getHospCode());
//                setLanguage(vertx, sessionId, item.getLanguage());
//                setUserId(vertx, sessionId, userId);
                setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(item.getHospCode(), item.getLanguage(), userId, item.getClisSmoId(), item.getUserGroup()));
                response.addUserInfo(builder);
            }
            
            MonitorLog.writeMonitorLog(MonitorKey.LOGIN_SUCCESS, "CheckAdminUser is ok");
        }
        return response.build();
    }
}
