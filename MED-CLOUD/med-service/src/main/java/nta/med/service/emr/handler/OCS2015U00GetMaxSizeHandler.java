package nta.med.service.emr.handler;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.emr.proto.EmrServiceProto;
@Service                                                                                                          
@Scope("prototype")  
public class OCS2015U00GetMaxSizeHandler extends ScreenHandler<EmrServiceProto.OCS2015U00GetMaxSizeRequest, EmrServiceProto.OCS2015U00GetMaxSizeResponse> {
	@Resource                                                                                                       
	private Bas0102Repository bas0102Repository;

	@Override
	@Transactional(readOnly = true)
	public EmrServiceProto.OCS2015U00GetMaxSizeResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, EmrServiceProto.OCS2015U00GetMaxSizeRequest request) throws Exception {
		EmrServiceProto.OCS2015U00GetMaxSizeResponse.Builder response = EmrServiceProto.OCS2015U00GetMaxSizeResponse.newBuilder();
		String result = bas0102Repository.getCodeNameByCodeTypeAndCode(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), "OCS_EMR", "MAX_SIZE");
		if (!StringUtils.isEmpty(result)) {
			response.setMaxSize(result);
		}
		return response.build();
	}

}
