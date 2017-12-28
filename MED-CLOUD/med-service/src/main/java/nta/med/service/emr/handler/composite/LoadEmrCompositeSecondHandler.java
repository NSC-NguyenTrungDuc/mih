package nta.med.service.emr.handler.composite;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.emr.handler.EMRGetLatestWarningStatusHandler;
import nta.med.service.emr.handler.EMRSetDataForTvExamHistHandler;
import nta.med.service.emr.handler.OCS2015U00GetDiscussNotifyHandler;
import nta.med.service.emr.handler.OCS2015U00GetPatientInfoHandler;
import nta.med.service.emr.handler.OCS2015U06EmrRecordHandler;
import nta.med.service.emr.handler.OCS2015U06OrderTypeComboHandler;
import nta.med.service.emr.handler.OCS2015U09GetTemplateComboBoxHandler;
import nta.med.service.emr.handler.OCS2015U21ControlDataValidatingHandler;
import nta.med.service.emr.handler.OcsEmrHistoryClinicReferHandler;
import nta.med.service.emr.handler.SettingDiscussHandler;
import nta.med.service.emr.proto.EmrServiceProto;
import nta.med.service.emr.proto.EmrServiceProto.LoadEmrCompositeSecondRequest;
import nta.med.service.emr.proto.EmrServiceProto.LoadEmrCompositeSecondResponse;
import nta.med.service.ihis.handler.nuri.NUR1016U00GrdNUR1016Handler;
import nta.med.service.ihis.handler.nuri.NUR1017U00GrdNUR1017Handler;
import nta.med.service.ihis.handler.nuro.NuroPatientReceptionHistoryListHandler;
import nta.med.service.ihis.handler.nuro.OCS1003P01GrdPatientHandler;
import nta.med.service.ihis.handler.nuro.OUT0106U00GridListHandler;
import nta.med.service.ihis.handler.ocsa.OCS0103U13CboListHandler;
import nta.med.service.ihis.handler.ocso.OCS1003P01LoadConsultEndYnAndIsNoConfirmConsultHandler;
import nta.med.service.ihis.handler.ocso.OCS1003P01SettingVisibleByUserHandler;
import nta.med.service.ihis.handler.ocso.OcsoOCS1003P01BtnListQueryHandler;
import nta.med.service.ihis.handler.ocso.OcsoOCS1003P01GridReserOrderListHandler;
import nta.med.service.ihis.handler.system.FormEnvironInfoSysDateHandler;
import nta.med.service.ihis.handler.system.GetOutJinryoCommentCntHandler;
import nta.med.service.ihis.handler.system.IpwonReserStatusHandler;
import nta.med.service.ihis.handler.system.LoadConsultEndYNHandler;
import nta.med.service.ihis.handler.system.LoadPatientSpecificCommentHandler;
import nta.med.service.ihis.handler.system.OpenAllergyInfoHandler;
import nta.med.service.ihis.handler.system.XPaInfoBoxHandler;

@Service                                                                                                          
@Scope("prototype")
public class LoadEmrCompositeSecondHandler extends ScreenHandler<EmrServiceProto.LoadEmrCompositeSecondRequest, EmrServiceProto.LoadEmrCompositeSecondResponse>{

	private static final Log LOGGER = LogFactory.getLog(LoadEmrCompositeSecondHandler.class);
	
