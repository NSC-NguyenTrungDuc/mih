package nta.med.app.vertx.ihis;

import nta.med.core.infrastructure.socket.vertx.AbstractVerticle;
import nta.med.core.infrastructure.SpringBeanFactory;
import nta.med.service.ihis.handler.clis.CLIS2015U02CboStatusHandler;
import nta.med.service.ihis.handler.clis.CLIS2015U02GrdProtocolHandler;
import nta.med.service.ihis.handler.clis.CLIS2015U02GrdStatusHandler;
import nta.med.service.ihis.handler.clis.CLIS2015U02GrdTrialDrgHandler;
import nta.med.service.ihis.handler.clis.CLIS2015U02SaveLayoutHandler;
import nta.med.service.ihis.handler.clis.CLIS2015U03CheckPatientHandler;
import nta.med.service.ihis.handler.clis.CLIS2015U03PatientListDataValidatingHandler;
import nta.med.service.ihis.handler.clis.CLIS2015U03PatientListHandler;
import nta.med.service.ihis.handler.clis.CLIS2015U03ProtocolListHandler;
import nta.med.service.ihis.handler.clis.CLIS2015U03SaveLayoutHandler;
import nta.med.service.ihis.handler.clis.CLIS2015U03SearchPatientHandler;
import nta.med.service.ihis.handler.clis.CLIS2015U04GetPatientListItemHandler;
import nta.med.service.ihis.handler.clis.CLIS2015U04GetPatientStatusListItemHandler;
import nta.med.service.ihis.handler.clis.CLIS2015U04GetProtocolItemHandler;
import nta.med.service.ihis.handler.clis.CLIS2015U04GetProtocolListByPatientItemHandler;
import nta.med.service.ihis.handler.clis.CLIS2015U04UpdateStatusPatientItemHandler;
import nta.med.service.ihis.handler.clis.CLIS2015U09CheckSmoCodeOnDeleteHandler;
import nta.med.service.ihis.handler.clis.CLIS2015U09GetCodeNameHandler;
import nta.med.service.ihis.handler.clis.CLIS2015U09PrefectureCodeHandler;
import nta.med.service.ihis.handler.clis.CLIS2015U13TrialItemListHandler;
import nta.med.service.ihis.handler.clis.Clis2015U09CheckSmoCodeHandler;
import nta.med.service.ihis.handler.clis.Clis2015U09GrdHandler;
import nta.med.service.ihis.handler.clis.Clis2015U09SaveHandler;
import nta.med.service.ihis.proto.ClisServiceProto;

public class ClisVerticle extends AbstractVerticle {

	public ClisVerticle() {
		super(ClisServiceProto.class, ClisServiceProto.getDescriptor());
	}

	@Override
	protected void doStart() throws Exception {
	 // [START] CLIS2015U09
	 registerHandler(ClisServiceProto.CLIS2015U09GrdRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(Clis2015U09GrdHandler.class));
	 registerHandler(ClisServiceProto.CLIS2015U09SaveRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(Clis2015U09SaveHandler.class));
	 registerHandler(ClisServiceProto.CLIS2015U09CheckSmoCodeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(Clis2015U09CheckSmoCodeHandler.class));
	 registerHandler(ClisServiceProto.CLIS2015U09PrefectureCodeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CLIS2015U09PrefectureCodeHandler.class));
	 registerHandler(ClisServiceProto.CLIS2015U09GetCodeNameRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CLIS2015U09GetCodeNameHandler.class));
	 registerHandler(ClisServiceProto.CLIS2015U09CheckSmoCodeOnDeleteRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CLIS2015U09CheckSmoCodeOnDeleteHandler.class));
	 
	// [END] CLIS2015U09

	// [START] CLIS2015U02
	 registerHandler(ClisServiceProto.CLIS2015U02GrdProtocolRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CLIS2015U02GrdProtocolHandler.class));
	 registerHandler(ClisServiceProto.CLIS2015U02GrdStatusRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CLIS2015U02GrdStatusHandler.class));
	 registerHandler(ClisServiceProto.CLIS2015U02CboStatusRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CLIS2015U02CboStatusHandler.class));
	 registerHandler(ClisServiceProto.CLIS2015U02SaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CLIS2015U02SaveLayoutHandler.class));
	 registerHandler(ClisServiceProto.CLIS2015U02GrdTrialDrgRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CLIS2015U02GrdTrialDrgHandler.class));

	// [END] CLIS2015U02
	registerHandler(ClisServiceProto.CLIS2015U03ProtocolListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CLIS2015U03ProtocolListHandler.class));
	registerHandler(ClisServiceProto.CLIS2015U03PatientListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CLIS2015U03PatientListHandler.class));
	registerHandler(ClisServiceProto.CLIS2015U03SearchPatientRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CLIS2015U03SearchPatientHandler.class));
	registerHandler(ClisServiceProto.CLIS2015U03CheckPatientRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CLIS2015U03CheckPatientHandler.class));
	registerHandler(ClisServiceProto.CLIS2015U03SaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CLIS2015U03SaveLayoutHandler.class));
	registerHandler(ClisServiceProto.CLIS2015U03PatientListDataValidatingRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CLIS2015U03PatientListDataValidatingHandler.class));
	// [START] CLIS2015U03
	
	// [START] CLIS2015U04	
	registerHandler(ClisServiceProto.CLIS2015U04GetProtocolItemRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CLIS2015U04GetProtocolItemHandler.class));
	registerHandler(ClisServiceProto.CLIS2015U04GetPatientListItemRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CLIS2015U04GetPatientListItemHandler.class));
	registerHandler(ClisServiceProto.CLIS2015U04GetPatientStatusListItemRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CLIS2015U04GetPatientStatusListItemHandler.class));
	registerHandler(ClisServiceProto.CLIS2015U04GetProtocolListByPatientItemRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CLIS2015U04GetProtocolListByPatientItemHandler.class));
	registerHandler(ClisServiceProto.CLIS2015U04UpdateStatusPatientItemRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CLIS2015U04UpdateStatusPatientItemHandler.class));
	// [END] CLIS2015U04
	
	// [START] CLIS2015U13
	registerHandler(ClisServiceProto.CLIS2015U13TrialItemListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CLIS2015U13TrialItemListHandler.class));
	// [END] CLIS2015U03
	}
	@Override
	protected void doStop() throws Exception {
	}

}
