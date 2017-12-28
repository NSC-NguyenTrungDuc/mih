package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.res.Res0102Repository;
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
public class NuroRES1001U00DoctorExamStatusHandler extends ScreenHandler<NuroServiceProto.NuroRES1001U00DoctorExamStatusRequest, NuroServiceProto.NuroRES1001U00DoctorExamStatusResponse>{
	private static final Log LOGGER = LogFactory.getLog(NuroRES1001U00DoctorExamStatusHandler.class);
	@Resource
	private Res0102Repository res0102Repository;

    @Override
	public boolean isValid(NuroServiceProto.NuroRES1001U00DoctorExamStatusRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getExamPreDate()) && DateUtil.toDate(request.getExamPreDate(), DateUtil.PATTERN_YYMMDD_BLANK) == null) {
			return false;
		}
		return true;
	}

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroRES1001U00DoctorExamStatusResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroRES1001U00DoctorExamStatusRequest request) throws Exception {
		NuroServiceProto.NuroRES1001U00DoctorExamStatusResponse.Builder response = NuroServiceProto.NuroRES1001U00DoctorExamStatusResponse.newBuilder();
		String sessionHospCode = getHospitalCode(vertx, sessionId);
		String hospCode = getHospitalCode(vertx, sessionId);
		boolean isOtherClinic = false;
		if(!StringUtils.isEmpty(request.getHospCodeLink())){
			hospCode = request.getHospCodeLink();
			isOtherClinic = true;
		}
		List<String> listObject = res0102Repository.getDoctorExamStatus(hospCode, sessionHospCode, request.getType(), DateUtil.toDate(request.getExamPreDate(),DateUtil.PATTERN_YYMMDD_BLANK), request.getExamPreTime(), request.getDoctorCode(), isOtherClinic);
         if (listObject != null && !listObject.isEmpty()) {
             for (String obj : listObject) {
                 response.setDoctorExamStatus(StringUtils.isEmpty(obj) ? "" : obj);
             }
         }
		return response.build();
	}
}
