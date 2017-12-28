package nta.med.service.emr.handler;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0272Repository;
import nta.med.service.emr.proto.EmrServiceProto;
import nta.med.service.emr.proto.EmrServiceProto.SettingDiscussRequest;
import nta.med.service.emr.proto.EmrServiceProto.SettingDiscussResponse;

@Service
@Scope("prototype")
public class SettingDiscussHandler extends ScreenHandler<EmrServiceProto.SettingDiscussRequest, EmrServiceProto.SettingDiscussResponse>{

	@Resource
	private Bas0272Repository bas0272Repository;
	
	@Override
	@Transactional(readOnly = true)
	public SettingDiscussResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			SettingDiscussRequest request) throws Exception {
		EmrServiceProto.SettingDiscussResponse.Builder response = EmrServiceProto.SettingDiscussResponse.newBuilder();
		String outDiscussYn = bas0272Repository.getOutDiscussYn(getHospitalCode(vertx, sessionId), getUserId(vertx, sessionId), request.getGwa());
		if(!StringUtils.isEmpty(outDiscussYn)){
			response.setResult(outDiscussYn);
		}
		return response.build();
	}

}
