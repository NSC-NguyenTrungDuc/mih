package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur0102;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.nur.Nur0102Repository;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020U00InputLockRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020U00InputLockResponse;

@Service
@Scope("prototype")
public class NUR1020U00InputLockHandler extends
		ScreenHandler<NuriServiceProto.NUR1020U00InputLockRequest, NuriServiceProto.NUR1020U00InputLockResponse> {

	@Resource
	private Nur0102Repository nur0102Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR1020U00InputLockResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR1020U00InputLockRequest request) throws Exception {
		NuriServiceProto.NUR1020U00InputLockResponse.Builder response = NuriServiceProto.NUR1020U00InputLockResponse.newBuilder();
		
		List<Nur0102> items = nur0102Repository.findByCodeTypeCodeLanguage(getHospitalCode(vertx, sessionId)
				, "NUR1020_MODIFY_LIMIT"
				, "01"
				, getLanguage(vertx, sessionId));
		
		for (Nur0102 nur0102 : items) {
			NuriModelProto.NUR1020U00InputLockInfo.Builder info = NuriModelProto.NUR1020U00InputLockInfo.newBuilder()
					.setLimitYn(nur0102.getCodeName())
					.setLimit(nur0102.getSortKey() == null ? "" : String.format("%.0f",nur0102.getSortKey()));
			response.addInfoLst(info);
		}
		
		return response.build();
	}

}
