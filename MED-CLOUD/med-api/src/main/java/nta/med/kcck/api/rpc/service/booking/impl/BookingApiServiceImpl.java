package nta.med.kcck.api.rpc.service.booking.impl;

import java.util.List;
import java.util.concurrent.TimeUnit;

import javax.annotation.Resource;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import nta.med.common.remoting.ServiceUnavailableException;
import nta.med.common.remoting.rpc.glossary.RpcService;
import nta.med.common.remoting.rpc.message.RpcMessageBuilder;
import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.common.util.concurrent.future.FutureEx;
import nta.med.core.domain.event.BookingEvent;
import nta.med.core.glossary.Language;
import nta.med.core.infrastructure.socket.listener.AbstractListener;
import nta.med.core.utils.BeanUtils;
import nta.med.data.mongo.medi.BookingEventRepository;
import nta.med.kcck.api.adapter.NuroAdapter;
import nta.med.kcck.api.rpc.RpcApiSession;
import nta.med.kcck.api.rpc.proto.BookingModelProto;
import nta.med.kcck.api.rpc.proto.BookingServiceProto;
import nta.med.kcck.api.rpc.proto.SystemServiceProto;
import nta.med.kcck.api.rpc.service.AbstractRpcApiService;
import nta.med.kcck.api.rpc.service.booking.BookingApiService;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

/**
 * @author dainguyen.
 */
public class BookingApiServiceImpl extends AbstractRpcApiService implements BookingApiService {

	private static final Logger LOGGER = LoggerFactory.getLogger(BookingApiServiceImpl.class);
	
	@Resource
    private NuroAdapter nuroAdapter;
	
	@Resource
    BookingEventRepository eventRepository;
    
	private BookingEventAdapter adapter = new BookingEventAdapter();
    
	public BookingApiServiceImpl() {
        super(BookingServiceProto.class, BookingServiceProto.getDescriptor());
    }

    @Override
    public boolean isCompatible(String s) {
        return true;
    }

    @RpcService(name = "BookingExaminationRequest", authenticate = true)
    public BookingServiceProto.BookingExaminationResponse bookExamination(RpcApiSession session, BookingServiceProto.BookingExaminationRequest request) {
    	return nuroAdapter.bookingExamination(session, request);
    }

    @RpcService(name = "SubscribeBookingEventRequest", authenticate = true)
    public BookingServiceProto.SubscribeBookingEventResponse subscribeBooking(RpcApiSession session, BookingServiceProto.SubscribeBookingEventRequest request) {
        BookingServiceProto.SubscribeBookingEventResponse.Builder r = BookingServiceProto.SubscribeBookingEventResponse.newBuilder();
        r.setResult(BookingServiceProto.SubscribeBookingEventResponse.Result.SUCCESS);

        if(request.hasEventId() && request.getEventId() > 0) {
            List<BookingEvent> lostEvents = eventRepository.findByIdGreaterThan(request.getEventId());
            for (BookingEvent event : lostEvents) {
                r.addEvents(toEvent(event));
            }
        }


        session.subscribeBooking(session.getHospCode());
        return r.build();
    }

    private BookingServiceProto.BookingEvent toEvent(BookingEvent event) {
        //TODO: implement booking event
        BookingServiceProto.BookingEvent.Builder r = BookingServiceProto.BookingEvent.newBuilder()
                .setId(1L).setTimestamp(1L)
                .setType("");
        if(event != null)
        {
            BeanUtils.copyProperties(event, r, Language.JAPANESE.toString());
        }
        return r.build();
    }


    public BookingEventAdapter getAdapter() {
        return adapter;
    }

    public class BookingEventAdapter extends AbstractListener<NuroServiceProto.BookingEvent> {
    	
        @Override
        public void onEvent(NuroServiceProto.BookingEvent event) {
        	LOGGER.info("BEGIN BookingEventAdapter");
            for(RpcApiSession s : context.getSessions()) {
                final Rpc.RpcMessage m = RpcMessageBuilder.build(toApiEvent(event), Rpc.RpcMessage.Result.SUCCESS);
                if(m != null && s.hasSubscribedBooking(event.getHospCode())) async(null, null, "ON_BOOKS", () -> { s.send(m); });
            }
        }

