package nta.med.service.ihis.handler.adma;

import java.util.ArrayList;
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
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.model.ihis.adma.Adm107UFwkUserIdInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.AdmaModelProto;
import nta.med.service.ihis.proto.AdmaServiceProto;
import nta.med.service.ihis.proto.AdmaServiceProto.Adm107UFwkUserIdRequest;
import nta.med.service.ihis.proto.AdmaServiceProto.Adm107UFwkUserIdResponse;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class Adm107UFwkUserIdHandler extends ScreenHandler<AdmaServiceProto.Adm107UFwkUserIdRequest, AdmaServiceProto.Adm107UFwkUserIdResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(Adm107UFwkUserIdHandler.class);         
	@Resource                                                                                                       
	private Adm3200Repository adm3200Repository;
	@Resource                                                                                                       
	private Bas0001Repository bas0001Repository;
	        
	
	@Override
    @Transactional
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, Adm107UFwkUserIdRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId)) && !StringUtils.isEmpty(request.getHospCode())) {
			List<Bas0001> bas0001s = bas0001Repository.findLatestByHospCode(request.getHospCode());
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(bas0001s.size() > 0 ? bas0001s.get(0).getHospCode() : getHospitalCode(vertx, sessionId),
					bas0001s.size() > 0 ? bas0001s.get(0).getLanguage() : getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override                          
	@Transactional(readOnly = true)
	public Adm107UFwkUserIdResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, Adm107UFwkUserIdRequest request) throws Exception {
		AdmaServiceProto.Adm107UFwkUserIdResponse.Builder response = AdmaServiceProto.Adm107UFwkUserIdResponse.newBuilder();
	   List<Adm107UFwkUserIdInfo> listCombo = new ArrayList<Adm107UFwkUserIdInfo>();
	   String language = getLanguage(vertx, sessionId);
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			listCombo = adm3200Repository.getAdm107uFwkUserID(request.getHospCode(), language);
		} else {
			listCombo = adm3200Repository.getAdm107uFwkUserID(getHospitalCode(vertx, sessionId), language);
		}
		if(!CollectionUtils.isEmpty(listCombo)){
			for(Adm107UFwkUserIdInfo item : listCombo){
				//CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				AdmaModelProto.Adm107UFwkUserIdInfo.Builder info = AdmaModelProto.Adm107UFwkUserIdInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
//				if (!StringUtils.isEmpty(item.getCodeName())) {
//					info.setUserNm(item.getCodeName());
//				}
//				if (!StringUtils.isEmpty(item.getCode())) {
//					info.setUserId(item.getCode());
//				}
//				if (Language.JAPANESE.toString().equalsIgnoreCase(language)) {
//					info.setGroupUser("ユーザ");
//				} else if (Language.VIETNAMESE.toString().equalsIgnoreCase(language)) {
//					info.setGroupUser("Người Dùng");
//				} else {
//					info.setGroupUser("User");
//				}
				response.addListInfo(info);
			}
		}
		return response.build();
	}
	
	@Override
	public Adm107UFwkUserIdResponse postHandle(Vertx vertx, String clientId, String sessionId, long contextId,
				Adm107UFwkUserIdRequest request, Adm107UFwkUserIdResponse response) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId)) && !StringUtils.isEmpty(request.getHospCode())) {
			setSessionInfo(vertx, sessionId,
					SessionUserInfo.setSessionUserInfoByUserGroup(UserGroup.NTA.getValue(), Language.JAPANESE.toString().toUpperCase(), "", 0));
		}
			
		return response;
	}
}	