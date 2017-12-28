package nta.med.app.vertx.ihis;

import nta.med.core.infrastructure.socket.vertx.AbstractVerticle;
import nta.med.core.infrastructure.SpringBeanFactory;
import nta.med.service.ihis.handler.phys.*;
import nta.med.service.ihis.proto.PhysServiceProto;

public class PhysVerticle extends AbstractVerticle {

	public PhysVerticle() {
		super(PhysServiceProto.class, PhysServiceProto.getDescriptor());
	}

	@Override
	protected void doStart() throws Exception {
		//-----[START] [PHY8002U00]

		registerHandler(PhysServiceProto.PHY8002U00GrdQueryRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY8002U00GrdQueryHandler.class));
		registerHandler(PhysServiceProto.PHY8002U00GrdGroupQueryRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY8002U00GrdGroupQueryHandler.class));
		registerHandler(PhysServiceProto.PHY8002U00GrdPHYRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY8002U00GrdPHYHandler.class));
		registerHandler(PhysServiceProto.PHY8002U00PrintRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY8002U00PrintHandler.class));
		registerHandler(PhysServiceProto.PHY8002U00SaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY8002U00SaveLayoutHandler.class));
		registerHandler(PhysServiceProto.PHY8002U00InsertInitValueRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY8002U00InsertInitValueHandler.class));
		//-----[END] [PHY8002U00]

		//-----[START] [PHY0001U00]
		registerHandler(PhysServiceProto.PHY0001U00GrdRehaSinryouryouCodeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY0001U00GrdRehaSinryouryouCodeHandler.class));
		registerHandler(PhysServiceProto.PHY0001U00GrdOCS0132Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY0001U00GrdOCS0132Handler.class));
		registerHandler(PhysServiceProto.PHY0001U00SaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY0001U00SaveLayoutHandler.class));
		//-----[END] [PHY0001U00]

		//-----[START] [PHY2001U04]
		registerHandler(PhysServiceProto.PHY2001U04GrdExcelRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY2001U04GrdExcelHandler.class));
		registerHandler(PhysServiceProto.PHY2001U04GrdInpRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY2001U04GrdInpHandler.class));
		registerHandler(PhysServiceProto.PHY2001U04GrdListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY2001U04GrdListHandler.class));
		registerHandler(PhysServiceProto.PHY2001U04GrdOutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY2001U04GrdOutHandler.class));
		registerHandler(PhysServiceProto.PHY2001U04GrdOut1001Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY2001U04GrdOut1001Handler.class));
		registerHandler(PhysServiceProto.PHY2001U04GrdPaCntRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY2001U04GrdPaCntHandler.class));
		registerHandler(PhysServiceProto.PHY2001U04LayDoctorNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY2001U04LayDoctorNameHandler.class));
		registerHandler(PhysServiceProto.PHY2001U04GrdPatientListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY2001U04GrdPatientListHandler.class));
		registerHandler(PhysServiceProto.PHY2001U04CboGwaRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY2001U04CboGwaHandler.class));
		registerHandler(PhysServiceProto.PHY2001U04SetSinryouryouAutoRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY2001U04SetSinryouryouAutoHandler.class));
		registerHandler(PhysServiceProto.PHY2001U04FnOutCheckNaewonYnRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY2001U04FnOutCheckNaewonYnHandler.class));
		registerHandler(PhysServiceProto.PHY2001U04GrdPatientListItemValueChangingRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY2001U04GrdPatientListItemValueChangingHandler.class));
		registerHandler(PhysServiceProto.PHY2001U04BtnDeleteGetDataTableRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY2001U04BtnDeleteGetDataTableHandler.class));
		registerHandler(PhysServiceProto.PHY2001U04PrRehAddRehasinryouryouRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY2001U04PrRehAddRehasinryouryouHandler.class));
		registerHandler(PhysServiceProto.PHY2001U04BtnDeleteExistYnRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY2001U04BtnDeleteExistYnHandler.class));
		registerHandler(PhysServiceProto.PHY2001U04BtnDeleteRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY2001U04BtnDeleteHandler.class));
		registerHandler(PhysServiceProto.PHY2001U04BtnJinryouEndClickUpdateOut1001Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY2001U04BtnJinryouEndClickUpdateOut1001Handler.class));
		registerHandler(PhysServiceProto.PHY2001U04BtnJinryouEndClickUpdateMultipleOut1001Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY2001U04BtnJinryouEndClickUpdateMultipleOut1001Handler.class));
		registerHandler(PhysServiceProto.PHY2001U04SaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY2001U04SaveLayoutHandler.class));
		registerHandler(PhysServiceProto.PHY2001U04LayNUR7001Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY2001U04LayNUR7001Handler.class));
		registerHandler(PhysServiceProto.PHY2001U04PrOutMakeAutoJubsuRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY2001U04PrOutMakeAutoJubsuHandler.class));
		registerHandler(PhysServiceProto.PHY2001U04FnPhyDupJubsuGubunRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY2001U04FnPhyDupJubsuGubunHandler.class));
		registerHandler(PhysServiceProto.PHY2001U04RefreshCounterRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY2001U04RefreshCounterHandler.class));
		registerHandler(PhysServiceProto.PHY2001U04InsertVitalRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY2001U04InsertVitalHandler.class));
		registerHandler(PhysServiceProto.PHY2001U04GetNewOrderFormOUTRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY2001U04GetNewOrderFormOUTHandler.class));
		registerHandler(PhysServiceProto.PHY2001U04GetNewOrderFormINPRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY2001U04GetNewOrderFormINPHandler.class));
		registerHandler(PhysServiceProto.PHY2001U04GetServerIPRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY2001U04GetServerIPHandler.class));
		registerHandler(PhysServiceProto.PHY2001U04JubsuFormCboGwaRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY2001U04JubsuFormCboGwaHandler.class));
		registerHandler(PhysServiceProto.PHY2001U04CboDoctorRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY2001U04CboDoctorHandler.class));
		registerHandler(PhysServiceProto.PHY2001U04GrdOCS0132Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY2001U04GrdOCS0132Handler.class));
		registerHandler(PhysServiceProto.PHY2001U04CreateAutoJubsuRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY2001U04CreateAutoJubsuHandler.class));

		//-----[END] [PHY2001U04]

		//-----[START] PHY8002U01
		registerHandler(PhysServiceProto.PHY8002U01GrdPHY8002Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY8002U01GrdPHY8002Handler.class));
		registerHandler(PhysServiceProto.PHY8002U01GrdPHY8003Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY8002U01GrdPHY8003Handler.class));
		registerHandler(PhysServiceProto.PHY8002U01GrdPHY8004Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY8002U01GrdPHY8004Handler.class));
		registerHandler(PhysServiceProto.PHY8002U01MultiGrdRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY8002U01MultiGrdHandler.class));
		registerHandler(PhysServiceProto.PHY8002U01PHY1000U00ScreenOpenRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY8002U01PHY1000U00ScreenOpenHandler.class));
		registerHandler(PhysServiceProto.PHY8002U01BtnPrintGetGwaNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY8002U01BtnPrintGetGwaNameHandler.class));
		registerHandler(PhysServiceProto.PHY8002U01BtnPrintGetDataWindowRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY8002U01BtnPrintGetDataWindowHandler.class));
		registerHandler(PhysServiceProto.PHY8002U01GetLayJissekiDataRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY8002U01GetLayJissekiDataHandler.class));
		registerHandler(PhysServiceProto.PHY8002U01GetPhy8002SeqRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY8002U01GetPhy8002SeqHandler.class));
		registerHandler(PhysServiceProto.PHY8002U01SaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY8002U01SaveLayoutHandler.class));
		registerHandler(PhysServiceProto.PHY8002U01GetScan001SeqRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY8002U01GetScan001SeqHandler.class));
		registerHandler(PhysServiceProto.PHY8002U01LoadFnInpRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY8002U01LoadFnInpHandler.class));

		//-----[END] PHY8002U01
	}

	@Override
	protected void doStop() throws Exception {

	}
}
