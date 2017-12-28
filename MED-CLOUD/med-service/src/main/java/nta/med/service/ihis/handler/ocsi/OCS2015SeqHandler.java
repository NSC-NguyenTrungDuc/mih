package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2015SeqRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class OCS2015SeqHandler extends ScreenHandler<OcsiServiceProto.OCS2015SeqRequest, SystemServiceProto.StringResponse> {
	
	@Resource
	private CommonRepository commonRepository;
	
	@Override
	@Transactional
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2015SeqRequest request) throws Exception {
		
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		response.setResult("");
		String seqNextVal;
		
		seqNextVal = commonRepository.getNextVal("OCS2015_SEQ");
		
		if (!StringUtils.isEmpty(seqNextVal)) {
			response.setResult(seqNextVal);
		}
		return response.build();
		
	}

}
