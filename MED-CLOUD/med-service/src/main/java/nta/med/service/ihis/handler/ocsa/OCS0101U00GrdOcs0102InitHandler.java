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
import nta.med.data.dao.medi.ocs.Ocs0102Repository;
import nta.med.data.model.ihis.ocsa.OCS0101U00GrdOcs0102ListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0101U00GrdOcs0102InitRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0101U00GrdOcs0102InitResponse;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0101U00GrdOcs0102InitHandler extends ScreenHandler<OcsaServiceProto.OCS0101U00GrdOcs0102InitRequest, OcsaServiceProto.OCS0101U00GrdOcs0102InitResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(OCS0101U00GrdOcs0102InitHandler.class);                                        
	@Resource                                                                                                       
	private Ocs0102Repository ocs0102Repository;                                                                    
	
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, OcsaServiceProto.OCS0101U00GrdOcs0102InitRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override         
	@Transactional(readOnly = true)
	public OCS0101U00GrdOcs0102InitResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0101U00GrdOcs0102InitRequest request) throws Exception {                                                                  
  	   	OcsaServiceProto.OCS0101U00GrdOcs0102InitResponse.Builder response = OcsaServiceProto.OCS0101U00GrdOcs0102InitResponse.newBuilder();                      
		List<OCS0101U00GrdOcs0102ListItemInfo> list = ocs0102Repository.getOCS0101U00GrdOcso0102InitListItem(request.getHospCode(), request.getSlipGubun(), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(list)){
			for(OCS0101U00GrdOcs0102ListItemInfo item : list){
			OcsaModelProto.OCS0101U00GrdOcs0102ListItemInfo.Builder info = OcsaModelProto.OCS0101U00GrdOcs0102ListItemInfo.newBuilder();
			BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
			response.addListGrd0Cs0102Init(info);
			}
		}
		return response.build();
	}

}