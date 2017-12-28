package nta.med.app.vertx.ihis;

import nta.med.core.infrastructure.socket.vertx.AbstractVerticle;
import nta.med.core.infrastructure.SpringBeanFactory;
import nta.med.service.ihis.handler.endo.*;
import nta.med.service.ihis.proto.EndoServiceProto;

public class EndoVerticle extends AbstractVerticle{
	
	public EndoVerticle() {
		super(EndoServiceProto.class, EndoServiceProto.getDescriptor());
	}
	@Override
    public void doStart() throws Exception{
		//[START] Endo
		registerHandler(EndoServiceProto.END1001U02DsvDwRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(END1001U02DsvDwHandler.class));
		registerHandler(EndoServiceProto.END1001U02DsvLDOCS0801Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(END1001U02DsvLDOCS0801Handler.class));
		registerHandler(EndoServiceProto.END1001U02GrdComment3Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(END1001U02GrdComment3Handler.class));
		registerHandler(EndoServiceProto.END1001U02GrdPaStatusRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(END1001U02GrdPaStatusHandler.class));
		registerHandler(EndoServiceProto.END1001U02GrdPurposeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(END1001U02GrdPurposeHandler.class));
		registerHandler(EndoServiceProto.END1001U02LayOrderDateRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(END1001U02LayOrderDateHandler.class));
		registerHandler(EndoServiceProto.END1001U02UpdateMerGrdRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(END1001U02UpdateMerGrdHandler.class));
		registerHandler(EndoServiceProto.END1001U02GrdComment1Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(END1001U02GrdComment1Handler.class));
		registerHandler(EndoServiceProto.END1001U02GrdComment2Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(END1001U02GrdComment2Handler.class));
		registerHandler(EndoServiceProto.END1001U02DsvGumsaNameRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(END1001U02DsvGumsaNameHandler.class));
		registerHandler(EndoServiceProto.END1001U02OnLoadRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(END1001U02OnLoadHandler.class));
		registerHandler(EndoServiceProto.END1001U02BtnQueryRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(END1001U02BtnQueryHandler.class));
		registerHandler(EndoServiceProto.END1001U02LoadCommentsRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(END1001U02LoadCommentsHandler.class));

		//[END] Endo
	}
	
	@Override
	protected void doStop() throws Exception {}
}
