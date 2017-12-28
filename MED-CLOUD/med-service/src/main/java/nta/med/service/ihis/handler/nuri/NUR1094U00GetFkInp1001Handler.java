package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.inp.Inp1001;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1094U00GetFkInp1001Request;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class NUR1094U00GetFkInp1001Handler
		extends ScreenHandler<NuriServiceProto.NUR1094U00GetFkInp1001Request, SystemServiceProto.StringResponse> {

	@Resource
	private Inp1001Repository inp1001Repository;

	@Override
	@Transactional(readOnly = true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR1094U00GetFkInp1001Request request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		List<Inp1001> inps = inp1001Repository.findByHospCodeBunhoFDate(getHospitalCode(vertx, sessionId),
				request.getBunho(), DateUtil.toDate(request.getDate(), DateUtil.PATTERN_YYMMDD));

		response.setResult(CollectionUtils.isEmpty(inps) ? "" : String.format("%.0f", inps.get(0).getPkinp1001()));
		return response.build();
	}

}
