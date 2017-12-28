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
import nta.med.data.dao.medi.ocs.Ocs0101Repository;
import nta.med.data.model.ihis.ocsa.OCS0203U00LaySlipInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0203U00LaySlipRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0203U00LaySlipResponse;

@Service                                                                                                          
@Scope("prototype")
public class OCS0203U00LaySlipHandler extends ScreenHandler<OcsaServiceProto.OCS0203U00LaySlipRequest, OcsaServiceProto.OCS0203U00LaySlipResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0203U00LaySlipHandler.class);                                    
	
	@Resource                                                                                                       
	private Ocs0101Repository ocs0101Repository;                                                                    
	
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, OCS0203U00LaySlipRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override              
	@Transactional(readOnly = true)
	public OCS0203U00LaySlipResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, OCS0203U00LaySlipRequest request) throws Exception {
  	   	OcsaServiceProto.OCS0203U00LaySlipResponse.Builder response = OcsaServiceProto.OCS0203U00LaySlipResponse.newBuilder();                      
		List<OCS0203U00LaySlipInfo> list =  ocs0101Repository.getOCS0203U00LaySlipInfo(request.getHospCode(), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(list)){
			for(OCS0203U00LaySlipInfo item : list){
				OcsaModelProto.OCS0203U00LaySlipInfo.Builder info = OcsaModelProto.OCS0203U00LaySlipInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addInfoList(info);
			}
		}
		return response.build();
	} 

}