        private BookingServiceProto.BookingEvent toApiEvent(NuroServiceProto.BookingEvent event) {
            BookingModelProto.BookingExamInfo.Builder bookingExam = BookingModelProto.BookingExamInfo.newBuilder();
            NuroModelProto.BookingExamInfo bookingExamInfo = event.getBookingExamInfo();
            BeanUtils.copyProperties(bookingExamInfo, bookingExam, Language.JAPANESE.toString());
            bookingExam.setPatientCode(event.getPatientCode());
            bookingExam.setPatientName(event.getPatientName());
            bookingExam.setHospCode(event.getHospCode());
            if(bookingExamInfo.getAction() != null && bookingExamInfo.getAction().equals(NuroModelProto.BookingExamInfo.Action.BOOKING)){
                bookingExam.setAction(BookingModelProto.BookingExamInfo.Action.BOOKING);
                LOGGER.info("BookingEventAdapter: toApiEvent: Action.BOOKING");
            }
            if(bookingExamInfo.getAction() != null && bookingExamInfo.getAction().equals(NuroModelProto.BookingExamInfo.Action.CHANGE_BOOKING)){
                bookingExam.setAction(BookingModelProto.BookingExamInfo.Action.CHANGE_BOOKING);
                LOGGER.info("BookingEventAdapter: toApiEvent: Action.CHANGE_BOOKING");
            }
            if(bookingExamInfo.getAction() != null && bookingExamInfo.getAction().equals(NuroModelProto.BookingExamInfo.Action.CANCEL_BOOKING)){
                bookingExam.setAction(BookingModelProto.BookingExamInfo.Action.CANCEL_BOOKING);
                LOGGER.info("BookingEventAdapter: toApiEvent: Action.CANCEL_BOOKING");
            }
            BookingServiceProto.BookingEvent.Builder r = BookingServiceProto.BookingEvent.newBuilder();
            r.setId(System.currentTimeMillis()).setType("11").setTimestamp(System.currentTimeMillis());
            r.setBookingId(1).setBookingExam(bookingExam);
            return r.build();
        }
    }
    
    @RpcService(name = "ChangeBookingExaminationRequest", authenticate = true)
    public BookingServiceProto.ChangeBookingExaminationResponse changeBookingExamination(RpcApiSession session, BookingServiceProto.ChangeBookingExaminationRequest request) {
    	return nuroAdapter.changeBookingExamination(session, request);
    }
    
    @RpcService(name = "CancelBookingExaminationRequest", authenticate = true)
    public BookingServiceProto.CancelBookingExaminationResponse cancelBookingExamination(RpcApiSession session, BookingServiceProto.CancelBookingExaminationRequest request) {
    	return nuroAdapter.cancelBookingExamination(session, request);
    }
    
    @Override
	public BookingServiceProto.BookingExaminationResponse bookExamToExternalSystem(BookingServiceProto.BookingExaminationRequest request) throws Exception {
    	LOGGER.info("BookingApiService: bookExamToExternalSystem : patient_code = " + request.getPatientCode());
        for (RpcApiSession session : context.getSessions()) {
            if(session.isAuthorized(request.getHospCode()) && session.hasCapability(SystemServiceProto.LoginRequest.Capability.APPOINT_EXAM)) {
                FutureEx<Rpc.RpcMessage> res = session.invoke(RpcMessageBuilder.build(request, null));
                Rpc.RpcMessage r = res.get(30, TimeUnit.SECONDS);
                if(r != null) return parser.parse(r);
            }
        }

        throw new ServiceUnavailableException();
	}

	@Override
	public BookingServiceProto.GetMisSurveyLinkResponse getMisSurveyLink(BookingServiceProto.GetMisSurveyLinkRequest request) throws Exception {
		for (RpcApiSession session : context.getSessions()) {
            if(session.isAuthorized(request.getHospCode()) && session.hasCapability(SystemServiceProto.LoginRequest.Capability.GET_MIS_SURVEY_LINK)) {
                FutureEx<Rpc.RpcMessage> res = session.invoke(RpcMessageBuilder.build(request, null));
                Rpc.RpcMessage r = res.get(30, TimeUnit.SECONDS);
                if(r != null) return parser.parse(r);
            }
        }

        throw new ServiceUnavailableException();
	}
}
