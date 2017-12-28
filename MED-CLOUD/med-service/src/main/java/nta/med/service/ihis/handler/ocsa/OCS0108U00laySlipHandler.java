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
import nta.med.data.model.ihis.ocsa.OCS0108U00laySlipItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0108U00laySlipRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0108U00laySlipResponse;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0108U00laySlipHandler extends ScreenHandler<OcsaServiceProto.OCS0108U00laySlipRequest, OcsaServiceProto.OCS0108U00laySlipResponse> {                             
	
	private static final Log LOGGER = LogFactory.getLog(OCS0108U00laySlipHandler.class);                                        
	
	@Resource                                                                                                       
	private Ocs0101Repository ocs0101Repository;                                                                    

	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, OCS0108U00laySlipRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override          
	@Transactional(readOnly = true)
	public OCS0108U00laySlipResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, OCS0108U00laySlipRequest request)
			throws Exception {                                                               
  	   	OcsaServiceProto.OCS0108U00laySlipResponse.Builder response = OcsaServiceProto.OCS0108U00laySlipResponse.newBuilder();                      
		List<OCS0108U00laySlipItemInfo> listLaySlip =ocs0101Repository.getOCS0108U00laySlipItemInfo(request.getHospCode(), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listLaySlip)){
			for(OCS0108U00laySlipItemInfo item:listLaySlip){
				OcsaModelProto.OCS0108U00laySlipItemInfo.Builder info =OcsaModelProto.OCS0108U00laySlipItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addLaySlip(info);
			}
		}
		return response.build();
	}
		                                                                                                   
}