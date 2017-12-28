package nta.med.kcck.api.socket.vertx;

import nta.med.core.glossary.AdministrationNotice;
import nta.med.core.infrastructure.SpringBeanFactory;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.infrastructure.socket.vertx.VertxContext;
import nta.med.kcck.api.socket.handler.system.GetMisTokenHandler;
import nta.med.service.ihis.proto.SystemServiceProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.vertx.java.core.Handler;
import org.vertx.java.core.eventbus.Message;

import java.util.Map;

public class SystemVerticle extends ApiVerticle{
	
	public SystemVerticle() {
		super(SystemServiceProto.class, SystemServiceProto.getDescriptor());
	}

	private static final Log LOGGER = LogFactory.getLog(SystemVerticle.class);

	@Override
	protected void doStart() throws Exception {
		registerHandler(SystemServiceProto.GetMisTokenRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(GetMisTokenHandler.class));

        vertx.eventBus().registerHandler(AdministrationNotice.MAINTAINANCE_WHOLE_SYSTEM_NOTICE.getAddress(), (Handler<Message<Integer>>) event -> {
            LOGGER.info("Receive maintainance notice: " + event.body());
            VertxContext.current().maintainance("ALL", event.body() != null && event.body() != 0);
        }, event -> {
            if (event.succeeded()) {
                LOGGER.info("Completed registerHandler of " + AdministrationNotice.MAINTAINANCE_WHOLE_SYSTEM_NOTICE.getAddress());
            } else {
                LOGGER.info(String.format("RegisterHandler of %s was failed. Result = %s", AdministrationNotice.MAINTAINANCE_WHOLE_SYSTEM_NOTICE.getAddress(), event.result()));
            }
        });
	}

    @Override
    protected void doStop() throws Exception {
        for (Map.Entry<String, ScreenHandler> entry : handlers.entrySet()) {
            vertx.eventBus().unregisterHandler(entry.getKey(), xhandler, event -> {
                if (event.succeeded()) {
                    LOGGER.info(String.format("lifecyclet: service %s was successfully unregistered.", entry.getKey()));
                } else {
                    LOGGER.error(String.format("lifecyclet: unregistering service %s was failed.", entry.getKey()), event.cause());
                }
            });
        }
    }

    @Override
    protected boolean isProcessable() {
        return false;
    }

    @Override
    boolean isNodeBasedHandle() {
        return true;
    }
}
