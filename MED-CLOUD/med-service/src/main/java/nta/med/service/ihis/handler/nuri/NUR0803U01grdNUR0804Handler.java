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
import nta.med.data.dao.medi.nur.Nur0804Repository;
import nta.med.data.model.ihis.nuri.NUR0803U01grdNUR0804Info;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0803U01grdNUR0804Request;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0803U01grdNUR0804Response;

@Service
@Scope("prototype")
public class NUR0803U01grdNUR0804Handler extends
		ScreenHandler<NuriServiceProto.NUR0803U01grdNUR0804Request, NuriServiceProto.NUR0803U01grdNUR0804Response> {

	@Resource
	private Nur0804Repository nur0804Repository;

	@Override
	@Transactional(readOnly = true)
	public NUR0803U01grdNUR0804Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0803U01grdNUR0804Request request) throws Exception {
		NuriServiceProto.NUR0803U01grdNUR0804Response.Builder response = NuriServiceProto.NUR0803U01grdNUR0804Response
				.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);

		List<NUR0803U01grdNUR0804Info> items = nur0804Repository.getNUR0803U01grdNUR0804Info(hospCode,
				request.getNeedGubun(), request.getNeedAsmtCode(),
				DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD));

		for (NUR0803U01grdNUR0804Info item : items) {
			NuriModelProto.NUR0803U01grdNUR0804Info.Builder info = NuriModelProto.NUR0803U01grdNUR0804Info.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			response.addItems(info);
		}

		return response.build();
	}

}
