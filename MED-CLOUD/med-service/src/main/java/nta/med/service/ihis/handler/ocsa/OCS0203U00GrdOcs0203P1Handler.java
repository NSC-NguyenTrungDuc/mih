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
import nta.med.data.model.ihis.ocsa.OCS0203U00GrdOcs0203P1Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0203U00GrdOcs0203P1Request;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0203U00GrdOcs0203P1Response;

@Service                                                                                                          
@Scope("prototype")
public class OCS0203U00GrdOcs0203P1Handler extends ScreenHandler<OcsaServiceProto.OCS0203U00GrdOcs0203P1Request,OcsaServiceProto.OCS0203U00GrdOcs0203P1Response>  {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0203U00GrdOcs0203P1Handler.class);                                    
	
	@Resource                                                                                                       
	private Ocs0103Repository ocs0103Repository;                                                                    
	
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, OCS0203U00GrdOcs0203P1Request request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override           
	@Transactional(readOnly = true)
	public OCS0203U00GrdOcs0203P1Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0203U00GrdOcs0203P1Request request) throws Exception {
  	   	OcsaServiceProto.OCS0203U00GrdOcs0203P1Response.Builder response = OcsaServiceProto.OCS0203U00GrdOcs0203P1Response.newBuilder();                      
		List<OCS0203U00GrdOcs0203P1Info> list =  ocs0103Repository.getOCS0203U00GrdOcs0203P1Info(request.getHospCode(), request.getSlipCode(), request.getMemb());
		if(!CollectionUtils.isEmpty(list)){
			for(OCS0203U00GrdOcs0203P1Info item : list){
				OcsaModelProto.OCS0203U00GrdOcs0203P1Info.Builder info = OcsaModelProto.OCS0203U00GrdOcs0203P1Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				if(item.getValue999() != null){
					info.setValue999(item.getValue999().toString());
				}
				response.addInfoList(info);
			}
		}
		return response.build();
	}  

}
