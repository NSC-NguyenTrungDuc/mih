package nta.med.app.vertx.ihis;

import nta.med.core.infrastructure.SpringBeanFactory;
import nta.med.core.infrastructure.socket.vertx.AbstractVerticle;
import nta.med.service.ihis.handler.ocsi.*;
import nta.med.service.ihis.proto.OcsiServiceProto;

public class OcsiVerticle extends AbstractVerticle{

	public OcsiVerticle() {
		super(OcsiServiceProto.class, OcsiServiceProto.getDescriptor());
	}
	
	@Override
    public void doStart() throws Exception{
		//[START] OCS2003R00
		registerHandler(OcsiServiceProto.OCS2003R00layOCS2003Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003R00layOCS2003Handler.class));
		registerHandler(OcsiServiceProto.OCS2003R00layOCS2001Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003R00layOCS2001Handler.class));
		registerHandler(OcsiServiceProto.OCS2003R00layPatientRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003R00layPatientHandler.class));
		
		//OCS1024U00
		registerHandler(OcsiServiceProto.OCS1024U00ApplySangOrderInfoRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS1024U00ApplySangOrderInfoHandler.class));
		registerHandler(OcsiServiceProto.OCS1024U00getBogyongNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS1024U00getBogyongNameHandler.class));
		registerHandler(OcsiServiceProto.OCS1024U00btnListGrdOCS1024Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS1024U00btnListGrdOCS1024Handler.class));
		registerHandler(OcsiServiceProto.OCS1024U00ValidationCheckRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS1024U00ValidationCheckHandler.class));
		registerHandler(OcsiServiceProto.OCS1024U00GetPkInp1001Order1Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS1024U00GetPkInp1001Order1Handler.class));
		registerHandler(OcsiServiceProto.OCS1024U00GetPkInp1001Order2Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS1024U00GetPkInp1001Order2Handler.class));
		registerHandler(OcsiServiceProto.OCS1024U00PROcsLoadHangmogInfoRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS1024U00PROcsLoadHangmogInfoHandler.class));
		registerHandler(OcsiServiceProto.OCS1024U00getJusaNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS1024U00getJusaNameHandler.class));
		registerHandler(OcsiServiceProto.OCS1024U00grdOCS1024Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS1024U00grdOCS1024Handler.class));
		registerHandler(OcsiServiceProto.OCS1024U00grdOCS1024JusaRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS1024U00grdOCS1024JusaHandler.class));
		registerHandler(OcsiServiceProto.OCS1024U00isDonbokYNRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS1024U00isDonbokYNHandler.class));
		registerHandler(OcsiServiceProto.OCS1024U00xEditGridCell20Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS1024U00xEditGridCell20Handler.class));
		registerHandler(OcsiServiceProto.OCS1024U00SaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS1024U00SaveLayoutHandler.class));
		
		registerHandler(OcsiServiceProto.OCS2003P01GrdOutsangRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003P01GrdOutsangHandler.class));
		registerHandler(OcsiServiceProto.OCS2003Q02xEditGridCellRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003Q02xEditGridCellHandler.class));
		registerHandler(OcsiServiceProto.OCS2003Q02GetCodeNameGwaRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003Q02GetCodeNameGwaHandler.class));
		registerHandler(OcsiServiceProto.OCS2003Q02GetCodeNameDoctorRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003Q02GetCodeNameDoctorHandler.class));
		registerHandler(OcsiServiceProto.OCS2003Q02GetPKINP1001Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003Q02GetPKINP1001Handler.class));
		registerHandler(OcsiServiceProto.OCS2003Q02grdNotActingRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003Q02grdNotActingHandler.class));
		registerHandler(OcsiServiceProto.OCS2003Q02GetFindWorkerRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003Q02GetFindWorkerHandler.class));
		registerHandler(OcsiServiceProto.OCS2003Q02CheckDrgInjNoActOrderRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003Q02CheckDrgInjNoActOrderHandler.class));
		registerHandler(OcsiServiceProto.OCS2003Q02BatchDeleteProcessRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003Q02BatchDeleteProcessHandler.class));
		registerHandler(OcsiServiceProto.OCS2003Q02BannabProcessRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003Q02BannabProcessHandler.class));
		
		registerHandler(OcsiServiceProto.OCS2003Q02GetCodeNameGwaRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003Q02GetCodeNameGwaHandler.class));
		registerHandler(OcsiServiceProto.OCS2003Q02GetCodeNameDoctorRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003Q02GetCodeNameDoctorHandler.class));
		registerHandler(OcsiServiceProto.OCS2003Q02GetPKINP1001Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003Q02GetPKINP1001Handler.class));
		
		registerHandler(OcsiServiceProto.OCS2003Q11dataLayoutMIORequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003Q11dataLayoutMIOHandler.class));
		registerHandler(OcsiServiceProto.OCS2003Q11layQueryRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003Q11layQueryHandler.class));
		
		registerHandler(OcsiServiceProto.OCS2003P01ApplyCopyRehaRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003P01ApplyCopyRehaHandler.class));
		registerHandler(OcsiServiceProto.OCS2003P01ControlDataValRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003P01ControlDataValHandler.class));
		registerHandler(OcsiServiceProto.OCS2003P01GrdOutsangColumnChangedRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003P01GrdOutsangColumnChangedHandler.class));
		registerHandler(OcsiServiceProto.OCS2003P01IsCommonDocConsultRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003P01IsCommonDocConsultHandler.class));
		registerHandler(OcsiServiceProto.OCS2003P01IsSameNameCHKRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003P01IsSameNameCHKHandler.class));
		registerHandler(OcsiServiceProto.OCS2003P01MakeInputGubunTabRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003P01MakeInputGubunTabHandler.class));
		registerHandler(OcsiServiceProto.OCS2003P01MakeJinryoGwaRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003P01MakeJinryoGwaHandler.class));
		registerHandler(OcsiServiceProto.OCS2003P01OrderValidationRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003P01OrderValidationHandler.class));
		registerHandler(OcsiServiceProto.OCS2003P01ProcessCommonDocRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003P01ProcessCommonDocHandler.class));
		registerHandler(OcsiServiceProto.OCS2003P01SetToiwonGojiYNforBtnRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003P01SetToiwonGojiYNforBtnHandler.class));

		registerHandler(OcsiServiceProto.OCS2003P01SetSameOrderDateGroupSerRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003P01SetSameOrderDateGroupSerHandler.class));
		registerHandler(OcsiServiceProto.OCS2003P01GrdPatientListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003P01GrdPatientListHandler.class));
		registerHandler(OcsiServiceProto.OCS2003P01MenuCycleOrderGubunClickRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003P01MenuCycleOrderGubunClickHandler.class));
		registerHandler(OcsiServiceProto.OCS2003U03getJusaRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003U03getJusaHandler.class));
		registerHandler(OcsiServiceProto.OCS2003U03getRemarkRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003U03getRemarkHandler.class));
		registerHandler(OcsiServiceProto.OCS2003U03orderJungboRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003U03orderJungboHandler.class));
		registerHandler(OcsiServiceProto.OCS2003P01LayQueryLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003P01LayQueryLayoutHandler.class));
		registerHandler(OcsiServiceProto.OCS2003P01SaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003P01SaveLayoutHandler.class));
		
		registerHandler(OcsiServiceProto.OCS6010U10LayQueryLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10LayQueryLayoutHandler.class));
		registerHandler(OcsiServiceProto.OCS6010U10LaySiksaJunpyoRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10LaySiksaJunpyoHandler.class));
		registerHandler(OcsiServiceProto.OCS6010U10CreateOrderGubunRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10CreateOrderGubunHandler.class));
		registerHandler(OcsiServiceProto.OCS6010U10CreatePopupMenuRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10CreatePopupMenuHandler.class));
		registerHandler(OcsiServiceProto.OCS6010U10PopupCase6Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10PopupCase6Handler.class));
		registerHandler(OcsiServiceProto.OCS6010U10PrOcsPlanDirectConvRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10PrOcsPlanDirectConvHandler.class));
		registerHandler(OcsiServiceProto.OCS6010U10PopupCase22Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10PopupCase22Handler.class));
		registerHandler(OcsiServiceProto.OCS6010U10PopupCase23Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10PopupCase23Handler.class));
		registerHandler(OcsiServiceProto.OCS6010U10GetCheckValueRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10GetCheckValueHandler.class));
		registerHandler(OcsiServiceProto.OCS6010U10GetCheckModifyPlanRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10GetCheckModifyPlanHandler.class));
		registerHandler(OcsiServiceProto.OCS6010U10GetCheckDupDirRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10GetCheckDupDirHandler.class));
		registerHandler(OcsiServiceProto.OCS6010U10LoadIpwonLstRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10LoadIpwonLstHandler.class));
		registerHandler(OcsiServiceProto.OCS6010U10GetAdminUsernmRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10GetAdminUsernmHandler.class));
		registerHandler(OcsiServiceProto.OCS6010U10LoadPrintPGMIDRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10LoadPrintPGMIDHandler.class));
		registerHandler(OcsiServiceProto.OCS6010U10LoadDetailDataRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10LoadDetailDataHandler.class));
		registerHandler(OcsiServiceProto.OCS6010U10DayApplyOCS6013Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10DayApplyOCS6013Handler.class));
		registerHandler(OcsiServiceProto.OCS6010U10PrOcsApplyPlanOrdRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10PrOcsApplyPlanOrdHandler.class));
		registerHandler(OcsiServiceProto.OCS6010U10SaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10SaveLayoutHandler.class));
		registerHandler(OcsiServiceProto.OCS6010U10OrderInfoCase2Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10OrderInfoCase2Handler.class));
		registerHandler(OcsiServiceProto.OCS6010U10OrderInfoCase3Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10OrderInfoCase3Handler.class));
		registerHandler(OcsiServiceProto.OCS6010U10OrderInfoCaseDfltRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10OrderInfoCaseDfltHandler.class));
		registerHandler(OcsiServiceProto.OCS6010U10OrderInfoCaseOcsRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10OrderInfoCaseOcsHandler.class));		
		registerHandler(OcsiServiceProto.OCS2003U03getResDateRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003U03getResDateHandler.class));
		registerHandler(OcsiServiceProto.OCS2003U03getSysRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003U03getSysHandler.class));
		registerHandler(OcsiServiceProto.OCS2003U03getTocheckRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003U03getTocheckHandler.class));
		registerHandler(OcsiServiceProto.OCS2003U03grdOcs2017Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003U03grdOcs2017Handler.class));
		registerHandler(OcsiServiceProto.OCS2003U03grdOrderRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003U03grdOrderHandler.class));
		registerHandler(OcsiServiceProto.OCS2003U03proBannabRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003U03proBannabHandler.class));
		registerHandler(OcsiServiceProto.OCS2003U03proBongtuRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003U03proBongtuHandler.class));
		registerHandler(OcsiServiceProto.OCS2003U03proMagamRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003U03proMagamHandler.class));
		registerHandler(OcsiServiceProto.OCS2003U03proPrintRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003U03proPrintHandler.class));
		registerHandler(OcsiServiceProto.OCS2003U03proSunabRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003U03proSunabHandler.class));
		
		registerHandler(OcsiServiceProto.OCS2003U03grdOrderdateRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003U03grdOrderdateHandler.class));
		registerHandler(OcsiServiceProto.OCS2003U03grdDrugOrderRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003U03grdDrugOrderHandler.class));
		registerHandler(OcsiServiceProto.OCS2003U03getPkocskeyRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003U03getPkocskeyHandler.class));
		registerHandler(OcsiServiceProto.OCS2003U03GetCountRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003U03GetCountHandler.class));
		registerHandler(OcsiServiceProto.OCS2003U03getStopStartDateRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003U03getStopStartDateHandler.class));
		registerHandler(OcsiServiceProto.OCS2003U03getStopEndDateRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003U03getStopEndDateHandler.class));
		registerHandler(OcsiServiceProto.OCS2003U03getActResDateRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003U03getActResDateHandler.class));
		registerHandler(OcsiServiceProto.OCS2003U03getDVRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003U03getDVHandler.class));
		registerHandler(OcsiServiceProto.OCS2003U03getBogyongCodeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003U03getBogyongCodeHandler.class));
		registerHandler(OcsiServiceProto.OCS2003U03getPRNCURRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003U03getPRNCURHandler.class));
		registerHandler(OcsiServiceProto.OCS2003U03getPRNRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003U03getPRNHandler.class));
		registerHandler(OcsiServiceProto.OCS2003U03getJusaCurRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003U03getJusaCurHandler.class));
		registerHandler(OcsiServiceProto.OCSCHKDISCHARGEgrdStatus1Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCSCHKDISCHARGEgrdStatus1Handler.class));
		registerHandler(OcsiServiceProto.OCSCHKDISCHARGEFkinp1001Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCSCHKDISCHARGEFkinp1001Handler.class));
		registerHandler(OcsiServiceProto.OCS2003U99GetSyokudomeCntRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003U99GetSyokudomeCntHandler.class));
		
		registerHandler(OcsiServiceProto.OCS2003U99cboReRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003U99cboReHandler.class));
		registerHandler(OcsiServiceProto.OCS2003U99DeptCodeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003U99DeptCodeHandler.class));
		registerHandler(OcsiServiceProto.OCS2003U99grdInp1001Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003U99grdInp1001Handler.class));
		registerHandler(OcsiServiceProto.OCS2003U99IdBuseoRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003U99IdBuseoHandler.class));
		registerHandler(OcsiServiceProto.OCS2003U99InsertAdm0700Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003U99InsertAdm0700Handler.class));
		registerHandler(OcsiServiceProto.OCS2003U99InsertAdm0710Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003U99InsertAdm0710Handler.class));
		registerHandler(OcsiServiceProto.OCS2003U99layCheckDupRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003U99layCheckDupHandler.class));
		registerHandler(OcsiServiceProto.OCS2003U99layChkCommonRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003U99layChkCommonHandler.class));
		registerHandler(OcsiServiceProto.OCS2003U99SaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003U99SaveLayoutHandler.class));
		registerHandler(OcsiServiceProto.OCS2003U99SeqRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003U99SeqHandler.class));		
		registerHandler(OcsiServiceProto.OCS2003U99proSikSaRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003U99proSikSaHandler.class));
		registerHandler(OcsiServiceProto.OCS2003U99LoadNotActingCountRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003U99LoadNotActingCountHandler.class));
		registerHandler(OcsiServiceProto.OCS2003U99BannabOrderCountRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003U99BannabOrderCountHandler.class));
		registerHandler(OcsiServiceProto.OCS2003U99CheckNotEndDirectRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003U99CheckNotEndDirectHandler.class));
		registerHandler(OcsiServiceProto.OCS2003U99DoctorRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003U99DoctorHandler.class));
		registerHandler(OcsiServiceProto.OCS2003U99LoadBuseoCodeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003U99LoadBuseoCodeHandler.class));
		
		registerHandler(OcsiServiceProto.OCS2005U02createHoCodeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2005U02createHoCodeHandler.class));
		registerHandler(OcsiServiceProto.OCS2005U02GetPkInp1001Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2005U02GetPkInp1001Handler.class));
		registerHandler(OcsiServiceProto.OCS2005U02GetIpwonDateRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2005U02GetIpwonDateHandler.class));
		registerHandler(OcsiServiceProto.OCS2005U02IsSameNameCHKRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2005U02IsSameNameCHKHandler.class));
		registerHandler(OcsiServiceProto.OCS2005U02paBoxPatientSelectedRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2005U02paBoxPatientSelectedHandler.class));
		registerHandler(OcsiServiceProto.OCS2005U02getMagamStatus1Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2005U02getMagamStatus1Handler.class));
		registerHandler(OcsiServiceProto.OCS2005U02getMagamStatus2Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2005U02getMagamStatus2Handler.class));
		registerHandler(OcsiServiceProto.OCS2005U02SetTabRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2005U02SetTabHandler.class));
		registerHandler(OcsiServiceProto.OCS2005U02IsNutCheckFromToDateRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2005U02IsNutCheckFromToDateHandler.class));
		registerHandler(OcsiServiceProto.OCS2005U02RecoveryDataCheckDeleteRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2005U02RecoveryDataCheckDeleteHandler.class));
		registerHandler(OcsiServiceProto.OCS2005U02btnListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2005U02btnListHandler.class));
		registerHandler(OcsiServiceProto.OCS2005U02LoadOldCommentRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2005U02LoadOldCommentHandler.class));
		registerHandler(OcsiServiceProto.OCS2005U02ProcCreateStopSiksaRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2005U02ProcCreateStopSiksaHandler.class));
		registerHandler(OcsiServiceProto.OCS2005U02ProcCreateSikjinRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2005U02ProcCreateSikjinHandler.class));
		registerHandler(OcsiServiceProto.OCS2005U02calSiksaDayClickRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2005U02calSiksaDayClickHandler.class));
		registerHandler(OcsiServiceProto.OCS2005U02ProcDailyNutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2005U02ProcDailyNutHandler.class));
		registerHandler(OcsiServiceProto.OCS2005U02ValidationCheckRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2005U02ValidationCheckHandler.class));
		registerHandler(OcsiServiceProto.OCS2005U02SaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2005U02SaveLayoutHandler.class));
		registerHandler(OcsiServiceProto.OCS2005U02RecoveryDataCheckRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2005U02RecoveryDataCheckHandler.class));
		registerHandler(OcsiServiceProto.OCS2005U02DeleteCurrentTabRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2005U02DeleteCurrentTabHandler.class));
		
		registerHandler(OcsiServiceProto.OCS2005U02AutoMaSetComboRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2005U02AutoMaSetComboHandler.class));
		registerHandler(OcsiServiceProto.OCS2005U02AutoMaLoadComboRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2005U02AutoMaLoadComboHandler.class));
		registerHandler(OcsiServiceProto.OCS2005U02grdOCS2005Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2005U02grdOCS2005Handler.class));
		registerHandler(OcsiServiceProto.OCS2005U02grdPatientListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2005U02grdPatientListHandler.class));
		registerHandler(OcsiServiceProto.OCS2005U02createHoDongRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2005U02createHoDongHandler.class));
		registerHandler(OcsiServiceProto.OCS2005U02layVWOCSOCS2005NUTRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2005U02layVWOCSOCS2005NUTHandler.class));
		
		registerHandler(OcsiServiceProto.OCS2005U00BuwiNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2005U00BuwiNameHandler.class));
		registerHandler(OcsiServiceProto.OCS2005U00checkInputControlRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2005U00checkInputControlHandler.class));
		registerHandler(OcsiServiceProto.OCS2005U00fwkComboRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2005U00fwkComboHandler.class));
		registerHandler(OcsiServiceProto.OCS2005U00getCodeNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2005U00getCodeNameHandler.class));
		registerHandler(OcsiServiceProto.OCS2005U00getPKSeqRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2005U00getPKSeqHandler.class));
		registerHandler(OcsiServiceProto.OCS2005U00grdNur0112Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2005U00grdNur0112Handler.class));
		registerHandler(OcsiServiceProto.OCS2005U00grdNUR0114Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2005U00grdNUR0114Handler.class));
		registerHandler(OcsiServiceProto.OCS2005U00grdNUR01152Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2005U00grdNUR01152Handler.class));
		registerHandler(OcsiServiceProto.OCS2005U00grdNUR0115Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2005U00grdNUR0115Handler.class));
		registerHandler(OcsiServiceProto.OCS2005U00grdOCS2015Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2005U00grdOCS2015Handler.class));
		registerHandler(OcsiServiceProto.OCS2005U00JisiOrderGubunRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2005U00JisiOrderGubunHandler.class));
		registerHandler(OcsiServiceProto.OCS2005U00layComboRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2005U00layComboHandler.class));
		registerHandler(OcsiServiceProto.OCS2005U00layDirectInfoRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2005U00layDirectInfoHandler.class));
		registerHandler(OcsiServiceProto.OCS2005U00layoutComboRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2005U00layoutComboHandler.class));
		registerHandler(OcsiServiceProto.OCS2005U00SeqNextvalRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2005U00SeqNextvalHandler.class));
		registerHandler(OcsiServiceProto.OCS2005U00SetHangmogNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2005U00SetHangmogNameHandler.class));
		registerHandler(OcsiServiceProto.OCS2005U00setInputControlRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2005U00setInputControlHandler.class));
		registerHandler(OcsiServiceProto.OCS2004U00layTabItemRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2004U00layTabItemHandler.class));
		registerHandler(OcsiServiceProto.OCS2004U00DupCheckRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2004U00DupCheckHandler.class));
		registerHandler(OcsiServiceProto.OCS2004U00setFromDateRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2004U00setFromDateHandler.class));
		registerHandler(OcsiServiceProto.OCS2004U00getPKSeqRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2004U00getPKSeqHandler.class));
		registerHandler(OcsiServiceProto.OCS2004U00setFromDate2Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2004U00setFromDate2Handler.class));
		registerHandler(OcsiServiceProto.OCS2004U00layAllOCS2005Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2004U00layAllOCS2005Handler.class));
		registerHandler(OcsiServiceProto.OCS2004U00layOCS2006Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2004U00layOCS2006Handler.class));
		registerHandler(OcsiServiceProto.OCS2004U00layOCS2005Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2004U00layOCS2005Handler.class));
		registerHandler(OcsiServiceProto.OCS2004U00proCreateJisiRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2004U00proCreateJisiHandler.class));
		registerHandler(OcsiServiceProto.OCS2004U00proOCS2005Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2004U00proOCS2005Handler.class));
		registerHandler(OcsiServiceProto.OCS6010U10PopupTAgrdNUR0114Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10PopupTAgrdNUR0114Handler.class));
		registerHandler(OcsiServiceProto.OCS6010U10PopupTAgrdOCS2006Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10PopupTAgrdOCS2006Handler.class));
		registerHandler(OcsiServiceProto.OCS6010U10PopupTAgrdOCS2015Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10PopupTAgrdOCS2015Handler.class));
		registerHandler(OcsiServiceProto.OCS6010U10PopupTAgrdOCS2016Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10PopupTAgrdOCS2016Handler.class));
		registerHandler(OcsiServiceProto.OCS6010U10PopupTASavelayout2015Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10PopupTASavelayout2015Handler.class));
		registerHandler(OcsiServiceProto.OCS6010U10PopupTASavelayout2016Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10PopupTASavelayout2016Handler.class));
		registerHandler(OcsiServiceProto.OCS6010U10PopupTAProcDAOTRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10PopupTAProcDAOTHandler.class));
		registerHandler(OcsiServiceProto.OCS6010U10PopupTAGetPKOCSRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10PopupTAGetPKOCSHandler.class));
		registerHandler(OcsiServiceProto.OCS6010U10PopupTACreateCombo1Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10PopupTACreateCombo1Handler.class));
		registerHandler(OcsiServiceProto.OCS6010U10PopupTACreateCombo2Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10PopupTACreateCombo2Handler.class));
		registerHandler(OcsiServiceProto.OCS6010U10PopupTAGetAdminUSERNAMERequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10PopupTAGetAdminUSERNAMEHandler.class));
		registerHandler(OcsiServiceProto.OCS6010U10PopupTAgrdOCS2006ItemValueRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10PopupTAgrdOCS2006ItemValueHandler.class));
		registerHandler(OcsiServiceProto.OCS6010U10O2ASetOCS2016Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10O2ASetOCS2016Handler.class));
		registerHandler(OcsiServiceProto.OCS6010U10frmARActingSuryangRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10frmARActingSuryangHandler.class));
		registerHandler(OcsiServiceProto.OCS6010U10frmARActingSeqOCS2016Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10frmARActingSeqOCS2016Handler.class));
		registerHandler(OcsiServiceProto.OCS6010U10frmARActingUserNmRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10frmARActingUserNmHandler.class));
		registerHandler(OcsiServiceProto.OCS6010U10PopupIfJusaConfRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10PopupIfJusaConfHandler.class));
		registerHandler(OcsiServiceProto.OCS2015SeqRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2015SeqHandler.class));
		registerHandler(OcsiServiceProto.OCS6010U10frmARActingOCS2005Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10frmARActingOCS2005Handler.class));
		registerHandler(OcsiServiceProto.OCS6010U10frmARActinggrdOCS2015Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10frmARActinggrdOCS2015Handler.class));
		registerHandler(OcsiServiceProto.OCS6010U10frmARActinggrdOCS2016Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10frmARActinggrdOCS2016Handler.class));
		registerHandler(OcsiServiceProto.OCS6010U10frmARActingSaveRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10frmARActingSaveHandler.class));
		registerHandler(OcsiServiceProto.OCS6010U10frmDirectActingUserNmRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10frmDirectActingUserNmHandler.class));
		registerHandler(OcsiServiceProto.OCS6010U10frmDirectActinggrdNUR0113Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10frmDirectActinggrdNUR0113Handler.class));
		registerHandler(OcsiServiceProto.OCS6010U10frmDirectActinggrdOCS2015Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10frmDirectActinggrdOCS2015Handler.class));
		registerHandler(OcsiServiceProto.OCS6010U10frmDirectActingSaveRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10frmDirectActingSaveHandler.class));
		registerHandler(OcsiServiceProto.OCS6010U10frmARActingSeqOCS2015Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10frmARActingSeqOCS2015Handler.class));
		registerHandler(OcsiServiceProto.OCS2003P01XEditGridCellRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2003P01XEditGridCellHandler.class));
		registerHandler(OcsiServiceProto.OCS6010U10InsertOCS2016Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10InsertOCS2016Handler.class));
		registerHandler(OcsiServiceProto.OCS6010U10PopupIAbtnListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10PopupIAbtnListHandler.class));
		registerHandler(OcsiServiceProto.OCS6010U10PopupIAGetPkOCS2015Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10PopupIAGetPkOCS2015Handler.class));
		registerHandler(OcsiServiceProto.OCS6010U10PopupIAfrmInsulinActingLoadRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10PopupIAfrmInsulinActingLoadHandler.class));
		registerHandler(OcsiServiceProto.OCS6010U10PopupIAlayOCS2006Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10PopupIAlayOCS2006Handler.class));
		registerHandler(OcsiServiceProto.OCS6010U10PopupIAxEditGridCell3Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10PopupIAxEditGridCell3Handler.class));
		registerHandler(OcsiServiceProto.OCS6010U10PopupO2AgrdOCS2015Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10PopupO2AgrdOCS2015Handler.class));
		registerHandler(OcsiServiceProto.OCS6010U10PopupMAgrdOCS2016Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10PopupMAgrdOCS2016Handler.class));
		registerHandler(OcsiServiceProto.OCS6010U10PopupMPDGetCheckModifyPlandateRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10PopupMPDGetCheckModifyPlandateHandler.class));
		registerHandler(OcsiServiceProto.OCS6010U10PopupDAgrdOCS2006Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10PopupDAgrdOCS2006Handler.class));
		registerHandler(OcsiServiceProto.OCS6010U10PopupDASavelayout2015Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10PopupDASavelayout2015Handler.class));
		registerHandler(OcsiServiceProto.OCS6010U10PopupDASavelayout2016Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10PopupDASavelayout2016Handler.class));
		registerHandler(OcsiServiceProto.OCS6010U10PopupDAfrmDirectActingLoadRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10PopupDAfrmDirectActingLoadHandler.class));
		registerHandler(OcsiServiceProto.OCS6010U10PopupDAProcDirectActOrderRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10PopupDAProcDirectActOrderHandler.class));
		registerHandler(OcsiServiceProto.OCS6010U10PopupDAbtnListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10PopupDAbtnListHandler.class));
		registerHandler(OcsiServiceProto.OCS6010U10PopupILgrdOCS2016Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10PopupILgrdOCS2016Handler.class));
		registerHandler(OcsiServiceProto.OCS6010U10PopupIAgrdOCS2015Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10PopupIAgrdOCS2015Handler.class));
		registerHandler(OcsiServiceProto.OCS6010U10PopupIAgrdOCS2016Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10PopupIAgrdOCS2016Handler.class));
		registerHandler(OcsiServiceProto.OCS6010U10PopupIAlayOCS2005Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10PopupIAlayOCS2005Handler.class));
		registerHandler(OcsiServiceProto.OCS6010U10PopupIASaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10PopupIASaveLayoutHandler.class));
		registerHandler(OcsiServiceProto.OCS6010U10PopupO2ASavePerformerRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10PopupO2ASavePerformerHandler.class));
		registerHandler(OcsiServiceProto.OCS6010U10PopupMASavePerformerRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS6010U10PopupMASavePerformerHandler.class));
		registerHandler(OcsiServiceProto.OCS2004U00SaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS2004U00SaveLayoutHandler.class));
		registerHandler(OcsiServiceProto.OCS1024U00xEditGridCellRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS1024U00xEditGridCellHandler.class));
	}
	
	@Override
	protected void doStop() throws Exception {
		
	}
}
