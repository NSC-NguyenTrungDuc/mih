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
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm3100Repository;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.model.ihis.adma.ADM103UgrdUserGrpInfo;
import nta.med.service.ihis.proto.AdmaModelProto;
import nta.med.service.ihis.proto.AdmaServiceProto;

@Service
@Scope("prototype")
public class ADM103UgrdUserGrpHandler extends ScreenHandler<AdmaServiceProto.ADM103UgrdUserGrpRequest, AdmaServiceProto.ADM103UgrdUserGrpResponse> {
	private static final Log LOGGER = LogFactory.getLog(ADM103UgrdUserGrpHandler.class);
    @Resource
    private Adm3100Repository adm3100Repository;
    @Resource
    private Bas0001Repository bas0001Repository;

    @Override
    @Transactional
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.ADM103UgrdUserGrpRequest request) throws Exception {
    	if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId)) && !StringUtils.isEmpty(request.getHospCode())) {
			List<Bas0001> bas0001s = bas0001Repository.findLatestByHospCode(request.getHospCode());
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(bas0001s.size() > 0 ? bas0001s.get(0).getHospCode() : getHospitalCode(vertx, sessionId),
					bas0001s.size() > 0 ? bas0001s.get(0).getLanguage() : getLanguage(vertx, sessionId), "", 1));
		}
    }
    
    @Override
	@Transactional(readOnly = true)
    public AdmaServiceProto.ADM103UgrdUserGrpResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.ADM103UgrdUserGrpRequest request) throws Exception {
        AdmaServiceProto.ADM103UgrdUserGrpResponse.Builder response = AdmaServiceProto.ADM103UgrdUserGrpResponse.newBuilder();
        List<ADM103UgrdUserGrpInfo> listItem = adm3100Repository.getADM103UgrdUserGrpInfo(request.getHospCode(), getLanguage(vertx, sessionId));
        if (!CollectionUtils.isEmpty(listItem)) {
            for (ADM103UgrdUserGrpInfo item : listItem) {
                AdmaModelProto.ADM103UgrdUserGrpInfo.Builder builder = AdmaModelProto.ADM103UgrdUserGrpInfo.newBuilder();
                BeanUtils.copyProperties(item, builder, getLanguage(vertx, sessionId));
                response.addUserList(builder);
            }
        }
        return response.build();
    }
    
    @Override
	public AdmaServiceProto.ADM103UgrdUserGrpResponse postHandle(Vertx vertx, String clientId, String sessionId, long contextId,
				AdmaServiceProto.ADM103UgrdUserGrpRequest request, AdmaServiceProto.ADM103UgrdUserGrpResponse response) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId)) && !StringUtils.isEmpty(request.getHospCode())) {
			setSessionInfo(vertx, sessionId,
					SessionUserInfo.setSessionUserInfoByUserGroup(UserGroup.NTA.getValue(), Language.JAPANESE.toString().toUpperCase(), "", 0));
		}
			
		return response;
	}
}
