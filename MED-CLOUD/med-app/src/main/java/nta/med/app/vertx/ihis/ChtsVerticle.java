package nta.med.app.vertx.ihis;

import nta.med.core.infrastructure.socket.vertx.AbstractVerticle;
import nta.med.core.infrastructure.SpringBeanFactory;
import nta.med.service.ihis.handler.chts.*;
import nta.med.service.ihis.proto.ChtsServiceProto;

public class ChtsVerticle extends AbstractVerticle {

	public ChtsVerticle() {
		super(ChtsServiceProto.class, ChtsServiceProto.getDescriptor());
	}

	@Override
	protected void doStart() throws Exception {
		//[START] CHT0110U00
		registerHandler(ChtsServiceProto.CHT0110U00GetCodeNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(CHT0110U00GetCodeNameHandler.class));
		registerHandler(ChtsServiceProto.CHT0110U00ExecuteRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CHT0110U00ExecuteHandler.class));
		registerHandler(ChtsServiceProto.CHT0110U00grdCHT0110Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CHT0110U00grdCHT0110Handler.class));
		//[END] CHT0110U00

		//[START] [CHT0115Q01] - Register
		registerHandler(ChtsServiceProto.CHT0115Q01grdCHT0115Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CHT0115Q01grdCHT0115Handler.class));
		registerHandler(ChtsServiceProto.CHT0115Q01TransactionalRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CHT0115Q01TransactionalHandler.class));

		//[END] [CHT0115Q01] - Register

		//[START] [CHT0117] Manage position code [treatment-surgery]
		registerHandler(ChtsServiceProto.CHT0117GrdCHT0117InitRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CHT0117GrdCHT0117InitHandler.class));
		registerHandler(ChtsServiceProto.CHT0117GrdCHT0118InitRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CHT0117GrdCHT0118InitHandler.class));
		registerHandler(ChtsServiceProto.CHT0117LayNextSubBuwiCdRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CHT0117LayNextSubBuwiCdHandler.class));
		registerHandler(ChtsServiceProto.CHT0117grdCHT0117CheckRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CHT0117grdCHT0117CheckHandler.class));
		registerHandler(ChtsServiceProto.CHT0117TransactionalRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CHT0117TransactionalHandler.class));
		//[END] [CHT0117]Manage position code [treatment-surgery]

		//[START] [CHT0110Q01]
		registerHandler(ChtsServiceProto.CHT0110Q01GrdCHT0110MListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CHT0110Q01GrdCHT0110MListHandler.class));
		//[END] [CHT0110Q01]
		//[START] [CHT0115Q00]
		registerHandler(ChtsServiceProto.CHT0115Q00GrdScPostRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CHT0115Q00GrdScPostHandler.class));
		registerHandler(ChtsServiceProto.CHT0115Q00GrdScPreRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CHT0115Q00GrdScPreHandler.class));
		registerHandler(ChtsServiceProto.CHT0115Q00SusikCodeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CHT0115Q00SusikCodeHandler.class));
		registerHandler(ChtsServiceProto.CHT0115Q00LayoutCommonRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CHT0115Q00LayoutCommonHandler.class));
		//[END] [CHT0115Q00]

		//[START] CHT0117Q00
		registerHandler(ChtsServiceProto.CHT0117Q00DloCHT0117Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CHT0117Q00DloCHT0117Handler.class));
		registerHandler(ChtsServiceProto.CHT0117Q00GrdCHT0118Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CHT0117Q00GrdCHT0118Handler.class));
		//[END] CHT0117Q00

		//[START] CHT0113Q00
		registerHandler(ChtsServiceProto.CHT0113Q00GrdCHT0113Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CHT0113Q00GrdCHT0113Handler.class));
		//[END] CHT0113Q00
	}

	@Override
	protected void doStop() throws Exception {

	}

}
