package nta.med.service.ihis.handler.inps;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003U01CheckBoolRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003U01CheckBoolResponse;

@Service
@Scope("prototype")
public class INP1003U01CheckBoolHandler extends ScreenHandler<InpsServiceProto.INP1003U01CheckBoolRequest, InpsServiceProto.INP1003U01CheckBoolResponse>{
	@Resource
	private Bas0260Repository bas0260Repository;

	@Override
	@Transactional(readOnly=true)
	public INP1003U01CheckBoolResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1003U01CheckBoolRequest request) throws Exception {
		InpsServiceProto.INP1003U01CheckBoolResponse.Builder response = InpsServiceProto.INP1003U01CheckBoolResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		//String language = getLanguage(vertx, sessionId);
		
		String result = bas0260Repository.getINP1003U01CheckBool(hospCode, request.getGwa(), request.getBuseoYmd());
		
		if(result != null && result.length() != 0)
			response.setResult(result);
		
		return response.build();
	}
	
}
