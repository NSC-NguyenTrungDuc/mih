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
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.ocsa.OCS0108U00CreateComboItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0108U00CreateComboRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0108U00CreateComboResponse;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0108U00CreateComboHandler extends ScreenHandler<OcsaServiceProto.OCS0108U00CreateComboRequest, OcsaServiceProto.OCS0108U00CreateComboResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(OCS0108U00CreateComboHandler.class);                                        
	
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;                                                                    
	                 
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, OCS0108U00CreateComboRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override           
	@Transactional(readOnly = true)
	public OCS0108U00CreateComboResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0108U00CreateComboRequest request) throws Exception {                                                                  
  	   	OcsaServiceProto.OCS0108U00CreateComboResponse.Builder response = OcsaServiceProto.OCS0108U00CreateComboResponse.newBuilder();                      
		List<OCS0108U00CreateComboItemInfo> listComboItem =ocs0132Repository.getOCS0108U00CreateComboItemInfo(request.getHospCode(), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listComboItem)){
			for(OCS0108U00CreateComboItemInfo item : listComboItem){
				OcsaModelProto.OCS0108U00CreateComboItemInfo.Builder info = OcsaModelProto.OCS0108U00CreateComboItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addComboItem(info);
			}
		}
		return response.build();
	}                                                                                                                                                   
}