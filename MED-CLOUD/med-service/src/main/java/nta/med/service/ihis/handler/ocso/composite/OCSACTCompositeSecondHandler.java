package nta.med.service.ihis.handler.ocso.composite;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.handler.ocso.OCSACTDefaultJearyoHandler;
import nta.med.service.ihis.handler.ocso.OCSACTGrdJearyoHandler;
import nta.med.service.ihis.handler.ocso.OCSACTGrdSangByungHandler;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.ihis.proto.OcsoServiceProto.OCSACTCompositeSecondRequest;
import nta.med.service.ihis.proto.OcsoServiceProto.OCSACTCompositeSecondResponse;

@Service                                                                                                          
@Scope("prototype") 
public class OCSACTCompositeSecondHandler  extends ScreenHandler<OcsoServiceProto.OCSACTCompositeSecondRequest, OcsoServiceProto.OCSACTCompositeSecondResponse>{

	private static final Log LOGGER = LogFactory.getLog(OCSACTCompositeSecondHandler.class);                                    
	@Resource                                                                                                       
	private OCSACTGrdJearyoHandler oCSACTGrdJearyoHandler; 
	@Resource                                                                                                       
	private OCSACTGrdSangByungHandler oCSACTGrdSangByungHandler; 
	@Resource                                                                                                       
	private OCSACTDefaultJearyoHandler oCSACTDefaultJearyoHandler; 
	
	@Override
	@Transactional(readOnly = true)
	public OCSACTCompositeSecondResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCSACTCompositeSecondRequest request) throws Exception {
		OcsoServiceProto.OCSACTCompositeSecondResponse.Builder response = OcsoServiceProto.OCSACTCompositeSecondResponse.newBuilder(); 
		response.setGrdJearyoList(oCSACTGrdJearyoHandler.handle(vertx, clientId, sessionId, contextId, request.getGrdJearyoParam()));
		
		response.setGrdSangList(oCSACTGrdSangByungHandler.handle(vertx, clientId, sessionId, contextId, request.getGrdSangParam()));
		
		response.setGrdDefaultList(oCSACTDefaultJearyoHandler.handle(vertx, clientId, sessionId, contextId, request.getGrdDefaultParam()));
		return response.build();
	}

}