	@Resource
	FormEnvironInfoSysDateHandler     formEnvironInfoSysDateHandler;
	@Resource
	OCS2015U21ControlDataValidatingHandler   oCS2015U21ControlDataValidatingHandler;
	@Resource
	OpenAllergyInfoHandler      openAllergyInfoHandler;
	@Resource
	LoadConsultEndYNHandler    loadConsultEndYNHandler;
	@Resource
	OCS1003P01LoadConsultEndYnAndIsNoConfirmConsultHandler   oCS1003P01LoadConsultEndYnAndIsNoConfirmConsultHandler;
	@Resource
	LoadPatientSpecificCommentHandler    loadPatientSpecificCommentHandler;
	@Resource
	GetOutJinryoCommentCntHandler    getOutJinryoCommentCntHandler;
	@Resource
	IpwonReserStatusHandler    ipwonReserStatusHandler;
	@Resource
	XPaInfoBoxHandler    xPaInfoBoxHandler;
	@Resource
	OCS1003P01SettingVisibleByUserHandler   oCS1003P01SettingVisibleByUserHandler;
	@Resource
	OcsoOCS1003P01GridReserOrderListHandler   ocsoOCS1003P01GridReserOrderListHandler;
	@Resource
	OUT0106U00GridListHandler    oUT0106U00GridListHandler;
	@Resource
	NuroPatientReceptionHistoryListHandler   nuroPatientReceptionHistoryListHandler;
	@Resource
	EMRSetDataForTvExamHistHandler   eMRSetDataForTvExamHistHandler;
	@Resource
	OcsEmrHistoryClinicReferHandler   ocsEmrHistoryClinicReferHandler;
	@Resource
	OCS2015U06EmrRecordHandler   oCS2015U06EmrRecordHandler;
	@Resource
	SettingDiscussHandler     settingDiscussHandler;
	@Resource
	OCS2015U00GetDiscussNotifyHandler   oCS2015U00GetDiscussNotifyHandler;
	@Resource
	EMRGetLatestWarningStatusHandler    eMRGetLatestWarningStatusHandler;
	@Resource
	OCS0103U13CboListHandler    oCS0103U13CboListHandler;
	@Resource
	OCS1003P01GrdPatientHandler   oCS1003P01GrdPatientHandler;
	@Resource
	OcsoOCS1003P01BtnListQueryHandler   ocsoOCS1003P01BtnListQueryHandler;
	@Resource
	NUR1016U00GrdNUR1016Handler    nUR1016U00GrdNUR1016Handler;
	@Resource
	NUR1017U00GrdNUR1017Handler    nUR1017U00GrdNUR1017Handler;
	@Resource
	OCS2015U00GetPatientInfoHandler   oCS2015U00GetPatientInfoHandler;
	@Resource
	OCS2015U09GetTemplateComboBoxHandler  oCS2015U09GetTemplateComboBoxHandler;
	@Resource
	OCS2015U06OrderTypeComboHandler    oCS2015U06OrderTypeComboHandler;
	
