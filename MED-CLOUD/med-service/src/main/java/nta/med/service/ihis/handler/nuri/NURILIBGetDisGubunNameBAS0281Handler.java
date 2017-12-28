package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0281Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NURILIBGetDisGubunNameBAS0281Request;
import nta.med.service.ihis.proto.NuriServiceProto.NURILIBOutputResponse;

@Service
@Scope("prototype")
public class NURILIBGetDisGubunNameBAS0281Handler extends ScreenHandler<NuriServiceProto.NURILIBGetDisGubunNameBAS0281Request, NuriServiceProto.NURILIBOutputResponse>{
	@Resource
	private Bas0281Repository bas0281Repository;
	
	@Override
	@Transactional(readOnly=true)
	public NURILIBOutputResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NURILIBGetDisGubunNameBAS0281Request request) throws Exception {
		NuriServiceProto.NURILIBOutputResponse.Builder response = NuriServiceProto.NURILIBOutputResponse.newBuilder();
		String result = bas0281Repository.getDisGubunName(request.getDate(), request.getGubun());
		
		if (!StringUtils.isEmpty(result))
			response.setOutput(result);
		
		return response.build();
	}

}
