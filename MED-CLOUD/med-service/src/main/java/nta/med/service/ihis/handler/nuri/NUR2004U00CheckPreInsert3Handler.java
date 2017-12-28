package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.bas.Bas0250;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0250Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U00CheckPreInsert3Request;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class NUR2004U00CheckPreInsert3Handler
		extends ScreenHandler<NuriServiceProto.NUR2004U00CheckPreInsert3Request, SystemServiceProto.StringResponse> {

	@Resource
	private Bas0250Repository bas0250Repository;

	@Override
	@Transactional
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2004U00CheckPreInsert3Request request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		List<Bas0250> listBas0250 = bas0250Repository.findByHoCodeHoDongFDate(getHospitalCode(vertx, sessionId),
				request.getToHoCode1(), request.getToHoDong1(), request.getOrderDate());

		response.setResult(CollectionUtils.isEmpty(listBas0250) ? "" : "Y");
		return response.build();
	}

}