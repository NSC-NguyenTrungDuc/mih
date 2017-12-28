package nta.med.app.vertx.ihis;

import nta.med.core.infrastructure.SpringBeanFactory;
import nta.med.core.infrastructure.socket.vertx.AbstractVerticle;
import nta.med.service.ihis.handler.ocso.*;
import nta.med.service.ihis.handler.ocso.composite.OCSACT2CompositeHandler;
import nta.med.service.ihis.handler.ocso.composite.OCSACTCompositeFirstHandler;
import nta.med.service.ihis.handler.ocso.composite.OCSACTCompositeSecondHandler;
import nta.med.service.ihis.proto.OcsoServiceProto;

public class OcsoVerticle extends AbstractVerticle {

	public OcsoVerticle() {
		super(OcsoServiceProto.class, OcsoServiceProto.getDescriptor());
	}

	@Override
	protected void doStart() throws Exception {
		//[START] OCS1003P01

		registerHandler(OcsoServiceProto.OcsoOCS1003P01GridReserOrderListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsoOCS1003P01GridReserOrderListHandler.class));
		registerHandler(OcsoServiceProto.OcsoOCS1003P01GridPatientListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsoOCS1003P01GridPatientListHandler.class));
		registerHandler(OcsoServiceProto.OcsoOCS1003P01GridOutSangRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsoOCS1003P01GridOutSangHandler.class));
		registerHandler(OcsoServiceProto.OcsoOCS1003P01GetChuciRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsoOCS1003P01GetChuciHandler.class));
		registerHandler(OcsoServiceProto.OcsoOCS1003P01BasLoadGwaNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsoOCS1003P01BasLoadGwaNameHandler.class));
		registerHandler(OcsoServiceProto.OcsoOCS1003P01CheckXRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsoOCS1003P01CheckXHandler.class));
		registerHandler(OcsoServiceProto.OcsoOCS1003P01UpdateJubsuRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsoOCS1003P01UpdateJubsuHandler.class));
		registerHandler(OcsoServiceProto.OcsoOCS1003P01LayJinryoGwaRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsoOCS1003P01LayJinryoGwaHandler.class));
		registerHandler(OcsoServiceProto.OcsoOCS1003P01UpdateDoctorRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsoOCS1003P01UpdateDoctorHandler.class));
		registerHandler(OcsoServiceProto.OcsoOCS1003P01CheckYRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsoOCS1003P01CheckYHandler.class));

		registerHandler(OcsoServiceProto.OcsoOCS1003P01OutOrderEndTempRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsoOCS1003P01OutOrderEndTempHandler.class));
		registerHandler(OcsoServiceProto.OcsoOCS1003P01LayoutQueryRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsoOCS1003P01LayoutQueryHandler.class));
		registerHandler(OcsoServiceProto.OcsoOCS1003P01UpdateDcYnRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsoOCS1003P01UpdateDcYnHandler.class));
		registerHandler(OcsoServiceProto.OcsoOCS1003P01InsertOutSangRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsoOCS1003P01InsertOutSangHandler.class));
		registerHandler(OcsoServiceProto.OcsoOCS1003P01InsertDataOCS1003Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsoOCS1003P01InsertDataOCS1003Handler.class));
		registerHandler(OcsoServiceProto.OcsoOCS1003P01UpdateDataOCS1003Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsoOCS1003P01UpdateDataOCS1003Handler.class));
		registerHandler(OcsoServiceProto.OcsoOCS1003P01UpdateOutSangRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsoOCS1003P01UpdateOutSangHandler.class));
		registerHandler(OcsoServiceProto.OcsoOCS1003P01CheckDataSendYnRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsoOCS1003P01CheckDataSendYnHandler.class));
		registerHandler(OcsoServiceProto.OcsoOCS1003P01DeleteFromOutsangRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsoOCS1003P01DeleteFromOutsangHandler.class));
		registerHandler(OcsoServiceProto.OcsoOCS1003P01DeleteFromOCS1003Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsoOCS1003P01DeleteFromOCS1003Handler.class));
		registerHandler(OcsoServiceProto.OcsoOCS1003P01GetOcsKeySeqRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsoOCS1003P01GetOcsKeySeqHandler.class));
		registerHandler(OcsoServiceProto.OcsoOCS1003P01GetMaxOcs1003SeqRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsoOCS1003P01GetMaxOcs1003SeqHandler.class));
		registerHandler(OcsoServiceProto.OcsoOCS1003P01GetGwoFromOutsangRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsoOCS1003P01GetGwoFromOutsangHandler.class));
		registerHandler(OcsoServiceProto.OcsoOCS1003P01GetPkSeq1Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsoOCS1003P01GetPkSeq1Handler.class));
		registerHandler(OcsoServiceProto.OcsoOCS1003P01GetPkSeq2Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsoOCS1003P01GetPkSeq2Handler.class));
		registerHandler(OcsoServiceProto.OcsoOCS1003P01CheckUsedSangRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsoOCS1003P01CheckUsedSangHandler.class));
		registerHandler(OcsoServiceProto.OcsoOCS1003P01CheckFkOcsRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsoOCS1003P01CheckFkOcsHandler.class));
		registerHandler(OcsoServiceProto.OcsoOCS1003P01GetGubunRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsoOCS1003P01GetGubunHandler.class));
		registerHandler(OcsoServiceProto.OcsoOCS1003P01CheckIsSameNameYnRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsoOCS1003P01CheckIsSameNameYnHandler.class));
		registerHandler(OcsoServiceProto.OcsoOCS1003P01SangDupCheckRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsoOCS1003P01SangDupCheckHandler.class));

		registerHandler(OcsoServiceProto.OCS0132ComboListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0132ComboListHandler.class));
		//registerHandler(OcsoServiceProto.OCS0132CodeNameListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0132CodeNameListHandler.class));
		registerHandler(OcsoServiceProto.OCS1003P01SaveLayOutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS1003P01SaveLayOutHandler.class));
		registerHandler(OcsoServiceProto.OcsoOCS1003P01BtnListQueryRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsoOCS1003P01BtnListQueryHandler.class));
		registerHandler(OcsoServiceProto.OcsoOCS1003P01LayPatRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsoOCS1003P01LayPatHandler.class));
		registerHandler(OcsoServiceProto.OcsoOCS1003P01GetGroupKeyRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsoOCS1003P01GetGroupKeyHandler.class));

		registerHandler(OcsoServiceProto.OCS1003P01ChangeUserRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS1003P01ChangeUserHandler.class));
		registerHandler(OcsoServiceProto.OCS1003P01SettingVisibleByUserRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS1003P01SettingVisibleByUserHandler.class));
		registerHandler(OcsoServiceProto.OcsoOCS1003P01GrdOutSangSaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsoOCS1003P01GrdOutSangSaveLayoutHandler.class));
		registerHandler(OcsoServiceProto.OcsOCS1003P01CheckHangSangInfoRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsOCS1003P01CheckHangSangInfoHandler.class));
		registerHandler(OcsoServiceProto.OCS1003P01GetUserOptionAndOrderCountRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS1003P01GetUserOptionAndOrderCountHandler.class));
		registerHandler(OcsoServiceProto.OCS1003P01OpenAllergyInforRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS1003P01OpenAllergyInforHandler.class));
		registerHandler(OcsoServiceProto.OCS1003P01LoadConsultEndYnAndIsNoConfirmConsultRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS1003P01LoadConsultEndYnAndIsNoConfirmConsultHandler.class));
		registerHandler(OcsoServiceProto.OCS1003P01CheckPatientEtcRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS1003P01CheckPatientEtcHandler.class));
		//[END] OCS1003P01

		//[START] OCS1003Q05
		registerHandler(OcsoServiceProto.OcsoOCS1003Q05DiseaseListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsoOCS1003Q05DiseaseListHandler.class));
		registerHandler(OcsoServiceProto.OcsoOCS1003Q05ScheduleRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsoOCS1003Q05ScheduleHandler.class));
		registerHandler(OcsoServiceProto.OcsoOCS1003Q05OrderListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsoOCS1003Q05OrderListHandler.class));
		registerHandler(OcsoServiceProto.OcsoOCS1003Q05CodeListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsoOCS1003Q05CodeListHandler.class));
		registerHandler(OcsoServiceProto.OcsoOCS1003Q05ComboListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsoOCS1003Q05ComboListHandler.class));
		registerHandler(OcsoServiceProto.OcsoOCS1003Q05GrdRowFocusChangedRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsoOCS1003Q05GrdRowFocusChangedHandler.class));
		//[END] OCS1003Q05

		//[START][SERVER][OUTSANGU00] - Manage injuries and diseases by patient
		registerHandler(OcsoServiceProto.OUTSANGU00InitializeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OUTSANGU00InitializeHandler.class));
		registerHandler(OcsoServiceProto.OUTSANGU00getCodeNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OUTSANGU00getCodeNameHandler.class));
		registerHandler(OcsoServiceProto.OUTSANGU00getFindWorkerRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OUTSANGU00getFindWorkerHandler.class));
		registerHandler(OcsoServiceProto.OUTSANGU00TransactionRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OUTSANGU00TransactionHandler.class));

		// NEW
		registerHandler(OcsoServiceProto.OUTSANGU00createGwaDataRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OUTSANGU00createGwaDataHandler.class));
		registerHandler(OcsoServiceProto.OUTSANGU00findBoxToGwaRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OUTSANGU00findBoxToGwaHandler.class));
		registerHandler(OcsoServiceProto.OUTSANGU00findBoxToDoctorRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OUTSANGU00findBoxToDoctorHandler.class));
		registerHandler(OcsoServiceProto.OUTSANGU00GetGwaNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OUTSANGU00GetGwaNameHandler.class));
		registerHandler(OcsoServiceProto.OUTSANGU00GetDoctorNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OUTSANGU00GetDoctorNameHandler.class));
		registerHandler(OcsoServiceProto.OUTSANGU00GridOutSangSaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OUTSANGU00GridOutSangSaveLayoutHandler.class));
		//[END][SERVER][OUTSANGU00] - Manage injuries and diseases by patient

		//[START] OCS1003Q02
		registerHandler(OcsoServiceProto.OCS1003Q02GridOUT1001Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS1003Q02GridOUT1001Handler.class));
		registerHandler(OcsoServiceProto.OCS1003GrdOUT1001RowFocusChangedRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS1003GrdOUT1001RowFocusChangedHandler.class));
		//[END] OCS1003Q02

		//[START] OCS1003Q09
		registerHandler(OcsoServiceProto.OCS1003Q09GridOCS1003AndSangRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS1003Q09GridOCS1003AndSangHandler.class));
		registerHandler(OcsoServiceProto.OCS1003Q09GridOCS1003Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS1003Q09GridOCS1003Handler.class));
		registerHandler(OcsoServiceProto.OCS1003Q09GridOUT1001Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS1003Q09GridOUT1001Handler.class));
		registerHandler(OcsoServiceProto.OCS1003Q09LoadComboDataSourceRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS1003Q09LoadComboDataSourceHandler.class));
		registerHandler(OcsoServiceProto.OCS1003Q09CheckOrdDanuiRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS1003Q09CheckOrdDanuiHandler.class));
		registerHandler(OcsoServiceProto.OCS1003DloCheckLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS1003DloCheckLayoutHandler.class));
		//[END]OCS1003Q09

		//[START]OCS1003R00----
		registerHandler(OcsoServiceProto.OCS1003R00FormLoadRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS1003R00FormLoadHandler.class));
		//[END]OCS1003R00------

		//[START]OCSACT------
		registerHandler(OcsoServiceProto.OCSACTDefaultJearyoRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCSACTDefaultJearyoHandler.class));
		registerHandler(OcsoServiceProto.OCSACTGrdSangByungRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCSACTGrdSangByungHandler.class));
		registerHandler(OcsoServiceProto.OCSACTGrdPaListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCSACTGrdPaListHandler.class));
		registerHandler(OcsoServiceProto.OCSACTBtnReportViewerClickRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCSACTBtnReportViewerClickHandler.class));
		registerHandler(OcsoServiceProto.OCSACTBtnReserViewerClickRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCSACTBtnReserViewerClickHandler.class));
		registerHandler(OcsoServiceProto.OCSACTGrdOrderGridColumnProtectModifyRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCSACTGrdOrderGridColumnProtectModifyHandler.class));
		registerHandler(OcsoServiceProto.OCSACTGrdJaeryoGridColumnProtectModifyRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCSACTGrdJaeryoGridColumnProtectModifyHandler.class));
		registerHandler(OcsoServiceProto.OCSACTCommandRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCSACTCommandHandler.class));
		registerHandler(OcsoServiceProto.OCSACTTempOrderRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCSACTTempOrderHandler.class));
		registerHandler(OcsoServiceProto.OCSACTLayconstantAlarmRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCSACTLayconstantAlarmHandler.class));
		registerHandler(OcsoServiceProto.OCSACTLayconstantConstRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCSACTLayconstantConstHandler.class));
		registerHandler(OcsoServiceProto.OCSACTCboSystemRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCSACTCboSystemHandler.class));
		registerHandler(OcsoServiceProto.OCSACTCboIoGubunRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCSACTCboIoGubunHandler.class));
		registerHandler(OcsoServiceProto.FwEMRHelperExecuteEMRRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(FwEMRHelperExecuteEMRHandler.class));
		registerHandler(OcsoServiceProto.OCSACTUpdateRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCSACTUpdateHandler.class));
		registerHandler(OcsoServiceProto.OCSACTBtnEMRClickRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCSACTBtnEMRClickHandler.class));
		registerHandler(OcsoServiceProto.OCSACTGrdJaeryoGridColumnChangedRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCSACTGrdJaeryoGridColumnChangedHandler.class));
		registerHandler(OcsoServiceProto.OCSACTGrdOrderGridColumnChangedRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCSACTGrdOrderGridColumnChangedHandler.class));
		registerHandler(OcsoServiceProto.OCSACTCheckNaewonYnRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCSACTCheckNaewonYnHandler.class));
		registerHandler(OcsoServiceProto.OCSACTGetFindWorkerRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCSACTGetFindWorkerHandler.class));

		registerHandler(OcsoServiceProto.OCSACTGrdJearyoRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCSACTGrdJearyoHandler.class));
		registerHandler(OcsoServiceProto.OCSACTCboSystemSelectedIndexChangedRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCSACTCboSystemSelectedIndexChangedHandler.class));
		registerHandler(OcsoServiceProto.OCSACTGrdOrderRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCSACTGrdOrderHandler.class));
		registerHandler(OcsoServiceProto.OCSACTProcEkgInterfaceRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCSACTProcEkgInterfaceHandler.class));
		registerHandler(OcsoServiceProto.OCSACTGrdRowFocusChangedRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCSACTGrdRowFocusChangedHandler.class));
		registerHandler(OcsoServiceProto.OCSACTChangeOrderCodeGrdOrderListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCSACTChangeOrderCodeGrdOrderListHandler.class));
		registerHandler(OcsoServiceProto.OCSACTCboTimeAndSystemRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCSACTCboTimeAndSystemHandler.class));
		registerHandler(OcsoServiceProto.OCSACTGroupedPatientAndOrderRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCSACTGroupedPatientAndOrderHandler.class));
		registerHandler(OcsoServiceProto.OCSACT2GetPatientListINJRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCSACT2GetPatientListINJHandler.class));
		registerHandler(OcsoServiceProto.OCSACT2GetPatientListOCSRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCSACT2GetPatientListOCSHandler.class));
		registerHandler(OcsoServiceProto.OCSACT2GetPatientListCPLRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCSACT2GetPatientListCPLHandler.class));
		registerHandler(OcsoServiceProto.OCSACT2GetComboUserRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCSACT2GetComboUserHandler.class));
		registerHandler(OcsoServiceProto.OCSACT2GetGrdPaListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCSACT2GetGrdPaListHandler.class));
		//[END]OCSACT----

		//[START] OCS1023U00
		registerHandler(OcsoServiceProto.OCS1023U00GrdOCS1023Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS1023U00GrdOCS1023Handler.class));
		registerHandler(OcsoServiceProto.OCS1023U00SaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS1023U00SaveLayoutHandler.class));
		// [END] OCS1023U00

		//[START] OUTSANGQ00
		registerHandler(OcsoServiceProto.OUTSANGQ00IsEnableSangCodeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OUTSANGQ00IsEnableSangCodeHandler.class));
		registerHandler(OcsoServiceProto.OUTSANGQ00LayoutGwaRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OUTSANGQ00LayoutGwaHandler.class));
		registerHandler(OcsoServiceProto.OUTSANGQ00GrdOutSangRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OUTSANGQ00GrdOutSangHandler.class));
		registerHandler(OcsoServiceProto.OUTSANGU00GrdOCS0301Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OUTSANGU00GrdOCS0301Handler.class));
