package nta.med.app.vertx.ihis;

import nta.med.core.infrastructure.SpringBeanFactory;
import nta.med.core.infrastructure.socket.vertx.AbstractVerticle;
import nta.med.service.ihis.handler.drgs.*;
import nta.med.service.ihis.handler.drgs.composite.OpenScreenDRG5100P01CompositeHandler;
import nta.med.service.ihis.proto.DrgsServiceProto;

public class DrgsVerticle extends AbstractVerticle {

	public DrgsVerticle() {
		super(DrgsServiceProto.class, DrgsServiceProto.getDescriptor());
	}

	@Override
	protected void doStart() throws Exception {
		//[START] [DRG5100P01] - Publish out-patient prescription
		registerHandler(DrgsServiceProto.DrgsDRG5100P01OrderListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(DrgsDRG5100P01OrderListHandler.class));
		registerHandler(DrgsServiceProto.DrgsDRG5100P01AntiDataListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DrgsDRG5100P01AntiDataListHandler.class));
		registerHandler(DrgsServiceProto.DrgsDRG5100P01AutoJubsuListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DrgsDRG5100P01AutoJubsuListHandler.class));
		registerHandler(DrgsServiceProto.DrgsDRG5100P01LabelListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DrgsDRG5100P01LabelListHandler.class));
		registerHandler(DrgsServiceProto.DrgsDRG5100P01NebokLabelListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DrgsDRG5100P01NebokLabelListHandler.class));
		registerHandler(DrgsServiceProto.DrgsDRG5100P01PaidOrderListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DrgsDRG5100P01PaidOrderListHandler.class));
		registerHandler(DrgsServiceProto.DrgsDRG5100P01PaidJubsuListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DrgsDRG5100P01PaidJubsuListHandler.class));
		registerHandler(DrgsServiceProto.DrgsDRG5100P01OrderOrderListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DrgsDRG5100P01OrderOrderListHandler.class));

		registerHandler(DrgsServiceProto.DrgsDRG5100P01ConstantInfoRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DrgsDRG5100P01ConstantInfoHandler.class));
		registerHandler(DrgsServiceProto.DrgsDRG5100P01MakeBongtuOutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DrgsDRG5100P01MakeBongtuOutHandler.class));
		registerHandler(DrgsServiceProto.DrgsDRG5100P01CheckDsvBoRyuRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DrgsDRG5100P01CheckDsvBoRyuHandler.class));
		registerHandler(DrgsServiceProto.DrgsDRG5100P01GetTimerRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DrgsDRG5100P01GetTimerHandler.class));
		registerHandler(DrgsServiceProto.DrgsDRG5100P01CheckJubsuRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DrgsDRG5100P01CheckJubsuHandler.class));
		registerHandler(DrgsServiceProto.DrgsDRG5100P01MinFKOCS1003Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DrgsDRG5100P01MinFKOCS1003Handler.class));
		registerHandler(DrgsServiceProto.DrgsDRG5100P01LoadChebangPrintRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DrgsDRG5100P01LoadChebangPrintHandler.class));
		registerHandler(DrgsServiceProto.DrgsDRG5100P01LoadMakayJungboRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DrgsDRG5100P01LoadMakayJungboHandler.class));

		registerHandler(DrgsServiceProto.DrgsDRG5100P01DrgwonneaOWnCurListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DrgsDRG5100P01DrgwonneaOWnCurListHandler.class));
		registerHandler(DrgsServiceProto.DrgsDRG5100P01WnSerialQryListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DrgsDRG5100P01WnSerialQryListHandler.class));
		registerHandler(DrgsServiceProto.DrgsDRG5100P01SetNumberRowInsertRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DrgsDRG5100P01SetNumberRowInsertHandler.class));
		registerHandler(DrgsServiceProto.DrgsDRG5100P01GetBogyongNameRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DrgsDRG5100P01GetBogyongNameHandler.class));
		registerHandler(DrgsServiceProto.DrgsDRG5100P01OrderJungboListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DrgsDRG5100P01OrderJungboListHandler.class));
		registerHandler(DrgsServiceProto.DrgsDRG5100P01SetBarDrgBunhoRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DrgsDRG5100P01SetBarDrgBunhoHandler.class));
		registerHandler(DrgsServiceProto.DrgsDRG5100P01JungboListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DrgsDRG5100P01JungboListHandler.class));
		registerHandler(DrgsServiceProto.DrgsDRG5100P01CommentNumberRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DrgsDRG5100P01CommentNumberHandler.class));
		registerHandler(DrgsServiceProto.DrgsDRG5100P01FkocListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DrgsDRG5100P01FkocListHandler.class));
		registerHandler(DrgsServiceProto.DrgsDRG5100P01MaxSeqRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DrgsDRG5100P01MaxSeqHandler.class));
		registerHandler(DrgsServiceProto.DrgsDRG5100P01InsertDataIntoDrgActRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DrgsDRG5100P01InsertDataIntoDrgActHandler.class));
		registerHandler(DrgsServiceProto.DrgsDRG5100P01UpdateFkdrg4010InDRG2010Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DrgsDRG5100P01UpdateFkdrg4010InDRG2010Handler.class));
		registerHandler(DrgsServiceProto.DrgsDRG5100P01UpdateDrgPackYNInDRG2010Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DrgsDRG5100P01UpdateDrgPackYNInDRG2010Handler.class));
		registerHandler(DrgsServiceProto.DrgsDRG5100P01UpdatePowderYNRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DrgsDRG5100P01UpdatePowderYNHandler.class));
		registerHandler(DrgsServiceProto.DrgsDRG5100P01LayAntiDataListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DrgsDRG5100P01LayAntiDataListHandler.class));

		registerHandler(DrgsServiceProto.DrgsDRG5100P01DrgProcMainRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DrgsDRG5100P01DrgProcMainHandler.class));
		registerHandler(DrgsServiceProto.DrgsDRG5100P01DrgMasterInsertRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DrgsDRG5100P01DrgMasterInsertHandler.class));
		//[END] [DRG5100P01] - Publish out-patient prescription

		//[START] [DRG0130U00]
		registerHandler(DrgsServiceProto.DrgsDRG0130U00GrdDrg0130Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DrgsDRG0130U00GrdDrg0130Handler.class));
		registerHandler(DrgsServiceProto.DrgsDRG0130U00CautionCodeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DrgsDRG0130U00CautionCodeHandler.class));
		registerHandler(DrgsServiceProto.DRG0130U00SaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG0130U00SaveLayoutHandler.class));

		//[END] [DRG0130U00]

		//[START] [DRG0140U00] - Manage efficacy
		//registerHandler(DrgsServiceProto.DRG0140U00MasterDetailGridRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG0140U00MasterDetailGridHandler.class));
		//registerHandler(DrgsServiceProto.DRG0140U00ChangeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG0140U00ChangeHandler.class));

		registerHandler(DrgsServiceProto.DRG0140U00GrdMasterRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG0140U00GrdMasterHandler.class));
		registerHandler(DrgsServiceProto.DRG0140U00GrdDetailRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG0140U00GrdDetailHandler.class));
		registerHandler(DrgsServiceProto.DRG0140U00GrdMasterColumnChangedRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG0140U00GrdMasterColumnChangedHandler.class));
		registerHandler(DrgsServiceProto.DRG0140U00GrdDetailColumnChangedRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG0140U00GrdDetailColumnChangedHandler.class));
		registerHandler(DrgsServiceProto.DRG0140U00SaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG0140U00SaveLayoutHandler.class));
		//[END] [DRG0140U00] - Manage efficacy

		//[START] [DRG0201U00] - Used drugs for Outpatient
		registerHandler(DrgsServiceProto.DRG0201U00CboGridRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG0201U00CboGridHandler.class));
		//registerHandler(DrgsServiceProto.DRG0201U00GridPaidRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG0201U00GrdPaidHandler.class));
		//registerHandler(DrgsServiceProto.DRG0201U00DetailServerCallRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG0201U00DetailServerCallHandler.class));
		registerHandler(DrgsServiceProto.DRG0201U00ValidatePrintAdmMediRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG0201U00ValidatePrintAdmMediHandler.class));

		registerHandler(DrgsServiceProto.DRG0201U00ProcAtcInterfaceRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG0201U00ProcAtcInterfaceHandler.class));
		registerHandler(DrgsServiceProto.DRG0201U00GetPatientIdRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG0201U00GetPatientIdHandler.class));
		registerHandler(DrgsServiceProto.DRG0201U00PrDrgUpdateChulgoRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG0201U00PrDrgUpdateChulgoHandler.class));
		registerHandler(DrgsServiceProto.DRG0201U00BarCodeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG0201U00BarCodeHandler.class));

		//client define
		registerHandler(DrgsServiceProto.DRG0201U00GrdOrderListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG0201U00GrdOrderListHandler.class));
		registerHandler(DrgsServiceProto.DRG0201U00GrdPaidRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG0201U00GrdPaidHandler.class));
		registerHandler(DrgsServiceProto.DRG0201U00GrdOrderTbxBarCodeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG0201U00GrdOrderTbxBarCodeHandler.class));
		registerHandler(DrgsServiceProto.DRG0201U00GrdOrderDetailServerCallRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG0201U00GrdOrderDetailServerCallHandler.class));
		registerHandler(DrgsServiceProto.DRG0201U00LockChkRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG0201U00LockChkHandler.class));
		registerHandler(DrgsServiceProto.DRG0201U00PrintAdmMediCheckDrgRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG0201U00PrintAdmMediCheckDrgHandler.class));
		registerHandler(DrgsServiceProto.DRG0201U00PrintAdmMediCheckInjRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG0201U00PrintAdmMediCheckInjHandler.class));
		registerHandler(DrgsServiceProto.DRG0201U00TxtDrgBunhoDataValidatingKeyPressRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG0201U00TxtDrgBunhoDataValidatingKeyPressHandler.class));
		registerHandler(DrgsServiceProto.DRG0201U00CbxActorRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG0201U00CbxActorHandler.class));

		//[END] [DRG0140U01] - Used drugs for Outpatient

		//[START] DrgsDRG5100P01 NEW
		registerHandler(DrgsServiceProto.DRG0201U00ActChkRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG0201U00ActChkHandler.class));
		registerHandler(DrgsServiceProto.DrgsDRG5100P01GridPaidListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DrgsDRG5100P01GridPaidListHandler.class));
		registerHandler(DrgsServiceProto.DrgsDRG5100P01ProcAtcInterfaceRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DrgsDRG5100P01ProcAtcInterfaceHandler.class));
		registerHandler(DrgsServiceProto.DrgsDRG5100P01DsvOrderJungboRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DrgsDRG5100P01DsvOrderJungboHandler.class));
		registerHandler(DrgsServiceProto.DrgsDRG5100P01LayBongtuRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DrgsDRG5100P01LayBongtuHandler.class));
		registerHandler(DrgsServiceProto.DrgsDRG5100P01DsvOrderPrintRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DrgsDRG5100P01DsvOrderPrintHandler.class));
		registerHandler(DrgsServiceProto.DRG5100P01CheckActRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG5100P01CheckActHandler.class));
		//[END] DrgsDRG5100P01 NEW
		//[START] DRG9001R01
		registerHandler(DrgsServiceProto.DRG9001R01Lay9001Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG9001R01Lay9001Handler.class));
		//[END] DRG9001R01

		//[START] DRG9001R02
		registerHandler(DrgsServiceProto.DRG9001R02Lay9001Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG9001R02Lay9001Handler.class));
		//[END] DRG9001R02

		// [START] DRG0102U01
		registerHandler(DrgsServiceProto.DRG0102U01GrdMasterRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG0102U01GrdMasterHandler.class));
		registerHandler(DrgsServiceProto.DRG0102U01GrdDetailRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG0102U01GrdDetailHandler.class));
		registerHandler(DrgsServiceProto.DRG0102U01GrdMasterCheckRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG0102U01GrdMasterCheckHandler.class));
		registerHandler(DrgsServiceProto.DRG0102U01GrdDetailCheckRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG0102U01GrdDetailCheckHandler.class));
		registerHandler(DrgsServiceProto.DRG0102U01SaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG0102U01SaveLayoutHandler.class));
		//[END] DRG0102U01

		//[START] DRG9040U01
		registerHandler(DrgsServiceProto.DRG9040U01GrdJUSAOrderListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG9040U01GrdJUSAOrderListHandler.class));
		registerHandler(DrgsServiceProto.DRG9040U01GrdOrderRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG9040U01GrdOrderHandler.class));
		registerHandler(DrgsServiceProto.DRG9040U01GrdOrderListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG9040U01GrdOrderListHandler.class));
		registerHandler(DrgsServiceProto.DRG9040U01GrdOrderListOutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG9040U01GrdOrderListOutHandler.class));
		registerHandler(DrgsServiceProto.DRG9040U01GrdOrderOutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG9040U01GrdOrderOutHandler.class));
		registerHandler(DrgsServiceProto.DRG9040U01SaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG9040U01SaveLayoutHandler.class));
		registerHandler(DrgsServiceProto.DRG9040U01LayPaCommentRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG9040U01LayPaCommentHandler.class));
		registerHandler(DrgsServiceProto.OpenScreenDRG5100P01CompositeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OpenScreenDRG5100P01CompositeHandler.class));
		//[END] DRG9040U01
		
		registerHandler(DrgsServiceProto.DrgsDRG5100P01PrintNameRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DrgsDRG5100P01PrintNameHandler.class));
		
		// [START MIH]
		registerHandler(DrgsServiceProto.DRG3041P01UserIDRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3041P01UserIDHandler.class));
		registerHandler(DrgsServiceProto.DRG3041P01grdChulgoListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3041P01grdChulgoListHandler.class));
		registerHandler(DrgsServiceProto.DRG3041P01grdChulgoJUSAOrderRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3041P01grdChulgoJUSAOrderHandler.class));
		registerHandler(DrgsServiceProto.DRG3041P01DsvSaveRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3041P01DsvSaveHandler.class));
		registerHandler(DrgsServiceProto.DRG3041P05layIDLoadRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3041P05layIDLoadHandler.class));
		registerHandler(DrgsServiceProto.DRG3041P05getUserIDRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3041P05getUserIDHandler.class));
		registerHandler(DrgsServiceProto.DRG3041P05LabelRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3041P05LabelHandler.class));
		registerHandler(DrgsServiceProto.DRG3041P05grdIpgoJUSAOrderRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3041P05grdIpgoJUSAOrderHandler.class));
		registerHandler(DrgsServiceProto.DRG3041P05grdMixListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3041P05grdMixListHandler.class));
		registerHandler(DrgsServiceProto.DRG3041P05cbxBuseoRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3041P05cbxBuseoHandler.class));
		registerHandler(DrgsServiceProto.DRG3041P05MakeBarcodeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3041P05MakeBarcodeHandler.class));
		registerHandler(DrgsServiceProto.DRG3041P06layIDLoadRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3041P06layIDLoadHandler.class));
		registerHandler(DrgsServiceProto.DRG3041P06laySunameRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3041P06laySunameHandler.class));
		registerHandler(DrgsServiceProto.DRG3041P06layHodongRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3041P06layHodongHandler.class));
		registerHandler(DrgsServiceProto.DRG3041P06getUserIDRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3041P06getUserIDHandler.class));
		registerHandler(DrgsServiceProto.DRG3041P06LabelRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3041P06LabelHandler.class));
		registerHandler(DrgsServiceProto.DRG3041P06grdActJUSAOrderRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3041P06grdActJUSAOrderHandler.class));
		registerHandler(DrgsServiceProto.DRG3041P06grdActListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3041P06grdActListHandler.class));
		registerHandler(DrgsServiceProto.DRG3041P06cbxBuseoRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3041P06cbxBuseoHandler.class));
		registerHandler(DrgsServiceProto.DRG3041P06MakeBarcodeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3041P06MakeBarcodeHandler.class));
		registerHandler(DrgsServiceProto.DRG9001R03cboHoDongRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG9001R03cboHoDongHandler.class));
		registerHandler(DrgsServiceProto.DRG9001R03lay9001RRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG9001R03lay9001RHandler.class));
		registerHandler(DrgsServiceProto.DRG9001R04lay9001RRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG9001R04lay9001RHandler.class));
		registerHandler(DrgsServiceProto.DRG9001R04cboHoDongRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG9001R04cboHoDongHandler.class));
		registerHandler(DrgsServiceProto.DRG3041P01cbxBuseoRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3041P01cbxBuseoHandler.class));
		registerHandler(DrgsServiceProto.DRG3010Q12queryHistoryRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010Q12queryHistoryHandler.class));
		registerHandler(DrgsServiceProto.DRG3010Q12cboBuseoRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010Q12cboBuseoHandler.class));
		registerHandler(DrgsServiceProto.DRG3010Q12grdDrgHistoryRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010Q12grdDrgHistoryHandler.class));
		registerHandler(DrgsServiceProto.DRG3010Q12grdPalistRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010Q12grdPalistHandler.class));
		registerHandler(DrgsServiceProto.DRG3010Q12AntibioticListgrdAntibioticListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010Q12AntibioticListgrdAntibioticListHandler.class));
		registerHandler(DrgsServiceProto.ComboHoDongGwaNameRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ComboHoDongGwaNameHandler.class));
		
		registerHandler(DrgsServiceProto.DRG3010P99cbxActorRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99cbxActorHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99cbxBuseoRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99cbxBuseoHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99grdDcOrderRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99grdDcOrderHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99grdJusaDcOrderRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99grdJusaDcOrderHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99grdListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99grdListHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99grdMagamJusaOrderRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99grdMagamJusaOrderHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99grdMagamOrderRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99grdMagamOrderHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99grdMiMagamJusaOrderRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99grdMiMagamJusaOrderHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99grdMiMagamOrderRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99grdMiMagamOrderHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99grdPaDcListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99grdPaDcListHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99PaPrnRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99PaPrnHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99grdPaRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99grdPaHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99grdPrnJusaRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99grdPrnJusaHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99grdPrnRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99grdPrnHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99layOutOrderRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99layOutOrderHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99layConstantRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99layConstantHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99OrdPrnCurRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99OrdPrnCurHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99OrdPrnSerialRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99OrdPrnSerialHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99SerialvRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99SerialvHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99OrdPrnRemarkRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99OrdPrnRemarkHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99layOrderJungboRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99layOrderJungboHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99getBarDrgBunhoRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99getBarDrgBunhoHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99getBodyIndexRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99getBodyIndexHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99layOrderBarcodeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99layOrderBarcodeHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99getBodyIndexBarcodeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99getBodyIndexBarcodeHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99JusaCurRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99JusaCurHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99JusaSerialRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99JusaSerialHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99JusaserialvRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99JusaserialvHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99SerRemarkRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99SerRemarkHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99JusaLabelRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99JusaLabelHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99JusaKRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99JusaKHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99JusaCommentRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99JusaCommentHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99getFkocs2003Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99getFkocs2003Handler.class));
		registerHandler(DrgsServiceProto.DRG3010P99CheckDetailMaxActingRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99CheckDetailMaxActingHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99DeleteDrg3041Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99DeleteDrg3041Handler.class));
		registerHandler(DrgsServiceProto.DRG3010P99FnDrgChulgoDateRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99FnDrgChulgoDateHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99MaxSeqRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99MaxSeqHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99InsertDrgAtcRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99InsertDrgAtcHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99ToiwonGojiYnRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99ToiwonGojiYnHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99FnAdmMsgRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99FnAdmMsgHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99UpdateDrg3010Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99UpdateDrg3010Handler.class));
		registerHandler(DrgsServiceProto.DRG3010P99getRemarkRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99getRemarkHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99getYOrderGubunRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99getYOrderGubunHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99PrLoadBongtuRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99PrLoadBongtuHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99PrMakeBongtuRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99PrMakeBongtuHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99PrInpMagamRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99PrInpMagamHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99PrPrintGubunRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99PrPrintGubunHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99PrMakeBarcodeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99PrMakeBarcodeHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99PrBunhoCancelRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99PrBunhoCancelHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99PrMakeDrg3060Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99PrMakeDrg3060Handler.class));
		registerHandler(DrgsServiceProto.DRG3010P99PrMasterInsertRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99PrMasterInsertHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99PrDrgProcMainRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99PrDrgProcMainHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99PrDrg5010Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99PrDrg5010Handler.class));
		registerHandler(DrgsServiceProto.DRG3010P99PrDrg5030Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99PrDrg5030Handler.class));
		registerHandler(DrgsServiceProto.DRG3010P99PrDrgIfsRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99PrDrgIfsHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99PrJihInjIfsProcRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99PrJihInjIfsProcHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P99cbxTimeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P99cbxTimeHandler.class));
		registerHandler(DrgsServiceProto.DRG3041P06grdActListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3041P06grdActListHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P10CboRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P10CboHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P10GrdDcOrderRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P10GrdDcOrderHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P10GrdDrgBunhoRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P10GrdDrgBunhoHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P10GrdJusaDcOrderRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P10GrdJusaDcOrderHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P10GrdMagamJusaOrdRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P10GrdMagamJusaOrdHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P10GrdMagamOrdRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P10GrdMagamOrdHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P10GrdMagamPaQueryRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P10GrdMagamPaQueryHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P10GrdMiMaJuOrdRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P10GrdMiMaJuOrdHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P10GrdMiMaOrdRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P10GrdMiMaOrdHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P10GrdPaDcRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P10GrdPaDcHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P10GrdPaRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P10GrdPaHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P10LayAntiDataRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P10LayAntiDataHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P10LayOrderJungboRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P10LayOrderJungboHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P10PostLoadRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P10PostLoadHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P10BoRyuRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P10BoRyuHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P10PrDrgInpBunhoCancelRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P10PrDrgInpBunhoCancelHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P10BtnNumberCancelRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P10BtnNumberCancelHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P10PrDrgLoadPrintGubunRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P10PrDrgLoadPrintGubunHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P10DsvOrderPrint1Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P10DsvOrderPrint1Handler.class));
		registerHandler(DrgsServiceProto.DRG3010P10DsvOrderPrint2Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P10DsvOrderPrint2Handler.class));
		registerHandler(DrgsServiceProto.DRG3010P10DsvOrderPrint3Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P10DsvOrderPrint3Handler.class));
		registerHandler(DrgsServiceProto.DRG3010P10DsvOrderPrint4Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P10DsvOrderPrint4Handler.class));
		registerHandler(DrgsServiceProto.DRG3010P10DsvJusaOrderPrint1Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P10DsvJusaOrderPrint1Handler.class));
		registerHandler(DrgsServiceProto.DRG3010P10DsvJusaOrderPrint2Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P10DsvJusaOrderPrint2Handler.class));
		registerHandler(DrgsServiceProto.DRG3010P10DsvJusaOrderPrint3Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P10DsvJusaOrderPrint3Handler.class));
		registerHandler(DrgsServiceProto.DRG3010P10DsvJusaOrderPrint4Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P10DsvJusaOrderPrint4Handler.class));
		registerHandler(DrgsServiceProto.DRG3010P10DsvJusaLabel1Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P10DsvJusaLabel1Handler.class));
		registerHandler(DrgsServiceProto.DRG3010P10DsvJusaLabel2Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P10DsvJusaLabel2Handler.class));
		registerHandler(DrgsServiceProto.DRG3010P10DsvJusaLabel3Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P10DsvJusaLabel3Handler.class));
		registerHandler(DrgsServiceProto.DRG3010P10PrDrgInpMagamRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P10PrDrgInpMagamHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P10Xbtn2ClickRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P10Xbtn2ClickHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P10LayAntinQueryEndRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P10LayAntinQueryEndHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P10SetCycleDateRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P10SetCycleDateHandler.class));
		registerHandler(DrgsServiceProto.DRG3010P10PrJihInjIfsProcRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG3010P10PrJihInjIfsProcHandler.class));
		// [END MIH]
	}

	@Override
	protected void doStop() throws Exception {

	}
}

