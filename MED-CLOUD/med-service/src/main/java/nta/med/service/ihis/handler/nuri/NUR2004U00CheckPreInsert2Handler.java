package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.bas.Bas0260;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U00CheckPreInsert2Request;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class NUR2004U00CheckPreInsert2Handler
		extends ScreenHandler<NuriServiceProto.NUR2004U00CheckPreInsert2Request, SystemServiceProto.StringResponse> {

	@Resource
	private Bas0260Repository bas0260Repository;

	@Override
	@Transactional(readOnly = true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2004U00CheckPreInsert2Request request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();

		List<Bas0260> listBas0260 = bas0260Repository.findByHospCodeGwaBuseoGubunFDate(
				getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getToGwa(), "1", request.getOrderDate());
		
		response.setResult(CollectionUtils.isEmpty(listBas0260) ? "" : "Y");
		return response.build();
	}

}
