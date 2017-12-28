package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.nur.Nur0115Repository;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U00SeqNextvalRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class OCS2005U00SeqNextvalHandler extends ScreenHandler<OcsiServiceProto.OCS2005U00SeqNextvalRequest, SystemServiceProto.StringResponse>{
	@Resource
	private Nur0115Repository nur0115Repository;
	@Resource
	private CommonRepository commonRepository;
	
	@Override
	@Transactional
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2005U00SeqNextvalRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		response.setResult("");
		String controlName = request.getNameControl();
		String seqNextVal;
		if ("ocs2005".equals(controlName))
			seqNextVal = commonRepository.getNextVal("OCS2005_SEQ");
		else if ("ocs6005".equals(controlName))
			seqNextVal = commonRepository.getNextVal("OCS6005_SEQ");
		else
			seqNextVal = commonRepository.getNextVal("OCS6015_SEQ");
		
		if (!StringUtils.isEmpty(seqNextVal))
			response.setResult(seqNextVal);
		return response.build();
	}

}
