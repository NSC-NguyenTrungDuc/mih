package nta.med.service.ihis.handler.ocsa;

import javax.annotation.Resource;

import nta.med.data.dao.medi.cht.Cht0110Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsaOCS0204U00SangNameRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsaOCS0204U00SangNameResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OcsaOCS0204U00SangNameHandler
	extends ScreenHandler<OcsaServiceProto.OcsaOCS0204U00SangNameRequest, OcsaServiceProto.OcsaOCS0204U00SangNameResponse> {                     
	@Resource                                                                                                       
	private Cht0110Repository cht0110Repository;                                                                    
	                                                                                                                
	@Override         
	@Transactional(readOnly = true)
	public OcsaOCS0204U00SangNameResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsaOCS0204U00SangNameRequest request) throws Exception {                                                                
  	   	OcsaServiceProto.OcsaOCS0204U00SangNameResponse.Builder response = OcsaServiceProto.OcsaOCS0204U00SangNameResponse.newBuilder();                      
		String sangName = cht0110Repository.getCHT0110U00GetCodeName( getHospitalCode(vertx, sessionId),request.getCode());
        if(!StringUtils.isEmpty(sangName)){
        	response.setSangName(sangName);
        }
        return response.build();
	}
}