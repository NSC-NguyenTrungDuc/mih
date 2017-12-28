package nta.med.service.ihis.handler.ocso;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0310Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCSACTCommandHandler extends ScreenHandler<OcsoServiceProto.OCSACTCommandRequest, OcsoServiceProto.OCSACTSingleStringResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCSACTCommandHandler.class);                                    
	@Resource                                                                                                       
	private Bas0310Repository bas0310Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OCSACTSingleStringResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OCSACTCommandRequest request) throws Exception {
		OcsoServiceProto.OCSACTSingleStringResponse.Builder response = OcsoServiceProto.OCSACTSingleStringResponse.newBuilder();
		//count  = 0 means dont have record
		String getCount = bas0310Repository.getOCSACTCommand(getHospitalCode(vertx, sessionId), request.getHangmogCode());
		if(!StringUtils.isEmpty(getCount)){
			response.setResponseStr(getCount);
		}
		return response.build();
	}                                                                                                                 
}