package nta.med.app.vertx.ihis;

import nta.med.core.infrastructure.SpringBeanFactory;
import nta.med.core.infrastructure.socket.vertx.AbstractVerticle;
import nta.med.service.ihis.handler.ocsa.*;
import nta.med.service.ihis.handler.ocsa.composite.OCS0103U13OpenScreenHandler;
import nta.med.service.ihis.handler.ocsa.composite.OCS0103U14FirstOpenScreenHandler;
import nta.med.service.ihis.handler.ocsa.composite.OCS0103U16ScreenOpenHandler;
import nta.med.service.ihis.handler.ocsa.composite.OCS0103U17ScreenOpenHandler;
import nta.med.service.ihis.handler.ocsa.composite.OpenScreenU18CompositeHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;

public class OcsaVerticle extends AbstractVerticle {

	public OcsaVerticle() {
		super(OcsaServiceProto.class, OcsaServiceProto.getDescriptor());
	}
	
	@Override
	protected void doStart() throws Exception {
		//[START] OCS1003P01
		registerHandler(OcsaServiceProto.OCSAOCS0270Q00CboDoctorGradeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCSAOCS0270Q00CboDoctorGradeHandler.class));
		registerHandler(OcsaServiceProto.OCSAOCS0270Q00GridBAS0270Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCSAOCS0270Q00GridBAS0270Handler.class));
		//[END] OCS1003P01
		
		//[START] [SERVER][OCS0503Q01] - Refer examination request by patient
		registerHandler(OcsaServiceProto.OcsaOCS0503Q01ListDataRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsaOCS0503Q01ListDataHandler.class));
		//[END] [SERVER][OCS0503Q01] - Refer examination request by patient
		
		//[START] [SERVER][OCS0503U01] - Reply exam request
		registerHandler(OcsaServiceProto.OcsaOCS0503U01GrdOCS0503ListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsaOCS0503U01GrdOCS0503ListHandler.class));
		registerHandler(OcsaServiceProto.OcsaOCS0503U01CommonDataRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsaOCS0503U01CommonDataHandler.class));
		registerHandler(OcsaServiceProto.OCS0503U01SaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0503U01SaveLayoutHandler.class));
		//[END] [SERVER][OCS0503U01] - Reply exam request
		 
		//[START] OCS0503Q00
		registerHandler(OcsaServiceProto.OCS0503Q00LoadConsultInfoRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0503Q00LoadConsultInfoHandler.class));
		registerHandler(OcsaServiceProto.OCS0503Q00FilteringTheInformationRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0503Q00FilteringTheInformationHandler.class));
		registerHandler(OcsaServiceProto.OCS0503Q00DepartmentNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0503Q00DepartmentNameHandler.class));
		registerHandler(OcsaServiceProto.OCS0503Q00DoctorNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0503Q00DoctorNameHandler.class));
		registerHandler(OcsaServiceProto.OCS0503Q00FdwCommonGwaRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0503Q00FdwCommonGwaHandler.class));
		registerHandler(OcsaServiceProto.OCS0503Q00FdwCommonDoctorRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0503Q00FdwCommonDoctorHandler.class));
		//[END] OCS0503Q00
		
		//[START] OCS0221U00
		registerHandler(OcsaServiceProto.OcsaOCS0221U00GrdOCS0222ListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsaOCS0221U00GrdOCS0222ListHandler.class));
		registerHandler(OcsaServiceProto.OcsaOCS0221U00CommonDataRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsaOCS0221U00CommonDataHandler.class));
		registerHandler(OcsaServiceProto.OcsaOCS0221U00SeqRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsaOCS0221U00SeqHandler.class));
		
		registerHandler(OcsaServiceProto.OcsaOCS0221U00SaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsaOCS0221U00SaveLayoutHandler.class));
		//[END] OCS0221U00
		
		//[START] OCS0204U00
		registerHandler(OcsaServiceProto.OcsaOCS0204U00GrdOCS0204ListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsaOCS0204U00GrdOCS0204ListHandler.class));
		registerHandler(OcsaServiceProto.OcsaOCS0204U00GrdOCS0205ListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsaOCS0204U00GrdOCS0205ListHandler.class));
		
		registerHandler(OcsaServiceProto.OcsaOCS0204U00SangGubunNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsaOCS0204U00SangGubunNameHandler.class));
		registerHandler(OcsaServiceProto.OcsaOCS0204U00SangNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsaOCS0204U00SangNameHandler.class));
		registerHandler(OcsaServiceProto.OcsaOCS0204U00GwaRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsaOCS0204U00GwaHandler.class));
		registerHandler(OcsaServiceProto.OcsaOCS0204U00SaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsaOCS0204U00SaveLayoutHandler.class));
		registerHandler(OcsaServiceProto.OcsaOCS0204U00FindWorkerListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsaOCS0204U00FindWorkerListHandler.class));

		//[END] OCS0204U00
		
		//[START] OCS0150U00
		registerHandler(OcsaServiceProto.OcsaOCS0150U00ListUserRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsaOCS0150U00ListUserHandler.class));
		registerHandler(OcsaServiceProto.OcsaOCS0150U00DepartmentListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsaOCS0150U00DepartmentListHandler.class));
		registerHandler(OcsaServiceProto.OcsaOCS0150U00InsertIntoOCS0150Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsaOCS0150U00InsertIntoOCS0150Handler.class));
		registerHandler(OcsaServiceProto.OcsaOCS0150U00UpdateOCS0150Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsaOCS0150U00UpdateOCS0150Handler.class));
		registerHandler(OcsaServiceProto.OcsaOCS0150U00DeleteOCS0150Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsaOCS0150U00DeleteOCS0150Handler.class));
	    //[END] OCS0150U00
	    
	    //[START] OCS0208U00
		registerHandler(OcsaServiceProto.OcsaOCS0208U00CommonDataRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsaOCS0208U00CommonDataHandler.class));
		registerHandler(OcsaServiceProto.OcsaOCS0208U00LoadBogyongNameFromOcsRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsaOCS0208U00LoadBogyongNameFromOcsHandler.class));
		registerHandler(OcsaServiceProto.OcsaOCS0208U00LoadBogyongNameFromDrgRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsaOCS0208U00LoadBogyongNameFromDrgHandler.class));
		registerHandler(OcsaServiceProto.OcsaOCS0208U00SaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsaOCS0208U00SaveLayoutHandler.class));
	    //[END] OCS0208U00
		
		
		//[START] OCS0304U00
		registerHandler(OcsaServiceProto.OCS0304U00GrdOCS0304Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0304U00GrdOCS0304Handler.class));
		registerHandler(OcsaServiceProto.OCS0304U00GrdOCS0305Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0304U00GrdOCS0305Handler.class));
		registerHandler(OcsaServiceProto.OCS0304U00GrdOCS0306Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0304U00GrdOCS0306Handler.class));
