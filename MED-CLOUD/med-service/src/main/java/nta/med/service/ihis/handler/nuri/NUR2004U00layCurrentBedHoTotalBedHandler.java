package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0250Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U00layCurrentBedHoTotalBedRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class NUR2004U00layCurrentBedHoTotalBedHandler extends
		ScreenHandler<NuriServiceProto.NUR2004U00layCurrentBedHoTotalBedRequest, SystemServiceProto.StringResponse> {

	@Resource
	private Bas0250Repository bas0250Repository;

	@Override
	@Transactional(readOnly = true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2004U00layCurrentBedHoTotalBedRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		
		String rs = bas0250Repository.getHoTotalBedByHospCodeHoCode(getHospitalCode(vertx, sessionId),request.getHoCode());
		response.setResult(rs);
		return response.build();
	}

}