//		OUTSANGQ00GrdOutSangRequest
		//[END] OUTSANGQ00
		
		//[START] OCS1003R02
		registerHandler(OcsoServiceProto.OCS1003R02LayR02QueryStartingRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS1003R02LayR02QueryStartingHandler.class));
		registerHandler(OcsoServiceProto.OCS1003R02LayR03QueryStartingRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS1003R02LayR03QueryStartingHandler.class));
		//[END] OCS1003R02
		
		//[START] OUT2016
		registerHandler(OcsoServiceProto.OUT2016U00PatientLinkingRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OUT2016U00PatientLinkingHandler.class));
		registerHandler(OcsoServiceProto.OUT2016U00UpdatePatientLinkingRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OUT2016U00UpdatePatientLinkingHandler.class));
		//[END] OUT2016
		
		//[START] OCS2016
		registerHandler(OcsoServiceProto.OCS2016U00GrdQuestionRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2016U00GrdQuestionHandler.class));
		registerHandler(OcsoServiceProto.OCS2016GetLinkingDepartmentRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS2016GetLinkingDepartmentHandler.class));
		registerHandler(OcsoServiceProto.OCS2016U00LoadDiscussionRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2016U00LoadDiscussionHandler.class));
		registerHandler(OcsoServiceProto.OCS2016U00QuestionSaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2016U00QuestionSaveLayoutHandler.class));
		registerHandler(OcsoServiceProto.PatientLinkingFwkDoctorRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PatientLinkingFwkDoctorHandler.class));
		registerHandler(OcsoServiceProto.OCS2016GetUserDepartmentRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2016GetUserDepartmentHandler.class));
		registerHandler(OcsoServiceProto.OCS2016U00UpdateReplyRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2016U00UpdateReplyHandler.class));
		registerHandler(OcsoServiceProto.OCS2016U00GetShardingHospitalRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2016U00GetShardingHospitalHandler.class));
		//[END] OCS2016
		
		//[START] PHR
		registerHandler(OcsoServiceProto.OUTSANGPatientDiseaseRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OUTSANGPatientDiseaseHandler.class));
		registerHandler(OcsoServiceProto.OcsoPatientMedicineRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsoPatientMedicineHandler.class));
		//[END] PHR
		
		//[START] Composite
		registerHandler(OcsoServiceProto.OCSACTCompositeFirstRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCSACTCompositeFirstHandler.class));
		registerHandler(OcsoServiceProto.OCSACTCompositeSecondRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCSACTCompositeSecondHandler.class));
		registerHandler(OcsoServiceProto.OCSACT2CompositeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCSACT2CompositeHandler.class));
	   //[END] Composite
		
		registerHandler(OcsoServiceProto.OcsoUpdatePaidOrderRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsoUpdatePaidOrderHandler.class));
		
		//[START] OCS4001
		registerHandler(OcsoServiceProto.OCS4001U00Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS4001U00Handler.class));
		registerHandler(OcsoServiceProto.OCS4001U00SaveRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS4001U00SaveHandler.class));
		//[END] OCS4001		
	}

	@Override
	protected void doStop() throws Exception {

	}
}

