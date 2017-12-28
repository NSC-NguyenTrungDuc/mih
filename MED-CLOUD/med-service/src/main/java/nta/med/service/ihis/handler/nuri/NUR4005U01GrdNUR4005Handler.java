package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.nur.Nur4005Repository;
import nta.med.data.model.ihis.nuri.NUR4005U01GrdNUR4005Info;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR4005U01GrdNUR4005Request;
import nta.med.service.ihis.proto.NuriServiceProto.NUR4005U01GrdNUR4005Response;

@Service
@Scope("prototype")
public class NUR4005U01GrdNUR4005Handler extends
		ScreenHandler<NuriServiceProto.NUR4005U01GrdNUR4005Request, NuriServiceProto.NUR4005U01GrdNUR4005Response> {

	@Resource
	private Nur4005Repository nur4005Repository;

	@Override
	@Transactional(readOnly = true)
	public NUR4005U01GrdNUR4005Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR4005U01GrdNUR4005Request request) throws Exception {
		NuriServiceProto.NUR4005U01GrdNUR4005Response.Builder response = NuriServiceProto.NUR4005U01GrdNUR4005Response
				.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);

		List<NUR4005U01GrdNUR4005Info> items = nur4005Repository.getNUR4005U01GrdNUR4005Info(hospCode,
				CommonUtils.parseDouble(request.getFknur4001()));

		for (NUR4005U01GrdNUR4005Info item : items) {
			NuriModelProto.NUR4005U01GrdNUR4005Info.Builder info = NuriModelProto.NUR4005U01GrdNUR4005Info.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			response.addGrdList(info);
		}

		return response.build();
	}

}