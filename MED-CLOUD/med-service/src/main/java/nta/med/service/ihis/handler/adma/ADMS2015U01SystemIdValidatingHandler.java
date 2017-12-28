package nta.med.service.ihis.handler.adma;

import javax.annotation.Resource;

import nta.med.core.glossary.UserRole;
import nta.med.data.dao.medi.adm.AdmsGroupSystemRepository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.AdmaServiceProto;
import nta.med.service.ihis.proto.AdmaServiceProto.ADMS2015U01SystemIdValidatingRequest;
import nta.med.service.ihis.proto.AdmaServiceProto.ADMS2015U01SystemIdValidatingResponse;

import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class ADMS2015U01SystemIdValidatingHandler extends ScreenHandler<AdmaServiceProto.ADMS2015U01SystemIdValidatingRequest, AdmaServiceProto.ADMS2015U01SystemIdValidatingResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(ADMS2015U01SystemIdValidatingHandler.class);                                    
	@Resource                                                                                                       
	private AdmsGroupSystemRepository admsGroupSystemRepository;
	@Override
	public boolean isAuthorized(Vertx vertx, String sessionId){

		return UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId));
	}
	@Override                 
	@Transactional(readOnly = true)
	public ADMS2015U01SystemIdValidatingResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			ADMS2015U01SystemIdValidatingRequest request) throws Exception {
  	   	AdmaServiceProto.ADMS2015U01SystemIdValidatingResponse.Builder response = AdmaServiceProto.ADMS2015U01SystemIdValidatingResponse.newBuilder();                      
		String result =  admsGroupSystemRepository.getADMS2015U01SystemIdValidating(request.getHospCode(), getLanguage(vertx, sessionId), request.getSysId());
		if(!StringUtils.isEmpty(result)){
			response.setSysName(result);
		}
		return response.build();
	} 

}
