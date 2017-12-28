package nta.med.kcck.api.socket.vertx;

import java.util.Arrays;
import java.util.List;
import java.util.Map;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;

import nta.med.core.infrastructure.SpringBeanFactory;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.kcck.api.rpc.service.booking.impl.BookingApiServiceImpl;
import nta.med.kcck.api.rpc.service.hospital.impl.HospitalApiServiceImpl;
import nta.med.kcck.api.rpc.service.patient.impl.PatientApiServiceImpl;
import nta.med.kcck.api.socket.handler.nuro.BookingExaminationHandler;
import nta.med.kcck.api.socket.handler.nuro.CreatePatientHandler;
import nta.med.kcck.api.socket.handler.nuro.GetMisSurveyLinkHandler;
import nta.med.kcck.api.socket.handler.nuro.OrderTranferHandler;
import nta.med.kcck.api.socket.handler.nuro.SaveExaminationHandler;
import nta.med.service.ihis.proto.NuroServiceProto;

/**
 * @author dainguyen.
 */
public class NuroVerticle extends ApiVerticle {

    private static final Log LOGGER = LogFactory.getLog(NuroVerticle.class);

    public NuroVerticle() {
        super(NuroServiceProto.class, NuroServiceProto.getDescriptor());
    }

    @Override
    protected List<String> subscribeTopics() {
        return Arrays.asList(NuroServiceProto.PatientEvent.class.getSimpleName(), NuroServiceProto.BookingEvent.class.getSimpleName(),  NuroServiceProto.HospitalEvent.class.getSimpleName());
    }

    @Override
    protected void doStart() throws Exception {
        //subscribe
        subscribeHandler(NuroServiceProto.PatientEvent.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PatientApiServiceImpl.class).getAdapter());
        subscribeHandler(NuroServiceProto.BookingEvent.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(BookingApiServiceImpl.class).getAdapter());
        subscribeHandler(NuroServiceProto.HospitalEvent.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(HospitalApiServiceImpl.class).getAdapter());

        //handle
        registerHandler(NuroServiceProto.CreatePatientRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(CreatePatientHandler.class));
        registerHandler(NuroServiceProto.SaveExaminationRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SaveExaminationHandler.class));
        registerHandler(NuroServiceProto.BookingExaminationRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(BookingExaminationHandler.class));
        registerHandler(NuroServiceProto.OrderTranferRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OrderTranferHandler.class));
        registerHandler(NuroServiceProto.GetMisSurveyLinkRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(GetMisSurveyLinkHandler.class));
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