//	    registerHandler(OcsaServiceProto.OCS0304U00SaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS0304U00SaveLayoutHandler.class));
		registerHandler(OcsaServiceProto.OcsaOCS0304U00GetDoctorYaksokOpenIdRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsaOCS0304U00GetDoctorYaksokOpenIdHandler.class));
		registerHandler(OcsaServiceProto.OcsaOCS0304U00GetYaksokDirectNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsaOCS0304U00GetYaksokDirectNameHandler.class));
		registerHandler(OcsaServiceProto.OCS0304U00GrdOCS0304SaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0304U00GrdOCS0304SaveLayoutHandler.class));
		registerHandler(OcsaServiceProto.OCS0304U00GrdOCS0305SaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0304U00GrdOCS0305SaveLayoutHandler.class));
		registerHandler(OcsaServiceProto.OCS0304U00GrdOCS0306SaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0304U00GrdOCS0306SaveLayoutHandler.class));
		//[END] OCS0304U00 
		
		//[START] [OCS0301U00] - Manage order set for user
		registerHandler(OcsaServiceProto.OCS0301U00CboDoctorGwaRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0301U00CboDoctorGwaHandler.class));
		registerHandler(OcsaServiceProto.OCS0301U00MembCRUDRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0301U00MembCRUDHandler.class));
		registerHandler(OcsaServiceProto.OCS0301U00FwkUserRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0301U00FwkUserHandler.class));
		registerHandler(OcsaServiceProto.OCS0301U00GrdOCS0300Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0301U00GrdOCS0300Handler.class));
		registerHandler(OcsaServiceProto.OCS0301U00GrdOCS0301Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0301U00GrdOCS0301Handler.class));
		registerHandler(OcsaServiceProto.OCS0301U00SeqRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0301U00SeqHandler.class));
		registerHandler(OcsaServiceProto.OCS0301U00LayQueryLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0301U00LayQueryLayoutHandler.class));
		//[END] [OCS0301U00] - Manage order set for user
				
		//[START] OCS0503U00
		registerHandler(OcsaServiceProto.OcsaOCS0503U00LoadOutSangRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsaOCS0503U00LoadOutSangOCS0503U00Handler.class));
		registerHandler(OcsaServiceProto.OCS0503U00CreateTimeComboRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsaOCS0503U00CreateTimeComboOCS0503U00Handler.class));
		registerHandler(OcsaServiceProto.OCS0503U00CheckInpPatientRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsaOCS0503U00CheckInpPatientOCS0503U00Handler.class));
		registerHandler(OcsaServiceProto.OCS0503U00ValidationCheckRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsaOCS0503U00ValidationCheckOCS0503Handler.class));
		registerHandler(OcsaServiceProto.OCS0503U00GetCodeNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsaOCS0503U00GetCodeNameOCS0503Handler.class));
		registerHandler(OcsaServiceProto.OCS0503U00gridOSC0503ListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsaOCS0503U00GridOSC0503ListHandler.class));
		registerHandler(OcsaServiceProto.OCS0503U00SaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0503U00SaveLayoutHandler.class));
		registerHandler(OcsaServiceProto.OCS0503U00CommonRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsaOCS0503U00CommonRequestOCS0503Handler.class));
		registerHandler(OcsaServiceProto.OCS0503U00GetFindWorkerRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsaOCS0503U00GetFindWorkerOCS0503Handler.class));
		//[END] OCS0503U00
		
		//[START] OCS0311U00
		registerHandler(OcsaServiceProto.OCS0311U00FwkDanuiRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0311U00FwkDanuiHandler.class));
		registerHandler(OcsaServiceProto.OCS0311U00LayDanuiRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0311U00LayDanuiHandler.class));
		registerHandler(OcsaServiceProto.OCS0311U00LayHangmogCodeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0311U00LayHangmogCodeHandler.class));
		//	registerHandler(OcsaServiceProto.OCS0311U00InitializeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS0311U00InitializeHandler.class));
		registerHandler(OcsaServiceProto.OCS0311U00CboPartBySetTableRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0311U00CboPartBySetTableHandler.class));
		registerHandler(OcsaServiceProto.OCS0311U00grdSetHangmogGridFindRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0311U00grdSetHangmogGridFindHandler.class));
		registerHandler(OcsaServiceProto.OCS0311U00SaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0311U00SaveLayoutHandler.class));
		registerHandler(OcsaServiceProto.OCS0311U00grdHangmogCodeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0311U00grdHangmogCodeHandler.class));
		registerHandler(OcsaServiceProto.OCS0311U00grdSetCodeListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0311U00grdSetCodeListHandler.class));
		registerHandler(OcsaServiceProto.OCS0311U00grdSetHangmogRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0311U00grdSetHangmogHandler.class));
		registerHandler(OcsaServiceProto.OCS0311U00layDupHangmogCodeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0311U00layDupHangmogCodeHandler.class));
		registerHandler(OcsaServiceProto.OCS0311U00layDupSetCodeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0311U00layDupSetCodeHandler.class));
		registerHandler(OcsaServiceProto.OCS0311U00layDupSetHangmogRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0311U00layDupSetHangmogHandler.class));
		registerHandler(OcsaServiceProto.OCS0311U00laySetHangmogRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0311U00laySetHangmogHandler.class));
		//[END] OCS0311U00
		//[START] OCS0131U00
		registerHandler(OcsaServiceProto.OCS0131U00GetFwkCodeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0131U00GetFwkCodeHandler.class));
		registerHandler(OcsaServiceProto.OCS0131U00GrdOCS0131Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0131U00GrdOCS0131Handler.class));
		registerHandler(OcsaServiceProto.OCS0131U00GrdOCS0132Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0131U00GrdOCS0132Handler.class));
		registerHandler(OcsaServiceProto.OCS0131U00XSavePerformerRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0131U00XSavePerformerHandler.class));
		//[END] OCS0131U00
		//[START] OCS0133U00
		registerHandler(OcsaServiceProto.OCS0133U00ExecuteRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0133U00ExecuteHandler.class));
		registerHandler(OcsaServiceProto.OCS0133U00grdOCS0133ItemRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0133U00grdOCS0133ItemHandler.class));
		//[END] OCS0133U00
		
		//[START] OCS0108U00
		registerHandler(OcsaServiceProto.OCS0108U00CreateComboRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0108U00CreateComboHandler.class));
		registerHandler(OcsaServiceProto.OCS0108U00ExecuteRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0108U00ExecuteHandler.class));
		registerHandler(OcsaServiceProto.OCS0108U00grdOCS0103Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0108U00grdOCS0103Handler.class));
		registerHandler(OcsaServiceProto.OCS0108U00grdOCS0108Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0108U00grdOCS0108Handler.class));
		registerHandler(OcsaServiceProto.OCS0108U00laySlipRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0108U00laySlipHandler.class));
		//[END] OCS0108U00
		
		//[START] OCS0103U13
		registerHandler(OcsaServiceProto.OCS0103U13CboListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U13CboListHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U13FnAdmConvertKanaFullRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U13FnAdmConvertKanaFullHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U13LaySpecimenTreeListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U13LaySpecimenTreeListHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U13FormLoadRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U13FormLoadHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U13GrdSpecimenListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U13GrdSpecimenListHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U13GrdSearchOrderListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U13GrdSearchOrderListHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U13GrdSangyongOrderListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U13GrdSangyongOrderListHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U13PrOcsApplyNdayOrderRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U13PrOcsApplyNdayOrderHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U13GrdOrderListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U13GrdOrderListHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U13SaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U13SaveLayoutHandler.class));

		//[END] OCS0103U13
		
		//[START] [OCS0101U00] - Manage order slip
		registerHandler(OcsaServiceProto.OCS0101U00GrdOcs0101InitRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0101U00GrdOcs0101InitHandler.class));
		registerHandler(OcsaServiceProto.OCS0101U00GrdOcs0102InitRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0101U00GrdOcs0102InitHandler.class));
		registerHandler(OcsaServiceProto.OCS0101U00GrdOcs0106Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0101U00GrdOcs0106Handler.class));
		registerHandler(OcsaServiceProto.OCS0101U00LayComboRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0101U00LayComboHandler.class));
		registerHandler(OcsaServiceProto.OCS0101U00Grd0101CheckDataRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0101U00Grd0101CheckDataHandler.class));
		registerHandler(OcsaServiceProto.OCS0101U00Grd0102CheckDataRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0101U00Grd0102CheckDataHandler.class));
		registerHandler(OcsaServiceProto.OCS0101PreDeleteOcs0102CheckRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0101PreDeleteOcs0102CheckHandler.class));
		registerHandler(OcsaServiceProto.OCS0101U00TransactionalRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0101U00TransactionalHandler.class));
	    //[END] [OCS0101U00] - Manage order slip
	    
	    //[START] [OCS0113U00] - Manage liquid specimen code by order code
		registerHandler(OcsaServiceProto.OCS0113U00LaySlipInfoRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0113U00LaySlipInfoHandler.class));
		registerHandler(OcsaServiceProto.OCS0113U00GrdOCS0113Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0113U00GrdOCS0113Handler.class));
		registerHandler(OcsaServiceProto.OCS0113U00GrdOCS0103Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0113U00GrdOCS0103Handler.class));
		registerHandler(OcsaServiceProto.OCS0113U00GetCodeNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0113U00GetCodeNameHandler.class));
		registerHandler(OcsaServiceProto.OCS0113U00GetFindWorkerRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0113U00GetFindWorkerHandler.class));
		registerHandler(OcsaServiceProto.OCS0113U00TransactionalRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0113U00TransactionalHandler.class));
	    // [START] [OCS0113U00] - Manage liquid specimen code by order code
	    
	    //[START] OCS0103U12 
		registerHandler(OcsaServiceProto.OCS0103U12InitComboBoxRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U12InitComboBoxHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U12ScreenOpenRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U12ScreenOpenHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U12MakeSangyongTabRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U12MakeSangyongTabHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U12InitializeScreenRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U12InitializeScreenHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U12LoadColumnNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U12LoadColumnNameHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U12GrdSangyongOrderRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U12GrdSangyongOrderHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U12IsUpdateCheckSelectRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U12IsUpdateCheckSelectHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U12IsUpdateCheckInsertRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U12IsUpdateCheckInsertHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U12ProtectGroupControlRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U12ProtectGroupControlHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U12FbxJusaFindClickRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U12FbxJusaFindClickHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U12GridColumnProtectModifyRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U12GridColumnProtectModifyHandler.class));

		registerHandler(OcsaServiceProto.OCS0103U12LoadDrgOrderRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U12LoadDrgOrderHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U12LayDrugTreeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U12LayDrugTreeHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U12SetSameOrderDateGroupSerRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U12SetSameOrderDateGroupSerHandler.class));
        
		registerHandler(OcsaServiceProto.OCS0103U12SaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U12SaveLayoutHandler.class));
	  	//[END] OCS0103U12
		
		//[START] OCS0223U00
		registerHandler(OcsaServiceProto.OCS0223U00GrdOCS0223Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0223U00GrdOCS0223Handler.class));
		registerHandler(OcsaServiceProto.OCS0223U00CboSystemRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0223U00CboSystemHandler.class));
		registerHandler(OcsaServiceProto.OCS0223U00ExecutionRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0223U00ExecutionHandler.class));
		//[END] OCS0223U00
		
		// [START] OCS0103U16
		registerHandler(OcsaServiceProto.OCS0103U16GrdSangyongOrderRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U16GrdSangyongOrderHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U16SlipCodeTreeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U16SlipCodeTreeHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U16GrdSlipHangmogRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U16GrdSlipHangmogHandler.class));

		// [END] OCS0103U16
		//[START] OCS0103U14
		registerHandler(OcsaServiceProto.OCS0103U14GrdSlipHangmogRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U14GrdSlipHangmogHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U14LaySlipCodeTreeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U14LaySlipCodeTreeHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U14FormLoadRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U14FormLoadHandler.class));

		//[END] OCS0103U14
		//[START] OCS0103U10
		registerHandler(OcsaServiceProto.OCS0103U10CboInputGubunRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U10CboInputGubunHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U10GrdDrgOrderRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U10GrdDrgOrderHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U10GrdGeneralRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U10GrdGeneralHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U10DrugTreeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U10DrugTreeHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U10FormLoadRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U10FormLoadHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U10SetTabWonnaeDrgRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U10SetTabWonnaeDrgHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U10SaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U10SaveLayoutHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U10SearchConditionCboRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U10SearchConditionCboHandler.class));

		//[END] OCS0103U10
		
		//[START] OCS0103U17
		registerHandler(OcsaServiceProto.CboSearchConditionRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(CboSearchConditionHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U17LayHangwiGubunRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U17LayHangwiGubunHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U17LoadHangwiOrder3Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U17LoadHangwiOrder3Handler.class));
		registerHandler(OcsaServiceProto.OCS0103U17MakeJaeryoGubunTabRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U17MakeJaeryoGubunTabHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U17LoadJaeryoOrderRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U17LoadJaeryoOrderHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U17IsJundalTableRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U17IsJundalTableHandler.class));
		//[END] OCS0103U17
		
		//[START] OCS0103U18
		registerHandler(OcsaServiceProto.OCS0103U18GrdOrderRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U18GrdOrderHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U18InitializeScreenRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U18InitializeScreenHandler.class));
		//[END] OCS0103U18
		
		//[START] OCS0803U00
		registerHandler(OcsaServiceProto.OCS0803U00grdOCS0804Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0803U00grdOCS0804Handler.class));
		registerHandler(OcsaServiceProto.OCS0803U00grdOCS0803Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0803U00grdOCS0803Handler.class));
		registerHandler(OcsaServiceProto.OCS0803U00CreateComboRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0803U00CreateComboHandler.class));
		registerHandler(OcsaServiceProto.OCS0803U00GetCodeNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0803U00GetCodeNameHandler.class));
		registerHandler(OcsaServiceProto.OCS0803U00GetFindWorkerRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0803U00GetFindWorkerHandler.class));
		registerHandler(OcsaServiceProto.OCS0803U00ExecuteRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0803U00ExecuteHandler.class));
	    //[END] OCS0803U00
	    
	    //[START] OCS0301Q09
		registerHandler(OcsaServiceProto.OCS0301Q09GrdOCS0301Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0301Q09GrdOCS0301Handler.class));
		registerHandler(OcsaServiceProto.OCS0301Q09GrdOCS0303Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0301Q09GrdOCS0303Handler.class));
		registerHandler(OcsaServiceProto.OCS0301Q09RbtMembCheckedChangedRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0301Q09RbtMembCheckedChangedHandler.class));
		registerHandler(OcsaServiceProto.OCS0301Q09IsDoctorRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0301Q09IsDoctorHandler.class));
		registerHandler(OcsaServiceProto.OCS0301Q09SetUserCheckBoxRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0301Q09SetUserCheckBoxHandler.class));
		registerHandler(OcsaServiceProto.OCS0301Q09CheckExistsYasokCodeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0301Q09CheckExistsYasokCodeHandler.class));
		registerHandler(OcsaServiceProto.OCS0301Q09TxtYaksokCodeDataValidatingRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0301Q09TxtYaksokCodeDataValidatingHandler.class));
        
	    //[END] OCS0301Q09
	    //[END] OCS0103U11
		registerHandler(OcsaServiceProto.OCS0103U11InitializeScreenRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U11InitializeScreenHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U11GrdSlipHangMogRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U11GrdSlipHangMogHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U11LaySlipCodeTreeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U11LaySlipCodeTreeHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U11GetFkocsRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U11GetFkOcsHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U11LoadSlipHangmogRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U11LoadSlipHangmogHandler.class));
	    //[END] OCS0103U11
	    
	    	
		//[START] OCSAPPROVE
		registerHandler(OcsaServiceProto.OCSAPPROVEGrdOrderRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCSAPPROVEGrdOrderHandler.class));
		registerHandler(OcsaServiceProto.OCSAPPROVEGrdPatientListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCSAPPROVEGrdPatientListHandler.class));
		registerHandler(OcsaServiceProto.OCSAPPROVEInitScreenRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCSAPPROVEInitScreenHandler.class));
		registerHandler(OcsaServiceProto.OCSAPPROVESaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCSAPPROVESaveLayoutHandler.class));
		//[END] OCSAPPROVE
		
		
		//[START] OCS0801U00
		registerHandler(OcsaServiceProto.OCS0801U00GrdOCS0801Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0801U00GrdOCS0801Handler.class));
		registerHandler(OcsaServiceProto.OCS0801U00GetCodeNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0801U00GetCodeNameHandler.class));
		registerHandler(OcsaServiceProto.OCS0801U00TransactionalRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0801U00TransactionalHandler.class));
		registerHandler(OcsaServiceProto.OCS0801U00GrdOCS0802Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0801U00GrdOCS0802Handler.class));
		//[END] OCS0801U00
	
		//[START] OCS0150Q00
		registerHandler(OcsaServiceProto.OCS0150Q00GridOCS0150Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0150Q00GridOCS0150Handler.class));
		registerHandler(OcsaServiceProto.OCS0150Q00SaveLayoutForGridOCS0150Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0150Q00SaveLayoutForGridOCS0150Handler.class));
		registerHandler(OcsaServiceProto.OCS0150Q00FindboxMembRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0150Q00FindboxMembHandler.class));
		//[END] OCS0150Q00
		//[START] OCS0208U00
		registerHandler(OcsaServiceProto.OCS0208Q00GrdOCS0208Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0208U00GrdOCS0208Handler.class));
		registerHandler(OcsaServiceProto.OCS0208Q00CommonDataRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0208Q00CommonDataHandler.class));
		//[END] OCS0208U00
		
		//[START] OCS0208Q01
		registerHandler(OcsaServiceProto.OCS0208Q01GrdChiryoGubunRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0208Q01GrdChiryoGubunHandler.class));
		registerHandler(OcsaServiceProto.OCS0208Q01GrdDrg0120Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0208Q01GrdDrg0120Handler.class));
		registerHandler(OcsaServiceProto.OCS0208Q01GrdOCS0208Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0208Q01GrdOCS0208Handler.class));
		//[START] OCS0208Q01
		
		//[START] OCS0103Q00
		registerHandler(OcsaServiceProto.Ocs0103Q00GrdHangMogRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(Ocs0103Q00GrdHangMogHandler.class));
		registerHandler(OcsaServiceProto.Ocs0103Q00LoadOcs0103Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(Ocs0103Q00LoadOcs0103Handler.class));
		registerHandler(OcsaServiceProto.OCS0103Q00CreateOrderGubunRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103Q00CreateOrderGubunHandler.class));
		registerHandler(OcsaServiceProto.OCS0103Q00LoadKatakanaFullRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103Q00LoadKataskanaFullHandler.class));
		registerHandler(OcsaServiceProto.OCS0103Q00CheckHangmogNameInxRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103Q00CheckHangmogNameInxHandler.class));
		//[END] OCS0103Q00
		
		//[START]OCS0311Q00
		registerHandler(OcsaServiceProto.OCS0311Q00LayDownListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0311Q00LayDownListHandler.class));
		registerHandler(OcsaServiceProto.OCS0311Q00LayRootListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0311Q00LayRootListHandler.class));
		registerHandler(OcsaServiceProto.OCS0311Q00LaySetRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0311Q00LaySetHandler.class));
		registerHandler(OcsaServiceProto.OCS0311Q00CboSetPartRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0311Q00CboSetPartHandler.class));
		registerHandler(OcsaServiceProto.OCS0311Q00LayDownListQueryEndRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0311Q00LayDownListQueryEndHandler.class));
		//[END]OCS0311Q00
		
		//[START] OCS0103U19
		registerHandler(OcsaServiceProto.OCS0103U19InitializeScreenRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U19InitializeScreenHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U19GetFkOcsRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U19GetFkOcsHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U19GrdSearchOrderRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U19GrdSearchOrderHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U19GrdJaeryoOrderRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U19GrdJaeryoOrderHandler.class));
		//[END] OCS0103U19
		
		
		//[START] OCS0103U00
		registerHandler(OcsaServiceProto.OCS0103U00GrdOCS0103Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U00GrdOCS0103Handler.class));
		registerHandler(OcsaServiceProto.OCS0103U00GrdOCS0108Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U00GrdOCS0108Handler.class));
		registerHandler(OcsaServiceProto.OCS0103U00GrdOCS0113Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U00GrdOCS0113Handler.class));
		registerHandler(OcsaServiceProto.OCS0103U00GrdOCS0115Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U00GrdOCS0115Handler.class));
		registerHandler(OcsaServiceProto.OCS0103U00GrdOCS0115ColChangedJundalPartRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U00GrdOCS0115ColChangedJundalPartHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U00GrdOCS0115ColChangedJundalPartOutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U00GrdOCS0115ColChangedJundalPartOutHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U00GrdOCS0115ColChangedJundalPartInpRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U00GrdOCS0115ColChangedJundalPartInpHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U00GrdOCS0115ColChangedMovePartRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U00GrdOCS0115ColChangedMovePartHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U00GrdOCS0113ColChangedRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U00GrdOCS0113ColChangedHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U00FindBoxDataValidatingRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U00FindBoxDataValidatingHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U00LayCommonSgCodeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U00LayCommonSgCodeHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U00LayCommonJaeryoCodeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U00LayCommonJaeryoCodeHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U00LoadKanaFullRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U00LoadKanaFullHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U00GetJundalTableRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U00GetJundalTableHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U00SaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U00SaveLayoutHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U00FwkCommonRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U00FwkCommonHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U00GridColumnChangedRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U00GridColumnChangedHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U00LoadAllComboRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS0103U00LoadAllComboHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U00GetProtocolRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS0103U00GetProtocolHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U00GetNameProtocolRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS0103U00GetNameProtocolHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U00GetCommonYnRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS0103U00GetCommonYnHandler.class));
		
		//[END] OCS0103U00
		
		//[START] OCS0131U01
		registerHandler(OcsaServiceProto.Ocs0131U01Grd0131Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(Ocs0131U01Grd0131Handler.class));
		registerHandler(OcsaServiceProto.Ocs0131U01Grd0132Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(Ocs0131U01Grd0132Handler.class));
		registerHandler(OcsaServiceProto.Ocs0131U01SaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(Ocs0131U01SaveLayoutHandler.class));
		//[END] OCS0131U01
		
		//[START] OCS0204Q00
		registerHandler(OcsaServiceProto.OCS0204Q00GrdOCS0205Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0204Q00GrdOCS0205Handler.class));
		registerHandler(OcsaServiceProto.OCS0204Q00LayOCS0204Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0204Q00LayOCS0204Handler.class));
		registerHandler(OcsaServiceProto.OCS0204Q00CreateDoctorComboRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0204Q00CreateDoctorComboHandler.class));
		registerHandler(OcsaServiceProto.OCS0204Q00GetOcsUserNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0204Q00GetOcsUserNameHandler.class));
		registerHandler(OcsaServiceProto.OCS0204Q00CreateDoctorCombo1Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0204Q00CreateDoctorCombo1Handler.class));
		//[END] OCS0204Q00
		
		//[START] OCS0103U15
		registerHandler(OcsaServiceProto.OCS0103U15LaySlipCodeTreeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U15LaySlipCodeTreeHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U15GrdSlipHangmogRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U15GrdSlipHangmogHandler.class));
		//[END] OCS0103U15
		
		//[START] OCS0221Q01
		registerHandler(OcsaServiceProto.OCS0221Q01DloOCS0221Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0221Q01DloOCS0221Handler.class));
		registerHandler(OcsaServiceProto.OCS0221Q01GrdOCS0222Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0221Q01GrdOCS0222Handler.class));
		//[END] OCS0221Q01
		
		// [START] OCS3003Q10
		registerHandler(OcsaServiceProto.OCS3003Q10GrdOrderDateRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS3003Q10GrdOrderDateHandler.class));
		registerHandler(OcsaServiceProto.OCS3003Q10GrdOrderRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS3003Q10GrdOrderHandler.class));
		registerHandler(OcsaServiceProto.OCS3003Q10GrdSangRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS3003Q10GrdSangHandler.class));
