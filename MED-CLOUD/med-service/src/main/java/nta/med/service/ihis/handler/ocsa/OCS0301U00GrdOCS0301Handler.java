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
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs0301Repository;
import nta.med.data.model.ihis.ocsa.OCS0301U00MembGrdInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0301U00GrdOCS0301Request;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0301U00GrdOCS0301Response;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0301U00GrdOCS0301Handler
	extends ScreenHandler<OcsaServiceProto.OCS0301U00GrdOCS0301Request, OcsaServiceProto.OCS0301U00GrdOCS0301Response> {                     
	@Resource                                                                                                       
	private Ocs0301Repository ocs0301Repository;                                                                     
	           
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, OCS0301U00GrdOCS0301Request request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override    
	@Transactional(readOnly = true)
	public OCS0301U00GrdOCS0301Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0301U00GrdOCS0301Request request) throws Exception {                                                                  
  	   	OcsaServiceProto.OCS0301U00GrdOCS0301Response.Builder response = OcsaServiceProto.OCS0301U00GrdOCS0301Response.newBuilder();                      
  	   	List<OCS0301U00MembGrdInfo> list =  ocs0301Repository.getOcs0301OCS0301U00MembGrdListItem(request.getHospCode(), request.getMemb(), 
					CommonUtils.parseDouble(request.getFkocs0300Seq()));
		if(!CollectionUtils.isEmpty(list)){
			for(OCS0301U00MembGrdInfo item : list){
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