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
import nta.med.data.dao.medi.adm.AdmsGroupSystemRepository;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.AdmaServiceProto;
import nta.med.service.ihis.proto.AdmaServiceProto.ADMS2015U01GetSystemRequest;
import nta.med.service.ihis.proto.AdmaServiceProto.ADMS2015U01GetSystemResponse;
import nta.med.service.ihis.proto.CommonModelProto;

@Service                                                                                                          
@Scope("prototype")
public class ADMS2015U01GetSystemHandler extends ScreenHandler<AdmaServiceProto.ADMS2015U01GetSystemRequest, AdmaServiceProto.ADMS2015U01GetSystemResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(ADMS2015U01GetSystemHandler.class);                                    
	@Resource                                                                                                       
	private AdmsGroupSystemRepository admsGroupSystemRepository;
	
	@Resource
	private Bas0001Repository bas0001Repository;
	
	@Override
	public boolean isAuthorized(Vertx vertx, String sessionId){
		
		return UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId));
	}
	
	 
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, ADMS2015U01GetSystemRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override                       
	@Transactional(readOnly = true)
	public ADMS2015U01GetSystemResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			ADMS2015U01GetSystemRequest request) throws Exception {
  	   	AdmaServiceProto.ADMS2015U01GetSystemResponse.Builder response = AdmaServiceProto.ADMS2015U01GetSystemResponse.newBuilder();                      
		List<ComboListItemInfo> list =  admsGroupSystemRepository.getADMS2015U01System(request.getHospCode(), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(list)){
			for(ComboListItemInfo item : list){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addSystemInfo(info);
			}
		}
		
		return response.build();
	} 

}
