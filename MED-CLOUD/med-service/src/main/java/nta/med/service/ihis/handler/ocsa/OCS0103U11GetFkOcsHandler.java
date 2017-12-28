package nta.med.service.ihis.handler.ocsa;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.phy.Phy8002Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U11GetFkocsRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U11GetFkocsResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U11GetFkOcsHandler 
	extends ScreenHandler<OcsaServiceProto.OCS0103U11GetFkocsRequest, OcsaServiceProto.OCS0103U11GetFkocsResponse> {                     
	@Resource                                                                                                       
	private Phy8002Repository phy8002Repository;                                                                    
	                                                                                                                
	@Override               
	@Transactional(readOnly = true)
	public OCS0103U11GetFkocsResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, OCS0103U11GetFkocsRequest request)
			throws Exception {                                                                   
  	   	OcsaServiceProto.OCS0103U11GetFkocsResponse.Builder response = OcsaServiceProto.OCS0103U11GetFkocsResponse.newBuilder();                      
		Double resutl = phy8002Repository.getOCS0103U11GetFkOcs(getHospitalCode(vertx, sessionId), CommonUtils.parseDouble(request.getPkOcsKey()));
		if(resutl != null){
			response.setPkocsResult(resutl.toString());
		}
		return response.build();
	}

}