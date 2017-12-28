package nta.med.service.ihis.handler.nuro;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class OUT1001P01FindboxValidatingHandler extends ScreenHandler<NuroServiceProto.OUT1001P01FindboxValidatingRequest, NuroServiceProto.OUT1001P01FindboxValidatingResponse> {
	private static final Log LOG = LogFactory.getLog(OUT1001P01FindboxValidatingHandler.class);
	@Resource
	private Bas0260Repository bas0260Repository;
	@Resource
	private Bas0270Repository  bas0270Repository;
	
	@Override
	public boolean isValid(NuroServiceProto.OUT1001P01FindboxValidatingRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getStartDate()) && DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.OUT1001P01FindboxValidatingResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.OUT1001P01FindboxValidatingRequest request) throws Exception {
		NuroServiceProto.OUT1001P01FindboxValidatingResponse.Builder response = NuroServiceProto.OUT1001P01FindboxValidatingResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		if(request.getControlName().equalsIgnoreCase("fbxToGwa")){
			String result = bas0260Repository.getOUTSANGU00GwaName(hospCode, DateUtil.toDate(request.getStartDate(), 
					DateUtil.PATTERN_YYMMDD),request.getFind1(), getLanguage(vertx, sessionId));
			if(result != null && !result.isEmpty()){
				response.setGwaName(result);
			}
		}else if(request.getControlName().equalsIgnoreCase("fbxToDoctor")){
			String result = bas0270Repository.getOUTSANGU00DoctorName(hospCode, request.getGwa(),
					request.getFind1(), DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD));
			if(result != null && !result.isEmpty()){
				response.setDoctorName(result);
			}
		}
		return response.build();
	}
}
