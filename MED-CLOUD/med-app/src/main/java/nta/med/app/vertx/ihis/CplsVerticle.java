
package nta.med.app.vertx.ihis;

import nta.med.core.infrastructure.SpringBeanFactory;
import nta.med.core.infrastructure.socket.vertx.AbstractVerticle;
import nta.med.service.ihis.handler.cpls.*;
import nta.med.service.ihis.handler.cpls.composite.CPL2010U00OpenScreenCompositeHandler;
import nta.med.service.ihis.handler.nuro.CPL3020U02ExecuteCase1FinalUpdateCPL3020Handler;
import nta.med.service.ihis.proto.CplsServiceProto;

public class CplsVerticle extends AbstractVerticle {

	public CplsVerticle() {
		super(CplsServiceProto.class, CplsServiceProto.getDescriptor());
	}

	@Override
	protected void doStart() throws Exception {
		//[START][CPL0108U00] - [Manage type codes]
		registerHandler(CplsServiceProto.CPL0108U00GrdDetailRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL0108U00GrdDetailHandler.class));
		registerHandler(CplsServiceProto.CPL0108U00GrdMasterRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL0108U00GrdMasterHandler.class));
		registerHandler(CplsServiceProto.CPL0108U00CheckItemGrdMasterRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL0108U00CheckItemGrdMasterHandler.class));
		registerHandler(CplsServiceProto.CPL0108U00CheckItemGrdDetailRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL0108U00CheckItemGrdDetailHandler.class));
		registerHandler(CplsServiceProto.CPL0108U00SaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL0108U00SaveLayoutHandler.class));
		//[END][CPL0108U00] - [Manage type codes]
		// --- [START] CPL0104U00 ---
		registerHandler(CplsServiceProto.CPL0104U00GrdDetailRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(CplsCPL0104U00GrdDetailCPL0104Handler.class));
		registerHandler(CplsServiceProto.CPL0104U00GrdMasterRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(CplsCPL0104U00GrdMasterCPL0104Handler.class));
		registerHandler(CplsServiceProto.CPL0104U00SaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL0104U00SaveLayoutHandler.class));
		// --- [END] CPL0104U00---

		// --- [START] CPL2010U00---
		registerHandler(CplsServiceProto.CPL2010U00ChangeTimeUpdateCPL2010Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(CplsCPL2010U00ChangeTimeUpdateCPL2010Handler.class));
		registerHandler(CplsServiceProto.CPL2010U00MlayConstantInfoRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(CplsCPL2010U00MlayConstantCPL2010Handler.class));
		registerHandler(CplsServiceProto.CPL2010U00LayPrintNameRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL2010U00LayPrintNameHandler.class));
		registerHandler(CplsServiceProto.CPL2010U00LayBarcodeTemp2Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL2010U00LayBarcodeTemp2Handler.class));
		registerHandler(CplsServiceProto.CPL2010U00GrdOrderRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL2010U00GrdOrderHandler.class));
		registerHandler(CplsServiceProto.CPL2010U00OrderCancelGetYNRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(CplsCPL2010U00OrderCancelGetYNCPL2010Handler.class));
		registerHandler(CplsServiceProto.CPL2010U00CheckInjCplOrderRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(CplsCPL2010U00CheckInjCplOrderCPL2010Handler.class));
		registerHandler(CplsServiceProto.CPL2010U00ExecuteGetYValueRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(CplsCPL2010U00ExecuteGetYValueCPL2010Handler.class));
		registerHandler(CplsServiceProto.CPL2010U00GrdPaListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(CPL2010U00GrdPaListHandler.class));
		registerHandler(CplsServiceProto.CPL2010U00OrderCancelGrdOrderRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(CplsCPL2010U00OrderCancelGrdOrderCPL2010Handler.class));
		registerHandler(CplsServiceProto.CPL2010U00PaqryGrdPaRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(CplsCPL2010U00PaqryGrdPaCPL2010Handler.class));
		registerHandler(CplsServiceProto.CPL2010U00GrdTubeQueryStartingRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(CplsCPL2010U00GrdTubeQueryStartingCPL2010Handler.class));
		registerHandler(CplsServiceProto.CPL2010U00GrdSpecimenRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(CplsCPL2010U00GrdSpecimenCPL2010Handler.class));
		registerHandler(CplsServiceProto.CPL2010U00ChangeTimeGrdSpecimenRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(CplsCPL2010U00ChangeTimeGrdSpecimenCPL2010Handler.class));
		registerHandler(CplsServiceProto.CPL2010U00SetPrintRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(CplsCPL2010U00SetPrintCPL2010Handler.class));
		registerHandler(CplsServiceProto.CPL2010U00SaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL2010U00SaveLayoutHandler.class));
		registerHandler(CplsServiceProto.CPL2010U00OrderCancelExecuteRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL2010U00OrderCancelExecuteHandler.class));
		registerHandler(CplsServiceProto.CPL2010U00VsvPaRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL2010U00VsvPaHandler.class));
		registerHandler(CplsServiceProto.CPL2010U00LayChkNamesRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL2010U00LayChkNamesHandler.class));
		// --- [END] CPL2010U00---

		//[START][CPL0106U00] - [Manage group code]
		registerHandler(CplsServiceProto.CPL0106U00FwkGumsaRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL0106U00FwkGumsaHandler.class));
		registerHandler(CplsServiceProto.CPL0106U00GrdCodeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL0106U00GrdCodeHandler.class));
		registerHandler(CplsServiceProto.CPL0106U00GrdGroupRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL0106U00GrdGroupHandler.class));
		registerHandler(CplsServiceProto.CPL0106U00SaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL0106U00SaveLayoutHandler.class));
		registerHandler(CplsServiceProto.CPL0106U00GridColumnChangeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(CPL0106U00GridColumnChangeHandler.class));
		//[END][CPL0106U00] - [Manage group code]
		//[START] CPL7001Q01
		registerHandler(CplsServiceProto.CPL7001CboUitakRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL7001CboUitakHandler.class));
		registerHandler(CplsServiceProto.CPL7001Q01LayDailyReportRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL7001Q01LayDailyReportHandler.class));
		//[END] CPL7001Q01
		//[START] CPL7001Q02
		registerHandler(CplsServiceProto.CPL7001Q02LayMonthlyReportRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL7001Q02LayMonthlyReportHandler.class));
		//[END] CPL7001Q02

		//[START] CPL2010R01
		registerHandler(CplsServiceProto.CPL2010R01LayReserDateRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL2010R01LayReserDateHandler.class));
		registerHandler(CplsServiceProto.CPL2010R01LaySpecimenListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL2010R01LaySpecimenListHandler.class));
		//[END] CPL2010R01

		//[START] CPL2010R00
		registerHandler(CplsServiceProto.CPL2010R00GetBarCodeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL2010R00GetBarCodeHandler.class));
		//[END] CPL2010R00

		//[START] CPL3010U00
		registerHandler(CplsServiceProto.CPL3010U00BtnUrineClickRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3010U00BtnUrineClickHandler.class));
		registerHandler(CplsServiceProto.CPL3010U00QuerySpecimenBySerRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3010U00QuerySpecimenBySerHandler.class));
		registerHandler(CplsServiceProto.CPL3010U00GetYValueRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3010U00GetYValueHandler.class));
		registerHandler(CplsServiceProto.CPL3010U00QueryLaySpecimenReadUpdateRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3010U00QueryLaySpecimenReadUpdateHandler.class));
		registerHandler(CplsServiceProto.CPL3010U00QueryLaySpecimenReadSelectJundalGubunRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3010U00QueryLaySpecimenReadSelectJundalGubunHandler.class));
		registerHandler(CplsServiceProto.CPL3010U00GetZValueRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3010U00GetZValueHandler.class));
		registerHandler(CplsServiceProto.CPL3010U00ExecuteRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3010U00ExecuteHandler.class));
		//new define
		registerHandler(CplsServiceProto.CPL3010U00QueryLaySpecimenReadRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3010U00QueryLaySpecimenReadHandler.class));
		registerHandler(CplsServiceProto.CPL3010U00SaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3010U00SaveLayoutHandler.class));
		registerHandler(CplsServiceProto.CPL3010U00SaveLayUrineRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3010U00SaveLayUrineHandler.class));

		registerHandler(CplsServiceProto.CPL3010U00DsvUrineRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3010U00DsvUrineHandler.class));
		registerHandler(CplsServiceProto.CPL3010U00GrdGumRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3010U00GrdGumHandler.class));
		registerHandler(CplsServiceProto.CPL3010U00GrdPartRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3010U00GrdPartHandler.class));
		registerHandler(CplsServiceProto.CPL3010U00LayBarCodeTempRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3010U00LayBarCodeTempHandler.class));
		registerHandler(CplsServiceProto.CPL3010U00LayBarCodeTemp2Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3010U00LayBarCodeTemp2Handler.class));
		registerHandler(CplsServiceProto.CPL3010U00LaySpecimenReadRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3010U00LaySpecimenReadHandler.class));
		registerHandler(CplsServiceProto.CPL3010U00LaySpecimenRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3010U00LaySpecimenHandler.class));
		registerHandler(CplsServiceProto.CPL3010U00VSVJubsujaRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3010U00VSVJubsujaHandler.class));
		registerHandler(CplsServiceProto.CPL3010U00VSVJundalGubunRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3010U00VSVJundalGubunHandler.class));
		registerHandler(CplsServiceProto.CPL3010U00GetPrintNameRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3010U00GetPrintNameHandler.class));
		//[END] CPL3010U00

		//[START] CPL3020U00
		registerHandler(CplsServiceProto.CPL3020U00PrCplSpecimenInfoResultRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3020U00PrCplSpecimenInfoResultHandler.class));
		registerHandler(CplsServiceProto.CPL3020U00PrOcsoChkResultMsgRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3020U00PrOcsoChkResultMsgHandler.class));
		registerHandler(CplsServiceProto.CPL3020U00PrOcsUpdateResultRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3020U00PrOcsUpdateResultHandler.class));
		registerHandler(CplsServiceProto.CPL3020U00Execute2ProceduresCheckRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3020U00Execute2ProceduresCheckHandler.class));
		registerHandler(CplsServiceProto.CPL3020U00GetSpecimenInfoRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3020U00GetSpecimenInfoHandler.class));
		registerHandler(CplsServiceProto.CPL3020U00ExecuteUpdateConfirmYNRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3020U00ExecuteUpdateConfirmYNHandler.class));
		registerHandler(CplsServiceProto.CPL3020U00SelectInOutGubunRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3020U00SelectInOutGubunHandler.class));
		registerHandler(CplsServiceProto.CPL3020U00ExecuteUpdateCplResultRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3020U00ExecuteUpdateCplResultHandler.class));
		registerHandler(CplsServiceProto.CPL3020U00PrCplCalInsertBaseResultRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3020U00PrCplCalInsertBaseResultHandler.class));
		registerHandler(CplsServiceProto.CPL3020U00SelectFromStandardRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3020U00SelectFromStandardHandler.class));
		registerHandler(CplsServiceProto.CPL3020U00ExecuteGetYValueRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3020U00ExecuteGetYValueHandler.class));
		registerHandler(CplsServiceProto.CPL3020U00ExecuteUpdateCpl2090Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3020U00ExecuteUpdateCpl2090Handler.class));
		registerHandler(CplsServiceProto.CPL3020U00ExecuteInsertCpl2090Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3020U00ExecuteInsertCpl2090Handler.class));
		registerHandler(CplsServiceProto.CPL3020U00FwkResultGetYRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3020U00FwkResultGetYHandler.class));
		registerHandler(CplsServiceProto.CPL3020U00FwkResultInputSQLRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3020U00FwkResultInputSQLHandler.class));
		registerHandler(CplsServiceProto.CPL3020U00LayCommonRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3020U00LayCommonHandler.class));
		registerHandler(CplsServiceProto.CPL3020U00ResultUpdateUpdateCPL3020Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3020U00ResultUpdateUpdateCPL3020Handler.class));

		registerHandler(CplsServiceProto.CPL3020U00GrdResultRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3020U00GrdResultHandler.class));
		registerHandler(CplsServiceProto.CPL3020U00GrdPaRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3020U00GrdPaHandler.class));
		registerHandler(CplsServiceProto.CPL3020U00FwkJundalGubunRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3020U00FwkJundalGubunHandler.class));
		registerHandler(CplsServiceProto.CPL3020U00FwkNoteGubunRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3020U00FwkNoteGubunHandler.class));
		registerHandler(CplsServiceProto.CPL3020U00GrdPaRowFocusChangedRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3020U00GrdPaRowFocusChangedHandler.class));
		registerHandler(CplsServiceProto.CPL3020U00SavePerformerRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3020U00SavePerformerHandler.class));
		registerHandler(CplsServiceProto.CPL3020U00VsvNoteRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3020U00VsvNoteHandler.class));
		//[END] CPL3020U00

		//----------[START] CPLCPL3010U01
		registerHandler(CplsServiceProto.CPL3010U01IsWriteFileSelectCodeValueRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(CPL3010U01IsWriteFileSelectCodeValueHandler.class));
		registerHandler(CplsServiceProto.CPL3010U01IsWriteFileUpdateNoParamRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(CplsCPL3010U01IsWriteFileUpdateNoParamHandler.class));
		registerHandler(CplsServiceProto.CPL3010U01IsWriteFileSelectOrUpdateRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(CplsCPL3010U01IsWriteFileSelectOrUpdateHandler.class));
		registerHandler(CplsServiceProto.CPL3010U01SearchMaxInfoRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(CplsCPL3010U01SearchMaxInfoHandler.class));
		//new define
		registerHandler(CplsServiceProto.CPL3010U01GrdHangmogRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3010U01GrdHangmogHandler.class));
		registerHandler(CplsServiceProto.CPL3010U01GrdResultRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3010U01GrdResultHandler.class));
		registerHandler(CplsServiceProto.CPL3010U01LaySpecimenRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3010U01LaySpecimenHandler.class));
		registerHandler(CplsServiceProto.CPL3010U01LayPrint2Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3010U01LayPrint2Handler.class));
		registerHandler(CplsServiceProto.CPL3010U01GrdPaRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3010U01GrdPaHandler.class));
		registerHandler(CplsServiceProto.CPL3010U01PrePrintRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3010U01PrePrintHandler.class));
		registerHandler(CplsServiceProto.CPL3010U01IsFileWriteRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3010U01IsFileWriteHandler.class));
		registerHandler(CplsServiceProto.CPL3010U01PrCplInsertCpl9000Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3010U01PrCplInsertCpl9000Handler.class));
		registerHandler(CplsServiceProto.CPL3010U01SaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3010U01SaveLayoutHandler.class));
		registerHandler(CplsServiceProto.CPL3010U01CodeValueRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3010U01CodeValueHandler.class));

		//----------[END ] CPLCPL3010U01
		//[START] CPL0000Q00
		registerHandler(CplsServiceProto.CPL0000Q00LayJungboRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL0000Q00LayJungboHandler.class));
		registerHandler(CplsServiceProto.CPL0000Q00LaySigeyulTempRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL0000Q00LaySigeyulTempHandler.class));
		registerHandler(CplsServiceProto.CPL0000Q00LaySubHangmogRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL0000Q00LaySubHangmogHandler.class));
