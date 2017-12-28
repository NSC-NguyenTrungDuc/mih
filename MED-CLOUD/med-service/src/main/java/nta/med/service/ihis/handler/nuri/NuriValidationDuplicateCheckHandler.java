package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur1016Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuriServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class NuriValidationDuplicateCheckHandler extends ScreenHandler<NuriServiceProto.NuriNUR1016U00ValidationDuplicateCheckRequest, NuriServiceProto.NuriNUR1016U00ValidationDuplicateCheckResponse> {
	private static final Log LOGGER = LogFactory.getLog(NuriValidationDuplicateCheckHandler.class);

	@Resource
	private Nur1016Repository nur1016Repository;

	@Override
	public boolean isValid(NuriServiceProto.NuriNUR1016U00ValidationDuplicateCheckRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getStartDate()) && DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	
	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NuriNUR1016U00ValidationDuplicateCheckResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuriServiceProto.NuriNUR1016U00ValidationDuplicateCheckRequest request) throws Exception {
		NuriServiceProto.NuriNUR1016U00ValidationDuplicateCheckResponse.Builder response = NuriServiceProto.NuriNUR1016U00ValidationDuplicateCheckResponse.newBuilder();
		String result = nur1016Repository.getNuriValidationDuplicateCheck(getHospitalCode(vertx, sessionId), request.getBunho(),request.getAllergyGubun(), request.getStartDate());
		if (!StringUtils.isEmpty(result)) {
			response.setResult(result);
		}
		return response.build();
	}
}
