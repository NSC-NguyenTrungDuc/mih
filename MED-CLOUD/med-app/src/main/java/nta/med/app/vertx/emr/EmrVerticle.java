package nta.med.app.vertx.emr;

import nta.med.core.infrastructure.SpringBeanFactory;
import nta.med.core.infrastructure.socket.vertx.AbstractVerticle;
import nta.med.service.emr.handler.CheckHospUseMovieTalkHandler;
import nta.med.service.emr.handler.EMRDisplayBookmarkHistoryHandler;
import nta.med.service.emr.handler.EMRGetByPatientCodeAndHospCodeHandler;
import nta.med.service.emr.handler.EMRGetLatestWarningStatusHandler;
import nta.med.service.emr.handler.EMRSetDataForTvExamHistHandler;
import nta.med.service.emr.handler.LoadPatientInfectionHandler;
import nta.med.service.emr.handler.NUR2001U04CheckExistMedicalRecordHandler;
import nta.med.service.emr.handler.OCS2015U00EmrGetNoticeEditTimeHandler;
import nta.med.service.emr.handler.OCS2015U00EmrGetTimeoutSpanHandler;
import nta.med.service.emr.handler.OCS2015U00EmrRecordLockHandler;
import nta.med.service.emr.handler.OCS2015U00EmrRecordUnlockHandler;
import nta.med.service.emr.handler.OCS2015U00GetDataPrintEmrMedicalHandler;
import nta.med.service.emr.handler.OCS2015U00GetDiscussNotifyHandler;
import nta.med.service.emr.handler.OCS2015U00GetDoctorPatientReportHandler;
import nta.med.service.emr.handler.OCS2015U00GetHtmlContentHandler;
import nta.med.service.emr.handler.OCS2015U00GetInfoEPortViewerHandler;
import nta.med.service.emr.handler.OCS2015U00GetLinkMISHandler;
import nta.med.service.emr.handler.OCS2015U00GetMaxSizeHandler;
import nta.med.service.emr.handler.OCS2015U00GetPatientInfoHandler;
import nta.med.service.emr.handler.OCS2015U00GetUserOptionsHandler;
import nta.med.service.emr.handler.OCS2015U00LoadPatientMedicalRecordHandler;
import nta.med.service.emr.handler.OCS2015U00SelectEmrRecordByPkout1001Handler;
import nta.med.service.emr.handler.OCS2015U03OrderGubunHandler;
import nta.med.service.emr.handler.OCS2015U04AddBookmarkHandler;
import nta.med.service.emr.handler.OCS2015U04DeleteBookmarkHandler;
import nta.med.service.emr.handler.OCS2015U04EditBookmarkByPkout1001Handler;
import nta.med.service.emr.handler.OCS2015U04EditBookmarkHandler;
import nta.med.service.emr.handler.OCS2015U04EmrRecordLoadBookmarkContentHandler;
import nta.med.service.emr.handler.OCS2015U04LoadBookmarkByPk0ut1001Handler;
import nta.med.service.emr.handler.OCS2015U04LoadExaminationHandler;
import nta.med.service.emr.handler.OCS2015U06EmrRecordHandler;
import nta.med.service.emr.handler.OCS2015U06EmrRecordUpdateMetaHandler;
import nta.med.service.emr.handler.OCS2015U06EmrTagHandler;
import nta.med.service.emr.handler.OCS2015U06EmrTemplateHandler;
import nta.med.service.emr.handler.OCS2015U06EmrTemplateTypeHandler;
import nta.med.service.emr.handler.OCS2015U06OrderTypeComboHandler;
import nta.med.service.emr.handler.OCS2015U07EmrRecordInsertHandler;
import nta.med.service.emr.handler.OCS2015U07GetChildTagOfParentHandler;
import nta.med.service.emr.handler.OCS2015U09EmrRecordUpdateHandler;
import nta.med.service.emr.handler.OCS2015U09GetNodeTagsForContextHandler;
import nta.med.service.emr.handler.OCS2015U09GetRootTagsForContextHandler;
import nta.med.service.emr.handler.OCS2015U09GetTemplateComboBoxHandler;
import nta.med.service.emr.handler.OCS2015U21ControlDataValidatingHandler;
import nta.med.service.emr.handler.OCS2015U21GrdPatientHandler;
import nta.med.service.emr.handler.OCS2015U30EmrTagGetTagHandler;
import nta.med.service.emr.handler.OCS2015U30EmrTagSaveLayoutHandler;
import nta.med.service.emr.handler.OCS2015U31EmrTagGetTagHandler;
import nta.med.service.emr.handler.OCS2015U31EmrTagGetTemplateTagsHandler;
import nta.med.service.emr.handler.OCS2015U31EmrTemplateHandler;
import nta.med.service.emr.handler.OCS2015U31EmrTemplateSaveLayoutHandler;
import nta.med.service.emr.handler.OCS2015U31EmrTemplateTypeHandler;
import nta.med.service.emr.handler.OCS2015U31GetADM3200UserHandler;
import nta.med.service.emr.handler.OCS2015U31GetEmrTemplateHandler;
import nta.med.service.emr.handler.OCS2015U31GetTemplateTagsHandler;
import nta.med.service.emr.handler.OCS2015U31LoadComboDepartHandler;
import nta.med.service.emr.handler.OCS2015U31LoadComboDoctorHandler;
import nta.med.service.emr.handler.OCS2015U31LoadGridDepartAndDoctorHandler;
import nta.med.service.emr.handler.OCS2015U31SaveLayoutHandler;
import nta.med.service.emr.handler.OCS2015U40EmrHistoryMedicalRecordHandler;
import nta.med.service.emr.handler.OCS2015U40EmrMedicalRecordContentHandler;
import nta.med.service.emr.handler.OCS2015U44EmrHistoricRecordUpdateHandler;
import nta.med.service.emr.handler.OCS2016U02CheckLoadExpandHandler;
import nta.med.service.emr.handler.OcsEmrHistoryClinicReferHandler;
import nta.med.service.emr.handler.OcsEmrPatientReceptionHistoryListHandler;
import nta.med.service.emr.handler.SettingDiscussHandler;
import nta.med.service.emr.handler.composite.LoadEmrCompositeFirstHandler;
import nta.med.service.emr.handler.composite.LoadEmrCompositeSecondHandler;
import nta.med.service.emr.handler.composite.OCSACT2CompositeSecondHandler;
import nta.med.service.emr.handler.composite.OCSACT2GetPatientExpandHandler;
import nta.med.service.emr.handler.composite.SaveEmrCompositeFirstHandler;
import nta.med.service.emr.handler.composite.SaveEmrCompositeSecondHandler;
import nta.med.service.emr.handler.composite.SaveEmrCompositeThirdHandler;
import nta.med.service.emr.proto.EmrServiceProto;

