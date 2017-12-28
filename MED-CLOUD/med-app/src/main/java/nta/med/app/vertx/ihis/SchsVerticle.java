package nta.med.app.vertx.ihis;

import nta.med.core.infrastructure.socket.vertx.AbstractVerticle;
import nta.med.core.infrastructure.SpringBeanFactory;
import nta.med.service.ihis.handler.schs.*;
import nta.med.service.ihis.proto.SchsServiceProto;

public class SchsVerticle  extends AbstractVerticle {

	public SchsVerticle() {
		super(SchsServiceProto.class, SchsServiceProto.getDescriptor());
	}

	@Override
	protected void doStart() throws Exception {
		//[START] - [SERVER][SCH0201Q01] - Inspection order list (Part)
		registerHandler(SchsServiceProto.SchsSCH0201Q01SCH0109ComboListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SchsSCH0201Q01SCH0109ComboListHandler.class));
		registerHandler(SchsServiceProto.SchsSCH0201Q01SCH0001ComboListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SchsSCH0201Q01SCH0001ComboListHandler.class));
		registerHandler(SchsServiceProto.SchsSCH0201Q01ExitsJundalTableRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SchsSCH0201Q01ExitsJundalTableHandler.class));
		registerHandler(SchsServiceProto.SchsSCH0201Q01ReserListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SchsSCH0201Q01ReserListHandler.class));
		registerHandler(SchsServiceProto.SchsSCH0201Q01GumsaComboListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SchsSCH0201Q01GumsaComboListHandler.class));
		registerHandler(SchsServiceProto.SchsSCH0201Q01ReserListCboRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SchsSCH0201Q01ReserListCboHandler.class));
		//[END] - [SERVER][SCH0201Q01] - Inspection order list (Part)

		//[START] - [SERVER][SCH0201Q02] - Inspection order list (Department)
		registerHandler(SchsServiceProto.SchsSCH0201Q02ReserList02Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SchsSCH0201Q02ReserList02Handler.class));
		registerHandler(SchsServiceProto.SchsSCH0201Q02ReserList03Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SchsSCH0201Q02ReserList03Handler.class));
		registerHandler(SchsServiceProto.SchsSCH0201Q02JundalComboListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(SchsSCH0201Q02JundalComboListHandler.class));
		//[END] - [SERVER][SCH0201Q02] - Inspection order list (Department)

		//[START] - [SERVER][SCH0201Q04] - Refer order status by month
		registerHandler(SchsServiceProto.SchsSCH0201Q04PrartListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SchsSCH0201Q04PrartListHandler.class));
		registerHandler(SchsServiceProto.SchsSCH0201Q04GetMonthReserListInfoRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SchsSCH0201Q04GetMonthReserListInfoHandler.class));
		registerHandler(SchsServiceProto.SchsSCH0201Q04ReserTimeListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SchsSCH0201Q04ReserTimeListHandler.class));
		registerHandler(SchsServiceProto.SchsSCH0201Q04PrSchTimeListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SchsSCH0201Q04PrSchTimeListHandler.class));
		registerHandler(SchsServiceProto.SchsSCH0201Q04GetCalReserRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(SchsSCH0201Q04GetCalReserHandler.class));
		registerHandler(SchsServiceProto.SchsSCH0201Q04GetFormLoadRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(SchsSCH0201Q04GetFormLoadHandler.class));
		registerHandler(SchsServiceProto.SchsSCH0201Q04GetCboListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(SchsSCH0201Q04GetCboListHandler.class));
		//[END] - [SERVER][SCH0201Q04] - Refer order status by month

		//[START] - [SERVER][SCH0201Q12] - Outpatient inspection order list
		registerHandler(SchsServiceProto.SCH0201Q12ComboListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SCH0201Q12ComboListHandler.class));
		registerHandler(SchsServiceProto.SCH0201Q12FwkDoctorListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SCH0201Q12FwkDoctorListHandler.class));
		registerHandler(SchsServiceProto.SCH0201Q12GrdListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SCH0201Q12GrdListHandler.class));
		registerHandler(SchsServiceProto.SCH0201Q12FindBoxRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SCH0201Q12FindBoxHandler.class));
		registerHandler(SchsServiceProto.SCH0201Q12UpdateReserDataRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SCH0201Q12UpdateReserDataHandler.class));
		registerHandler(SchsServiceProto.SCH0201Q12UpdateKensaYnRequest .class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SCH0201Q12UpdateKensaYnHandler.class));
		//[END] - [SERVER][SCH0201Q12] - Outpatient inspection order list

		//[START] [SERVER][SCH0201U99] - Manage inspection order
		registerHandler(SchsServiceProto.SchsSCH0201U99CommonDataRequest .class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SchsSCH0201U99CommonDataHandler.class));
		registerHandler(SchsServiceProto.SchsSCH0201U99GrdOrderListRequest .class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SchsSCH0201U99GrdOrderListHandler.class));
		registerHandler(SchsServiceProto.SchsSCH0201U99GrdTimeListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SchsSCH0201U99GrdTimeListHandler.class));
		registerHandler(SchsServiceProto.SchsSCH0201U99DateScheduleListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SchsSCH0201U99DateScheduleListHandler.class));
		registerHandler(SchsServiceProto.SchsSCH0201U99ReserListRequest .class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SchsSCH0201U99ReserListHandler.class));
		registerHandler(SchsServiceProto.SchsSCH0201U99ReserTimeChkRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SchsSCH0201U99ReserTimeChkHandler.class));
		registerHandler(SchsServiceProto.SchsSCH0201U99LayoutTimeListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SchsSCH0201U99LayoutTimeListHandler.class));
		registerHandler(SchsServiceProto.SchsSCH0201U99LayoutCommonListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SchsSCH0201U99LayoutCommonListHandler.class));
		registerHandler(SchsServiceProto.SchsSCH0201U99GetGwaNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SchsSCH0201U99GetGwaNameHandler.class));
		registerHandler(SchsServiceProto.SchsSCH0201U99GetJundalPartNameRequest  .class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SchsSCH0201U99GetJundalPartNameHandler.class));
		registerHandler(SchsServiceProto.SchsSCH0201U99ExecIUDRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SchsSCH0201U99ExecIUDHandler.class));
		registerHandler(SchsServiceProto.SchsSCH0201U99ExecTimeListRequest .class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SchsSCH0201U99ExecTimeListHandler.class));
		registerHandler(SchsServiceProto.SchsSCH0201U99ExecEtcInsertRequest .class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SchsSCH0201U99ExecEtcInsertHandler.class));
		registerHandler(SchsServiceProto.SchsSCH0201U99DeleteSCH0201Request .class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SchsSCH0201U99DeleteSCH0201Handler.class));

		registerHandler(SchsServiceProto.SchsSCH0201U99ComboGumsaPartRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(SchsSCH0201U99ComboGumsaPartHandler.class));
		registerHandler(SchsServiceProto.SCH0201U99BookingDetailRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(SCH0201U99BookingDetailHandler.class));
		//[END] [SERVER][SCH0201U99] - Manage inspection order

		//[START] SCH0109U00
		registerHandler(SchsServiceProto.SCH0109U00GrdDetailRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SCH0109U00GrdDetailHandler.class));
		registerHandler(SchsServiceProto.SCH0109U00LayDupDRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SCH0109U00LayDupDHandler.class));
		registerHandler(SchsServiceProto.SCH0109U00GrdMasterRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SCH0109U00GrdMasterHandler.class));
		registerHandler(SchsServiceProto.SCH0109U00LayDupMRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SCH0109U00LayDupMHandler.class));
		registerHandler(SchsServiceProto.SCH0109U00XSavePerformerRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SCH0109U00XSavePerformerHandler.class));
		//[END] SCH0109U00

		//[START] SCH0201Q05
		registerHandler(SchsServiceProto.SCH0201Q05LayReserListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SCH0201Q05LayReserListHandler.class));
		//[END] SCH0201Q05

		//[START] SCH3001U00
		registerHandler(SchsServiceProto.SCH3001U00GrdJukyongDateRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SCH3001U00GrdJukyongDateHandler.class));
		registerHandler(SchsServiceProto.SCH3001U00GrdSCH0001Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SCH3001U00GrdSCH0001Handler.class));
		registerHandler(SchsServiceProto.SCH3001U00GrdSCH0002Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SCH3001U00GrdSCH0002Handler.class));
		registerHandler(SchsServiceProto.SCH3001U00GrdSCH3000Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SCH3001U00GrdSCH3000Handler.class));
		registerHandler(SchsServiceProto.SCH3001U00GrdSCH3100Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SCH3001U00GrdSCH3100Handler.class));
		registerHandler(SchsServiceProto.SCH3001U00GrdSCH3101Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SCH3001U00GrdSCH3101Handler.class));
		registerHandler(SchsServiceProto.SCH3001U00GetCboGumsaRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SCH3001U00GetCboGumsaHandler.class));
		registerHandler(SchsServiceProto.SCH3001U00VsvHangmogCodeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SCH3001U00VsvHangmogCodeHandler.class));
		registerHandler(SchsServiceProto.SCH3001U00VsvUserNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SCH3001U00VsvUserNameHandler.class));
		registerHandler(SchsServiceProto.SCH3001U00GrdSCH0002ValidateGridColumnChangedRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SCH3001U00GrdSCH0002ValidateGridColumnChangedHandler.class));

		registerHandler(SchsServiceProto.SCH3001U00DeleteSelectedYoilRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SCH3001U00DeleteSelectedYoilHandler.class));
		registerHandler(SchsServiceProto.SCH3001U00XSavePerformerCase1Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SCH3001U00XSavePerformerCase1Handler.class));
		registerHandler(SchsServiceProto.SCH3001U00XSavePerformerCase2Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SCH3001U00XSavePerformerCase2Handler.class));
		registerHandler(SchsServiceProto.SCH3001U00XSavePerformerCase3Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SCH3001U00XSavePerformerCase3Handler.class));
		registerHandler(SchsServiceProto.SCH3001U00XSavePerformerCase4Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SCH3001U00XSavePerformerCase4Handler.class));
		registerHandler(SchsServiceProto.SCH3001U00XSavePerformerCase5Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SCH3001U00XSavePerformerCase5Handler.class));
		registerHandler(SchsServiceProto.SCH3001U00XSavePerformerCase6Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SCH3001U00XSavePerformerCase6Handler.class));
		registerHandler(SchsServiceProto.SCH3001U00XSavePerformerCase7Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SCH3001U00XSavePerformerCase7Handler.class));

		registerHandler(SchsServiceProto.SCH3001U00GrdSCH0001RowFocusChangedRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SCH3001U00GrdSCH0001RowFocusChangedHandler.class));
		registerHandler(SchsServiceProto.SCH3001U00LoadDataForGridRequestInCaseDeleteRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SCH3001U00LoadDataForGridRequestInCaseDeleteHandler.class));
		registerHandler(SchsServiceProto.SCH3001U00LayDupOCS0103Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SCH3001U00LayDupOCS0103Handler.class));
		registerHandler(SchsServiceProto.SCH3001U00BtnMake2SaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SCH3001U00BtnMake2SaveLayoutHandler.class));
		registerHandler(SchsServiceProto.SCH3001U00BtnBtnListUpdateRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SCH3001U00BtnBtnListUpdateHandler.class));
		//[END] SCH3001U00

		//[START] SCH0109U01
		registerHandler(SchsServiceProto.SCH0109U01GrdMasterRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(SCH0109U01GrdMasterHandler.class));
		registerHandler(SchsServiceProto.SCH0109U01LayDupDRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(SCH0109U01LayDupDHandler.class));
		registerHandler(SchsServiceProto.SCH0109U01GrdDetailRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(SCH0109U01GrdDetailHandler.class));
		registerHandler(SchsServiceProto.SCH0109U01LayDupMRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(SCH0109U01LayDupMHandler.class));
		registerHandler(SchsServiceProto.SCH0109U01SaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(SCH0109U01SaveLayoutHandler.class));

		//[END] SCH0109U01

		//[START] SCH0201U10
		registerHandler(SchsServiceProto.SCH0201U10GrdOrderListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(SCH0201U10GrdOrderListHandler.class));
		registerHandler(SchsServiceProto.SCH0201U10LayReserInfoRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(SCH0201U10LayReserInfoHandler.class));
		registerHandler(SchsServiceProto.SCH0201U10LayReserInfoQueryEndRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(SCH0201U10LayReserInfoQueryEndHandler.class));
		registerHandler(SchsServiceProto.SCH0201U10GrdReserListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(SCH0201U10GrdReserListHandler.class));
		registerHandler(SchsServiceProto.SCH0201U99GetListBookingRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(SCH0201U99GetListBookingHandler.class));
		registerHandler(SchsServiceProto.Schs0201U99CheckInsertRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(Schs0201U99CheckInsertHandler.class));
		//registerHandler(SchsServiceProto.Schs0201U99CheckReserRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(Schs0201U99CheckReserHandler.class));
		registerHandler(SchsServiceProto.Schs0201U99CheckORCAEnvInfoRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(Schs0201U99CheckORCAEnvInfoHandler.class));
		registerHandler(SchsServiceProto.Schs0201U99BookingLabRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(Schs0201U99BookingLabHandler.class));
		//[START] SCH0201U10
	}

	@Override
	protected void doStop() throws Exception {

	}
}

