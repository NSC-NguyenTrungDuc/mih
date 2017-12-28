package nta.med.app.vertx.ihis;

import nta.med.core.infrastructure.SpringBeanFactory;
import nta.med.core.infrastructure.socket.vertx.AbstractVerticle;
import nta.med.service.ihis.handler.injs.*;
import nta.med.service.ihis.handler.injs.composite.INJ1001U01CompositeFirstHandler;
import nta.med.service.ihis.handler.injs.composite.INJ1001U01CompositeLoadDataHandler;
import nta.med.service.ihis.handler.injs.composite.INJ1001U01CompositeSecondHandler;
import nta.med.service.ihis.proto.InjsServiceProto;

public class InjsVerticle extends AbstractVerticle {

	public InjsVerticle() {
		super(InjsServiceProto.class, InjsServiceProto.getDescriptor());
	}

	@Override
	protected void doStart() throws Exception {
		//[START] [INJ1001U01] - Receive at injection dept.
		registerHandler(InjsServiceProto.InjsINJ1001U01ActorListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(InjsINJ1001U01ActorListHandler.class));
		registerHandler(InjsServiceProto.InjsINJ1001U01DetailListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(InjsINJ1001U01DetailListHandler.class));
		registerHandler(InjsServiceProto.InjsINJ1001U01MasterListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(InjsINJ1001U01MasterListHandler.class));
		registerHandler(InjsServiceProto.InjsINJ1001U01InfectionListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(InjsINJ1001U01InfectionListHandler.class));
		registerHandler(InjsServiceProto.InjsINJ1001U01ScheduleRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(InjsINJ1001U01ScheduleHandler.class));
		registerHandler(InjsServiceProto.InjsINJ1001U01LabelNewListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(InjsINJ1001U01LabelNewListHandler.class));
		registerHandler(InjsServiceProto.InjsINJ1001U01ReserDateListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(InjsINJ1001U01ReserDateListHandler.class));
		registerHandler(InjsServiceProto.InjsINJ1001U01TempListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(InjsINJ1001U01TempListHandler.class));
		registerHandler(InjsServiceProto.INJ0102ComboListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(INJ0102ComboListHandler.class));
		registerHandler(InjsServiceProto.INJ1001U01ComboListSortKeyRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(INJ1001U01ComboListSortKeyHandler.class));
		registerHandler(InjsServiceProto.InjsINJ1001U01CplOrderStatusRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(InjsINJ1001U01CplOrderStatusHandler.class));
		registerHandler(InjsServiceProto.InjsINJ1001U01PrintNameListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(InjsINJ1001U01PrintNameListHandler.class));
		registerHandler(InjsServiceProto.InjsINJ1001U01ChkbStateRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(InjsINJ1001U01ChkbStateHandler.class));
		registerHandler(InjsServiceProto.InjsINJ1001U01SettingPrintRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(InjsINJ1001U01SettingPrintHandler.class));
		registerHandler(InjsServiceProto.INJ0102CodeNameListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(INJ0102CodeNameListHandler.class));
		registerHandler(InjsServiceProto.InjsINJ1001U01OrderDateListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(InjsINJ1001U01OrderDateListHandler.class));
		registerHandler(InjsServiceProto.InjsINJ1001U01UpdateRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(InjsINJ1001U01UpdateHandler.class));
		registerHandler(InjsServiceProto.INJ1001U01LayCommonRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(InjsINJ1001U01LayCommonHandler.class));
		registerHandler(InjsServiceProto.INJ1001FormJusaBedLayPatientListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(InjsINJ1001FormJusaBedLayPatientListHandler.class));
		registerHandler(InjsServiceProto.INJ1001U01FormJusaBedLayHosilListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(InjsINJ1001U01FormJusaBedLayHosilListHandler.class));
		registerHandler(InjsServiceProto.INJ1001U01FormJusaBedLayPatientRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(InjsINJ1001U01FormJusaBedLayPatientHandler.class));
		registerHandler(InjsServiceProto.INJ1001U01GrdOCS1003Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(InjsINJ1001U01GrdOCS1003Handler.class));
		registerHandler(InjsServiceProto.INJ1001U01CboTimeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(InjsINJ1001U01CboTimeHandler.class));
		registerHandler(InjsServiceProto.INJ1001U01XEditGridCell88Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(InjsINJ1001U01XEditGridCell88Handler.class));
		registerHandler(InjsServiceProto.INJ1001U01XEditGridCell89Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(InjsINJ1001U01XEditGridCell89Handler.class));
		registerHandler(InjsServiceProto.INJ1001U01MlayConstantInfoRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(InjsINJ1001U01MlayConstantInfoHandler.class));
		registerHandler(InjsServiceProto.INJ1001FormJusaBedLayGroupedRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(InjsINJ1001FormJusaBedLayGroupedHandler.class));
		registerHandler(InjsServiceProto.InjsINJ1001U01CommentListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(InjsINJ1001U01CommentListHandler.class));
		registerHandler(InjsServiceProto.InjsINJ1001U01AllergyListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(InjsINJ1001U01AllergyListHandler.class));
		registerHandler(InjsServiceProto.INJ1001U01Grouped2Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(INJ1001U01Grouped2Handler.class));


		registerHandler(InjsServiceProto.INJ1001U01GrdSangRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(INJ1001U01GrdSangHandler.class));
		registerHandler(InjsServiceProto.INJ1001U01GroupedRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(INJ1001U01GroupedHandler.class));
		//registerHandler(InjsServiceProto.INJ1001U01GridDetailSaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(INJ1001U01GridDetailSaveLayoutHandler.class));
		registerHandler(InjsServiceProto.INJ1001U01SaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(INJ1001U01SaveLayoutHandler.class));

		//[END] [INJ1001U01] - Receive at injection dept.

		//[START] INJ1002R01
		registerHandler(InjsServiceProto.INJ1002R01LayQuery1Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(INJ1002R01LayQuery1Handler.class));
		registerHandler(InjsServiceProto.INJ1002R01LayQuery2Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(INJ1002R01LayQuery2Handler.class));
		//[END] INJ1002R01

		//[START] INJ1002U01
		registerHandler(InjsServiceProto.INJ1002U01InitializeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(INJ1002U01InitializeHandler.class));
		//[END] INJ1002U01

		//[START] INJ0101U00
		registerHandler(InjsServiceProto.INJ0101U00GrdMasterRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(INJ0101U00GrdMasterHandler.class));
		registerHandler(InjsServiceProto.INJ0101U00GrdDetailRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(INJ0101U00GrdDetailHandler.class));
		registerHandler(InjsServiceProto.INJ0101U00GrdMasterGridColumnChangedRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(INJ0101U00GrdMasterGridColumnChangedHandler.class));
		registerHandler(InjsServiceProto.INJ0101U00GrdDetailGridColumnChangedRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(INJ0101U00GrdDetailGridColumnChangedHandler.class));
		registerHandler(InjsServiceProto.INJ0101U00UpdateINJ0101Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(INJ0101U00UpdateINJ0101Handler.class));
		registerHandler(InjsServiceProto.INJ0101U00GrdDetailSaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(INJ0101U00GrdDetailSaveLayoutHandler.class));

		//		INJ0101U00UpdateINJ0102Request		
		//[END] INJ0101U00

		//[START] INJ1002U01 - NEW
		registerHandler(InjsServiceProto.INJ1002U01GrdOrderRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(INJ1002U01GrdOrderHandler.class));
		registerHandler(InjsServiceProto.INJ1002U01LayReserDateRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(INJ1002U01LayReserDateHandler.class));
		registerHandler(InjsServiceProto.INJ1002U01SaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(INJ1002U01SaveLayoutHandler.class));
		registerHandler(InjsServiceProto.INJ1002U01LoadComboBoxRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(INJ1002U01LoadComboBoxHandler.class));
		//[END] INJ1002U01 - NEW

		//[START] INJ0101U01
		registerHandler(InjsServiceProto.INJ0101U01GrdMasterRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(INJ0101U01GrdMasterHandler.class));
		registerHandler(InjsServiceProto.INJ0101U01GrdDetailRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(INJ0101U01GrdDetailHandler.class));
		registerHandler(InjsServiceProto.INJ0101U01GrdMasterCheckRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(INJ0101U01GrdMasterCheckHandler.class));
		registerHandler(InjsServiceProto.INJ0101U01GrdDetailCheckRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(INJ0101U01GrdDetailCheckHandler.class));
		registerHandler(InjsServiceProto.INJ0101U01SaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(INJ0101U01SaveLayoutHandler.class));
		//[START] INJ0101U01
		
		//[START] Composite
		registerHandler(InjsServiceProto.INJ1001U01CompositeFirstRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(INJ1001U01CompositeFirstHandler.class));
		registerHandler(InjsServiceProto.INJ1001U01CompositeSecondRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(INJ1001U01CompositeSecondHandler.class));
		registerHandler(InjsServiceProto.INJ1001U01CompositeLoadDataRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(INJ1001U01CompositeLoadDataHandler.class));
		//[END] Composite
		registerHandler(InjsServiceProto.INJ0000Q00layActDateRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(INJ0000Q00layActDateHandler.class));
		registerHandler(InjsServiceProto.INJ0000Q00layActingRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(INJ0000Q00layActingHandler.class));
		registerHandler(InjsServiceProto.INJ0000Q00layOrderRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(INJ0000Q00layOrderHandler.class));
		registerHandler(InjsServiceProto.INJ0000Q00layOrderListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(INJ0000Q00layOrderListHandler.class));
	}

	@Override
	protected void doStop() throws Exception {

	}
}

