package nta.med.service.emr.handler.composite;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.emr.handler.OCS2015U00GetMaxSizeHandler;
import nta.med.service.emr.handler.OCS2015U00GetPatientInfoHandler;
import nta.med.service.emr.handler.OCS2015U06EmrTagHandler;
import nta.med.service.emr.handler.PatientInfoLoadPatientNaewonListHandler;
import nta.med.service.emr.proto.EmrServiceProto;
import nta.med.service.emr.proto.EmrServiceProto.LoadEmrCompositeFirstRequest;
import nta.med.service.emr.proto.EmrServiceProto.LoadEmrCompositeFirstResponse;
import nta.med.service.ihis.handler.ocso.OcsoOCS1003P01CheckYHandler;
import nta.med.service.ihis.handler.ocso.OcsoOCS1003P01LayPatHandler;
import nta.med.service.ihis.handler.system.FormEnvironInfoSysDateHandler;
import nta.med.service.ihis.handler.system.PrOcsLoadNaewonInfoHandler;

@Service                                                                                                          
@Scope("prototype")
public class LoadEmrCompositeFirstHandler extends ScreenHandler<EmrServiceProto.LoadEmrCompositeFirstRequest, EmrServiceProto.LoadEmrCompositeFirstResponse>{

	private static final Log LOGGER = LogFactory.getLog(LoadEmrCompositeFirstHandler.class);
	
	@Resource
	OcsoOCS1003P01CheckYHandler ocsoOCS1003P01CheckYHandler;
	@Resource
	OCS2015U00GetMaxSizeHandler  oCS2015U00GetMaxSizeHandler;
	@Resource
	OCS2015U06EmrTagHandler      oCS2015U06EmrTagHandler;
	@Resource
	OcsoOCS1003P01LayPatHandler   ocsoOCS1003P01LayPatHandler;
	@Resource
	PatientInfoLoadPatientNaewonListHandler  patientInfoLoadPatientNaewonListHandler;
	@Resource
	FormEnvironInfoSysDateHandler     formEnvironInfoSysDateHandler;
	@Resource
	PrOcsLoadNaewonInfoHandler    prOcsLoadNaewonInfoHandler;
	@Resource
	OCS2015U00GetPatientInfoHandler oCS2015U00GetPatientInfoHandler;
	
	@Override
	@Transactional
	public LoadEmrCompositeFirstResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			LoadEmrCompositeFirstRequest request) throws Exception {
		EmrServiceProto.LoadEmrCompositeFirstResponse.Builder response = EmrServiceProto.LoadEmrCompositeFirstResponse.newBuilder();
		
		response.setOcs1003P01CheckY(ocsoOCS1003P01CheckYHandler.handle(vertx, clientId, sessionId, contextId, request.getOcs1003P01CheckY()));
		
		response.setOcs2015U00GetMaxSize(oCS2015U00GetMaxSizeHandler.handle(vertx, clientId, sessionId, contextId, request.getOcs2015U00GetMaxSize()));
		
		response.setOcs2015U06EmrTag(oCS2015U06EmrTagHandler.handle(vertx, clientId, sessionId, contextId, request.getOcs2015U06EmrTag()));
		
		response.setOcs1003P01LayPat(ocsoOCS1003P01LayPatHandler.handle(vertx, clientId, sessionId, contextId, request.getOcs1003P01LayPat()));
		
		response.setPatientInfoNaewonLst(patientInfoLoadPatientNaewonListHandler.handle(vertx, clientId, sessionId, contextId, request.getPatientInfoNaewonLst()));
		
		response.setEnvironInfoSysDate(formEnvironInfoSysDateHandler.handle(vertx, clientId, sessionId, contextId, request.getEnvironInfoSysDate()));
		
		response.setOcsLoadNaewonInfo(prOcsLoadNaewonInfoHandler.handle(vertx, clientId, sessionId, contextId, request.getOcsLoadNaewonInfo()));
		
		response.setOcs2015U00GetPatientInfo(oCS2015U00GetPatientInfoHandler.handle(vertx, clientId, sessionId, contextId, request.getOcs2015U00GetPatientInfo()));
		return response.build();
	}

}
