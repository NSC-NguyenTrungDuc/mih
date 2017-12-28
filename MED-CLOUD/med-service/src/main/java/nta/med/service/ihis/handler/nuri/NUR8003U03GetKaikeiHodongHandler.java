package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR8003U03GetKaikeiHodongRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class NUR8003U03GetKaikeiHodongHandler
		extends ScreenHandler<NuriServiceProto.NUR8003U03GetKaikeiHodongRequest, SystemServiceProto.StringResponse> {

	@Resource
	private Inp1001Repository inp1001Repository;

	@Override
	@Transactional(readOnly = true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR8003U03GetKaikeiHodongRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();

		String rs = inp1001Repository.callFnInpLoadKaikeiHodongHis(getHospitalCode(vertx, sessionId),
				CommonUtils.parseDouble(request.getPkinp1001()), DateUtil.toDate(request.getDate(), DateUtil.PATTERN_YYMMDD));
		
		response.setResult(rs == null ? "" : rs);
		return response.build();
	}

}
