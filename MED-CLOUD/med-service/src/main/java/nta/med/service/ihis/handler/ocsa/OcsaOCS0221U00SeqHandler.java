package nta.med.service.ihis.handler.ocsa;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsaOCS0221U00SeqRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsaOCS0221U00SeqResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OcsaOCS0221U00SeqHandler
	extends ScreenHandler<OcsaServiceProto.OcsaOCS0221U00SeqRequest, OcsaServiceProto.OcsaOCS0221U00SeqResponse> {                     
	@Resource                                                                                                       
	private CommonRepository commonRepository;                                                                    
	                                                                                                                
	@Override
	@Transactional
	public OcsaOCS0221U00SeqResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, OcsaOCS0221U00SeqRequest request)
			throws Exception {                                                                   
  	   	OcsaServiceProto.OcsaOCS0221U00SeqResponse.Builder response = OcsaServiceProto.OcsaOCS0221U00SeqResponse.newBuilder();                      
		Double seq = CommonUtils.parseDouble(commonRepository.getNextVal("OCS0221_SEQ"));
		if(seq !=null){
			response.setSeqNextval(String.format("%.0f",seq));
		}
		return response.build();
	}
}