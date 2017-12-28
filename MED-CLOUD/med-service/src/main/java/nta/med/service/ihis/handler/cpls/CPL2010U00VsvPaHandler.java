package nta.med.service.ihis.handler.cpls;

import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U00VsvPaRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U00VsvPaResponse;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.List;

@Service
@Scope("prototype")
public class CPL2010U00VsvPaHandler extends ScreenHandler<CplsServiceProto.CPL2010U00VsvPaRequest, CplsServiceProto.CPL2010U00VsvPaResponse> {
	private static final Log LOGGER = LogFactory.getLog(CPL2010U00VsvPaHandler.class);  
	@Resource
	private Cpl2010Repository cpl2010Repository;
	
	@Override
	@Transactional(readOnly = true)
	public CPL2010U00VsvPaResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, CPL2010U00VsvPaRequest request)
			throws Exception {
        CplsServiceProto.CPL2010U00VsvPaResponse.Builder response = CplsServiceProto.CPL2010U00VsvPaResponse.newBuilder();
       	//get SunameVsvPa
		List<String> sunameVsvPa = cpl2010Repository.getSunameVsvPa(getHospitalCode(vertx, sessionId), request.getBunho());
		if(!CollectionUtils.isEmpty(sunameVsvPa)){
			response.setSuName(sunameVsvPa.get(0));
		}
		return response.build();
	}
}
