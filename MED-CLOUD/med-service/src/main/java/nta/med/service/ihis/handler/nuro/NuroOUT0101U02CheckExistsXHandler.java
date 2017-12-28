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
public class NuroOUT0101U02CheckExistsXHandler extends ScreenHandler<NuroServiceProto.NuroOUT0101U02CheckExistsXRequest, NuroServiceProto.NuroOUT0101U02CheckExistsXResponse>{
	private static final Log LOGGER = LogFactory.getLog(NuroOUT0101U02CheckExistsXHandler.class);
	@Resource
	private Out0101Repository out0101Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroOUT0101U02CheckExistsXResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOUT0101U02CheckExistsXRequest request) throws Exception {
		NuroServiceProto.NuroOUT0101U02CheckExistsXResponse.Builder response = NuroServiceProto.NuroOUT0101U02CheckExistsXResponse.newBuilder();
		String  nuroOUT0101U02CheckExistsX = out0101Repository.getNuroOUT0101U02CheckExistsX(getHospitalCode(vertx, sessionId), request.getPatientCode());
		if(nuroOUT0101U02CheckExistsX != null && !nuroOUT0101U02CheckExistsX.isEmpty()){
			response.setResultValue(nuroOUT0101U02CheckExistsX);
		}
		return response.build();
	}
}