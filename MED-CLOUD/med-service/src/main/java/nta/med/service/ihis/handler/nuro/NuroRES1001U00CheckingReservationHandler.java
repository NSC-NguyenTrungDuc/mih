package nta.med.service.ihis.handler.nuro;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.res.Res0103Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
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
public class NuroRES1001U00CheckingReservationHandler extends ScreenHandler<NuroServiceProto.NuroRES1001U00CheckingReservationRequest, NuroServiceProto.NuroRES1001U00CheckingReservationResponse> {
	private static final Log LOGGER = LogFactory.getLog(NuroRES1001U00CheckingReservationHandler.class);
	@Resource
	private Res0103Repository res0103Repository;

    @Override
	public boolean isValid(NuroServiceProto.NuroRES1001U00CheckingReservationRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getExamPreDate()) && DateUtil.toDate(request.getExamPreDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroRES1001U00CheckingReservationResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroRES1001U00CheckingReservationRequest request) throws Exception {
		NuroServiceProto.NuroRES1001U00CheckingReservationResponse.Builder response = NuroServiceProto.NuroRES1001U00CheckingReservationResponse.newBuilder();
		String result = res0103Repository.getNuroRES1001U00CheckingReservation(getHospitalCode(vertx, sessionId), getHospitalCode(vertx, sessionId), request.getDoctorCode(), 
    			request.getExamPreDate(), request.getExamPreTime(), request.getInputType(), false);
		if(!StringUtils.isEmpty(result)){
			response.setResult(result);
		}
		return response.build();
	}
}
