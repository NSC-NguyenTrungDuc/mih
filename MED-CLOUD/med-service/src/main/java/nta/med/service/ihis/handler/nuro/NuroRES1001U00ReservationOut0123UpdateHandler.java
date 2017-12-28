package nta.med.service.ihis.handler.nuro;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.out.Out0123Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.lang3.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class NuroRES1001U00ReservationOut0123UpdateHandler extends ScreenHandler<NuroServiceProto.NuroRES1001U00ReservationOut0123UpdateRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOG = LogFactory.getLog(NuroRES1001U00ReservationOut0123UpdateHandler.class);
	@Resource
	private Out0123Repository out0123Repository;

	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroRES1001U00ReservationOut0123UpdateRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		if(!StringUtils.isEmpty(request.getHospCodeLink())){
			hospCode = request.getHospCodeLink();
		}
		boolean result = updateOut0123(request, hospCode);
        response.setResult(result);
		return response.build();
	}
	
	private boolean updateOut0123(NuroServiceProto.NuroRES1001U00ReservationOut0123UpdateRequest request, String hospCode) {
		Integer resultUpdate = out0123Repository.updateNuroRES1001U00ReservationOut0123(request.getUserId(), request.getReserComment(), request.getReserType(), new Date(),
				hospCode, request.getPatientCode(), CommonUtils.parseDouble(request.getPkout1001()));
		if (resultUpdate > 0) {
			LOG.info("update success for " + resultUpdate + " records");
			return true;
		}else{
			return false;
		}
	}	
}
