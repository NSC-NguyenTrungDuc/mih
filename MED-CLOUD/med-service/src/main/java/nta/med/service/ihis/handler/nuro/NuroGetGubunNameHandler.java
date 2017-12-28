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
public class NuroGetGubunNameHandler extends ScreenHandler<NuroServiceProto.NuroGetGubunNameRequest, NuroServiceProto.NuroGetGubunNameResponse> {
	private static final Log LOG = LogFactory.getLog(NuroGetGubunNameHandler.class);
	
	@Resource
	private CommonRepository commonRepository;

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroGetGubunNameResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroGetGubunNameRequest request) throws Exception {
		NuroServiceProto.NuroGetGubunNameResponse.Builder response = NuroServiceProto.NuroGetGubunNameResponse.newBuilder();
		String retVal = commonRepository.getGubunName(getHospitalCode(vertx, sessionId), request.getNaewonDate(), request.getGubun());
    	if(!StringUtils.isEmpty(retVal)){
    		response.setRetValue(retVal);
    	}
		return response.build();
	}

}
