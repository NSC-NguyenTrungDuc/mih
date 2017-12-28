package nta.med.service.ihis.handler.nuro;

import javax.annotation.Resource;

import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class NuroOUT0101U02CheckExistsYHandler extends ScreenHandler<NuroServiceProto.NuroOUT0101U02CheckExistsYRequest, NuroServiceProto.NuroOUT0101U02CheckExistsYResponse> {
	private static final Log LOGGER = LogFactory.getLog(NuroOUT0101U02CheckExistsYHandler.class);
	@Resource
	private Out0101Repository out0101Repository;

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroOUT0101U02CheckExistsYResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOUT0101U02CheckExistsYRequest request) throws Exception {
		NuroServiceProto.NuroOUT0101U02CheckExistsYResponse.Builder response = NuroServiceProto.NuroOUT0101U02CheckExistsYResponse.newBuilder();
		String result = out0101Repository.getNuroOUT0101U02CheckExistsY(getHospitalCode(vertx, sessionId), request.getPatientCode());
		if(result != null && !result.isEmpty()){
			response.setResultValue(true);
		}else {
			response.setResultValue(false);
		}
		return response.build();
	}

}
