package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.nur.Nur0110Repository;
import nta.med.data.model.ihis.nuri.NUR0110U00GrdNUR0110Info;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0110U00GrdNUR0110Request;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0110U00GrdNUR0110Response;

@Service
@Scope("prototype")
public class NUR0110U00GrdNUR0110Handler extends
		ScreenHandler<NuriServiceProto.NUR0110U00GrdNUR0110Request, NuriServiceProto.NUR0110U00GrdNUR0110Response> {

	@Resource
	private Nur0110Repository nur0110Repository;

	@Override
	@Transactional(readOnly = true)
	public NUR0110U00GrdNUR0110Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0110U00GrdNUR0110Request request) throws Exception {
		NuriServiceProto.NUR0110U00GrdNUR0110Response.Builder response = NuriServiceProto.NUR0110U00GrdNUR0110Response
				.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);

		Integer offset = StringUtils.isEmpty(request.getOffset()) ? null
				: CommonUtils.parseInteger(request.getOffset());
		Integer startNum = StringUtils.isEmpty(request.getOffset()) || StringUtils.isEmpty(request.getPageNumber())
				? null : CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());

		List<NUR0110U00GrdNUR0110Info> items = nur0110Repository.getNUR0110U00GrdNUR0110Info(hospCode, startNum, offset);
		for (NUR0110U00GrdNUR0110Info item : items) {
			NuriModelProto.NUR0110U00GrdNUR0110Info.Builder info = NuriModelProto.NUR0110U00GrdNUR0110Info.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			response.addGrdLst(info);
		}
		
		return response.build();
	}

}
