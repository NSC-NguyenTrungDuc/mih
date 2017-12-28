package nta.med.service.ihis.handler.ocsa;

import javax.annotation.Resource;

import nta.med.core.common.annotation.Route;
import nta.med.data.dao.medi.ocs.Ocs0101Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0101U00Grd0101CheckDataRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0101U00Grd0101CheckDataResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0101U00Grd0101CheckDataHandler extends ScreenHandler<OcsaServiceProto.OCS0101U00Grd0101CheckDataRequest, OcsaServiceProto.OCS0101U00Grd0101CheckDataResponse> {                             
	
	@Resource                                                                                                       
	private Ocs0101Repository ocs0101Repository;                                                                    
	                                                                                                                
	@Override                    
	@Transactional(readOnly = true)
	@Route(global = true)
	public OCS0101U00Grd0101CheckDataResponse handle(Vertx vertx,
		String clientId, String sessionId, long contextId,
		OCS0101U00Grd0101CheckDataRequest request) throws Exception {                                                                   
  	   	OcsaServiceProto.OCS0101U00Grd0101CheckDataResponse.Builder response = OcsaServiceProto.OCS0101U00Grd0101CheckDataResponse.newBuilder();                      
		String result = ocs0101Repository.getOCS0101U00Grd0101CheckData(request.getValue(), getLanguage(vertx, sessionId));
		if(!StringUtils.isEmpty(result)){
			response.setChkResult(result);
		}
		return response.build();
	}

}