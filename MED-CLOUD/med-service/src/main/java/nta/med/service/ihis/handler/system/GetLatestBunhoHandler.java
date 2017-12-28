package nta.med.service.ihis.handler.system;

import javax.annotation.Resource;

import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.GetLatestBunhoRequest;
import nta.med.service.ihis.proto.SystemServiceProto.GetLatestBunhoResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class GetLatestBunhoHandler extends ScreenHandler<SystemServiceProto.GetLatestBunhoRequest, SystemServiceProto.GetLatestBunhoResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(GetLatestBunhoHandler.class);                                    
	@Resource                                                                                                       
	private Out0101Repository out0101Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public GetLatestBunhoResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, GetLatestBunhoRequest request)
			throws Exception {
		SystemServiceProto.GetLatestBunhoResponse.Builder response = SystemServiceProto.GetLatestBunhoResponse.newBuilder(); 
		String lastestBunho = out0101Repository.getLatestBunho();
		if(!StringUtils.isEmpty(lastestBunho)){
			response.setLatestBunho(lastestBunho);
		}
		return response.build();
	}                                                                                                                 
}