package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
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
public class NuroRES1001U00DoctorNameHandler extends ScreenHandler<NuroServiceProto.NuroRES1001U00DoctorNameRequest, NuroServiceProto.NuroRES1001U00DoctorNameResponse>{
	private static final Log LOGGER = LogFactory.getLog(NuroRES1001U00DoctorNameHandler.class);
	@Resource
	private Out1001Repository out1001Repository;

    @Override
	public boolean isValid(NuroServiceProto.NuroRES1001U00DoctorNameRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getExamPreDate()) && DateUtil.toDate(request.getExamPreDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroRES1001U00DoctorNameResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroRES1001U00DoctorNameRequest request) throws Exception {
		NuroServiceProto.NuroRES1001U00DoctorNameResponse.Builder response = NuroServiceProto.NuroRES1001U00DoctorNameResponse.newBuilder();
		List<String> listObject = out1001Repository.getDoctorName(getHospitalCode(vertx, sessionId), getHospitalCode(vertx, sessionId), request.getPatientCode(), 
        		request.getDepartmentCode(), request.getExamPreDate(), request.getExamPreTime(), false);
        if (listObject != null && !listObject.isEmpty()) {
            for (String obj : listObject) {
                response.setDoctorName(StringUtils.isEmpty(obj) ? "" : obj);
            }
        }
		return response.build();
	}
}
