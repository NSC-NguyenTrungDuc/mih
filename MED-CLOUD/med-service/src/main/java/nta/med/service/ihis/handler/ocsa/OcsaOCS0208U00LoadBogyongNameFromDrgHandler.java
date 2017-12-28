package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.drg.Drg0120Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsaOCS0208U00LoadBogyongNameFromDrgRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsaOCS0208U00LoadBogyongNameFromDrgResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OcsaOCS0208U00LoadBogyongNameFromDrgHandler
	extends ScreenHandler<OcsaServiceProto.OcsaOCS0208U00LoadBogyongNameFromDrgRequest, OcsaServiceProto.OcsaOCS0208U00LoadBogyongNameFromDrgResponse> {                     
	@Resource                                                                                                       
	private Drg0120Repository drg0120Repository;                                                                    
	                                                                                                                
	@Override    
	@Transactional(readOnly = true)
	public OcsaOCS0208U00LoadBogyongNameFromDrgResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OcsaOCS0208U00LoadBogyongNameFromDrgRequest request){                                                                  
    	OcsaServiceProto.OcsaOCS0208U00LoadBogyongNameFromDrgResponse.Builder response = OcsaServiceProto.OcsaOCS0208U00LoadBogyongNameFromDrgResponse.newBuilder();                      
		List<String> listBogyongCode = drg0120Repository.getBogyongNameOcsaOCS0208U00CommonData(getHospitalCode(vertx, sessionId), request.getCode());
        if(!CollectionUtils.isEmpty(listBogyongCode)){
        	String bogYoungName=listBogyongCode.get(0);
        	if(!StringUtils.isEmpty(bogYoungName)){
        		response.setBogyongName(bogYoungName);
        	}
        }
        return response.build();
	}

}