package nta.med.service.ihis.handler.pfes;

import javax.annotation.Resource;

import nta.med.data.dao.medi.pfe.Pfe0101Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PfesServiceProto;
import nta.med.service.ihis.proto.PfesServiceProto.PFE0101U00LayDupDResponse;
import nta.med.service.ihis.proto.PfesServiceProto.PFE0101U00LayDupMRequest;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class PFE0101U00LayDupMHandler
	extends ScreenHandler<PfesServiceProto.PFE0101U00LayDupMRequest, PfesServiceProto.PFE0101U00LayDupDResponse> {                     
	@Resource                                                                                                       
	private Pfe0101Repository pfe0101Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public PFE0101U00LayDupDResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, PFE0101U00LayDupMRequest request)
			throws Exception {                                                                  
  	   	PfesServiceProto.PFE0101U00LayDupDResponse.Builder response = PfesServiceProto.PFE0101U00LayDupDResponse.newBuilder();                      
		String layDupM=pfe0101Repository.getPFE0101U00LayDupM(request.getCodeType(), getLanguage(vertx, sessionId));
		if(!StringUtils.isEmpty(layDupM)){
			response.setResult(layDupM);
		}
		return response.build();
	}
}