package nta.med.app.vertx.ihis;

import nta.med.core.infrastructure.socket.vertx.AbstractVerticle;
import nta.med.core.infrastructure.SpringBeanFactory;
import nta.med.service.ihis.handler.pfes.*;
import nta.med.service.ihis.proto.PfesServiceProto;

public class PfesVerticle extends AbstractVerticle {

	public PfesVerticle() {
		super(PfesServiceProto.class, PfesServiceProto.getDescriptor());
	}

	@Override
	protected void doStart() throws Exception {
		//[START]PFE0101U00
		registerHandler(PfesServiceProto.PFE0101U00GrdMCodeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PFE0101U00GrdMCodeHandler.class));
		registerHandler(PfesServiceProto.PFE0101U00GrdDCodeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PFE0101U00GrdDCodeHandler.class));
		registerHandler(PfesServiceProto.PFE0101U00LayDupDRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PFE0101U00LayDupDHandler.class));
		registerHandler(PfesServiceProto.PFE0101U00LayDupMRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PFE0101U00LayDupMHandler.class));
		registerHandler(PfesServiceProto.PFE0101U00LayUserNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PFE0101U00LayUserNameHandler.class));
		registerHandler(PfesServiceProto.PFE0101U00GrdDcodeColumnChangedRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PFE0101U00GrdDcodeColumnChangedHandler.class));
		registerHandler(PfesServiceProto.PFE0101U00SaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PFE0101U00SaveLayoutHandler.class));

		//[END]PFE0101U00

		//[START] PFE7001Q01
		registerHandler(PfesServiceProto.PFE7001Q01LayDailyReportRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PFE7001Q01LayDailyReportHandler.class));
		registerHandler(PfesServiceProto.PFE7001Q02LayMonthlyReportRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PFE7001Q02LayMonthlyReportHandler.class));
		//[END] PFE7001Q01

		//[START] PFE0101U01
		registerHandler(PfesServiceProto.PFE0101U01GrdDCodeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PFE0101U01GrdDCodeHandler.class));
		registerHandler(PfesServiceProto.PFE0101U01GrdMCodeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PFE0101U01GrdMCodeHandler.class));
		registerHandler(PfesServiceProto.PFE0101U01LayDupDRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PFE0101U01LayDupDHandler.class));
		registerHandler(PfesServiceProto.PFE0101U01LayDupMRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PFE0101U01LayDupMHandler.class));
		registerHandler(PfesServiceProto.PFE0101U01LayUserNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PFE0101U01LayUserNameHandler.class));
		registerHandler(PfesServiceProto.PFE0101U01SaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PFE0101U01SaveLayoutHandler.class));
		//[END] PFE0101U01
	}

	@Override
	protected void doStop() throws Exception {

	}
}
