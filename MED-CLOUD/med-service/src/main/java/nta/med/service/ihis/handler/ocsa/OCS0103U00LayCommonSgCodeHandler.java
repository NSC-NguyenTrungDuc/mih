package nta.med.service.ihis.handler.ocsa;

import java.util.Date;
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
import nta.med.data.dao.medi.bas.Bas0310Repository;
import nta.med.data.model.ihis.ocsa.OCS0103U00LayCommonInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U00LayCommonSgCodeRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U00LayCommonSgCodeResponse;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U00LayCommonSgCodeHandler extends ScreenHandler<OcsaServiceProto.OCS0103U00LayCommonSgCodeRequest, OcsaServiceProto.OCS0103U00LayCommonSgCodeResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0103U00LayCommonSgCodeHandler.class);                                    
	
	@Resource                                                                                                       
	private Bas0310Repository bas0310Repository;                                                                    
	
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, OCS0103U00LayCommonSgCodeRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override          
	@Transactional(readOnly = true)
	public OCS0103U00LayCommonSgCodeResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0103U00LayCommonSgCodeRequest request) throws Exception {                                                                  
  	   	OcsaServiceProto.OCS0103U00LayCommonSgCodeResponse.Builder response = OcsaServiceProto.OCS0103U00LayCommonSgCodeResponse.newBuilder();                      
		List<OCS0103U00LayCommonInfo> listLay = bas0310Repository.getOCS0103U00LayCommonInfo(request.getHospCode(), new Date(), request.getSgCode(), request.getStartDate());
		if(!CollectionUtils.isEmpty(listLay)){
			for(OCS0103U00LayCommonInfo item : listLay){
				OcsaModelProto.OCS0103U00LayCommonInfo.Builder info  = OcsaModelProto.OCS0103U00LayCommonInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addLayCommonSgItem(info);
			}
		}
		return response.build();
	}                                                                                                                                                   

}