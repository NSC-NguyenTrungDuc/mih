package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0401U01SelectSeq0403Request;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class NUR0401U01SelectSeq0403Handler
		extends ScreenHandler<NuriServiceProto.NUR0401U01SelectSeq0403Request, SystemServiceProto.StringResponse> {

	@Resource
	private CommonRepository commonRepository;
	
	@Override
	@Transactional
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0401U01SelectSeq0403Request request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		
		String rs = commonRepository.getNextVal("NUR0403_SEQ");
		response.setResult(rs == null ? "" : rs);
		
		return response.build();
	}

	
}
