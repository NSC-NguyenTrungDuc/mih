package nta.med.service.ihis.handler.nuro;
import javax.annotation.Resource;

import nta.med.core.common.annotation.Route;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class NuroOUT1001U01DeleteJubsuDataHandler  extends ScreenHandler<NuroServiceProto.NuroOUT1001U01DeleteJubsuDataRequest, NuroServiceProto.NuroOUT1001U01DeleteJubsuDataResponse> {
	private static final Log LOGGER = LogFactory.getLog(NuroOUT1001U01DeleteJubsuDataHandler.class);
	@Resource
	private Out1001Repository out1001Repository;

	@Override
	@Route(global = false)
	public NuroServiceProto.NuroOUT1001U01DeleteJubsuDataResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOUT1001U01DeleteJubsuDataRequest request) throws Exception {
		NuroServiceProto.NuroOUT1001U01DeleteJubsuDataResponse.Builder response = NuroServiceProto.NuroOUT1001U01DeleteJubsuDataResponse.newBuilder();
		Integer result = out1001Repository.deleteOut1001ById(getHospitalCode(vertx, sessionId), CommonUtils.parseDouble(request.getPkout1001()));
		response.setResultDelete(result != null && result > 0);
		return response.build();
	}
}
