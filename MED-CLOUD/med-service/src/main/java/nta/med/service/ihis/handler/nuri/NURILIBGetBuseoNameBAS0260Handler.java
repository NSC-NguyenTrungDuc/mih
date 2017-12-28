package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NURILIBChkSimsaMagamINP1001Request;
import nta.med.service.ihis.proto.NuriServiceProto.NURILIBGetBuseoNameBAS0260Request;
import nta.med.service.ihis.proto.NuriServiceProto.NURILIBOutputResponse;

@Service
@Scope("prototype")
public class NURILIBGetBuseoNameBAS0260Handler extends ScreenHandler<NuriServiceProto.NURILIBGetBuseoNameBAS0260Request, NuriServiceProto.NURILIBOutputResponse>{
	@Resource
	Bas0260Repository bas0260Reposity;
	
	@Override
	@Transactional(readOnly=true)
	public NURILIBOutputResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NURILIBGetBuseoNameBAS0260Request request) throws Exception {
		NuriServiceProto.NURILIBOutputResponse.Builder response = NuriServiceProto.NURILIBOutputResponse.newBuilder();
		String result = bas0260Reposity.getNURILIBbuseoInfo(getHospitalCode(vertx, sessionId), request.getBuseoGubun(), request.getGwa(), request.getNaewonDate());
		if (!StringUtils.isEmpty(result))
			response.setOutput(result);
		return response.build();
	}

}
