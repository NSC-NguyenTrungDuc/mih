package nta.med.service.ihis.handler.adma;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.bas.Bas0001;
import nta.med.core.glossary.Language;
import nta.med.core.glossary.UserGroup;
import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.service.ihis.proto.AdmaServiceProto;
import nta.med.service.ihis.proto.CommonModelProto;

@Service
@Scope("prototype")
public class Adm107UFbxIDDataValidatingHandler extends ScreenHandler<AdmaServiceProto.Adm107UFbxIDDataValidatingRequest, AdmaServiceProto.Adm107UFbxIDDataValidatingResponse> {
	private static final Log LOGGER = LogFactory.getLog(Adm107UFbxIDDataValidatingHandler.class);
	@Resource
    private Adm3200Repository adm3200Repository;
	@Resource
    private Bas0001Repository bas0001Repository;

	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.Adm107UFbxIDDataValidatingRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId)) && !StringUtils.isEmpty(request.getHospCode())) {
			List<Bas0001> bas0001s = bas0001Repository.findLatestByHospCode(request.getHospCode());
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(bas0001s.size() > 0 ? bas0001s.get(0).getHospCode() : getHospitalCode(vertx, sessionId),
					bas0001s.size() > 0 ? bas0001s.get(0).getLanguage() : getLanguage(vertx, sessionId), "", 1));
		}
    }
	
    @Override
    @Transactional(readOnly = true)
    public AdmaServiceProto.Adm107UFbxIDDataValidatingResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.Adm107UFbxIDDataValidatingRequest request) throws Exception {
        AdmaServiceProto.Adm107UFbxIDDataValidatingResponse.Builder response = AdmaServiceProto.Adm107UFbxIDDataValidatingResponse.newBuilder();
        
        List<String> listUFbx = adm3200Repository.getAdm107uUserNm(request.getHospCode(), request.getUserId(), getLanguage(vertx, sessionId));
        if (!CollectionUtils.isEmpty(listUFbx)) {
            for (String item : listUFbx) {
                CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
                if (!StringUtils.isEmpty(item)) {
                    info.setDataValue(item);
                }
                response.addFbxItem(info);
            }
        }
        
        return response.build();
    }
    
    @Override
	public AdmaServiceProto.Adm107UFbxIDDataValidatingResponse postHandle(Vertx vertx, String clientId, String sessionId, long contextId,
				AdmaServiceProto.Adm107UFbxIDDataValidatingRequest request, AdmaServiceProto.Adm107UFbxIDDataValidatingResponse response) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId)) && !StringUtils.isEmpty(request.getHospCode())) {
			setSessionInfo(vertx, sessionId,
					SessionUserInfo.setSessionUserInfoByUserGroup(UserGroup.NTA.getValue(), Language.JAPANESE.toString().toUpperCase(), "", 0));
		}
			
		return response;
	}
}