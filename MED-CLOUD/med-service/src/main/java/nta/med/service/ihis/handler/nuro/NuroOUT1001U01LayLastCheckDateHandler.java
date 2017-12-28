package nta.med.service.ihis.handler.nuro;


import javax.annotation.Resource;

import nta.med.core.common.annotation.Route;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;


@Service
@Scope("prototype")
public class NuroOUT1001U01LayLastCheckDateHandler extends ScreenHandler<NuroServiceProto.NuroOUT1001U01LayLastCheckDateRequest, NuroServiceProto.NuroOUT1001U01LayLastCheckDateResponse> {
	private static final Log LOGGER = LogFactory.getLog(NuroOUT1001U01LayLastCheckDateHandler.class);
	@Resource
	private Out1001Repository out1001Repository;
	
	@Override
	public boolean isValid(NuroServiceProto.NuroOUT1001U01LayLastCheckDateRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getDate()) && DateUtil.toDate(request.getDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	@Transactional(readOnly = true)
	@Route(global = false)
	public NuroServiceProto.NuroOUT1001U01LayLastCheckDateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOUT1001U01LayLastCheckDateRequest request) throws Exception {
		String nuroOUT0101U02GetBirthDay = out1001Repository.getNuroOUT1001U01LayLastCheckDate(getHospitalCode(vertx, sessionId), request.getGubun(), request.getBunho(), request.getDate());
        NuroServiceProto.NuroOUT1001U01LayLastCheckDateResponse.Builder response = NuroServiceProto.NuroOUT1001U01LayLastCheckDateResponse.newBuilder();
        if(!StringUtils.isEmpty(nuroOUT0101U02GetBirthDay)){
        	response.setLastCheckDate(nuroOUT0101U02GetBirthDay);
        }
		return response.build();
	}

}
