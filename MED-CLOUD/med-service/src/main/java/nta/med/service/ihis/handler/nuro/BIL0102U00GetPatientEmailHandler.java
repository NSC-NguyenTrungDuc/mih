package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.NuroServiceProto.BIL0102U00GetPatientEmailRequest;
import nta.med.service.ihis.proto.NuroServiceProto.BIL0102U00GetPatientEmailResponse;

@Service
@Scope("prototype")
public class BIL0102U00GetPatientEmailHandler extends ScreenHandler<NuroServiceProto.BIL0102U00GetPatientEmailRequest, NuroServiceProto.BIL0102U00GetPatientEmailResponse>{
	private static final Log LOGGER = LogFactory.getLog(BIL0102U00GetPatientEmailHandler.class);
	
	@Resource
	private Out0101Repository out0101Repository;
	
	@Override
	@Transactional(readOnly = true)
	public BIL0102U00GetPatientEmailResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			BIL0102U00GetPatientEmailRequest request) throws Exception {
		NuroServiceProto.BIL0102U00GetPatientEmailResponse.Builder response = NuroServiceProto.BIL0102U00GetPatientEmailResponse.newBuilder();
		String hospCode = request.getHospCode();
		if(StringUtils.isEmpty(hospCode)) {
			hospCode = getHospitalCode(vertx, sessionId);
		}
		List<String> email = out0101Repository.getPatientEmail(hospCode, request.getBunho());
		if (!CollectionUtils.isEmpty(email)) {
			response.setEmail(StringUtils.isEmpty(email.get(0)) ? "" : email.get(0));
		}
		return response.build();
	}

}
