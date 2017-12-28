package nta.med.service.ihis.handler.ocsa.composite;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.handler.ocsa.OCS0103U13GrdSangyongOrderListHandler;
import nta.med.service.ihis.handler.ocsa.OCS0103U14FormLoadHandler;
import nta.med.service.ihis.handler.ocsa.OCS0103U14GrdSlipHangmogHandler;
import nta.med.service.ihis.handler.ocsa.OCS0103U14LaySlipCodeTreeHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U14FirstOpenScreenRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U14FirstOpenScreenResponse;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U14FirstOpenScreenHandler 
	extends ScreenHandler<OcsaServiceProto.OCS0103U14FirstOpenScreenRequest, OcsaServiceProto.OCS0103U14FirstOpenScreenResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0103U14FirstOpenScreenHandler.class);                                     
	 @Resource
	 private OCS0103U14FormLoadHandler oCS0103U14FormLoadHandler;	 
	 @Resource
	 private OCS0103U13GrdSangyongOrderListHandler oCS0103U13GrdSangyongOrderListHandler;
	 @Resource
	 private OCS0103U14LaySlipCodeTreeHandler oCS0103U14LaySlipCodeTreeHandler;
	 @Resource
	 private OCS0103U14GrdSlipHangmogHandler oCS0103U14GrdSlipHangmogHandler;
	  
	@Override     
	@Transactional(readOnly = true)
	public OCS0103U14FirstOpenScreenResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, OCS0103U14FirstOpenScreenRequest request)
			throws Exception {                                                                 
  	   	OcsaServiceProto.OCS0103U14FirstOpenScreenResponse.Builder response = OcsaServiceProto.OCS0103U14FirstOpenScreenResponse.newBuilder();                      	     	   	
  	   	response.setFormLoadRes(oCS0103U14FormLoadHandler.handle(vertx, clientId, sessionId, contextId, request.getFormLoadRq()));  	   
  	   	response.setSangyongRes(oCS0103U13GrdSangyongOrderListHandler.handle(vertx, clientId, sessionId, contextId, request.getSangyongRq()));  	    
  	   	response.setLaySlipcodeRes(oCS0103U14LaySlipCodeTreeHandler.handle(vertx, clientId, sessionId, contextId, request.getLaySlipcodeRq()));  	    
  	   	response.setGrdSliphangmogRes(oCS0103U14GrdSlipHangmogHandler.handle(vertx, clientId, sessionId, contextId, request.getGrdSliphangmogRq()));  	    
  	    return response.build();
	}
}