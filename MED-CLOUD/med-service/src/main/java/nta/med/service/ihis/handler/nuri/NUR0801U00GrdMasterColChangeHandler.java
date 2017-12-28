package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur0801;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.nur.Nur0801Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0801U00GrdMasterColChangeRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class NUR0801U00GrdMasterColChangeHandler
		extends ScreenHandler<NuriServiceProto.NUR0801U00GrdMasterColChangeRequest, SystemServiceProto.StringResponse> {

	@Resource
	private Nur0801Repository nur0801Repository;
	
	@Override
	@Transactional(readOnly = true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0801U00GrdMasterColChangeRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		
		List<Nur0801> items = nur0801Repository.findByHospCodeHoDong(getHospitalCode(vertx, sessionId), request.getHoDong());
		response.setResult(CollectionUtils.isEmpty(items) ? "" : "Y");
		
		return response.build();
	}

}