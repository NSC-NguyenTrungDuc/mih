package nta.med.service.ihis.handler.nuro;

import javax.annotation.Resource;

import nta.med.data.dao.medi.CommonRepository;
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
public class NuroGetGwaNameBAS0260Handler extends ScreenHandler<NuroServiceProto.NuroGetGwaNameBAS0260Request, NuroServiceProto.NuroGetGwaNameBAS0260Response> {
	private static final Log LOG = LogFactory.getLog(NuroGetGwaNameBAS0260Handler.class);
	
	@Resource
	private CommonRepository commonRepository;

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroGetGwaNameBAS0260Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroGetGwaNameBAS0260Request request) throws Exception {
		NuroServiceProto.NuroGetGwaNameBAS0260Response.Builder response = NuroServiceProto.NuroGetGwaNameBAS0260Response.newBuilder();
		String retVal = commonRepository.getGwaNameBAS0260(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getGwa(), request.getDate());
    	if(!StringUtils.isEmpty(retVal)){
    		response.setRetValue(retVal);
    	}
		return response.build();
	}

}
