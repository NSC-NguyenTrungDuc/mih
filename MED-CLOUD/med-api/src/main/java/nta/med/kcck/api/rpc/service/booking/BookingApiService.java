package nta.med.kcck.api.rpc.service.booking;

import nta.med.kcck.api.rpc.RpcApiSession;
import nta.med.kcck.api.rpc.proto.BookingServiceProto;

/**
 * @author dainguyen.
 */
public interface BookingApiService {

    BookingServiceProto.BookingExaminationResponse bookExamination(RpcApiSession session, BookingServiceProto.BookingExaminationRequest request);

    BookingServiceProto.SubscribeBookingEventResponse subscribeBooking(RpcApiSession session, BookingServiceProto.SubscribeBookingEventRequest request);
    
    BookingServiceProto.BookingExaminationResponse bookExamToExternalSystem(BookingServiceProto.BookingExaminationRequest request) throws Exception;
    
    BookingServiceProto.GetMisSurveyLinkResponse getMisSurveyLink(BookingServiceProto.GetMisSurveyLinkRequest request) throws Exception;

}
