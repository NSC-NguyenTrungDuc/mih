package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.nur.Nur1020Repository;
import nta.med.data.dao.medi.nur.Nur1122Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020U00QueryRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class NUR1020U00QueryHandler
		extends ScreenHandler<NuriServiceProto.NUR1020U00QueryRequest, SystemServiceProto.StringResponse> {

	@Resource
	private Nur1020Repository nur1020Repository;
	
	@Resource
	private Nur1122Repository nur1122Repository;
	
	@Override
	@Transactional(readOnly = true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR1020U00QueryRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String queryType = request.getQueryType();
		
		if("1".equals(queryType)){
			String rs = nur1020Repository.getNUR1020U00MaxYmd(hospCode, request.getBunho(), request.getYmd());
			response.setResult(rs);
		}
		else {
			String rs = nur1122Repository.getNUR1020U00MaxYmd(hospCode, request.getBunho(), request.getYmd());
			response.setResult(rs);
		}
		
		return response.build();
	}

}