//		registerHandler(CplsServiceProto.CPL0000Q00InitializeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL0000Q00InitializeHandler.class));
		registerHandler(CplsServiceProto.CPL0000Q00ScreenOpenUpdateRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL0000Q00ScreenOpenUpdateHandler.class));
		registerHandler(CplsServiceProto.CPL0000Q00LayOrderRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL0000Q00LayOrderHandler.class));
		registerHandler(CplsServiceProto.CPL0000Q00LayOrderResultListQueryRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL0000Q00LayOrderResultListQueryHandler.class));
		registerHandler(CplsServiceProto.CPL0000Q00LayOrderJubsuListQueryRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL0000Q00LayOrderJubsuListQueryHandler.class));
		registerHandler(CplsServiceProto.CPL0000Q00FrmGraphGetSigeyulRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL0000Q00FrmGraphGetSigeyulHandler.class));
		registerHandler(CplsServiceProto.CPL0000Q00GetSigeyulDataSelect2Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL0000Q00GetSigeyulDataSelect2Handler.class));
		registerHandler(CplsServiceProto.CPL0000Q00ResultListQuerySelect1Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL0000Q00ResultListQuerySelect1Handler.class));
		registerHandler(CplsServiceProto.CPL0000Q00ResultListQuerySelect2Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL0000Q00ResultListQuerySelect2Handler.class));
		registerHandler(CplsServiceProto.CPL0000Q00InsertCPLTEMPRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL0000Q00InsertCPLTEMPHandler.class));
		registerHandler(CplsServiceProto.CPL0000Q00DeleteAndSelectRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL0000Q00DeleteAndSelectHandler.class));
		registerHandler(CplsServiceProto.CPL0000Q00LayResultListTempRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL0000Q00LayResultListTempHandler.class));
		registerHandler(CplsServiceProto.CPL0000Q00FrmSigeyulDelCplTempRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL0000Q00FrmSigeyulDelCplTempHandler.class));

		//[END] CPL0000Q00

		//[START] CPL3020U02
