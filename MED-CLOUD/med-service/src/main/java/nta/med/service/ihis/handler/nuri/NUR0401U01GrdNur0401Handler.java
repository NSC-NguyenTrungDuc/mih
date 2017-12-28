package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur0401;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.nur.Nur0401Repository;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0401U01GrdNur0401Request;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0401U01GrdNur0401Response;

@Service
@Scope("prototype")
public class NUR0401U01GrdNur0401Handler extends
		ScreenHandler<NuriServiceProto.NUR0401U01GrdNur0401Request, NuriServiceProto.NUR0401U01GrdNur0401Response> {

	@Resource
	private Nur0401Repository nur0401Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR0401U01GrdNur0401Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0401U01GrdNur0401Request request) throws Exception {
		NuriServiceProto.NUR0401U01GrdNur0401Response.Builder response = NuriServiceProto.NUR0401U01GrdNur0401Response.newBuilder();
		
		List<Nur0401> items = nur0401Repository.findByHospCodeNurPlanBunryu(getHospitalCode(vertx, sessionId), request.getNurPlanBunryu());
		for (Nur0401 item : items) {
			NuriModelProto.NUR0401U01GrdNur0401Info.Builder info = NuriModelProto.NUR0401U01GrdNur0401Info.newBuilder();
			info.setNurPlanJin(item.getNurPlanJin());
			info.setNurPlanJinName(item.getNurPlanJinName() == null ? "" : item.getNurPlanJinName());
			info.setNurPlanBunryu(item.getNurPlanBunryu());
			info.setVald(item.getVald());
			info.setSortKey(String.format("%.0f",item.getSortKey()));
			
			response.addGrdList(info);
		}
		
		return response.build();
	}

}
