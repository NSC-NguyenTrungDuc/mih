package nta.med.kcck.api.socket.handler.nuro;

import javax.annotation.Resource;

import org.springframework.stereotype.Component;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.kcck.api.rpc.proto.BookingModelProto;
import nta.med.kcck.api.rpc.proto.BookingServiceProto;
import nta.med.kcck.api.rpc.service.booking.BookingApiService;
import nta.med.service.ihis.proto.NuroServiceProto;

@Component("getMisSurveyLinkHandler")
public class GetMisSurveyLinkHandler extends ScreenHandler<NuroServiceProto.GetMisSurveyLinkRequest, NuroServiceProto.GetMisSurveyLinkResponse>{

	@Resource
	private BookingApiService bookingApiService;
	
	@Override
	public NuroServiceProto.GetMisSurveyLinkResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuroServiceProto.GetMisSurveyLinkRequest request) throws Exception {
		
		NuroServiceProto.GetMisSurveyLinkResponse.Builder r = NuroServiceProto.GetMisSurveyLinkResponse.newBuilder();
		r.setId(request.getId());
		
		BookingServiceProto.GetMisSurveyLinkResponse res = bookingApiService.getMisSurveyLink(toApiRequest(request));
		r.setResult(res.getResult());
		r.setSurveyLink(res.getSurveyLink());
		
		return r.build();
	}
	
	private BookingServiceProto.GetMisSurveyLinkRequest toApiRequest(NuroServiceProto.GetMisSurveyLinkRequest request){
		BookingServiceProto.GetMisSurveyLinkRequest.Builder r = BookingServiceProto.GetMisSurveyLinkRequest.newBuilder();
		r.setId(request.getId());
		r.setHospCode(request.getHospCode());
		r.setPatientCode(request.getPatientCode());
		r.setDepartmentCode(request.getDepartmentCode());
		r.setReservationCode(request.getReservationCode());
		
		if(request.getBookingExamInfo() != null){
			BookingModelProto.BookingExamInfo.Builder bInfo = BookingModelProto.BookingExamInfo.newBuilder();
			BeanUtils.copyProperties(request.getBookingExamInfo(), bInfo, "JA");
			r.setBookingExamInfo(bInfo.build());
		}
		
		return r.build();
	}
	
}
