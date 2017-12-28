package nta.med.service.ihis.handler.nuro;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0210Repository;
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
public class NuroOUT0101U02GetTypeNameHandler extends ScreenHandler<NuroServiceProto.NuroOUT0101U02GetTypeNameRequest, NuroServiceProto.NuroOUT0101U02GetTypeNameResponse>{
	private static final Log LOGGER = LogFactory.getLog(NuroOUT0101U02GetTypeNameHandler.class);
	@Resource
	private Bas0210Repository bas0210Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroOUT0101U02GetTypeNameResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOUT0101U02GetTypeNameRequest request) throws Exception {
		NuroServiceProto.NuroOUT0101U02GetTypeNameResponse.Builder response = NuroServiceProto.NuroOUT0101U02GetTypeNameResponse.newBuilder();
		String  nuroOUT1001U01CheckDoctor = bas0210Repository.getNuroOUT0101U02GetTypeName(request.getTypeCode(), getLanguage(vertx, sessionId));
		if(!StringUtils.isEmpty(nuroOUT1001U01CheckDoctor)){
			response.setTypeName(nuroOUT1001U01CheckDoctor);
		}
		return response.build();
	}

}
