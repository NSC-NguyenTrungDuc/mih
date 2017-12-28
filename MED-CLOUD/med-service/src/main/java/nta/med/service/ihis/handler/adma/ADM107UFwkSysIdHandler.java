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

import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.data.dao.medi.adm.Adm0200Repository;
import nta.med.data.model.ihis.adma.ADM103LaySysListGrpInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.AdmaServiceProto;
import nta.med.service.ihis.proto.AdmaServiceProto.ADM107UFwkSysIdRequest;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class ADM107UFwkSysIdHandler extends ScreenHandler<AdmaServiceProto.ADM107UFwkSysIdRequest, SystemServiceProto.ComboResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(ADM107UFwkSysIdHandler.class);                                    
	@Resource                                                                                                       
	private Adm0200Repository adm0200Repository;                                                                    
	                 
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.ADM107UFwkSysIdRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override             
	@Transactional(readOnly = true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, ADM107UFwkSysIdRequest request) throws Exception {
		SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();  
		List<ADM103LaySysListGrpInfo> listLayGrp = null;
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			listLayGrp = adm0200Repository.getADM103LaySysListGrpInfo(request.getHospCode(), getLanguage(vertx, sessionId));
		} else {
			listLayGrp = adm0200Repository.getADM103LaySysListGrpInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
		}
		if (!CollectionUtils.isEmpty(listLayGrp)) {
			for (ADM103LaySysListGrpInfo item : listLayGrp) {
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder(); 
				if(!StringUtils.isEmpty(item.getSysId())) {
					info.setCode(item.getSysId());
				}
				if(!StringUtils.isEmpty(item.getSysNm())) {
					info.setCodeName(item.getSysNm());
				}
				response.addComboItem(info);
			}
		}
		return response.build();
	}                                                                                                                 
}