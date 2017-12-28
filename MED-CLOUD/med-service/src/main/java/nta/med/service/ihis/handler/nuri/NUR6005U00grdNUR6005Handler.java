package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur6005;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur6005Repository;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR6005U00grdNUR6005Request;
import nta.med.service.ihis.proto.NuriServiceProto.NUR6005U00grdNUR6005Response;

@Service
@Scope("prototype")
public class NUR6005U00grdNUR6005Handler extends
		ScreenHandler<NuriServiceProto.NUR6005U00grdNUR6005Request, NuriServiceProto.NUR6005U00grdNUR6005Response> {

	@Resource
	private Nur6005Repository nur6005Repository;

	@Override
	@Transactional(readOnly = true)
	public NUR6005U00grdNUR6005Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR6005U00grdNUR6005Request request) throws Exception {
		NuriServiceProto.NUR6005U00grdNUR6005Response.Builder response = NuriServiceProto.NUR6005U00grdNUR6005Response
				.newBuilder();

		List<Nur6005> items = nur6005Repository.findByHospCodeBunho(getHospitalCode(vertx, sessionId),
				request.getBunho());

		for (Nur6005 item : items) {
			NuriModelProto.NUR6005U00grdNUR6005Info.Builder info = NuriModelProto.NUR6005U00grdNUR6005Info.newBuilder()
					.setMetressGubun(item.getMetressGubun() == null ? "" : item.getMetressGubun())
					.setBunho(item.getBunho())
					.setStartDate(DateUtil.toString(item.getStartDate(), DateUtil.PATTERN_YYMMDD))
					.setEndDate(DateUtil.toString(item.getEndDate(), DateUtil.PATTERN_YYMMDD))
					.setFkinp1001(String.format("%.0f",item.getFkinp1001()));
			response.addGrdMasterItem(info);
		}
		
		return response.build();
	}

}