//		registerHandler(OcsaServiceProto.OCS3003Q10TabOrderGubunWorkTp4Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS3003Q10TabOrderGubunWorkTp4Handler.class));
//		registerHandler(OcsaServiceProto.OCS3003Q10TabOrderGubunWorkTp5Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS3003Q10TabOrderGubunWorkTp5Handler.class));

		// [END] OCS3003Q10
		
		//[START] OCS0203U00
		registerHandler(OcsaServiceProto.OCS0203U00GrdOcs0203P1Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS0203U00GrdOcs0203P1Handler.class));
		registerHandler(OcsaServiceProto.OCS0203U00LayOCS0212Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS0203U00LayOCS0212Handler.class));
		registerHandler(OcsaServiceProto.OCS0203U00LaySlipRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS0203U00LaySlipHandler.class));
		registerHandler(OcsaServiceProto.OCS0203U00LoadAllMembRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS0203U00LoadAllMembHandler.class));
		registerHandler(OcsaServiceProto.OCS0203U00GetOCSCOMUserIDRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS0203U00GetOCSCOMUserIDHandler.class));
		registerHandler(OcsaServiceProto.OCS0203U00SaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS0203U00SaveLayoutHandler.class));
		registerHandler(OcsaServiceProto.OCS0203U00LoadGwaRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS0203U00LoadGwaHandler.class));
		registerHandler(OcsaServiceProto.OCS0203U00GetOCSCOMUserNameRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS0203U00GetOCSCOMUserNameHandler.class));
		//[END] OCS0203U00
		
		//[START] OCS0118U00
		registerHandler(OcsaServiceProto.OCS0118U00FwkOCS0103Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS0118U00FwkOCS0103Handler.class));
		registerHandler(OcsaServiceProto.OCS0118U00GrdOCS0118Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS0118U00GrdOCS0118Handler.class));
		registerHandler(OcsaServiceProto.OCS0118U00CheckHangmogCodeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS0118U00CheckHangmogCodeHandler.class));
		registerHandler(OcsaServiceProto.OCS0118U00GrdSaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS0118U00GrdSaveLayoutHandler.class));
		//[END] OCS0118U00
		
		//[START] DOC4003U00
		registerHandler(OcsaServiceProto.DOC4003U00GrdDOC4003Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DOC4003U00GrdDOC4003Handler.class));
		registerHandler(OcsaServiceProto.DOC4003U00GetHospRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DOC4003U00GetHospHandler.class));
		registerHandler(OcsaServiceProto.DOC4003U00GetNextValRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DOC4003U00GetNextValHandler.class));
		registerHandler(OcsaServiceProto.DOC4003U00SaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DOC4003U00SaveLayoutHandler.class));
		//[END] DOC4003U00
		
		//[START] composite
		registerHandler(OcsaServiceProto.OpenScreenU18CompositeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OpenScreenU18CompositeHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U17ScreenOpenRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS0103U17ScreenOpenHandler.class));
		registerHandler(OcsaServiceProto.OCS0103U16ScreenOpenRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS0103U16ScreenOpenHandler.class));
		//[END] composite
		
		//Merge requests: OCS0103U14FormLoadRequest - OCS0103U13GrdSangyongOrderListRequest - OCS0103U14LaySlipCodeTreeRequest - OCS0103U14GrdSlipHangmogRequest 
		//[START]
		registerHandler(OcsaServiceProto.OCS0103U14FirstOpenScreenRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U14FirstOpenScreenHandler.class));
		//[END]
		
		// BEGIN
		registerHandler(OcsaServiceProto.OCS0103U13OpenScreenRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS0103U13OpenScreenHandler.class));
		// END
		
		registerHandler(OcsaServiceProto.OCS0103U00CheckAdminUserRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS0103U00CheckAdminUserHandler.class));
		
		// START MIH
		registerHandler(OcsaServiceProto.OcsCHTAPPROVEgrdAPP1001Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OcsCHTAPPROVEgrdAPP1001Handler.class));
		registerHandler(OcsaServiceProto.OcsCHTAPPROVEgrdPatientRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OcsCHTAPPROVEgrdPatientHandler.class));
		registerHandler(OcsaServiceProto.OcsCHTAPPROVEsaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OcsCHTAPPROVEsaveLayoutHandler.class));
		registerHandler(OcsaServiceProto.OcsCHTAPPROVEfbxAPPRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OcsCHTAPPROVEfbxAPPHandler.class));
		registerHandler(OcsaServiceProto.OcsCHTAPPROVEgetOneResultRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OcsCHTAPPROVEgetOneResultHandler.class));
		registerHandler(OcsaServiceProto.OcsCHTAPPROVElayGwaRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OcsCHTAPPROVElayGwaHandler.class));
		// END MIH
		
		registerHandler(OcsaServiceProto.OCS0304Q00grdOCS0305Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS0304Q00grdOCS0305Handler.class));
		registerHandler(OcsaServiceProto.OCS0304Q00grdOCS0306Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS0304Q00grdOCS0306Handler.class));
		registerHandler(OcsaServiceProto.OCS0304Q00layOCS0304Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS0304Q00layOCS0304Handler.class));
		registerHandler(OcsaServiceProto.OCS0304Q00PkOCS2005Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS0304Q00PkOCS2005Handler.class));
		registerHandler(OcsaServiceProto.OCS0304U00GetDoctoryaksokopenidRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS0304U00GetDoctoryaksokopenidHandler.class));
		registerHandler(OcsaServiceProto.OCS3003Q11grdOrderDateListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS3003Q11grdOrderDateListHandler.class));
	}

	@Override
	protected void doStop() throws Exception {

	}
}

