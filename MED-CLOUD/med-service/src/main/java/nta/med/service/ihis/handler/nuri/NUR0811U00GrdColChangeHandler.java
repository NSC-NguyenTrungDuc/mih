package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur0811;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.nur.Nur0811Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0811U00GrdColChangeRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class NUR0811U00GrdColChangeHandler
		extends ScreenHandler<NuriServiceProto.NUR0811U00GrdColChangeRequest, SystemServiceProto.StringResponse> {

	@Resource
	private Nur0811Repository nur0811Repository;
	
	@Override
	@Transactional(readOnly = true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0811U00GrdColChangeRequest request) throws Exception {
		
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		List<Nur0811> listNur0811 = nur0811Repository.findByHospCodeNeedHTypeNeedType(getHospitalCode(vertx, sessionId),
				request.getNeedHType(), request.getNeedType());
		
		response.setResult(CollectionUtils.isEmpty(listNur0811) ? "" : "Y");		
		return response.build();
	}

}
