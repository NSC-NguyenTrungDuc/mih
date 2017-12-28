package nta.med.service.ihis.handler.ocso.composite;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.handler.ocso.OCSACTCboSystemSelectedIndexChangedHandler;
import nta.med.service.ihis.handler.ocso.OCSACTLayconstantAlarmHandler;
import nta.med.service.ihis.handler.ocso.OCSACTLayconstantConstHandler;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.ihis.proto.OcsoServiceProto.OCSACTCompositeFirstRequest;
import nta.med.service.ihis.proto.OcsoServiceProto.OCSACTCompositeFirstResponse;

@Service                                                                                                          
@Scope("prototype") 
public class OCSACTCompositeFirstHandler extends ScreenHandler<OcsoServiceProto.OCSACTCompositeFirstRequest, OcsoServiceProto.OCSACTCompositeFirstResponse>{
	private static final Log LOGGER = LogFactory.getLog(OCSACTCompositeFirstHandler.class);                                    
	@Resource                                                                                                       
	private OCSACTCboSystemSelectedIndexChangedHandler oCSACTCboSystemSelectedIndexChangedHandler;  
	@Resource                                                                                                       
	private OCSACTLayconstantConstHandler oCSACTLayconstantConstHandler; 
	@Resource                                                                                                       
	private OCSACTLayconstantAlarmHandler oCSACTLayconstantAlarmHandler; 
	
	@Override
	@Transactional(readOnly = true)
	public OCSACTCompositeFirstResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCSACTCompositeFirstRequest request) throws Exception {
		OcsoServiceProto.OCSACTCompositeFirstResponse.Builder response = OcsoServiceProto.OCSACTCompositeFirstResponse.newBuilder(); 
		response.setCboSystemEventList(oCSACTCboSystemSelectedIndexChangedHandler.handle(vertx, clientId, sessionId, contextId, request.getCboSystemEventParam()));
		
		response.setLayConstList(oCSACTLayconstantConstHandler.handle(vertx, clientId, sessionId, contextId, request.getLayConstParam()));
		
		response.setLayAlarmList(oCSACTLayconstantAlarmHandler.handle(vertx, clientId, sessionId, contextId, request.getLayAlarmParam()));
		return response.build();
	} 

}
