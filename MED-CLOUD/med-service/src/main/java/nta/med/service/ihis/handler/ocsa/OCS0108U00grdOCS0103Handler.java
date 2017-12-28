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
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.model.ihis.ocsa.OCS0108U00grdOCS0103ItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0108U00grdOCS0103Request;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0108U00grdOCS0103Response;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0108U00grdOCS0103Handler extends ScreenHandler<OcsaServiceProto.OCS0108U00grdOCS0103Request, OcsaServiceProto.OCS0108U00grdOCS0103Response> {                             
	
	private static final Log LOGGER = LogFactory.getLog(OCS0108U00grdOCS0103Handler.class);                                        
	
	@Resource                                                                                                       
	private Ocs0103Repository ocs0103Repository;                                                                    
	
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, OCS0108U00grdOCS0103Request request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override                  
	@Transactional(readOnly = true)
	public OCS0108U00grdOCS0103Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0108U00grdOCS0103Request request) throws Exception {                                                                   
  	   	OcsaServiceProto.OCS0108U00grdOCS0103Response.Builder response = OcsaServiceProto.OCS0108U00grdOCS0103Response.newBuilder();                      
		List<OCS0108U00grdOCS0103ItemInfo> listGrd=ocs0103Repository.getOCS0108U00grdOCS0103ItemInfo(request.getHospCode(), getLanguage(vertx, sessionId),request.getHangmogNameInx(),request.getSlipCode());
		if(!CollectionUtils.isEmpty(listGrd)){
			for(OCS0108U00grdOCS0103ItemInfo item: listGrd){
				OcsaModelProto.OCS0108U00grdOCS0103ItemInfo.Builder info= OcsaModelProto.OCS0108U00grdOCS0103ItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
        		response.addGrdOcs0103(info);
			}
		}
		return response.build(); 
	}                                                                                                                                                   
}