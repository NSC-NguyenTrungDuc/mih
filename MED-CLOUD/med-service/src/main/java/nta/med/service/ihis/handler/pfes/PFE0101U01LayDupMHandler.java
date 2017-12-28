package nta.med.service.ihis.handler.pfes;

import javax.annotation.Resource;

import nta.med.data.dao.medi.pfe.Pfe0101Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PfesServiceProto;
import nta.med.service.ihis.proto.PfesServiceProto.PFE0101U01LayDupMRequest;
import nta.med.service.ihis.proto.PfesServiceProto.PFE0101U01StringResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class PFE0101U01LayDupMHandler 
	extends ScreenHandler<PfesServiceProto.PFE0101U01LayDupMRequest, PfesServiceProto.PFE0101U01StringResponse> {                     
	@Resource                                                                                                       
	private Pfe0101Repository pfe0101Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public PFE0101U01StringResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, PFE0101U01LayDupMRequest request)
			throws Exception {                                                            
  	   	PfesServiceProto.PFE0101U01StringResponse.Builder response = PfesServiceProto.PFE0101U01StringResponse.newBuilder();                      
		String getY = pfe0101Repository.getPFE0101U00LayDupM(request.getCodeType(), getLanguage(vertx, sessionId));
		if(!StringUtils.isEmpty(getY)){
			response.setResStr(getY);
		}
		return response.build();
	}
}