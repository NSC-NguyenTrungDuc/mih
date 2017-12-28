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
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class NuroNUR2001U04ComingStatusUpdateHandler extends ScreenHandler<NuroServiceProto.NuroNUR2001U04ComingStatusUpdateRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOGGER = LogFactory.getLog(NuroNUR2001U04ComingStatusUpdateHandler.class);
	@Resource
	private Out1001Repository out1001Repository;

	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroNUR2001U04ComingStatusUpdateRequest request) throws Exception {
		 SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		 Integer result = out1001Repository.updateComingStatus(getHospitalCode(vertx, sessionId), request.getComingStatus(), request.getPkout1001());
		 response.setResult(result != null && result > 0);
	     return response.build();
	}
}
