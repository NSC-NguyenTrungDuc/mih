package nta.med.service.ihis.handler.nuro;

import javax.annotation.Resource;

import nta.med.core.common.annotation.Route;
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
public class NuroOUT1001U01GetGubunNameHandler extends ScreenHandler<NuroServiceProto.NuroOUT1001U01GetGubunNameRequest, NuroServiceProto.NuroOUT1001U01GetGubunNameResponse>{
	private static final Log logger = LogFactory.getLog(NuroOUT1001U01GetGubunNameHandler.class);
	
	@Resource
	private Out1001Repository out1001Repository;

	@Override
	@Transactional(readOnly = true)
	@Route(global = false)
	public NuroServiceProto.NuroOUT1001U01GetGubunNameResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOUT1001U01GetGubunNameRequest request) throws Exception {
		NuroServiceProto.NuroOUT1001U01GetGubunNameResponse.Builder response = NuroServiceProto.NuroOUT1001U01GetGubunNameResponse.newBuilder();
		String result = out1001Repository.getNuroOUT1001U01GetGubunName(request.getGubun(), request.getNaewonDate(), request.getBunho(), getHospitalCode(vertx, sessionId));
		if(!StringUtils.isEmpty(result)){
			response.setValueGubunName(result);
		}
		return response.build();
	}
}
