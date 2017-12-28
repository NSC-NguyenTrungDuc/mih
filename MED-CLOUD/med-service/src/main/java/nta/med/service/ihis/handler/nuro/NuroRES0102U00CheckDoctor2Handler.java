package nta.med.service.ihis.handler.nuro;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.res.Res0103Repository;
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
public class NuroRES0102U00CheckDoctor2Handler extends ScreenHandler<NuroServiceProto.NuroRES0102U00CheckDoctorReq2Request, NuroServiceProto.NuroRES0102U00CheckDoctorResponse> {
	private static final Log logger = LogFactory.getLog(NuroRES0102U00CheckDoctor2Handler.class);

	@Resource
	private Res0103Repository res0103Repository;

	@Override
	public boolean isValid(NuroServiceProto.NuroRES0102U00CheckDoctorReq2Request request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getStartDate()) && DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroRES0102U00CheckDoctorResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroRES0102U00CheckDoctorReq2Request request) throws Exception {
		NuroServiceProto.NuroRES0102U00CheckDoctorResponse.Builder response = NuroServiceProto.NuroRES0102U00CheckDoctorResponse.newBuilder();
		String strNuroRES0102U00CheckDoctor2 = res0103Repository.getNuroRES0102U00CheckDoctor2(getHospitalCode(vertx, sessionId), request.getDoctor(), request.getStartDate());
		 if(!StringUtils.isEmpty(strNuroRES0102U00CheckDoctor2)) {
				response.setCheck(strNuroRES0102U00CheckDoctor2);
		}
		return response.build();
	}

}