	@Override
	@Transactional(readOnly = true)
	public LoadEmrCompositeSecondResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			LoadEmrCompositeSecondRequest request) throws Exception {
		EmrServiceProto.LoadEmrCompositeSecondResponse.Builder response = EmrServiceProto.LoadEmrCompositeSecondResponse.newBuilder();
		
		response.setEnvironInfoSysDate(formEnvironInfoSysDateHandler.handle(vertx, clientId, sessionId, contextId, request.getEnvironInfoSysDate()));
		
		response.setOcs2015U21ControlDataValidate(oCS2015U21ControlDataValidatingHandler.handle(vertx, clientId, sessionId, contextId, request.getOcs2015U21ControlDataValidate()));
		
		response.setOpenAllergyInfo(openAllergyInfoHandler.handle(vertx, clientId, sessionId, contextId, request.getOpenAllergyInfo()));
		
		response.setLoadConsultEndYn(loadConsultEndYNHandler.handle(vertx, clientId, sessionId, contextId, request.getLoadConsultEndYn()));
		
		response.setOcs1003P01LoadConsultEnd(oCS1003P01LoadConsultEndYnAndIsNoConfirmConsultHandler.handle(vertx, clientId, sessionId, contextId, request.getOcs1003P01LoadConsultEnd()));
		
		response.setLoadPatientSpecComment(loadPatientSpecificCommentHandler.handle(vertx, clientId, sessionId, contextId, request.getLoadPatientSpecComment()));
		
		response.setGetOutJinryoComment(getOutJinryoCommentCntHandler.handle(vertx, clientId, sessionId, contextId, request.getGetOutJinryoComment()));
		
		response.setIpwonReserStatus(ipwonReserStatusHandler.handle(vertx, clientId, sessionId, contextId, request.getIpwonReserStatus()));
		
		response.setXpaInfoBox(xPaInfoBoxHandler.handle(vertx, clientId, sessionId, contextId, request.getXpaInfoBox()));
		
		response.setOcs1003P01SettingVisible(oCS1003P01SettingVisibleByUserHandler.handle(vertx, clientId, sessionId, contextId, request.getOcs1003P01SettingVisible()));
		
		response.setOcs1003P01GridReserOrder(ocsoOCS1003P01GridReserOrderListHandler.handle(vertx, clientId, sessionId, contextId, request.getOcs1003P01GridReserOrder()));
		
		response.setOut0106U00GridLst(oUT0106U00GridListHandler.handle(vertx, clientId, sessionId, contextId, request.getOut0106U00GridLst()));
		
		response.setNuroPatientReceptionHis(nuroPatientReceptionHistoryListHandler.handle(vertx, clientId, sessionId, contextId, request.getNuroPatientReceptionHis()));
		
		response.setEmrSetDataTvxam(eMRSetDataForTvExamHistHandler.handle(vertx, clientId, sessionId, contextId, request.getEmrSetDataTvxam()));
		
		response.setOcsemrHisClinicRefer(ocsEmrHistoryClinicReferHandler.handle(vertx, clientId, sessionId, contextId, request.getOcsemrHisClinicRefer()));
		
		response.setOcs2015U06EmrRecord(oCS2015U06EmrRecordHandler.handle(vertx, clientId, sessionId, contextId, request.getOcs2015U06EmrRecord()));
		
		response.setSettingDiscuss(settingDiscussHandler.handle(vertx, clientId, sessionId, contextId, request.getSettingDiscuss()));
		
		response.setOcs2015U00GetDiscussNotify(oCS2015U00GetDiscussNotifyHandler.handle(vertx, clientId, sessionId, contextId, request.getOcs2015U00GetDiscussNotify()));
		
		response.setEmrGetLastestWarning(eMRGetLatestWarningStatusHandler.handle(vertx, clientId, sessionId, contextId, request.getEmrGetLastestWarning()));
		
		response.setOcs0103U13CboLst(oCS0103U13CboListHandler.handle(vertx, clientId, sessionId, contextId, request.getOcs0103U13CboLst()));
		
		response.setOcs1003P01GrdPatient(oCS1003P01GrdPatientHandler.handle(vertx, clientId, sessionId, contextId, request.getOcs1003P01GrdPatient()));
		
		response.setOcs1003P01BtnListQuery(ocsoOCS1003P01BtnListQueryHandler.handle(vertx, clientId, sessionId, contextId, request.getOcs1003P01BtnListQuery()));
		
		response.setNur1016U00Grd(nUR1016U00GrdNUR1016Handler.handle(vertx, clientId, sessionId, contextId, request.getNur1016U00Grd()));
		
		response.setNur1017U00Grd(nUR1017U00GrdNUR1017Handler.handle(vertx, clientId, sessionId, contextId, request.getNur1017U00Grd()));
		
		response.setOcs2015U00GetPatientInfo(oCS2015U00GetPatientInfoHandler.handle(vertx, clientId, sessionId, contextId, request.getOcs2015U00GetPatientInfo()));
		
		response.setOcs2015U09GetTemplateCombo(oCS2015U09GetTemplateComboBoxHandler.handle(vertx, clientId, sessionId, contextId, request.getOcs2015U09GetTemplateCombo()));
		
		response.setOcs2015U06OrderTypeCombo(oCS2015U06OrderTypeComboHandler.handle(vertx, clientId, sessionId, contextId, request.getOcs2015U06OrderTypeCombo()));
		return response.build();
	}

}
