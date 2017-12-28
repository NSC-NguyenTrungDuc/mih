package nta.med.service.ihis.handler.pfes;

import javax.annotation.Resource;

import nta.med.data.dao.medi.pfe.Pfe0102Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PfesServiceProto;
import nta.med.service.ihis.proto.PfesServiceProto.PFE0101U00LayDupDRequest;
import nta.med.service.ihis.proto.PfesServiceProto.PFE0101U00LayDupDResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class PFE0101U00LayDupDHandler
	extends ScreenHandler<PfesServiceProto.PFE0101U00LayDupDRequest , PfesServiceProto.PFE0101U00LayDupDResponse> {                     
	@Resource                                                                                                       
	private Pfe0102Repository pfe0102Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public PFE0101U00LayDupDResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, PFE0101U00LayDupDRequest request)
			throws Exception {                                                                  
  	   	PfesServiceProto.PFE0101U00LayDupDResponse.Builder response = PfesServiceProto.PFE0101U00LayDupDResponse.newBuilder();                      
		String layDupD=pfe0102Repository.getPFE0101U00LayDupDRequest(getHospitalCode(vertx, sessionId),request.getCodeType(),request.getCode(), getLanguage(vertx, sessionId));
		if(!StringUtils.isEmpty(layDupD)){
			response.setResult(layDupD);
		}
		return response.build();
	}

}