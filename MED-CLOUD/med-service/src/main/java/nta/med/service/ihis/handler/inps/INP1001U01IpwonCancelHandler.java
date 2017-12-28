package nta.med.service.ihis.handler.inps;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01IpwonCancelRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

/**
 * @author TEST_HaDN
 *
 */
@Service
@Scope("prototype")
public class INP1001U01IpwonCancelHandler
		extends ScreenHandler<InpsServiceProto.INP1001U01IpwonCancelRequest, SystemServiceProto.StringResponse> {

	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Override
	@Transactional(readOnly = true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1001U01IpwonCancelRequest request) throws Exception {
		
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		String result = inp1001Repository.checkExistsInpOrder(getHospitalCode(vertx, sessionId), request.getBunho(), CommonUtils.parseDouble(request.getPkinp1001()));
		response.setResult(result);
		
		return response.build();
	}

}
