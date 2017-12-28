package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

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
public class NuroNUR2001U04ExistingKeyStatusHandler extends ScreenHandler<NuroServiceProto.NuroNUR2001U04ExistingKeyStatusRequest, NuroServiceProto.NuroNUR2001U04ExistingKeyStatusResponse> {
	private static final Log LOGGER = LogFactory.getLog(NuroNUR2001U04ExistingKeyStatusHandler.class);
	@Resource
	private Out1001Repository out1001Repository;

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroNUR2001U04ExistingKeyStatusResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroNUR2001U04ExistingKeyStatusRequest request) throws Exception {
		NuroServiceProto.NuroNUR2001U04ExistingKeyStatusResponse.Builder response = NuroServiceProto.NuroNUR2001U04ExistingKeyStatusResponse.newBuilder();
		List<String> listObject = out1001Repository.getNuroNUR2001U04ExistingKeyStatus(getHospitalCode(vertx, sessionId), request.getPkout1001());
        if (listObject != null && !listObject.isEmpty()) {
            for (String obj : listObject) {
            	response.setResult(StringUtils.isEmpty(obj) ? "" : obj);
            }
        }
		return response.build();
	}
}
