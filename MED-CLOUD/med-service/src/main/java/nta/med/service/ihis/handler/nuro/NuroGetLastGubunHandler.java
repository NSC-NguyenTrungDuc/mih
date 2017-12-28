package nta.med.service.ihis.handler.nuro;

import javax.annotation.Resource;

import nta.med.core.common.annotation.Route;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class NuroGetLastGubunHandler extends ScreenHandler<NuroServiceProto.NuroGetLastGubunRequest, NuroServiceProto.NuroGetLastGubunResponse>{
	private static final Log LOG = LogFactory.getLog(NuroGetLastGubunHandler.class);
	
	@Resource
	private Out1001Repository out1001Repository;

	@Override
	@Transactional(readOnly = true)
	@Route(global = false)
	public NuroServiceProto.NuroGetLastGubunResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroGetLastGubunRequest request) throws Exception {
		NuroServiceProto.NuroGetLastGubunResponse.Builder response = NuroServiceProto.NuroGetLastGubunResponse.newBuilder();
		String retVal = out1001Repository.getLastGubun(getHospitalCode(vertx, sessionId), request.getBunho(), request.getGwa(), request.getNaewonDate());
    	if(!StringUtils.isEmpty(retVal)){
    		response.setRetValue(retVal);
    	}
		return response.build();
	}
}