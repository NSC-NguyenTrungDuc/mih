package nta.med.service.ihis.handler.ocsa;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.dao.medi.ocs.Ocs0106Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0101PreDeleteOcs0102CheckRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0101PreDeleteOcs0102CheckResponse;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0101PreDeleteOcs0102CheckHandler extends ScreenHandler<OcsaServiceProto.OCS0101PreDeleteOcs0102CheckRequest, OcsaServiceProto.OCS0101PreDeleteOcs0102CheckResponse>{                             
	
	@Resource                                                                                                       
	private Ocs0103Repository ocs0103Repository;   
	
	@Resource  
	private Ocs0106Repository ocs0106Repository;
	
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, OcsaServiceProto.OCS0101PreDeleteOcs0102CheckRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override      
	@Transactional(readOnly = true)
	public OCS0101PreDeleteOcs0102CheckResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0101PreDeleteOcs0102CheckRequest request) throws Exception {                                                                   
  	   	OcsaServiceProto.OCS0101PreDeleteOcs0102CheckResponse.Builder response = OcsaServiceProto.OCS0101PreDeleteOcs0102CheckResponse.newBuilder();     
  	   	String hospCode = request.getHospCode();
		String checkOcs0103 = ocs0103Repository.getOCS0101U00Grd0103CheckData(hospCode, request.getSlipCode());
		if(!StringUtils.isEmpty(checkOcs0103)){
			response.setOcs0103Result(checkOcs0103);
		}
		String checkOcs0106 = ocs0106Repository.getOCS0101U00Grd0106CheckData(hospCode, request.getSlipCode());
		if(!StringUtils.isEmpty(checkOcs0103)){
			response.setOcs0106Result(checkOcs0106);
		}
		return response.build();		
	}
}