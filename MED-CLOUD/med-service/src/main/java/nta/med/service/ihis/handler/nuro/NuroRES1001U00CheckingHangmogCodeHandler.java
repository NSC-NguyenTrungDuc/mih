package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
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
public class NuroRES1001U00CheckingHangmogCodeHandler extends ScreenHandler<NuroServiceProto.NuroRES1001U00CheckingHangmogCodeRequest, NuroServiceProto.NuroRES1001U00CheckingHangmogCodeResponse> {
	private static final Log LOG = LogFactory.getLog(NuroRES1001U00CheckingHangmogCodeHandler.class);
	@Resource
	private Ocs1003Repository ocs1003Repository;

    @Override
	public boolean isValid(NuroServiceProto.NuroRES1001U00CheckingHangmogCodeRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getExamPreDate()) && DateUtil.toDate(request.getExamPreDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroRES1001U00CheckingHangmogCodeResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroRES1001U00CheckingHangmogCodeRequest request) throws Exception {
		NuroServiceProto.NuroRES1001U00CheckingHangmogCodeResponse.Builder response = NuroServiceProto.NuroRES1001U00CheckingHangmogCodeResponse.newBuilder();
		List<String> listObject = ocs1003Repository.getNuroRES1001U00CheckingHangmogCode(getHospitalCode(vertx, sessionId), request.getPatientCode(), DateUtil.toDate(request.getExamPreDate(), DateUtil.PATTERN_YYMMDD), request.getDepartmentCode(), request.getDoctorCode());
        if (listObject != null && !listObject.isEmpty()) {
            for (String obj : listObject) {
                response.setResult(StringUtils.isEmpty(obj) ? "" : obj);
            }
        }
		return response.build();
	}
}
