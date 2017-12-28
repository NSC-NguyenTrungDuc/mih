package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur0102;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.nur.Nur0102Repository;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0401U01GrdNur0102Request;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0401U01GrdNur0102Response;

@Service
@Scope("prototype")
public class NUR0401U01GrdNur0102Handler extends
		ScreenHandler<NuriServiceProto.NUR0401U01GrdNur0102Request, NuriServiceProto.NUR0401U01GrdNur0102Response> {

	@Resource
	private Nur0102Repository nur0102Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR0401U01GrdNur0102Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0401U01GrdNur0102Request request) throws Exception {
		NuriServiceProto.NUR0401U01GrdNur0102Response.Builder response = NuriServiceProto.NUR0401U01GrdNur0102Response.newBuilder();
		
		List<Nur0102> listNur0102 = nur0102Repository.findByCodeTypeLanguage(getHospitalCode(vertx, sessionId),
				"NUR_PLAN_BUNRYU", getLanguage(vertx, sessionId));
		for (Nur0102 item : listNur0102) {
			NuriModelProto.NUR0401U01GrdNur0102Info.Builder info = NuriModelProto.NUR0401U01GrdNur0102Info.newBuilder();
			info.setNurPlanBunryu(item.getCode());
			info.setNurPlanBunryuName(item.getCodeName() == null ? "" : item.getCodeName());
			if(item.getSortKey() != null){
				info.setSortKey(String.format("%.0f",item.getSortKey()));
			}
			
			response.addGrdList(info);
		}
		
		return response.build();
	}

}
