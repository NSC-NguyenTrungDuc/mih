package nta.med.service.ihis.handler.nuri;

import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.nur.Nur1010Repository;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR1001U00BasicQuery1Handler extends ScreenHandler<NuriServiceProto.NUR1001U00BasicQuery1Request, SystemServiceProto.StringResponse> {

	@Resource
	private Nur1010Repository nur1010Repository;
	
	@Override
	@Transactional(readOnly = true)
	public SystemServiceProto.StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR1001U00BasicQuery1Request request) throws Exception {
				
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		
		response.setResult(nur1010Repository.getNUR1001U00BasicQuery1(getHospitalCode(vertx, sessionId), request.getJukyongDate(), CommonUtils.parseDouble(request.getFkinp1001())));
		
		return response.build();
	}
}
