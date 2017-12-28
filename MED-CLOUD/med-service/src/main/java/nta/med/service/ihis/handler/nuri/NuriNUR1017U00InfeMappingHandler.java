package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import nta.med.data.dao.medi.nur.Nur1017Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuriServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class NuriNUR1017U00InfeMappingHandler extends ScreenHandler<NuriServiceProto.NuriNUR1017U00InfeMappingRequest,  NuriServiceProto.NuriNUR1017U00InfeMappingResponse> {
	private static final Log LOGGER = LogFactory.getLog(NuriNUR1017U00InfeMappingHandler.class);
	@Resource
	private Nur1017Repository nur1017Repository;

	@Override
	@Transactional
	public  NuriServiceProto.NuriNUR1017U00InfeMappingResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuriServiceProto.NuriNUR1017U00InfeMappingRequest request) throws Exception {
	    NuriServiceProto.NuriNUR1017U00InfeMappingResponse.Builder response = NuriServiceProto.NuriNUR1017U00InfeMappingResponse.newBuilder();
		String result = nur1017Repository.callNuriPrNurInfeMapping(getHospitalCode(vertx, sessionId), request.getBunho(), request.getInfeCode(),
        		request.getTableId(), request.getUserId(), getLanguage(vertx, sessionId), "");
       if(!StringUtils.isEmpty(result)){
    	   response.setResult(result);
       }
		return response.build();
	}
}
