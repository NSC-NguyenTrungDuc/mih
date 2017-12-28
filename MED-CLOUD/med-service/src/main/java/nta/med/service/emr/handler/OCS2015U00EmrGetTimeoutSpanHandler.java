package nta.med.service.emr.handler;

import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.emr.proto.EmrServiceProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS2015U00EmrGetTimeoutSpanHandler extends ScreenHandler<EmrServiceProto.OCS2015U00EmrGetTimeoutSpanRequest, EmrServiceProto.OCS2015U00EmrGetTimeoutSpanResponse> {
	private static final Log LOGGER = LogFactory.getLog(OCS2015U00EmrGetTimeoutSpanHandler.class);                                    
	@Resource                                                                                                       
	private Bas0102Repository bas0102Repository;


	@Override
	@Transactional(readOnly = true)
	public EmrServiceProto.OCS2015U00EmrGetTimeoutSpanResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, EmrServiceProto.OCS2015U00EmrGetTimeoutSpanRequest request) throws Exception {
		EmrServiceProto.OCS2015U00EmrGetTimeoutSpanResponse.Builder response = EmrServiceProto.OCS2015U00EmrGetTimeoutSpanResponse.newBuilder();
		String result = bas0102Repository.getCodeNameByCodeTypeAndCode(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), "OCS_EMR", "LM_EDIT");
		if (!StringUtils.isEmpty(result)) {
			response.setTimespan(result);
		}
		return response.build();
	}
}