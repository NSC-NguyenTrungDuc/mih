package nta.med.service.ihis.handler.nuro;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.res.Res0104Repository;
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
public class NuroRES0102U00CheckDoctor3Handler extends ScreenHandler<NuroServiceProto.NuroRES0102U00CheckDoctorReq3Request, NuroServiceProto.NuroRES0102U00CheckDoctorResponse>{
	private static final Log logger = LogFactory.getLog(NuroRES0102U00CheckDoctor3Handler.class);

	@Resource
	private Res0104Repository res0104Repository;

	@Override
	public boolean isValid(NuroServiceProto.NuroRES0102U00CheckDoctorReq3Request request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getStartDate()) && DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroRES0102U00CheckDoctorResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroRES0102U00CheckDoctorReq3Request request) throws Exception {
		NuroServiceProto.NuroRES0102U00CheckDoctorResponse.Builder response = NuroServiceProto.NuroRES0102U00CheckDoctorResponse.newBuilder();
		String strNuroRES0102U00CheckDoctor3 = res0104Repository.getNuroRES0102U00CheckDoctor3(getHospitalCode(vertx, sessionId), request.getDoctor(), request.getStartDate());
		 if(!StringUtils.isEmpty(strNuroRES0102U00CheckDoctor3)) {
				response.setCheck(strNuroRES0102U00CheckDoctor3);
		}
		return response.build();
	}
}