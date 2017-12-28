package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR9999R11sqlCmdRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class NUR9999R11sqlCmdHandler
		extends ScreenHandler<NuriServiceProto.NUR9999R11sqlCmdRequest, SystemServiceProto.StringResponse> {

	@Resource
	private CommonRepository commonRepository;

	@Override
	@Transactional
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR9999R11sqlCmdRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();

		String seq = commonRepository.getNextVal("NUR9999_SEQ");
		response.setResult(seq == null ? "0" : seq);
		return response.build();
	}

}
