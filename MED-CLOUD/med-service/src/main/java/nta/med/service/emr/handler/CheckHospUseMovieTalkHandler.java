package nta.med.service.emr.handler;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;


import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.service.emr.proto.EmrServiceProto;
import nta.med.service.emr.proto.EmrServiceProto.CheckHospUseMovieTalkRequest;
import nta.med.service.emr.proto.EmrServiceProto.CheckHospUseMovieTalkResponse;

@Service
@Scope("prototype")
public class CheckHospUseMovieTalkHandler extends ScreenHandler<EmrServiceProto.CheckHospUseMovieTalkRequest, EmrServiceProto.CheckHospUseMovieTalkResponse>{

	@Resource
	private Bas0102Repository bas0102Repository;
	
	@Override
	public CheckHospUseMovieTalkResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			CheckHospUseMovieTalkRequest request) throws Exception {
		EmrServiceProto.CheckHospUseMovieTalkResponse.Builder response = EmrServiceProto.CheckHospUseMovieTalkResponse.newBuilder();
		String codeName = bas0102Repository.getCodeNameByCodeTypeAndCode(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),
				"MBS_SYSTEM", "USE_MOVIE_TALK");
		if(!StringUtils.isEmpty(codeName)){
			response.setCodeName(codeName);
		}
		return response.build();
	}

}
