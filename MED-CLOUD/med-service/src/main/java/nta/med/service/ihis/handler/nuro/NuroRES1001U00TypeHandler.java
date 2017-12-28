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
public class NuroRES1001U00TypeHandler extends ScreenHandler<NuroServiceProto.NuroRES1001U00TypeRequest, NuroServiceProto.NuroRES1001U00TypeResponse> {
	private static final Log LOGGER = LogFactory.getLog(NuroRES1001U00TypeHandler.class);
	@Resource
	private Out1001Repository out1001Repository;

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroRES1001U00TypeResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroRES1001U00TypeRequest request) throws Exception {
		NuroServiceProto.NuroRES1001U00TypeResponse.Builder response = NuroServiceProto.NuroRES1001U00TypeResponse.newBuilder();
		List<String> listObject = out1001Repository.getNuroRES1001U00TypeRequest(getHospitalCode(vertx, sessionId), getHospitalCode(vertx, sessionId), request.getPatientCode(), request.getDepartmentCode(), false);
		if (listObject != null && !listObject.isEmpty()) {
			for (String obj : listObject) {
				response.setType(StringUtils.isEmpty(obj) ? "" : obj);
			}
		}
		return response.build();
	}
}
