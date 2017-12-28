package nta.med.service.ihis.handler.bass;

import javax.annotation.Resource;

import nta.med.core.common.exception.ExecutionException;
import nta.med.data.dao.medi.bas.Bas0103Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.HOTCODEMASTERSaveOCS0103Request;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")  
@Transactional
public class HOTCODEMASTERSaveOCS0103Handler extends ScreenHandler<BassServiceProto.HOTCODEMASTERSaveOCS0103Request, SystemServiceProto.UpdateResponse>{                     
	private static final Log LOGGER = LogFactory.getLog(HOTCODEMASTERSaveOCS0103Handler.class);                                    
	@Resource                                                                                                       
	private Bas0103Repository bas0103Repository;                                                                    

	@Override
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			HOTCODEMASTERSaveOCS0103Request request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String errFlg = bas0103Repository.callPrAdmHotcodeMasterInsert(request.getHospCode(), request.getUserId(),"");
		if(!"0".equalsIgnoreCase(errFlg)){
			response.setResult(false);
			throw new ExecutionException(response.build());
		}
		response.setResult(true);
		return response.build();
	}                                                                                                                 
}