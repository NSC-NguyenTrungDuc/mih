package nta.med.app.vertx.orca;

import nta.med.core.infrastructure.socket.vertx.AbstractVerticle;
import nta.med.core.infrastructure.SpringBeanFactory;
import nta.med.service.ihis.handler.nuro.ORCATransferOrdersHandler;
import nta.med.service.orca.handler.ORCALibAcquisitionHandler;
import nta.med.service.orca.handler.ORCALibGetClaimDiagnosisHandler;
import nta.med.service.orca.handler.ORCALibGetClaimInfoHandler;
import nta.med.service.orca.handler.ORCALibGetClaimInsuredHandler;
import nta.med.service.orca.handler.ORCALibGetClaimOrderHandler;
import nta.med.service.orca.handler.ORCALibGetClaimPatientHandler;
import nta.med.service.orca.proto.OrcaServiceProto;

public class OrcaVerticle extends AbstractVerticle{
	public OrcaVerticle() {
		super(OrcaServiceProto.class, OrcaServiceProto.getDescriptor());
	}

	@Override
	protected void doStart() throws Exception {
		//[START] ORCA lib
        registerHandler(OrcaServiceProto.ORCALibGetClaimPatientRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ORCALibGetClaimPatientHandler.class));
        registerHandler(OrcaServiceProto.ORCALibAcquisitionRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ORCALibAcquisitionHandler.class));
        registerHandler(OrcaServiceProto.ORCALibGetClaimInsuredRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ORCALibGetClaimInsuredHandler.class));
        registerHandler(OrcaServiceProto.ORCALibGetClaimOrderRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ORCALibGetClaimOrderHandler.class));
        registerHandler(OrcaServiceProto.ORCALibGetClaimDiagnosisRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ORCALibGetClaimDiagnosisHandler.class));
        registerHandler(OrcaServiceProto.ORCALibGetClaimInfoRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ORCALibGetClaimInfoHandler.class));
        //[END] ORCA lib
        registerHandler(OrcaServiceProto.ORCATransferOrdersRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ORCATransferOrdersHandler.class));
	}

	@Override
	protected void doStop() throws Exception {
		// TODO Auto-generated method stub
		
	}
}
