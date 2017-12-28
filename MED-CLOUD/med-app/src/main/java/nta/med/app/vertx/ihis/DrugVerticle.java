
package nta.med.app.vertx.ihis;

import nta.med.core.infrastructure.socket.vertx.AbstractVerticle;
import nta.med.core.infrastructure.SpringBeanFactory;
import nta.med.service.ihis.handler.drug.*;
import nta.med.service.ihis.proto.DrugServiceProto;

public class DrugVerticle extends AbstractVerticle {
	
	public DrugVerticle() {
		super(DrugServiceProto.class, DrugServiceProto.getDescriptor());
	}

	@Override
	protected void doStart() throws Exception {
		//[START] DRGOCSCHK
		registerHandler(DrugServiceProto.DRGOCSCHKGrdOcsChkRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(DRGOCSCHKGrdOcsChkHandler.class));
		registerHandler(DrugServiceProto.DRGOCSCHKPreSmallCodeDataValidatingRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRGOCSCHKPreSmallCodeDataValidatingHandler.class));
		registerHandler(DrugServiceProto.DRGOCSCHKCautionCodeDataValidatingRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRGOCSCHKCautionCodeDataValidatingHandler.class));
		registerHandler(DrugServiceProto.DRGOCSCHKSmallCodeDataValidatingRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRGOCSCHKSmallCodeDataValidatingHandler.class));
		registerHandler(DrugServiceProto.DRGOCSCHKGetCautionListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRGOCSCHKGetCautionListHandler.class));
		//	registerHandler(DrugServiceProto.DRGOCSCHKSUpdateInv0110Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRGOCSCHKSUpdateInv0110Handler.class));
		registerHandler(DrugServiceProto.DRGOCSCHKSaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRGOCSCHKSaveLayoutHandler.class));
		//[END] DRGOCSCHK

		//[START] DRG0102U00
		//	registerHandler(DrugServiceProto.DRG0102U00GrdRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG0102U00GrdHandler.class));
		registerHandler(DrugServiceProto.DRG0102U00GrdMasterGridColumnChangedRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG0102U00GrdMasterGridColumnChangedHandler.class));
		registerHandler(DrugServiceProto.DRG0102U00GrdDetailGridColumnChangedRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG0102U00GrdDetailGridColumnChangedHandler.class));
		//	registerHandler(DrugServiceProto.DRG0102U00UpdateInv0102Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG0102U00UpdateInv0102Handler.class));
		registerHandler(DrugServiceProto.DRG0102U00UpdateInv0101Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG0102U00UpdateInv0101Handler.class));

		// Re-define
		registerHandler(DrugServiceProto.DRG0102U00GrdMasterRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG0102U00GrdMasterHandler.class));
		registerHandler(DrugServiceProto.DRG0102U00GrdDetailRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG0102U00GrdDetailHandler.class));
		registerHandler(DrugServiceProto.DRG0102U00GrdDetailSaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG0102U00GrdDetailSaveLayoutHandler.class));

		//[END] DRG0102U00

		//[START] DRG0120U00
		// Re-define
		registerHandler(DrugServiceProto.DRG0120U00ComboListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG0120U00ComboListHandler.class));
		registerHandler(DrugServiceProto.DRG0120U00GrdDrg0120Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG0120U00GrdDrg0120Handler.class));
		registerHandler(DrugServiceProto.DRG0120U00GrdDrg0120Item1Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG0120U00GrdDrg0120Item1Handler.class));
		registerHandler(DrugServiceProto.DRG0120U00GrdNaebogRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG0120U00GrdNaebogHandler.class));
		registerHandler(DrugServiceProto.DRG0120U00GrdYoiyongRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG0120U00GrdYoiyongHandler.class));
		registerHandler(DrugServiceProto.DRG0120U00SaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRG0120U00SaveLayoutHandler.class));

		//[END] DRG0120U00
		registerHandler(DrugServiceProto.DRGOCSCHKgrdOCS0108Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRGOCSCHKgrdOCS0108Handler.class));
		registerHandler(DrugServiceProto.DRGOCSCHKGrdOcsChkFullRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRGOCSCHKGrdOcsChkFullHandler.class));
		registerHandler(DrugServiceProto.DRGOCSCHKSaveGrdOcsChkRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRGOCSCHKSaveGrdOcsChkHandler.class));
		registerHandler(DrugServiceProto.DRGOCSCHKSaveGrdOcs0108Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRGOCSCHKSaveGrdOcs0108Handler.class));
		registerHandler(DrugServiceProto.DRGOCSCHKLoadCbxCHKRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DRGOCSCHKLoadCbxCHKHandler.class));
	}

	@Override
	protected void doStop() throws Exception {

	}
}
