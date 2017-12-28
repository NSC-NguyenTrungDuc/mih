package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.ocs.Ocs0103;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0110U00GrdNUR0115Case1Request;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0110U00GrdNUR0115Case1Response;

@Service
@Scope("prototype")
public class NUR0110U00GrdNUR0115Case1Handler extends
		ScreenHandler<NuriServiceProto.NUR0110U00GrdNUR0115Case1Request, NuriServiceProto.NUR0110U00GrdNUR0115Case1Response> {

	@Resource
	private Ocs0103Repository ocs0103Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR0110U00GrdNUR0115Case1Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0110U00GrdNUR0115Case1Request request) throws Exception {
		NuriServiceProto.NUR0110U00GrdNUR0115Case1Response.Builder response = NuriServiceProto.NUR0110U00GrdNUR0115Case1Response.newBuilder();
		
		List<Ocs0103> items = ocs0103Repository.findByHospCodeHangmogCodeSysDate(getHospitalCode(vertx, sessionId),
				request.getHangmogCode());
		
		for (Ocs0103 item : items) {
			NuriModelProto.NUR0110U00GrdNUR0115Case1Info.Builder info = NuriModelProto.NUR0110U00GrdNUR0115Case1Info.newBuilder()
					.setHangmogName(item.getHangmogName() == null ? "" : item.getHangmogName())
					.setSlipCode(item.getSlipCode() == null ? "" : item.getSlipCode());
			
			response.addInfoLst(info);
		}
		
		return response.build();
	}

}
