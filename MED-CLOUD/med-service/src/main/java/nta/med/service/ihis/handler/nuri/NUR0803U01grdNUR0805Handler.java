package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur0805Repository;
import nta.med.data.model.ihis.nuri.NUR0803U01grdNUR0805Info;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0803U01grdNUR0805Request;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0803U01grdNUR0805Response;

@Service
@Scope("prototype")
public class NUR0803U01grdNUR0805Handler extends
		ScreenHandler<NuriServiceProto.NUR0803U01grdNUR0805Request, NuriServiceProto.NUR0803U01grdNUR0805Response> {

	@Resource
	private Nur0805Repository nur0805Repository;

	@Override
	@Transactional(readOnly = true)
	public NUR0803U01grdNUR0805Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0803U01grdNUR0805Request request) throws Exception {
		NuriServiceProto.NUR0803U01grdNUR0805Response.Builder response = NuriServiceProto.NUR0803U01grdNUR0805Response
				.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);

		List<NUR0803U01grdNUR0805Info> items = nur0805Repository.getNUR0803U01grdNUR0805Info(hospCode,
				request.getNeedGubun(), request.getNeedAsmtCode(), request.getNeedResultCode(),
				DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD));

		for (NUR0803U01grdNUR0805Info item : items) {
			NuriModelProto.NUR0803U01grdNUR0805Info.Builder info = NuriModelProto.NUR0803U01grdNUR0805Info.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			response.addItems(info);
		}

		return response.build();
	}

}
