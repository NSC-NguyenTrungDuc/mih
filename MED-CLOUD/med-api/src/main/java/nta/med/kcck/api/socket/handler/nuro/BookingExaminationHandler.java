package nta.med.kcck.api.socket.handler.nuro;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.stereotype.Component;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.Language;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.kcck.api.rpc.proto.BookingServiceProto;
import nta.med.kcck.api.rpc.service.booking.BookingApiService;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.NuroServiceProto.BookingExaminationRequest;

@Component("bookingExamHandler")
public class BookingExaminationHandler extends ScreenHandler<NuroServiceProto.BookingExaminationRequest, NuroServiceProto.BookingExaminationResponse> {

	private static final Log LOGGER = LogFactory.getLog(BookingExaminationHandler.class);
	
    @Resource
    private BookingApiService bookingApiService;
	
	@Override
	public NuroServiceProto.BookingExaminationResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			BookingExaminationRequest request) throws Exception {
		LOGGER.info("BookingExaminationHandler: patient_code = " + request.getPatientCode());
		
		BookingServiceProto.BookingExaminationResponse rp = bookingApiService.bookExamToExternalSystem(toApiRequest(request));
		NuroServiceProto.BookingExaminationResponse.Builder r = NuroServiceProto.BookingExaminationResponse.newBuilder();
		BeanUtils.copyProperties(rp, r, Language.JAPANESE.toString());
		
		return r.build();
	}

	private BookingServiceProto.BookingExaminationRequest toApiRequest(NuroServiceProto.BookingExaminationRequest request){
		BookingServiceProto.BookingExaminationRequest.Builder rq = BookingServiceProto.BookingExaminationRequest.newBuilder();
		BeanUtils.copyProperties(request, rq, Language.JAPANESE.toString());
		if(request.hasAction()){
			if(request.getAction() == NuroServiceProto.BookingExaminationRequest.Action.BOOKING){
				rq.setAction(BookingServiceProto.BookingExaminationRequest.Action.BOOKING);
			} else if(request.getAction() == NuroServiceProto.BookingExaminationRequest.Action.CHANGE_BOOKING){
				rq.setAction(BookingServiceProto.BookingExaminationRequest.Action.CHANGE_BOOKING);
			} else if(request.getAction() == NuroServiceProto.BookingExaminationRequest.Action.CANCEL_BOOKING){
				rq.setAction(BookingServiceProto.BookingExaminationRequest.Action.CANCEL_BOOKING);
			}
		}
		
		return rq.build();
	}
}
