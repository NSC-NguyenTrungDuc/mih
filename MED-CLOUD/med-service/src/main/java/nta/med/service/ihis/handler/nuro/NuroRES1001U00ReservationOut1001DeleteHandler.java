package nta.med.service.ihis.handler.nuro;

import javax.annotation.Resource;

import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class NuroRES1001U00ReservationOut1001DeleteHandler extends ScreenHandler<NuroServiceProto.NuroRES1001U00ReservationOut1001DeleteRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOG = LogFactory.getLog(NuroRES1001U00ReservationOut1001DeleteHandler.class);
	@Resource
	private Out1001Repository out1001Repository;

    @Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroRES1001U00ReservationOut1001DeleteRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		boolean result = deleteOut1001ById(request, getHospitalCode(vertx, sessionId));
        response.setResult(result);
		return response.build();
	}
    
	private boolean deleteOut1001ById(NuroServiceProto.NuroRES1001U00ReservationOut1001DeleteRequest request, String hospCode) {
			Integer resultDelete = out1001Repository.deleteOut1001ById(hospCode, StringUtils.isEmpty(request.getPkout1001()) ? null : new Double(request.getPkout1001()));
			if (resultDelete > 0) {
				LOG.info("delete successfully for " + resultDelete + " records");
				return true;
			}else{
				return false;
			}
	}
}
