package nta.med.service.ihis.handler.nuro;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0210Repository;
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
public class NuroChkGetGongbiYNHandler extends ScreenHandler<NuroServiceProto.NuroChkGetGongbiYNRequest, NuroServiceProto.NuroChkGetGongbiYNResponse> {
	private static final Log LOG = LogFactory.getLog(NuroChkGetGongbiYNHandler.class);
	
	@Resource
	private Bas0210Repository bas0210Repository;

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroChkGetGongbiYNResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroChkGetGongbiYNRequest request) throws Exception {
		NuroServiceProto.NuroChkGetGongbiYNResponse.Builder response = NuroServiceProto.NuroChkGetGongbiYNResponse.newBuilder();
		String retVal = bas0210Repository.getNuroChkGetGongbiYN(request.getGubun(), request.getDate(), getLanguage(vertx, sessionId));
    	if(!StringUtils.isEmpty(retVal)){
    		response.setRetValue(retVal);
    	}
		return response.build();
	}

}
