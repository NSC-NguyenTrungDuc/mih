package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.sch.Sch0201Repository;
import nta.med.data.model.ihis.nuro.NuroCheckBookingInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class NuroCheckBookingHandler extends ScreenHandler<NuroServiceProto.NuroCheckBookingRequest, NuroServiceProto.NuroCheckBookingResponse> {
	private static final Log LOGGER = LogFactory.getLog(NuroCheckBookingHandler.class);
	@Resource
	private Sch0201Repository sch0201Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroCheckBookingResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroCheckBookingRequest request) throws Exception {
		 NuroServiceProto.NuroCheckBookingResponse.Builder response= NuroServiceProto.NuroCheckBookingResponse.newBuilder();
		 List<NuroCheckBookingInfo> listNuroCheckBookingRequest = sch0201Repository.getNuroCheckBookingInfo(getHospitalCode(vertx, sessionId), request.getPatientCode(), request.getReserDate());
         if (listNuroCheckBookingRequest != null && !listNuroCheckBookingRequest.isEmpty()) {
             for (NuroCheckBookingInfo item : listNuroCheckBookingRequest) {
                 NuroModelProto.NuroCheckBookingInfo.Builder bookingInfo = NuroModelProto.NuroCheckBookingInfo.newBuilder();
	                if(!StringUtils.isEmpty(item.getPatientCode())) {
	                    bookingInfo.setPatientCode(item.getPatientCode());
	                }
	                if(item.getReserDate() != null) {
	                    bookingInfo.setReserData(DateUtil.toString(item.getReserDate(), DateUtil.PATTERN_SLASH_YYYYMMDD_HH_COLON_MM_SS));
	                }
	                response.addCheckBookingInfo(bookingInfo);
             }

         }
		return response.build();
	}

}
