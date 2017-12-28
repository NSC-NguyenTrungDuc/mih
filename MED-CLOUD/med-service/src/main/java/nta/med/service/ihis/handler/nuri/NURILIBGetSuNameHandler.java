package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.nuro.NuroSearchPatientInfo;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NURILIBGetDisGubunNameBAS0281Request;
import nta.med.service.ihis.proto.NuriServiceProto.NURILIBGetSuNameRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NURILIBOutputResponse;

@Service
@Scope("prototype")
public class NURILIBGetSuNameHandler extends ScreenHandler<NuriServiceProto.NURILIBGetSuNameRequest, NuriServiceProto.NURILIBOutputResponse>{
	@Resource
	Out0101Repository out0101Repository;
	
	@Override
	@Transactional(readOnly=true)
	public NURILIBOutputResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NURILIBGetSuNameRequest request) throws Exception {
		NuriServiceProto.NURILIBOutputResponse.Builder response = NuriServiceProto.NURILIBOutputResponse.newBuilder();
		List<NuroSearchPatientInfo> list =  out0101Repository.getNuroSearchPatientInfo(getHospitalCode(vertx, sessionId), request.getBunho());
		if (!CollectionUtils.isEmpty(list)) 
			response.setOutput(list.get(0).getPatientName1());
		return response.build();
	}

}
