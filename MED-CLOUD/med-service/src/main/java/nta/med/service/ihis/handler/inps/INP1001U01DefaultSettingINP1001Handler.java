package nta.med.service.ihis.handler.inps;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01DefaultSettingINP1001Request;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class INP1001U01DefaultSettingINP1001Handler extends
		ScreenHandler<InpsServiceProto.INP1001U01DefaultSettingINP1001Request, SystemServiceProto.StringResponse> {

	@Resource
	private CommonRepository commonRepository;
	
	@Override
	@Transactional
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1001U01DefaultSettingINP1001Request request) throws Exception {

		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		String seq = commonRepository.getNextVal("INP1001_SEQ");
		response.setResult(seq == null ? "" : seq);
		
		return response.build();
	}

}
