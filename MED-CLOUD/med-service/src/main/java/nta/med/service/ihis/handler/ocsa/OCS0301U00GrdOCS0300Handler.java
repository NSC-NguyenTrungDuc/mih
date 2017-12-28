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
import nta.med.data.dao.medi.ocs.Ocs0300Repository;
import nta.med.data.model.ihis.ocsa.OCS0301U00MembGrdInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0301U00GrdOCS0300Request;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0301U00GrdOCS0300Response;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0301U00GrdOCS0300Handler
	extends ScreenHandler<OcsaServiceProto.OCS0301U00GrdOCS0300Request, OcsaServiceProto.OCS0301U00GrdOCS0300Response>{                     
	@Resource                                                                                                       
	private Ocs0300Repository ocs0300Repository;                                                                    
	        
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, OCS0301U00GrdOCS0300Request request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override        
	@Transactional(readOnly = true)
	public OCS0301U00GrdOCS0300Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0301U00GrdOCS0300Request request) throws Exception {                                                                 
  	   	OcsaServiceProto.OCS0301U00GrdOCS0300Response.Builder response = OcsaServiceProto.OCS0301U00GrdOCS0300Response.newBuilder();                      
		List<OCS0301U00MembGrdInfo> listOcs0300 = ocs0300Repository.getOcs0300OCS0301U00MembGrdListItem(request.getHospCode(), request.getMemb(), request.getInputTab());
		if(!CollectionUtils.isEmpty(listOcs0300)){
			for(OCS0301U00MembGrdInfo item : listOcs0300){
				OcsaModelProto.OCS0301U00MembGrdInfo.Builder info = OcsaModelProto.OCS0301U00MembGrdInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				if (item.getKeySeq() != null) {
			        info.setKeySeq(String.format("%.0f",item.getKeySeq()));
			    }
				if (item.getSeq() != null) {
			        info.setSeq(String.format("%.0f",item.getSeq()));
			     }
				response.addGridInfo(info);
			}
		}
		return response.build();
	}                                                                                                                                                   
}