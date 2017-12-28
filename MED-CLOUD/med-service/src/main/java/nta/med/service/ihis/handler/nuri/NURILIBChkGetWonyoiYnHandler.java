package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NURILIBChkBunhoRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NURILIBChkGetWonyoiYnRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NURILIBOutputResponse;

@Service
@Scope("prototype")
public class NURILIBChkGetWonyoiYnHandler extends ScreenHandler<NuriServiceProto.NURILIBChkGetWonyoiYnRequest, NuriServiceProto.NURILIBOutputResponse>{
	@Resource
	Out1001Repository out1001Reosity;
	
	@Override
	@Transactional(readOnly=true)
	public NURILIBOutputResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NURILIBChkGetWonyoiYnRequest request) throws Exception {
		NuriServiceProto.NURILIBOutputResponse.Builder response = NuriServiceProto.NURILIBOutputResponse.newBuilder();
		String result = out1001Reosity.getNURILIBwonyoiYn(getHospitalCode(vertx, sessionId), request.getBunho(), request.getNaewonDate(), request.getJubsuTime());
		if (!StringUtils.isEmpty(result))
			response.setOutput(result);
		return response.build();
	}

}
