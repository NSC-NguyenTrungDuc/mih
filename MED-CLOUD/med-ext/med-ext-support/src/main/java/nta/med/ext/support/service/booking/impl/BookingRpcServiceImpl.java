package nta.med.ext.support.service.booking.impl;

import nta.med.common.remoting.ServiceExecutionException;
import nta.med.common.remoting.rpc.glossary.RpcListener;
import nta.med.common.remoting.rpc.glossary.RpcService;
import nta.med.ext.support.proto.BookingServiceProto;
import nta.med.ext.support.proto.BookingServiceProto.BookingEvent;
import nta.med.ext.support.rpc.RpcExtContext;
import nta.med.ext.support.rpc.RpcExtSession;
import nta.med.ext.support.service.AbstractRpcExtService;
import nta.med.ext.support.service.booking.BookingRpcService;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import static nta.med.common.remoting.rpc.message.RpcMessageFormatter.format;

/**
 * @author dainguyen.
 */
public class BookingRpcServiceImpl extends AbstractRpcExtService implements BookingRpcService {

    private static final Logger LOGGER = LoggerFactory.getLogger(BookingRpcServiceImpl.class);

    private RpcExtContext.Listener<BookingEvent> listener;

    private BookingRpcService.Service service;
    
    public BookingRpcServiceImpl() {
        super("api.booking", BookingServiceProto.class, BookingServiceProto.getDescriptor());
    }

    @Override
    public boolean isCompatible(String s) {
        return true;
    }

    @RpcListener(name = "BookingEvent")
    public void onBookingEvent(RpcExtSession session, BookingEvent event) {
    	LOGGER.info("booking event = " + format(event));
        if(listener != null) try {
            listener.onEvent(event);
        } catch (InterruptedException e) {
            LOGGER.warn("booking event was interrupted, event = " + format(event));
        }
    }

    @RpcService(name = "BookingExaminationRequest")
    public BookingServiceProto.BookingExaminationResponse bookExamToExternalSystem(RpcExtSession session, BookingServiceProto.BookingExaminationRequest request){
    	LOGGER.info("BookingRpcService : bookExamToExternalSystem : patient_code = " + request.getPatientCode());
    	if(service != null) try {
            return service.bookExamToExternalSystem(request);
        } catch (Exception e) {
            LOGGER.warn("fail to invoke bookExamToExternalSystem, request = " + format(request));
        }
        throw new ServiceExecutionException();
    }
    
    @RpcService(name = "GetMisSurveyLinkRequest")
    public BookingServiceProto.GetMisSurveyLinkResponse getMisSurveyLink(RpcExtSession session, BookingServiceProto.GetMisSurveyLinkRequest request){
    	LOGGER.info("GetMisSurveyLinkRequest = " + format(request));
    	if(service != null) try {
            return service.getMisSurveyLink(request);
        } catch (Exception e) {
            LOGGER.warn("fail to invoke getMisSurveyLink, request = " + format(request));
        }
        throw new ServiceExecutionException();
    }
    
    public void setListener(RpcExtContext.Listener<BookingEvent> listener) {
        this.listener = listener;
    }

    @Override
    public BookingServiceProto.BookingExaminationResponse bookExamination(BookingServiceProto.BookingExaminationRequest request) {
        return invoke(request, 30000L, true);
    }

    @Override
    public BookingServiceProto.SubscribeBookingEventResponse subscribeBooking(BookingServiceProto.SubscribeBookingEventRequest request) {
        return invoke(request, 10000L, true);
    }
    
    @Override
    public BookingServiceProto.ChangeBookingExaminationResponse changeBookingExamination(BookingServiceProto.ChangeBookingExaminationRequest request) {
        return invoke(request, 10000L, true);
    }
    
    @Override
    public BookingServiceProto.CancelBookingExaminationResponse cancelBookingExamination(BookingServiceProto.CancelBookingExaminationRequest request) {
        return invoke(request, 10000L, true);
    }

	public BookingRpcService.Service getService() {
		return service;
	}

	public void setService(BookingRpcService.Service service) {
		this.service = service;
	}
	
}
