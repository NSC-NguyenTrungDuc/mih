package nta.med.service.ihis.handler.nuro;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class NuroRES1001U00ReservationOut1001UpdateHandler extends ScreenHandler<NuroServiceProto.NuroRES1001U00ReservationOut1001UpdateRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOG = LogFactory.getLog(NuroRES1001U00ReservationOut1001UpdateHandler.class);
	@Resource
	private Out1001Repository out1001Repository;

	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroRES1001U00ReservationOut1001UpdateRequest request) throws Exception {
		boolean result = false;
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		Integer resultUpdate = out1001Repository.updateNuroRES1001U00ReservationOut1001(request.getUserId(), new Date(), DateUtil.toDate(request.getExamPreDate(),DateUtil.PATTERN_YYMMDD),
        		request.getExamPreTime(), request.getReceptionNo(), getHospitalCode(vertx, sessionId), request.getPkout1001());
        if (resultUpdate > 0) {
        	LOG.info("update success for " + resultUpdate + " records");
        	result = true;
        }
        response.setResult(result);
		return response.build();
	}
}
