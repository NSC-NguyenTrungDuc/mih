package nta.med.service.emr.handler.composite;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.emr.handler.OCS2015U00GetPatientInfoHandler;
import nta.med.service.emr.handler.OCS2015U06OrderTypeComboHandler;
import nta.med.service.emr.handler.OCS2015U09GetTemplateComboBoxHandler;
import nta.med.service.emr.handler.PatientInfoLoadPatientNaewonListHandler;
import nta.med.service.emr.proto.EmrServiceProto;
import nta.med.service.emr.proto.EmrServiceProto.SaveEmrCompositeSecondRequest;
import nta.med.service.emr.proto.EmrServiceProto.SaveEmrCompositeSecondResponse;
import nta.med.service.ihis.handler.nuri.NUR1016U00GrdNUR1016Handler;
import nta.med.service.ihis.handler.nuri.NUR1017U00GrdNUR1017Handler;
import nta.med.service.ihis.handler.nuro.OCS1003P01GrdPatientHandler;
import nta.med.service.ihis.handler.nuro.OUT0106U00GridListHandler;
import nta.med.service.ihis.handler.ocso.OcsoOCS1003P01BtnListQueryHandler;
import nta.med.service.ihis.handler.system.FormEnvironInfoSysDateHandler;
import nta.med.service.ihis.handler.system.PrOcsLoadNaewonInfoHandler;

@Service                                                                                                          
@Scope("prototype")
@Transactional
public class SaveEmrCompositeSecondHandler extends ScreenHandler<EmrServiceProto.SaveEmrCompositeSecondRequest, EmrServiceProto.SaveEmrCompositeSecondResponse>{

	private static final Log LOGGER = LogFactory.getLog(SaveEmrCompositeSecondHandler.class);
	
	@Resource
	OCS1003P01GrdPatientHandler oCS1003P01GrdPatientHandler;
	@Resource
	OcsoOCS1003P01BtnListQueryHandler ocsoOCS1003P01BtnListQueryHandler;
	@Resource
	NUR1016U00GrdNUR1016Handler nUR1016U00GrdNUR1016Handler;
	@Resource
	NUR1017U00GrdNUR1017Handler nUR1017U00GrdNUR1017Handler;
	@Resource
	OUT0106U00GridListHandler oUT0106U00GridListHandler;
	@Resource
	OCS2015U00GetPatientInfoHandler oCS2015U00GetPatientInfoHandler;
	@Resource
	PatientInfoLoadPatientNaewonListHandler patientInfoLoadPatientNaewonListHandler;
	@Resource
	FormEnvironInfoSysDateHandler formEnvironInfoSysDateHandler;
	@Resource
	PrOcsLoadNaewonInfoHandler prOcsLoadNaewonInfoHandler;
	@Resource
	OCS2015U09GetTemplateComboBoxHandler oCS2015U09GetTemplateComboBoxHandler;
	@Resource
	OCS2015U06OrderTypeComboHandler oCS2015U06OrderTypeComboHandler;
	
	@Override
	public SaveEmrCompositeSecondResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			SaveEmrCompositeSecondRequest request) throws Exception {
		EmrServiceProto.SaveEmrCompositeSecondResponse.Builder response = EmrServiceProto.SaveEmrCompositeSecondResponse.newBuilder();
		
		response.setGrdPatient(oCS1003P01GrdPatientHandler.handle(vertx, clientId, sessionId, contextId, request.getGrdPatient()));
		
		response.setBtnListQuery(ocsoOCS1003P01BtnListQueryHandler.handle(vertx, clientId, sessionId, contextId, request.getBtnListQuery()));
		
		response.setGrdNur1016(nUR1016U00GrdNUR1016Handler.handle(vertx, clientId, sessionId, contextId, request.getGrdNur1016()));
		
		response.setGrdNur1017(nUR1017U00GrdNUR1017Handler.handle(vertx, clientId, sessionId, contextId, request.getGrdNur1017()));
		
		response.setGrdListOut0106(oUT0106U00GridListHandler.handle(vertx, clientId, sessionId, contextId, request.getGrdListOut0106()));
		
		response.setGetPatientInfo(oCS2015U00GetPatientInfoHandler.handle(vertx, clientId, sessionId, contextId, request.getGetPatientInfo()));
		
		response.setPatientInfoLoad(patientInfoLoadPatientNaewonListHandler.handle(vertx, clientId, sessionId, contextId, request.getPatientInfoLoad()));
		
		response.setEnvSysDate(formEnvironInfoSysDateHandler.handle(vertx, clientId, sessionId, contextId, request.getEnvSysDate()));
		
		response.setOcsLoadNaewon(prOcsLoadNaewonInfoHandler.handle(vertx, clientId, sessionId, contextId, request.getOcsLoadNaewon()));
		
		response.setTemplateCombo(oCS2015U09GetTemplateComboBoxHandler.handle(vertx, clientId, sessionId, contextId, request.getTemplateCombo()));
		
		response.setOrderTypeCombo(oCS2015U06OrderTypeComboHandler.handle(vertx, clientId, sessionId, contextId, request.getOrderTypeCombo()));
		
		return response.build();
	}

}