//		registerHandler(CplsServiceProto.CPL3020U02InitializeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3020U02InitializeHandler.class));
		registerHandler(CplsServiceProto.CPL3020U02SetAutoConfirmCheckedRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3020U02SetAutoConfirmCheckedHandler.class));
		registerHandler(CplsServiceProto.CPL3020U02GetSpecimenInfoSelectRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3020U02GetSpecimenInfoSelectHandler.class));
		registerHandler(CplsServiceProto.CPL3020U02ExecuteConfirmYNUpdateRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3020U02ExecuteConfirmYNUpdateHandler.class));
		registerHandler(CplsServiceProto.CPL3020U02ExecuteSelectInOutGubunRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3020U02ExecuteSelectInOutGubunHandler.class));
		registerHandler(CplsServiceProto.CPL3020U02ExecuteCase1FinalUpdateCPL3020Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3020U02ExecuteCase1FinalUpdateCPL3020Handler.class));
		registerHandler(CplsServiceProto.CPL3020U02ExecuteCase2Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3020U02ExecuteCase2Handler.class));
		registerHandler(CplsServiceProto.CPL3020U02FwkResultQueryStartingRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3020U02FwkResultQueryStartingHandler.class));
		registerHandler(CplsServiceProto.CPL3020U02RESULTMAPInitializeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3020U02RESULTMAPInitializeHandler.class));
		registerHandler(CplsServiceProto.CPL3020U02ExecuteCplResulUpdateRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3020U02ExecuteCplResulUpdateHandler.class));
		registerHandler(CplsServiceProto.CPL3020U02RESULTMAPPrCplResultMatchProcRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3020U02RESULTMAPPrCplResultMatchProcHandler.class));
		
		registerHandler(CplsServiceProto.CPL3020U02SetDataIFS7203Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3020U02SetDataIFS7203Handler.class));
		registerHandler(CplsServiceProto.CPL3020U02SetDataIFS7204Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3020U02SetDataIFS7204Handler.class));
		//[END] CPL3020U02	

		//[START] CPL0101U00
		registerHandler(CplsServiceProto.CPL0101U00GridMasterSaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL0101U00GridMasterSaveLayoutHandler.class));
		registerHandler(CplsServiceProto.CPL0101U00InitRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL0101U00InitHandler.class));
		registerHandler(CplsServiceProto.CPL0101U00MakeValSerViceRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL0101U00MakeValSerViceHandler.class));
		registerHandler(CplsServiceProto.CPL0101U00MakeFindWorkerRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL0101U00MakeFindWorkerHandler.class));
		registerHandler(CplsServiceProto.CPL0101U00CheckHangMogCopyRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL0101U00CheckHangMogCopyHandler.class));
		registerHandler(CplsServiceProto.CPL0101U00PrCplCopyCPL0101Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL0101U00PrCplCopyCPL0101Handler.class));
		//[END] CPL0101U00

		//[START] CPLFINDLIB
		registerHandler(CplsServiceProto.CPLFINDLIBGrdFindRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPLFINDLIBGrdFindHandler.class));
		//[END] CPLFINDLIB


		//[START] CPL3020U02-NEW
		registerHandler(CplsServiceProto.CPL3020U02CbxJangbiRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3020U02CbxJangbiHandler.class));
		registerHandler(CplsServiceProto.CPL3020U02GrdPaRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3020U02GrdPaHandler.class));
		registerHandler(CplsServiceProto.CPL3020U02GrdResultRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3020U02GrdResultHandler.class));
		registerHandler(CplsServiceProto.CPL3020U02AutoConfirmCheckedRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3020U02AutoConfirmCheckedHandler.class));
		registerHandler(CplsServiceProto.CPL3020U02SaveRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3020U02SaveHandler.class));
		registerHandler(CplsServiceProto.CPL3020U02ResultMapGrdIDRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3020U02ResultMapGrdIDHandler.class));
		registerHandler(CplsServiceProto.CPL3020U02ResultMapGrdRsltRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3020U02ResultMapGrdRsltHandler.class));
		registerHandler(CplsServiceProto.CPL3020U02PrCplResultMatchProcRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL3020U02PrCplResultMatchProcHandler.class));
		
		//[END] CPL3020U02-NEW

		//[START] MultiResultView
		registerHandler(CplsServiceProto.MultiResultViewLayPaInfoRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(MultiResultViewLayPaInfoHandler.class));
		registerHandler(CplsServiceProto.MultiResultViewGrdSigeyul1Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(MultiResultViewGrdSigeyul1Handler.class));
		registerHandler(CplsServiceProto.MultiResultViewGrdSigeyul2Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(MultiResultViewGrdSigeyul2Handler.class));
		registerHandler(CplsServiceProto.MultiResultViewGetJubsuSigeyulRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(MultiResultViewGetJubsuSigeyulHandler.class));
		registerHandler(CplsServiceProto.MultiResultViewGetPreJubsuSigeyulRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(MultiResultViewGetPreJubsuSigeyulHandler.class));
		//[END] MultiResultView

		//[START] CPL0108U01
		registerHandler(CplsServiceProto.CPL0108U01LayDupMRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL0108U01LayDupMHandler.class));
		registerHandler(CplsServiceProto.CPL0108U01LayDupDRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL0108U01LayDupDHandler.class));
		registerHandler(CplsServiceProto.CPL0108U01GrdMasterRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL0108U01GrdMasterHandler.class));
		registerHandler(CplsServiceProto.CPL0108U01GrdDetailRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL0108U01GrdDetailHandler.class));
		registerHandler(CplsServiceProto.CPL0108U01SaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL0108U01SaveLayoutHandler.class));
		//[START] CPL0108U01	
		
		//[START] CPL0001U00
		registerHandler(CplsServiceProto.CPL0001U00GrdSlipRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL0001U00GrdSlipHandler.class));
		registerHandler(CplsServiceProto.CPL0001U00GrdSaveRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL0001U00GrdSaveHandler.class));
		registerHandler(CplsServiceProto.CPL0001U00GrdChangeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL0001U00GrdChangeHandler.class));
		registerHandler(CplsServiceProto.CPL0001U00GrdComboRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL0001U00GrdComboHandler.class));
		registerHandler(CplsServiceProto.CPL0001U00CboJundalRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL0001U00CboJundalHandler.class));
		//[START] CPL0001U00	
		
		//[START] CPLMASTERUPLOADER
		registerHandler(CplsServiceProto.CPLMASTERUPLOADERPRCplBmlUploaderRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPLMASTERUPLOADERPRCplBmlUploaderHandler.class));
		//[END] CPLMASTERUPLOADER
		
		// [BEGIN] CPL2010U00 Composite
		registerHandler(CplsServiceProto.CPL2010U00OpenScreenCompositeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL2010U00OpenScreenCompositeHandler.class));
		// [END] CPL2010U00 Composite
		registerHandler(CplsServiceProto.CPL0000Q01fwkHangmogCodeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL0000Q01fwkHangmogCodeHandler.class));
		registerHandler(CplsServiceProto.CPL0000Q01layBmlUrlInfoRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL0000Q01layBmlUrlInfoHandler.class));
		registerHandler(CplsServiceProto.CPL0000Q01MakeValServiceRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL0000Q01MakeValServiceHandler.class));
		registerHandler(CplsServiceProto.CPL2010R02grdcpllistRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL2010R02grdcpllistHandler.class));
		registerHandler(CplsServiceProto.CPL2010R02grdOrderListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL2010R02grdOrderListHandler.class));
		registerHandler(CplsServiceProto.CPL2010R02xEditGridCell23Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL2010R02xEditGridCell23Handler.class));
		registerHandler(CplsServiceProto.CPL2010R02fbxBunhoDataValidatingRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL2010R02fbxBunhoDataValidatingHandler.class));
		
		// MIH
		registerHandler(CplsServiceProto.CPL2010U01CHANGETIMEgrdSpecimenRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL2010U01CHANGETIMEgrdSpecimenHandler.class));
		registerHandler(CplsServiceProto.CPL2010U01CHANGETIMESAveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL2010U01CHANGETIMESAveLayoutHandler.class));
		registerHandler(CplsServiceProto.CPL2010U01cbxActorRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL2010U01cbxActorHandler.class));
		registerHandler(CplsServiceProto.CPL2010U01cbxBuseoRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL2010U01cbxBuseoHandler.class));
		registerHandler(CplsServiceProto.CPL2010U01fwkHodongRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL2010U01fwkHodongHandler.class));
		registerHandler(CplsServiceProto.CPL2010U01grdTubeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL2010U01grdTubeHandler.class));
		registerHandler(CplsServiceProto.CPL2010U01layBarcodeTempRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL2010U01layBarcodeTempHandler.class));
		registerHandler(CplsServiceProto.CPL2010U01layBarcodeTemp2Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL2010U01layBarcodeTemp2Handler.class));
		registerHandler(CplsServiceProto.CPL2010U01layTubeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL2010U01layTubeHandler.class));
		registerHandler(CplsServiceProto.CPL2010U01vsvHodongRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL2010U01vsvHodongHandler.class));
		registerHandler(CplsServiceProto.CPL2010U01layPrintNameRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL2010U01layPrintNameHandler.class));
		registerHandler(CplsServiceProto.CPL2010U01cboTimeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL2010U01cboTimeHandler.class));
		registerHandler(CplsServiceProto.CPL2010U01grdSpecimenRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL2010U01grdSpecimenHandler.class));
		registerHandler(CplsServiceProto.CPL2010U01SaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL2010U01SaveLayoutHandler.class));
		registerHandler(CplsServiceProto.CPL2010U01grdPaListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL2010U01grdPaListHandler.class));
		registerHandler(CplsServiceProto.CPL2010U01grdPaRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL2010U01grdPaHandler.class));
		registerHandler(CplsServiceProto.CPL2010U01PostLoadRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL2010U01PostLoadHandler.class));
		registerHandler(CplsServiceProto.CPL2010U01SetPrintRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL2010U01SetPrintHandler.class));
		registerHandler(CplsServiceProto.CPL2010U01layBarcodeTempQueryEndRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL2010U01layBarcodeTempQueryEndHandler.class));
		registerHandler(CplsServiceProto.CPL2010U02layBarcodeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL2010U02layBarcodeHandler.class));
		registerHandler(CplsServiceProto.CPL2010U02grdSpecimenRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL2010U02grdSpecimenHandler.class));
		registerHandler(CplsServiceProto.CPL2010U02SaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPL2010U02SaveLayoutHandler.class));
	}

	@Override
	protected void doStop() throws Exception {

	}
}

