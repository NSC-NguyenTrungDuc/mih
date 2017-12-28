package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.nur.Nur0803Repository;
import nta.med.data.model.ihis.nuri.NUR0803U01grdNUR0803Info;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0803U01grdNUR0803Request;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0803U01grdNUR0803Response;

@Service
@Scope("prototype")
public class NUR0803U01grdNUR0803Handler extends
		ScreenHandler<NuriServiceProto.NUR0803U01grdNUR0803Request, NuriServiceProto.NUR0803U01grdNUR0803Response> {

	@Resource
	private Nur0803Repository nur0803Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR0803U01grdNUR0803Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0803U01grdNUR0803Request request) throws Exception {
		NuriServiceProto.NUR0803U01grdNUR0803Response.Builder response = NuriServiceProto.NUR0803U01grdNUR0803Response
				.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<NUR0803U01grdNUR0803Info> items = nur0803Repository.getNUR0803U01grdNUR0803Info(hospCode,
				request.getNeedGubun(), request.getHfile(), request.getEnable());
		
		for (NUR0803U01grdNUR0803Info item : items) {
			NuriModelProto.NUR0803U01grdNUR0803Info.Builder info = NuriModelProto.NUR0803U01grdNUR0803Info.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			response.addItems(info);
		}
		
		return response.build();
	}

}
