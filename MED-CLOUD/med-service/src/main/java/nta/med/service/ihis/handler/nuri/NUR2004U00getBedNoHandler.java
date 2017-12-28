package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U00getBedNoRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class NUR2004U00getBedNoHandler
		extends ScreenHandler<NuriServiceProto.NUR2004U00getBedNoRequest, SystemServiceProto.StringResponse> {

	@Resource
	private Inp1001Repository inp1001Repository;

	@Override
	@Transactional(readOnly = true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2004U00getBedNoRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();

		String bedNo2 = inp1001Repository.getVwOcsInp1001BedNo2ByHospCodePkinp1001(getHospitalCode(vertx, sessionId),
				CommonUtils.parseDouble(request.getFkinp1001()));

		response.setResult(bedNo2 == null ? "" : bedNo2);
		return response.build();
	}

}
