package nta.med.service.emr.handler.composite;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.emr.handler.OCS2015U06EmrRecordHandler;
import nta.med.service.emr.proto.EmrServiceProto;
import nta.med.service.emr.proto.EmrServiceProto.OCSACT2GetPatientExpandRequest;
import nta.med.service.emr.proto.EmrServiceProto.OCSACT2GetPatientExpandResponse;
import nta.med.service.ihis.handler.nuro.OUT0106U00GridListHandler;
import nta.med.service.ihis.handler.ocso.OcsoOCS1003P01GridOutSangHandler;

@Service
@Scope("prototype")
public class OCSACT2GetPatientExpandHandler extends
		ScreenHandler<EmrServiceProto.OCSACT2GetPatientExpandRequest, EmrServiceProto.OCSACT2GetPatientExpandResponse> {

	@Resource
	private OUT0106U00GridListHandler oUT0106U00GridListHandler;
	
	@Resource
	private OCS2015U06EmrRecordHandler oCS2015U06EmrRecordHandler;
	
	@Resource
	private OcsoOCS1003P01GridOutSangHandler ocsoOCS1003P01GridOutSangHandler;
	
	@Override
	@Transactional
	public OCSACT2GetPatientExpandResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCSACT2GetPatientExpandRequest request) throws Exception {
		
		EmrServiceProto.OCSACT2GetPatientExpandResponse.Builder response = EmrServiceProto.OCSACT2GetPatientExpandResponse.newBuilder();
		response.setGridListItem(oUT0106U00GridListHandler.handle(vertx, clientId, sessionId, contextId, request.getGridListItem()));
		response.setEmrRecordItem(oCS2015U06EmrRecordHandler.handle(vertx, clientId, sessionId, contextId, request.getEmrRecordItem()));
		response.setGridOutsangItem(ocsoOCS1003P01GridOutSangHandler.handle(vertx, clientId, sessionId, contextId, request.getGridOutsangItem()));
		
		return response.build();
	}

	
}
