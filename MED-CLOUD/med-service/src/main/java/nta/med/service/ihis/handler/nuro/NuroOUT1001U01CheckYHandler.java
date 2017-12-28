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
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;


@Service
@Scope("prototype")
public class NuroOUT1001U01CheckYHandler  extends ScreenHandler<NuroServiceProto.NuroOUT1001U01CheckYRequest, NuroServiceProto.NuroOUT1001U01CheckYResponse> {
	private static final Log LOGGER = LogFactory.getLog(NuroOUT1001U01CheckYHandler.class);
	@Resource
	private Out1001Repository out1001Repository;
	
	@Override
	@Route(global = false)
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroOUT1001U01CheckYResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOUT1001U01CheckYRequest request) throws Exception {
		String  nuroOUT1001U01CheckY = out1001Repository.getNuroOUT1001U01CheckY(getHospitalCode(vertx, sessionId), CommonUtils.parseDouble(request.getPkout1001()));
		NuroServiceProto.NuroOUT1001U01CheckYResponse.Builder response = NuroServiceProto.NuroOUT1001U01CheckYResponse.newBuilder();
		if(!StringUtils.isEmpty(nuroOUT1001U01CheckY)){
			response.setYValue(nuroOUT1001U01CheckY);
		}
		return response.build();
	}
}
