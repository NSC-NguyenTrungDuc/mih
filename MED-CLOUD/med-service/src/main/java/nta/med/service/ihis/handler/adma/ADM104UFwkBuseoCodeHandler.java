package nta.med.service.ihis.handler.adma;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.AdmaServiceProto;
import nta.med.service.ihis.proto.CommonModelProto;

@Service
@Scope("prototype")
public class ADM104UFwkBuseoCodeHandler extends ScreenHandler<AdmaServiceProto.ADM104UFwkBuseoCodeRequest, AdmaServiceProto.ADM104UFwkBuseoCodeResponse> {
    
	private static final Log LOGGER = LogFactory.getLog(ADM104UFwkBuseoCodeHandler.class);
    
	@Resource
    private Bas0260Repository bas0260Repository;

	@Override
    @Transactional
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.ADM104UFwkBuseoCodeRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
    @Override
    @Transactional(readOnly = true)
    public AdmaServiceProto.ADM104UFwkBuseoCodeResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.ADM104UFwkBuseoCodeRequest request) throws Exception {
        AdmaServiceProto.ADM104UFwkBuseoCodeResponse.Builder response = AdmaServiceProto.ADM104UFwkBuseoCodeResponse.newBuilder();
        List<ComboListItemInfo> listItem = bas0260Repository.getADM104UBuseoCode(request.getHospCode(), getLanguage(vertx, sessionId), request.getBuseoCode(), request.getGwaName());
        if (!CollectionUtils.isEmpty(listItem)) {
            for (ComboListItemInfo item : listItem) {
                CommonModelProto.ComboListItemInfo.Builder builder = CommonModelProto.ComboListItemInfo.newBuilder();
                BeanUtils.copyProperties(item, builder, getLanguage(vertx, sessionId));
                response.addItemInfo(builder);
            }
        }
        return response.build();
    }
}
