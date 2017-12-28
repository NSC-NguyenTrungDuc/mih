package nta.med.service.ihis.handler.inps;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.inp.Inp1001;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01LayCheckEctIpwonRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class INP1001U01LayCheckEctIpwonHandler
		extends ScreenHandler<InpsServiceProto.INP1001U01LayCheckEctIpwonRequest, SystemServiceProto.StringResponse> {

	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Override
	@Transactional(readOnly = true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1001U01LayCheckEctIpwonRequest request) throws Exception {

		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		List<Inp1001> lstInp1001 = inp1001Repository.findByHospCodeBunhoIpwonDate(getHospitalCode(vertx, sessionId), request.getBunho(), request.getIpwonDate());
		if(CollectionUtils.isEmpty(lstInp1001)){
			response.setResult("");
			return response.build();
		}
		
		String result = lstInp1001.get(0).getIpwonType() == null ? "" : lstInp1001.get(0).getIpwonType(); 
		response.setResult(result);
		return response.build();
	}

}
