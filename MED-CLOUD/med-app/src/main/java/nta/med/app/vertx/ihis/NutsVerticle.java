package nta.med.app.vertx.ihis;

import nta.med.core.infrastructure.socket.vertx.AbstractVerticle;
import nta.med.core.infrastructure.SpringBeanFactory;
import nta.med.service.ihis.handler.nuts.*;
import nta.med.service.ihis.proto.NutsServiceProto;

public class NutsVerticle extends AbstractVerticle {
	public NutsVerticle() {
		super(NutsServiceProto.class, NutsServiceProto.getDescriptor());
	}

	@Override
	protected void doStart() throws Exception {
		// [START] NUT0001U00
		registerHandler(NutsServiceProto.NUT0001U00LoadDoctorGwaRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NUT0001U00LoadDoctorGwaHandler.class));
		registerHandler(NutsServiceProto.NUT0001U00InitializeScreenRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NUT0001U00InitializeScreenHandler.class));
		registerHandler(NutsServiceProto.NUT0001U00Grd0002Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NUT0001U00Grd0002Handler.class));
		registerHandler(NutsServiceProto.NUT0001U00SaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NUT0001U00SaveLayoutHandler.class));
		registerHandler(NutsServiceProto.NUT0001U00LoadDoctorNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NUT0001U00LoadDoctorNameHandler.class));
		registerHandler(NutsServiceProto.NUT0001U00GetNaewonKeyRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NUT0001U00GetNaewonKeyHandler.class));
		
		registerHandler(NutsServiceProto.NUT9001U00grdINP5001Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NUT9001U00grdINP5001Handler.class));
		registerHandler(NutsServiceProto.NUT9001U00CursorIFS7501Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NUT9001U00CursorIFS7501Handler.class));
		registerHandler(NutsServiceProto.NUT9001U00btnFinalCClickRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NUT9001U00btnFinalCClickHandler.class));
		registerHandler(NutsServiceProto.NUT9001U00grdINP5001QueryEndRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NUT9001U00grdINP5001QueryEndHandler.class));
		registerHandler(NutsServiceProto.NUT9001U00cbxSiksaChangeYNCRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NUT9001U00cbxSiksaChangeYNCHandler.class));
		registerHandler(NutsServiceProto.NUT9001U00PRNutMagamRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NUT9001U00PRNutMagamHandler.class));
		registerHandler(NutsServiceProto.NUT9001U00PRIfsNutProcMainRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NUT9001U00PRIfsNutProcMainHandler.class));
		registerHandler(NutsServiceProto.NUT9001Q01createHoDongRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NUT9001Q01createHoDongHandler.class));
		registerHandler(NutsServiceProto.NUT9001Q01grdListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NUT9001Q01grdListHandler.class));
		registerHandler(NutsServiceProto.NUT9001U00ScreenOpenRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NUT9001U00ScreenOpenHandler.class));
		// [END] NUT0001U00
	}

	@Override
	protected void doStop() throws Exception {

	}

}
