package nta.med.app.vertx.ihis;

import nta.med.core.infrastructure.SpringBeanFactory;
import nta.med.core.infrastructure.socket.vertx.AbstractVerticle;
import nta.med.service.ihis.handler.inps.*;
import nta.med.service.ihis.proto.InpsServiceProto;

public class InpsVerticle extends AbstractVerticle {

	public InpsVerticle() {
		super(InpsServiceProto.class, InpsServiceProto.getDescriptor());
	}

	@Override
	protected void doStart() throws Exception {
		registerHandler(InpsServiceProto.INP2004Q01grdINP2004Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP2004Q01grdINP2004Handler.class));
		registerHandler(InpsServiceProto.INP1001Q00grdINP1001Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1001Q00GrdINP1001Handler.class));
		registerHandler(InpsServiceProto.INP2001U02grdOcs2003Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP2001U02grdOcs2003Handler.class));
		registerHandler(InpsServiceProto.INP2001U02layNuGroupRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP2001U02layNuGroupHandler.class));
		registerHandler(InpsServiceProto.INP2001U02setIconRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP2001U02setIconHandler.class));
		registerHandler(InpsServiceProto.INP2001U02grdOcs1003Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP2001U02grdOcs1003Handler.class));
		
		registerHandler(InpsServiceProto.INP1001R04cboHodongRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1001R04cboHodongHandler.class));
		registerHandler(InpsServiceProto.INP1001R04grdIpToiListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1001R04grdIpToiListHandler.class));
		registerHandler(InpsServiceProto.INP1001D01grdINP1001Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1001D01grdINP1001Handler.class));
		registerHandler(InpsServiceProto.INP1001D01cboHodongRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1001D01cboHodongHandler.class));
		registerHandler(InpsServiceProto.INP1003Q00fwkHoDongRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1003Q00fwkHoDongHandler.class));
		registerHandler(InpsServiceProto.INP1003Q00grdINP1003Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1003Q00grdINP1003Handler.class));
		registerHandler(InpsServiceProto.INP1003Q00cboReserEndTypeGridCellRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1003Q00cboReserEndTypeGridCellHandler.class));
		registerHandler(InpsServiceProto.INP1003Q00MakeHodongComboRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1003Q00MakeHodongComboHandler.class));
		registerHandler(InpsServiceProto.INP2001U02ProcessJunipRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP2001U02ProcessJunipHandler.class));
		registerHandler(InpsServiceProto.INP1001U01MultiComboRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1001U01MultiComboHandler.class));
		registerHandler(InpsServiceProto.INP1001U01LayLastCheckDateRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1001U01LayLastCheckDateHandler.class));
		registerHandler(InpsServiceProto.INP1001U01LayCheckEctIpwonRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1001U01LayCheckEctIpwonHandler.class));
		registerHandler(InpsServiceProto.INP1001U01FwkGubunRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1001U01FwkGubunHandler.class));
		registerHandler(InpsServiceProto.INP1001U01GrdInp1001Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1001U01GrdInp1001Handler.class));
		registerHandler(InpsServiceProto.INP1001U01GrdInp1004Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1001U01GrdInp1004Handler.class));
		registerHandler(InpsServiceProto.INP1001U01GrdInp1008Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1001U01GrdInp1008Handler.class));
		registerHandler(InpsServiceProto.INP2004Q00grdINP2004Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP2004Q00grdINP2004Handler.class));
		registerHandler(InpsServiceProto.INP2004Q00grdHoCodeListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP2004Q00grdHoCodeListHandler.class));
		// INP3003U00
		registerHandler(InpsServiceProto.INP3003U00cboSimsaMagamGubunresultAfterDisRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP3003U00cboSimsaMagamGubunresultAfterDisHandler.class));
		registerHandler(InpsServiceProto.INP3003U00layLoadToiwonResDateRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP3003U00layLoadToiwonResDateHandler.class));
		registerHandler(InpsServiceProto.INP3003U00grdINP2002Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP3003U00grdINP2002Handler.class));
		registerHandler(InpsServiceProto.INP3003U00grdINP1001Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP3003U00grdINP1001Handler.class));
		registerHandler(InpsServiceProto.INP3003U00grdINP1001PastRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP3003U00grdINP1001PastHandler.class));
		
		registerHandler(InpsServiceProto.INP1001U01EtcIpwongrdHistoryRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1001U01EtcIpwongrdHistoryHandler.class));
		registerHandler(InpsServiceProto.INP3003U00SakuraToiwonInputRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP3003U00SakuraToiwonInputHandler.class));
		registerHandler(InpsServiceProto.INP3003U00ToiwonCancelRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP3003U00ToiwonCancelHandler.class));
		registerHandler(InpsServiceProto.INP3003U00SaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP3003U00SaveLayoutHandler.class));
		
		// INP1003U01
		registerHandler(InpsServiceProto.INP1003U01grdINP1003Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1003U01grdINP1003Handler.class));
		registerHandler(InpsServiceProto.INP1003U01layBunhoValidationRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1003U01layBunhoValidationHandler.class));
		registerHandler(InpsServiceProto.INP1003U01cboEmergencyRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1003U01cboEmergencyHandler.class));
		registerHandler(InpsServiceProto.INP1003U01fbxInp1003Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1003U01fbxInp1003Handler.class));
		registerHandler(InpsServiceProto.INP1003U01CancelReserRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1003U01CancelReserHandler.class));
		registerHandler(InpsServiceProto.INP1003U01CheckBoolRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1003U01CheckBoolHandler.class));
		registerHandler(InpsServiceProto.INP1003U01SaveLayoutGrdRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1003U01SaveLayoutGrdHandler.class));
		registerHandler(InpsServiceProto.INP1003U01layDeleteRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1003U01layDeleteHandler.class));
		registerHandler(InpsServiceProto.INP1003U01layIpWonRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1003U01layIpWonHandler.class));
		registerHandler(InpsServiceProto.INP1003U01ProcedureRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1003U01ProcedureHandler.class));				
		
		registerHandler(InpsServiceProto.INPBATCHTRANScbxBuseoRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INPBATCHTRANScbxBuseoHandler.class));
		registerHandler(InpsServiceProto.INPBATCHTRANSExecuteProcedureRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INPBATCHTRANSExecuteProcedureHandler.class));
		registerHandler(InpsServiceProto.INPBATCHTRANSgrdInpListQueryStartingrbnMiTransRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INPBATCHTRANSgrdInpListQueryStartingrbnMiTransHandler.class));
		registerHandler(InpsServiceProto.INPBATCHTRANSgrdInpListQueryStartingrbnTransRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INPBATCHTRANSgrdInpListQueryStartingrbnTransHandler.class));
		registerHandler(InpsServiceProto.INPBATCHTRANSisJaewonPatientRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INPBATCHTRANSisJaewonPatientHandler.class));
		registerHandler(InpsServiceProto.INPBATCHTRANSlayOut0101Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INPBATCHTRANSlayOut0101Handler.class));
		registerHandler(InpsServiceProto.INPBATCHTRANSOrderTransRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INPBATCHTRANSOrderTransHandler.class));
		registerHandler(InpsServiceProto.INP1001U01ChangeGubunSaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1001U01ChangeGubunSaveLayoutHandler.class));
		
		registerHandler(InpsServiceProto.INP1001U01EtcIpwonlayCommonDoctorRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1001U01EtcIpwonlayCommonDoctorHandler.class));
		registerHandler(InpsServiceProto.INP1001U01EtcIpwonSaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1001U01EtcIpwonSaveLayoutHandler.class));
		registerHandler(InpsServiceProto.INP1001U01EtcIpwonxEditGridCellRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1001U01EtcIpwonxEditGridCellHandler.class));
		registerHandler(InpsServiceProto.INP1001U01IpwonSelectFormgrdIpwonHistoryRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1001U01IpwonSelectFormgrdIpwonHistoryHandler.class));
		registerHandler(InpsServiceProto.INP1001U01IpwonSelectFormxEditGridCellRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1001U01IpwonSelectFormxEditGridCellHandler.class));
		
		// INPORDERTRANS
		registerHandler(InpsServiceProto.INPORDERTRANSSangTransRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INPORDERTRANSSangTransHandler.class));
		registerHandler(InpsServiceProto.INPORDERTRANSSetProcessGongbiRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INPORDERTRANSSetProcessGongbiHandler.class));
		registerHandler(InpsServiceProto.INPORDERTRANSProcessRequisRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INPORDERTRANSProcessRequisHandler.class));
		registerHandler(InpsServiceProto.INPORDERTRANSLayOut0101Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INPORDERTRANSLayOut0101Handler.class));
		registerHandler(InpsServiceProto.INPORDERTRANSGrdWoiChulRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INPORDERTRANSGrdWoiChulHandler.class));
		registerHandler(InpsServiceProto.INPORDERTRANSGrdOutSangRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INPORDERTRANSGrdOutSangHandler.class));
		registerHandler(InpsServiceProto.INPORDERTRANSIsJaewonPatientRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INPORDERTRANSIsJaewonPatientHandler.class));
		registerHandler(InpsServiceProto.INPORDERTRANSGrdWoiChul2Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INPORDERTRANSGrdWoiChul2Handler.class));
		registerHandler(InpsServiceProto.INPORDERTRANSSelectListSQL3Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INPORDERTRANSSelectListSQL3Handler.class));
		registerHandler(InpsServiceProto.INPORDERTRANSGrdSiksaRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INPORDERTRANSGrdSiksaHandler.class));
		registerHandler(InpsServiceProto.INPORDERTRANSSelectListSQL2Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INPORDERTRANSSelectListSQL2Handler.class));
		
		registerHandler(InpsServiceProto.INP1003U00grdCSC0108Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1003U00grdCSC0108Handler.class));
		registerHandler(InpsServiceProto.INP1003U00cboCategoryGubunRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1003U00cboCategoryGubunHandler.class));
		registerHandler(InpsServiceProto.INP1003U00fwkDoctorRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1003U00fwkDoctorHandler.class));
		registerHandler(InpsServiceProto.INP1003U00fwkGwaRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1003U00fwkGwaHandler.class));
		registerHandler(InpsServiceProto.INP1003U00grdInpReserRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1003U00grdInpReserHandler.class));
		registerHandler(InpsServiceProto.INP1003U00xEditGridCellRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1003U00xEditGridCellHandler.class));
		registerHandler(InpsServiceProto.INP1003U00cboHodongRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1003U00cboHodongHandler.class));
		registerHandler(InpsServiceProto.INP1003U00MakeHodongComboRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1003U00MakeHodongComboHandler.class));
		registerHandler(InpsServiceProto.INP1003U00grdInpReserGridColumnChangeddtBunhoRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1003U00grdInpReserGridColumnChangeddtBunhoHandler.class));
		registerHandler(InpsServiceProto.INP1003U00grdInpReserGridColumnChangeddtReserRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1003U00grdInpReserGridColumnChangeddtReserHandler.class));
		registerHandler(InpsServiceProto.INP1003U00grdInpReserGridColumnChangedrtnresultRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1003U00grdInpReserGridColumnChangedrtnresultHandler.class));
		registerHandler(InpsServiceProto.INP1003U00grdInpReserGridColumnChangeddtHoSilRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1003U00grdInpReserGridColumnChangeddtHoSilHandler.class));
		registerHandler(InpsServiceProto.INP1003U00grdInpReserGridColumnChangeddtGwaRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1003U00grdInpReserGridColumnChangeddtGwaHandler.class));
		registerHandler(InpsServiceProto.INP1003U00grdInpReserGridColumnChangedrtndoctornameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1003U00grdInpReserGridColumnChangedrtndoctornameHandler.class));
		registerHandler(InpsServiceProto.INP1001U01INPDateFormExeProcRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1001U01INPDateFormExeProcHandler.class));
		
		registerHandler(InpsServiceProto.INP1001U01DoubleMultiCboRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1001U01DoubleMultiCboHandler.class));
		registerHandler(InpsServiceProto.INP1001U01DoubleLoadDataRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1001U01DoubleLoadDataHandler.class));
		registerHandler(InpsServiceProto.INP1001U01DoubleFindClickRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1001U01DoubleFindClickHandler.class));
		registerHandler(InpsServiceProto.INP1001U01ExecuteProcedureRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1001U01ExecuteProcedureHandler.class));
		registerHandler(InpsServiceProto.INP3003U00ExecuteProcedureRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP3003U00ExecuteProcedureHandler.class));
		registerHandler(InpsServiceProto.INP1001U01ReserSelectgrdINP1003Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1001U01ReserSelectgrdINP1003Handler.class));
		registerHandler(InpsServiceProto.INP1001U01DoubleGrdINP1002Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1001U01DoubleGrdINP1002InfoHandler.class));
		registerHandler(InpsServiceProto.INP1001U01DoubleGrdINP1008Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1001U01DoubleGrdINP1008Handler.class));
		registerHandler(InpsServiceProto.INPORDERTRANSGrdOCS2003Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INPORDERTRANSGrdOCS2003Handler.class));
		registerHandler(InpsServiceProto.INPORDERTRANSSelectListSQL0Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INPORDERTRANSSelectListSQL0Handler.class));
		registerHandler(InpsServiceProto.INP1001U01MakeIpwonTypeComboRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1001U01MakeIpwonTypeComboHandler.class));
		registerHandler(InpsServiceProto.INP1001U01LoadIpwonTypeListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1001U01LoadIpwonTypeListHandler.class));
		registerHandler(InpsServiceProto.INP1001U01DoubleSaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1001U01DoubleSaveLayoutHandler.class));
		registerHandler(InpsServiceProto.INP1001U01ChangeGubunGrdHistoryRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1001U01ChangeGubunGrdHistoryHandler.class));
		registerHandler(InpsServiceProto.INP1001U01ChangeGubunLayGubunRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1001U01ChangeGubunLayGubunHandler.class));
		registerHandler(InpsServiceProto.INP1001U01DefaultSettingINP1001Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1001U01DefaultSettingINP1001Handler.class));
		registerHandler(InpsServiceProto.INP1001U01DoubleGrdINP1002Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1001U01DoubleGrdINP1002InfoHandler.class));
		registerHandler(InpsServiceProto.INP1001U01DtpBirthDataValidatingRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1001U01DtpBirthDataValidatingHandler.class));
		registerHandler(InpsServiceProto.INP1001U01FindBoxFindClickRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1001U01FindBoxFindClickHandler.class));
		registerHandler(InpsServiceProto.INP1001U01GrdOut0103Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1001U01GrdOut0103Handler.class));
		registerHandler(InpsServiceProto.INP1001U01GrdOut0106Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1001U01GrdOut0106Handler.class));
		registerHandler(InpsServiceProto.INP1001U01IpwonCancelRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1001U01IpwonCancelHandler.class));
		registerHandler(InpsServiceProto.INP1001U01LayInp1002Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1001U01LayInp1002Handler.class));
		registerHandler(InpsServiceProto.INP1001U01LoadBoheomChildListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1001U01LoadBoheomChildListHandler.class));
		registerHandler(InpsServiceProto.INP1001U01LoadGongbiQueryRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1001U01LoadGongbiQueryHandler.class));
		registerHandler(InpsServiceProto.INP1001U01SaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1001U01SaveLayoutHandler.class));
		registerHandler(InpsServiceProto.INP1003U00SaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1003U00SaveLayoutHandler.class));
		registerHandler(InpsServiceProto.INPORDERTRANSExecuteProcRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INPORDERTRANSExecuteProcHandler.class));
		registerHandler(InpsServiceProto.INPORDERTRANSSelectListSQL1Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INPORDERTRANSSelectListSQL1Handler.class));
		registerHandler(InpsServiceProto.INPORDERTRANSAccountCompleteRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INPORDERTRANSAccountCompleteHandler.class));
		
		registerHandler(InpsServiceProto.INP1001D00grdINP1001Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INP1001D00grdINP1001Handler.class));
	}	

	@Override
	protected void doStop() throws Exception {
		
	}

}
