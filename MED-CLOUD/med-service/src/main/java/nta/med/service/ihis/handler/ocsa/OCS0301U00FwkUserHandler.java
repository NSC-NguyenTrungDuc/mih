package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.model.ihis.system.TripleListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0301U00FwkUserRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0301U00FwkUserResponse;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0301U00FwkUserHandler
	extends ScreenHandler<OcsaServiceProto.OCS0301U00FwkUserRequest, OcsaServiceProto.OCS0301U00FwkUserResponse> {                     
	@Resource                                                                                                       
	private Bas0260Repository bas0260Repository;                                                                    
	                       
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, OCS0301U00FwkUserRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override      
	@Transactional(readOnly = true)
	public OCS0301U00FwkUserResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, OCS0301U00FwkUserRequest request)
			throws Exception {                                                                
  	   	OcsaServiceProto.OCS0301U00FwkUserResponse.Builder response = OcsaServiceProto.OCS0301U00FwkUserResponse.newBuilder();                      
		List<TripleListItemInfo> list = bas0260Repository.getOCS0301U00CboGwa(request.getHospCode(), getLanguage(vertx, sessionId), request.getFind1(), request.getQueryMode());
		if(!CollectionUtils.isEmpty(list)){
			for(TripleListItemInfo item : list){
				CommonModelProto.TripleListItemInfo.Builder info = CommonModelProto.TripleListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addFwkUser(info);
			}
		}
		return response.build();
	}                                                                                                                                                   
}