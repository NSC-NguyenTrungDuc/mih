package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur0812;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.nur.Nur0812Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0812U00GrdDetailColChangeRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class NUR0812U00GrdDetailColChangeHandler
		extends ScreenHandler<NuriServiceProto.NUR0812U00GrdDetailColChangeRequest, SystemServiceProto.StringResponse> {

	@Resource
	private Nur0812Repository nur0812Repository;
	
	@Override
	@Transactional(readOnly = true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0812U00GrdDetailColChangeRequest request) throws Exception {
		
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		
		List<Nur0812> listNur0812 = nur0812Repository.findByNeedHTypeNeedGubunNeedAsmtCode(hospCode,
				request.getNeedHType(), request.getNeedGubun(), request.getNeedAsmtCode());
		
		response.setResult(CollectionUtils.isEmpty(listNur0812) ? "" : "Y");
		return response.build();
	}

	
}
