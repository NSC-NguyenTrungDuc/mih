package nta.med.service.ihis.handler.nuro;

import javax.annotation.Resource;

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

@Transactional
@Service
@Scope("prototype")
public class NuroProcOcsoDoctorChange2Handler extends ScreenHandler<NuroServiceProto.NuroProcOcsoDoctorChange2Request, NuroServiceProto.NuroProcOcsoDoctorChange2Response> {
	private static final Log LOGGER = LogFactory.getLog(NuroProcOcsoDoctorChange2Handler.class);
	@Resource
	private Out1001Repository out1001Repository;

	@Override
	public NuroServiceProto.NuroProcOcsoDoctorChange2Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroProcOcsoDoctorChange2Request request) throws Exception {
		NuroServiceProto.NuroProcOcsoDoctorChange2Response.Builder response = NuroServiceProto.NuroProcOcsoDoctorChange2Response.newBuilder();
		String result = out1001Repository.callNuroProcOcsoDoctorChange2(getHospitalCode(vertx, sessionId), request.getPkout1001(), request.getToDoctor(), request.getToClinicCode());
		if(!StringUtils.isEmpty(result)){
			response.setFlag(result);
		}
		return response.build();
	}
}
