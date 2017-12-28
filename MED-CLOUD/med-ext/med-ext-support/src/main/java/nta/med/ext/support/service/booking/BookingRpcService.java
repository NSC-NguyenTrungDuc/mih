package nta.med.ext.support.service.booking;

import nta.med.ext.support.proto.BookingModelProto;
import nta.med.ext.support.proto.BookingServiceProto;
import nta.med.ext.support.proto.BookingServiceProto.CancelBookingExaminationRequest;
import nta.med.ext.support.proto.BookingServiceProto.CancelBookingExaminationResponse;
import nta.med.ext.support.proto.BookingServiceProto.ChangeBookingExaminationRequest;
import nta.med.ext.support.proto.BookingServiceProto.ChangeBookingExaminationResponse;

/**
 * @author dainguyen.
 */
public interface BookingRpcService {

    BookingServiceProto.BookingExaminationResponse bookExamination(BookingServiceProto.BookingExaminationRequest request);

    BookingServiceProto.SubscribeBookingEventResponse subscribeBooking(BookingServiceProto.SubscribeBookingEventRequest request);

	ChangeBookingExaminationResponse changeBookingExamination(ChangeBookingExaminationRequest request);

	CancelBookingExaminationResponse cancelBookingExamination(CancelBookingExaminationRequest request);	
	
	interface Service{
		BookingServiceProto.BookingExaminationResponse bookExamToExternalSystem(BookingServiceProto.BookingExaminationRequest request) throws Exception;
		BookingServiceProto.GetMisSurveyLinkResponse getMisSurveyLink(BookingServiceProto.GetMisSurveyLinkRequest request) throws Exception;
	}
}
