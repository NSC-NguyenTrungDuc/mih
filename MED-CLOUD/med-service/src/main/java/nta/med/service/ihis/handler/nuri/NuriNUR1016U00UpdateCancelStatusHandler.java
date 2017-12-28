package nta.med.service.ihis.handler.nuri;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur1016Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class NuriNUR1016U00UpdateCancelStatusHandler extends ScreenHandler<NuriServiceProto.NuriNUR1016U00UpdateCancelStatusRequest, SystemServiceProto.UpdateResponse>{
	private static final Log LOG = LogFactory.getLog(NuriNUR1016U00UpdateCancelStatusHandler.class);
	
	@Resource
	private Nur1016Repository nur1016Repository;
	
	@Override
	public boolean isValid(NuriServiceProto.NuriNUR1016U00UpdateCancelStatusRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getStartDate()) && DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuriServiceProto.NuriNUR1016U00UpdateCancelStatusRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		Double pknur1016 = CommonUtils.parseDouble(request.getPknur1016());
		Integer result = nur1016Repository.updateCancelStatusNur1016(request.getUserId(), new Date(), getHospitalCode(vertx, sessionId), pknur1016, request.getBunho(),
				request.getAllergyGubun(), request.getStartDate());
		 response.setResult(result != null && result > 0);
		 return response.build();
	}
}