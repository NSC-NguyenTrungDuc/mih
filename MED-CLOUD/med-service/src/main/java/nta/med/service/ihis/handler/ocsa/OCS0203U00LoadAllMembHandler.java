package nta.med.service.ihis.handler.ocsa;

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
import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0203U00LoadAllMembRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0203U00LoadAllMembResponse;

@Service                                                                                                          
@Scope("prototype")
public class OCS0203U00LoadAllMembHandler extends ScreenHandler<OcsaServiceProto.OCS0203U00LoadAllMembRequest, OcsaServiceProto.OCS0203U00LoadAllMembResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0203U00LoadAllMembHandler.class);                                    
	
	@Resource                                                                                                       
	private Bas0270Repository bas0270Repository;                                                                    
	
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, OCS0203U00LoadAllMembRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override         
	@Transactional(readOnly = true)
	public OCS0203U00LoadAllMembResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0203U00LoadAllMembRequest request) throws Exception {
  	   	OcsaServiceProto.OCS0203U00LoadAllMembResponse.Builder response = OcsaServiceProto.OCS0203U00LoadAllMembResponse.newBuilder();                      
		List<ComboListItemInfo> list =  bas0270Repository.getOCS0203U00LoadAllMemb(request.getHospCode(), request.getGwa());
		if(!CollectionUtils.isEmpty(list)){
			for(ComboListItemInfo item : list){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addCboList(info);
			}
		}
		return response.build();
	}

}
