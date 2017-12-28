package nta.med.service.emr.handler.composite;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.emr.proto.EmrServiceProto;
import nta.med.service.emr.proto.EmrServiceProto.SaveEmrCompositeFirstRequest;
import nta.med.service.emr.proto.EmrServiceProto.SaveEmrCompositeFirstResponse;
import nta.med.service.ihis.handler.ocso.OcsoOCS1003P01CheckXHandler;
import nta.med.service.ihis.handler.ocso.OcsoOCS1003P01GetChuciHandler;
import nta.med.service.ihis.handler.system.CheckPatientStatusHandler;
import nta.med.service.ihis.handler.system.DupCheckInputOutOrderHandler;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

@Service                                                                                                          
@Scope("prototype")
public class SaveEmrCompositeFirstHandler extends ScreenHandler<EmrServiceProto.SaveEmrCompositeFirstRequest, EmrServiceProto.SaveEmrCompositeFirstResponse>{

	private static final Log LOGGER = LogFactory.getLog(SaveEmrCompositeFirstHandler.class);
	
	@Resource
	OcsoOCS1003P01CheckXHandler ocsoOCS1003P01CheckXHandler;
	@Resource
	CheckPatientStatusHandler checkPatientStatusHandler;
	@Resource
	OcsoOCS1003P01GetChuciHandler ocsoOCS1003P01GetChuciHandler;
	@Resource
	DupCheckInputOutOrderHandler dupCheckInputOutOrderHandler;
	
	@Override
	@Transactional(readOnly = true)
	public SaveEmrCompositeFirstResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			SaveEmrCompositeFirstRequest request) throws Exception {
		EmrServiceProto.SaveEmrCompositeFirstResponse.Builder response = EmrServiceProto.SaveEmrCompositeFirstResponse.newBuilder();
		response.setOcs1003P01Checkx(ocsoOCS1003P01CheckXHandler.handle(vertx, clientId, sessionId, contextId, request.getOcs1003P01Checkx()));
		
		for (SystemServiceProto.CheckPatientStatusRequest item : request.getCheckPatientStatusList()) {
            response.addCheckPatientStatus(checkPatientStatusHandler.handle(vertx, clientId, sessionId, contextId, item));
        }
		
		for (OcsoServiceProto.OcsoOCS1003P01GetChuciRequest item : request.getOcs1003P01GetChuciList()) {
            response.addOcs1003P01GetChuci(ocsoOCS1003P01GetChuciHandler.handle(vertx, clientId, sessionId, contextId, item));
        }
		
		for (SystemServiceProto.DupCheckInputOutOrderRequest item : request.getDupCheckInputOutOrderList()) {
            response.addDupCheckInputOutOrder(dupCheckInputOutOrderHandler.handle(vertx, clientId, sessionId, contextId, item));
        }
		
		return response.build();
	}

}
