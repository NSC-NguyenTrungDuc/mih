package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur4005Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

@Service
@Scope("prototype")
public class NUR9001U00fnPlanEndHandler
		extends ScreenHandler<NuriServiceProto.NUR9001U00fnPlanEndRequest, SystemServiceProto.StringResponse> {

	@Resource
	private Nur4005Repository nur4005Repository;

	@Override
	@Transactional(readOnly = true)
	public SystemServiceProto.StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR9001U00fnPlanEndRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		
		String rs = nur4005Repository.callFnNurPlanEndDate(getHospitalCode(vertx, sessionId),
				CommonUtils.parseDouble(request.getFknur4001()),
				DateUtil.toDate(request.getDate(), DateUtil.PATTERN_YYMMDD));
		
		response.setResult(rs);
		return response.build();
	}
}