public class EmrVerticle extends AbstractVerticle {

	public EmrVerticle() {
		super(EmrServiceProto.class, EmrServiceProto.getDescriptor());
	}

	@Override
	protected void doStart() throws Exception {
		registerHandler(EmrServiceProto.OCS2015U06EmrRecordRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2015U06EmrRecordHandler.class));
		registerHandler(EmrServiceProto.OCS2015U06EmrTagRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U06EmrTagHandler.class));
		registerHandler(EmrServiceProto.OCS2015U06EmrTemplateTypeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U06EmrTemplateTypeHandler.class));
		registerHandler(EmrServiceProto.OCS2015U06EmrTemplateRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U06EmrTemplateHandler.class));
		
		registerHandler(EmrServiceProto.OCS2015U07EmrRecordInsertRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U07EmrRecordInsertHandler.class));
		registerHandler(EmrServiceProto.OCS2015U06EmrRecordUpdateMetaRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U06EmrRecordUpdateMetaHandler.class));
		registerHandler(EmrServiceProto.OCS2015U30EmrTagGetTagRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U30EmrTagGetTagHandler.class));
		registerHandler(EmrServiceProto.OCS2015U30EmrTagSaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U30EmrTagSaveLayoutHandler.class));
		
		registerHandler(EmrServiceProto.OCS2015U31EmrTagGetTagRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U31EmrTagGetTagHandler.class));
		registerHandler(EmrServiceProto.OCS2015U31EmrTemplateRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U31EmrTemplateHandler.class));
		registerHandler(EmrServiceProto.OCS2015U31EmrTemplateTypeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U31EmrTemplateTypeHandler.class));
		registerHandler(EmrServiceProto.OCS2015U31EmrTemplateSaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U31EmrTemplateSaveLayoutHandler.class));
		registerHandler(EmrServiceProto.OCS2015U31EmrTagGetTemplateTagsRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U31EmrTagGetTemplateTagsHandler.class));
		registerHandler(EmrServiceProto.OCS2015U31LoadComboDepartRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U31LoadComboDepartHandler.class));
		registerHandler(EmrServiceProto.OCS2015U31LoadComboDoctorRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U31LoadComboDoctorHandler.class));
		registerHandler(EmrServiceProto.OCS2015U31LoadGridDepartAndDoctorRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U31LoadGridDepartAndDoctorHandler.class));
		
		// [START] OCS2015U40
		registerHandler(EmrServiceProto.OCS2015U40EmrHistoryMedicalRecordRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U40EmrHistoryMedicalRecordHandler.class));
		registerHandler(EmrServiceProto.OCS2015U40EmrMedicalRecordContentRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U40EmrMedicalRecordContentHandler.class));
		// [END] OCS2015U40
		
		// [START] OCS2015U44
		registerHandler(EmrServiceProto.OCS2015U44EmrHistoricRecordUpdateRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U44EmrHistoricRecordUpdateHandler.class));
		registerHandler(EmrServiceProto.OCS2015U00EmrRecordUnlockRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U00EmrRecordUnlockHandler.class));
		registerHandler(EmrServiceProto.OCS2015U00EmrRecordLockRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U00EmrRecordLockHandler.class));
		registerHandler(EmrServiceProto.OCS2015U00EmrGetTimeoutSpanRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U00EmrGetTimeoutSpanHandler.class));
		//[END] OCS2015U44
		
		//[START] OCS2015U00
		registerHandler(EmrServiceProto.OcsEmrPatientReceptionHistoryListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OcsEmrPatientReceptionHistoryListHandler.class));
		registerHandler(EmrServiceProto.OCS2015U00EmrGetNoticeEditTimeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U00EmrGetNoticeEditTimeHandler.class));
		registerHandler(EmrServiceProto.OCS2015U00SelectEmrRecordByPkout1001Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U00SelectEmrRecordByPkout1001Handler.class));
		registerHandler(EmrServiceProto.OCS2015U00LoadPatientMedicalRecordRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U00LoadPatientMedicalRecordHandler.class));
		registerHandler(EmrServiceProto.OCS2015U00GetUserOptionsRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U00GetUserOptionsHandler.class));
		registerHandler(EmrServiceProto.OCS2015U00GetPatientInfoRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U00GetPatientInfoHandler.class));
		registerHandler(EmrServiceProto.OCS2015U00GetDoctorPatientReportRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U00GetDoctorPatientReportHandler.class));
		//[END] OCS2015U00
		
		// -----[START] OCS2015U04 ---------
		registerHandler(EmrServiceProto.OCS2015U04LoadBookmarkByPk0ut1001Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U04LoadBookmarkByPk0ut1001Handler.class));
		registerHandler(EmrServiceProto.OCS2015U04EmrRecordLoadBookmarkContentRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U04EmrRecordLoadBookmarkContentHandler.class));
		registerHandler(EmrServiceProto.OCS2015U04LoadExaminationRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U04LoadExaminationHandler.class));
		registerHandler(EmrServiceProto.OCS2015U04EditBookmarkRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U04EditBookmarkHandler.class));
		registerHandler(EmrServiceProto.OCS2015U04EditBookmarkByPkout1001Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U04EditBookmarkByPkout1001Handler.class));
		registerHandler(EmrServiceProto.OCS2015U04DeleteBookmarkRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U04DeleteBookmarkHandler.class));
		registerHandler(EmrServiceProto.OCS2015U04AddBookmarkRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U04AddBookmarkHandler.class));
		registerHandler(EmrServiceProto.NUR2001U04CheckExistMedicalRecordRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(NUR2001U04CheckExistMedicalRecordHandler.class));
		// -----[END] OCS2015U04 ---------
		
		//-----[START] OCS2015U09 ---------
		registerHandler(EmrServiceProto.OCS2015U09EmrRecordUpdateRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U09EmrRecordUpdateHandler.class));
		registerHandler(EmrServiceProto.OCS2015U09GetTemplateComboBoxRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U09GetTemplateComboBoxHandler.class));
		registerHandler(EmrServiceProto.OCS2015U09GetRootTagsForContextRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U09GetRootTagsForContextHandler.class));
		registerHandler(EmrServiceProto.OCS2015U09GetNodeTagsForContextRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U09GetNodeTagsForContextHandler.class));
		//-----[END] OCS2015U09 ---------
		
		// -----[START] OCS2015U07 ---------
		registerHandler(EmrServiceProto.OCS2015U07GetChildTagOfParentRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U07GetChildTagOfParentHandler.class));
		// -----[END] OCS2015U07 ---------
		//-----[END] OCS2015U03 ---------
		registerHandler(EmrServiceProto.OCS2015U03OrderGubunRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U03OrderGubunHandler.class));
		registerHandler(EmrServiceProto.OcsEmrHistoryClinicReferRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OcsEmrHistoryClinicReferHandler.class));
		//-----[END] OCS2015U03 ---------
		//-----[START] OCS2015U06 ---------
		registerHandler(EmrServiceProto.OCS2015U06OrderTypeComboRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U06OrderTypeComboHandler.class));
		//-----[END] OCS2015U06 ---------
		
		registerHandler(EmrServiceProto.OCS2015U00GetMaxSizeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U00GetMaxSizeHandler.class));
		registerHandler(EmrServiceProto.EMRDisplayBookmarkHistoryRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(EMRDisplayBookmarkHistoryHandler.class));
		registerHandler(EmrServiceProto.EMRSetDataForTvExamHistRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(EMRSetDataForTvExamHistHandler.class));
		registerHandler(EmrServiceProto.OCS2015U21ControlDataValidatingRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U21ControlDataValidatingHandler.class));
		registerHandler(EmrServiceProto.EMRGetLatestWarningStatusRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(EMRGetLatestWarningStatusHandler.class));
		
		//-----[START] OCS2015U31 - NEW ---------
		registerHandler(EmrServiceProto.OCS2015U31GetADM3200UserRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U31GetADM3200UserHandler.class));
		registerHandler(EmrServiceProto.OCS2015U31GetEmrTemplateRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U31GetEmrTemplateHandler.class));
		registerHandler(EmrServiceProto.OCS2015U31GetTemplateTagsRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U31GetTemplateTagsHandler.class));
		registerHandler(EmrServiceProto.OCS2015U31SaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U31SaveLayoutHandler.class));
		//-----[END] OCS2015U31 - NEW ---------
		
		//-----[START] OCS2015U00 ---------
		registerHandler(EmrServiceProto.OCS2015U00GetDiscussNotifyRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U00GetDiscussNotifyHandler.class));
		registerHandler(EmrServiceProto.SettingDiscussRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(SettingDiscussHandler.class));
		//-----[END] OCS2015U00 ---------
		
		//[START] Compostite
		registerHandler(EmrServiceProto.LoadEmrCompositeFirstRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(LoadEmrCompositeFirstHandler.class));
		registerHandler(EmrServiceProto.LoadEmrCompositeSecondRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(LoadEmrCompositeSecondHandler.class));
		registerHandler(EmrServiceProto.SaveEmrCompositeFirstRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(SaveEmrCompositeFirstHandler.class));
		registerHandler(EmrServiceProto.SaveEmrCompositeSecondRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(SaveEmrCompositeSecondHandler.class));
		registerHandler(EmrServiceProto.SaveEmrCompositeThirdRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(SaveEmrCompositeThirdHandler.class));
		registerHandler(EmrServiceProto.OCSACT2GetPatientExpandRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCSACT2GetPatientExpandHandler.class));
		//[END] Composite
		
		//[START] EMR API
		registerHandler(EmrServiceProto.EMRGetByPatientCodeAndHospCodeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(EMRGetByPatientCodeAndHospCodeHandler.class));
		//[END] EMR API
		
		registerHandler(EmrServiceProto.OCS2016U02CheckLoadExpandRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2016U02CheckLoadExpandHandler.class));
		registerHandler(EmrServiceProto.OCS2015U00GetLinkMISRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U00GetLinkMISHandler.class));
		
		registerHandler(EmrServiceProto.OCS2015U00GetInfoEPortViewerRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2015U00GetInfoEPortViewerHandler.class));
		registerHandler(EmrServiceProto.OCSACT2CompositeSecondRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCSACT2CompositeSecondHandler.class));
		
		registerHandler(EmrServiceProto.CheckHospUseMovieTalkRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CheckHospUseMovieTalkHandler.class));
		
		registerHandler(EmrServiceProto.OCS2015U00GetDataPrintEmrMedicalRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2015U00GetDataPrintEmrMedicalHandler.class));
		registerHandler(EmrServiceProto.OCS2015U00GetHtmlContentRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2015U00GetHtmlContentHandler.class));
		registerHandler(EmrServiceProto.LoadPatientInfectionRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(LoadPatientInfectionHandler.class));
		registerHandler(EmrServiceProto.OCS2015U21GrdPatientRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2015U21GrdPatientHandler.class));
	}

	@Override
	protected void doStop() throws Exception {

}
}
