package nta.med.service.ihis.handler.adma;

import nta.med.core.domain.bas.Bas0001;
import nta.med.core.glossary.Language;
import nta.med.core.glossary.UserGroup;
import nta.med.core.glossary.UserRole;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm0200Repository;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.AdmaServiceProto;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.AdmaServiceProto.ADM108ULaySysListRequest;
import nta.med.service.ihis.proto.AdmaServiceProto.ADM108ULaySysListResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

import java.util.List;

@Service
@Scope("prototype")
public class ADM108ULaySysListHandler extends ScreenHandler<AdmaServiceProto.ADM108ULaySysListRequest, AdmaServiceProto.ADM108ULaySysListResponse> {
    private static final Log LOGGER = LogFactory.getLog(ADM108ULaySysListHandler.class);
    
    @Resource
    private Adm0200Repository adm0200Repository;
    
    @Resource                                                                                                       
	private Bas0001Repository bas0001Repository;
    
    @Override
    public boolean isAuthorized(Vertx vertx, String sessionId){
		return UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))
				|| UserRole.NORMAL_ADMIN.getValue().equals(getUserRole(vertx, sessionId));
    }
    
    @Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId,
    		ADM108ULaySysListRequest request) throws Exception {
    	
    	if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId)) && !StringUtils.isEmpty(request.getHospCode())) {
			List<Bas0001> bas0001s = bas0001Repository.findLatestByHospCode(request.getHospCode());
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(bas0001s.size() > 0 ? bas0001s.get(0).getHospCode() : getHospitalCode(vertx, sessionId),
					bas0001s.size() > 0 ? bas0001s.get(0).getLanguage() : getLanguage(vertx, sessionId), "", 1));
		}
    }
    
    @Override
    @Transactional(readOnly = true)
    public AdmaServiceProto.ADM108ULaySysListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.ADM108ULaySysListRequest request) throws Exception {
        AdmaServiceProto.ADM108ULaySysListResponse.Builder response = AdmaServiceProto.ADM108ULaySysListResponse.newBuilder();
        
        String hospCode = UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId)) ? request.getHospCode() : getHospitalCode(vertx, sessionId);
        List<ComboListItemInfo> list = adm0200Repository.findFwkSystem(hospCode, getLanguage(vertx, sessionId));
        if (!CollectionUtils.isEmpty(list)) {
            for (ComboListItemInfo item : list) {
                CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addLaySysListItemInfo(info);
            }
        }
        
        return response.build();
    }
    
    @Override
    public ADM108ULaySysListResponse postHandle(Vertx vertx, String clientId, String sessionId, long contextId,
    		ADM108ULaySysListRequest request, ADM108ULaySysListResponse response) throws Exception {
    	
    	if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId)) && !StringUtils.isEmpty(request.getHospCode())) {
			setSessionInfo(vertx, sessionId,
					SessionUserInfo.setSessionUserInfoByUserGroup(UserGroup.NTA.getValue(), Language.JAPANESE.toString().toUpperCase(), "", 0));
		}
			
		return response;
    }
}