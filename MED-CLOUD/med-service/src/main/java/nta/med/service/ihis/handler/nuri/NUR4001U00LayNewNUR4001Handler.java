package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur0401;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.nur.Nur0401Repository;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;

@Service                                                                                                          
@Scope("prototype")
public class NUR4001U00LayNewNUR4001Handler extends ScreenHandler<NuriServiceProto.NUR4001U00LayNewNUR4001Request, NuriServiceProto.NUR4001U00LayNewNUR4001Response> {   
	
	@Resource        
	private Nur0401Repository nur0401Repository;

	@Resource
	private CommonRepository commonRepository;
	
	@Override
	@Transactional
	public NuriServiceProto.NUR4001U00LayNewNUR4001Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR4001U00LayNewNUR4001Request request) throws Exception {
		NuriServiceProto.NUR4001U00LayNewNUR4001Response.Builder response = NuriServiceProto.NUR4001U00LayNewNUR4001Response
				.newBuilder();
		
		List<Nur0401> items = nur0401Repository.findByHospCodeNurPlanBunryuNurPlanJinVald(
				getHospitalCode(vertx, sessionId), request.getNurPlanBunryu(), request.getNurPlanJin(), "Y");
		
		for (Nur0401 item : items) {
			String nextSeq = commonRepository.getNextVal("NUR4001_SEQ");
			NuriModelProto.NUR4001U00LayNewNUR4001Info.Builder info = NuriModelProto.NUR4001U00LayNewNUR4001Info.newBuilder()
					.setPknur4001(nextSeq)
					.setJinName(item.getNurPlanJinName() == null ? "" : item.getNurPlanJinName())
					.setSortKey(item.getSortKey() == null ? "" : String.format("%.0f",item.getSortKey()));
			response.addLayList(info);
		}
		
		return response.build();
	}
}
