package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur0401;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.nur.Nur0401Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0401U01GetCodeNameRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class NUR0401U01GetCodeNameHandler
		extends ScreenHandler<NuriServiceProto.NUR0401U01GetCodeNameRequest, SystemServiceProto.StringResponse> {

	@Resource
	private Nur0401Repository nur0401Repository;
	
	@Override
	@Transactional(readOnly = true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0401U01GetCodeNameRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		
		List<Nur0401> items = nur0401Repository.findByHospCodeNurPlanJin(getHospitalCode(vertx, sessionId),
				request.getCode());
		
		response.setResult(CollectionUtils.isEmpty(items) ? "" : items.get(0).getNurPlanJinName());
		return response.build();
	}

}
