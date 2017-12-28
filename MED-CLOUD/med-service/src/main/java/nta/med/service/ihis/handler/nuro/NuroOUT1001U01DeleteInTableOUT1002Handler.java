package nta.med.service.ihis.handler.nuro;

import javax.annotation.Resource;

import nta.med.core.common.annotation.Route;
import nta.med.data.dao.medi.out.Out1002Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class NuroOUT1001U01DeleteInTableOUT1002Handler extends ScreenHandler<NuroServiceProto.NuroOUT1001U01DeleteInTableOUT1002Request, NuroServiceProto.NuroOUT1001U01DeleteInTableOUT1002Response>{
private static final Log logger = LogFactory.getLog(NuroOUT1001U01DeleteInTableOUT1002Handler.class);
	
	@Resource
	private Out1002Repository out1002Repository;
	
	@Override
	@Route(global = false)
	public NuroServiceProto.NuroOUT1001U01DeleteInTableOUT1002Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOUT1001U01DeleteInTableOUT1002Request request) throws Exception {
		NuroServiceProto.NuroOUT1001U01DeleteInTableOUT1002Response.Builder response = NuroServiceProto.NuroOUT1001U01DeleteInTableOUT1002Response.newBuilder();
		Integer result = out1002Repository.deleteOut1002ById(getHospitalCode(vertx, sessionId), request.getPkout1001());
		response.setResultDelete(result != null && result > 0);
		return response.build();
	}
}
