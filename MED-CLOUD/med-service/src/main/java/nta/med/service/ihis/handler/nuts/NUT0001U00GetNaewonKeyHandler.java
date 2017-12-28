package nta.med.service.ihis.handler.nuts;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NutsServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class NUT0001U00GetNaewonKeyHandler extends ScreenHandler<NutsServiceProto.NUT0001U00GetNaewonKeyRequest, NutsServiceProto.NUT0001U00GetNaewonKeyResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(NUT0001U00GetNaewonKeyHandler.class);                                    
	@Resource                                                                                                       
	private Ocs2003Repository ocs2003Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public NutsServiceProto.NUT0001U00GetNaewonKeyResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NutsServiceProto.NUT0001U00GetNaewonKeyRequest request) throws Exception {
		NutsServiceProto.NUT0001U00GetNaewonKeyResponse.Builder response = NutsServiceProto.NUT0001U00GetNaewonKeyResponse.newBuilder();
		Double result = ocs2003Repository.getNUT0001U00GetNaewonKey(getHospitalCode(vertx, sessionId), request.getIoKubun(), CommonUtils.parseDouble(request.getPkocs()));
		if(result != null){
			response.setResult(result.toString());
		}
		return response.build();
	}                                                                                                            
}