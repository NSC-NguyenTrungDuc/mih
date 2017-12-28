package nta.med.service.emr.handler.composite;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.emr.handler.OCS2015U06EmrRecordHandler;
import nta.med.service.emr.handler.OCS2015U09EmrRecordUpdateHandler;
import nta.med.service.emr.proto.EmrServiceProto;
import nta.med.service.emr.proto.EmrServiceProto.SaveEmrCompositeThirdRequest;
import nta.med.service.emr.proto.EmrServiceProto.SaveEmrCompositeThirdResponse;
import nta.med.service.ihis.handler.ocsa.OCS0103U10FormLoadHandler;
import nta.med.service.ihis.handler.ocsa.OCS0103U12GrdSangyongOrderHandler;

@Service                                                                                                          
@Scope("prototype")
@Transactional
public class SaveEmrCompositeThirdHandler extends ScreenHandler<EmrServiceProto.SaveEmrCompositeThirdRequest, EmrServiceProto.SaveEmrCompositeThirdResponse>{
	private static final Log LOGGER = LogFactory.getLog(SaveEmrCompositeThirdHandler.class);                                    
	@Resource
	private OCS2015U09EmrRecordUpdateHandler oCS2015U09EmrRecordUpdateHandler;
	@Resource
	private OCS2015U06EmrRecordHandler oCS2015U06EmrRecordHandler;
	@Resource
	private OCS0103U12GrdSangyongOrderHandler oCS0103U12GrdSangyongOrderHandler;
	@Resource
	private OCS0103U10FormLoadHandler oCS0103U10FormLoadHandler;
	
	@Override
	public SaveEmrCompositeThirdResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			SaveEmrCompositeThirdRequest request) throws Exception {
		EmrServiceProto.SaveEmrCompositeThirdResponse.Builder response = EmrServiceProto.SaveEmrCompositeThirdResponse.newBuilder();
		
		response.setEmrRecordUpdate(oCS2015U09EmrRecordUpdateHandler.handle(vertx, clientId, sessionId, contextId, request.getEmrRecordUpdate()));
		
		response.setEmrRecord(oCS2015U06EmrRecordHandler.handle(vertx, clientId, sessionId, contextId, request.getEmrRecord()));
		
		response.setGrdSangyongOrder(oCS0103U12GrdSangyongOrderHandler.handle(vertx, clientId, sessionId, contextId, request.getGrdSangyongOrder()));
		
		response.setU10FormLoad(oCS0103U10FormLoadHandler.handle(vertx, clientId, sessionId, contextId, request.getU10FormLoad()));
		
		return response.build();
	}

}
