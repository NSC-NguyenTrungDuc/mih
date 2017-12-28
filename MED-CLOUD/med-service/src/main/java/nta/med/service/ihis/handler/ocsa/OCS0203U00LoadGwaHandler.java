package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0203U00LoadGwaRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0203U00LoadGwaResponse;

@Service                                                                                                          
@Scope("prototype")   
public class OCS0203U00LoadGwaHandler extends ScreenHandler<OcsaServiceProto.OCS0203U00LoadGwaRequest, OcsaServiceProto.OCS0203U00LoadGwaResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0203U00LoadGwaHandler.class);                                    
	
	@Resource                                                                                                       
	private Bas0260Repository bas0260Repository;                                                                    
	
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, OCS0203U00LoadGwaRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override           
	@Transactional(readOnly = true)
	public OCS0203U00LoadGwaResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, OCS0203U00LoadGwaRequest request)
					throws Exception {
  	   	OcsaServiceProto.OCS0203U00LoadGwaResponse.Builder response = OcsaServiceProto.OCS0203U00LoadGwaResponse.newBuilder();                      
		List<ComboListItemInfo> listItem = bas0260Repository.getOCS0203U00LoadGwaInfo(request.getHospCode(), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listItem)){
			for(ComboListItemInfo item : listItem){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addCboList(info);
			}
		}
		return response.build();
	} 

}
