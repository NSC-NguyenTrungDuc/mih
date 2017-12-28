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
import nta.med.data.dao.medi.nur.Nur0404Repository;
import nta.med.data.model.ihis.nuri.NUR0401U01GrdNur0404Info;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0401U01GrdNur0404Request;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0401U01GrdNur0404Response;

@Service
@Scope("prototype")
public class NUR0401U01GrdNur0404Handler extends
		ScreenHandler<NuriServiceProto.NUR0401U01GrdNur0404Request, NuriServiceProto.NUR0401U01GrdNur0404Response> {

	@Resource
	private Nur0404Repository nur0404Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR0401U01GrdNur0404Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0401U01GrdNur0404Request request) throws Exception {
		NuriServiceProto.NUR0401U01GrdNur0404Response.Builder response = NuriServiceProto.NUR0401U01GrdNur0404Response.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		Integer offset = StringUtils.isEmpty(request.getOffset()) ? null : CommonUtils.parseInteger(request.getOffset());
		Integer startNum = StringUtils.isEmpty(request.getOffset()) || StringUtils.isEmpty(request.getPageNumber()) ? null
				: CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());
		
		List<NUR0401U01GrdNur0404Info> items = nur0404Repository.getNUR0401U01GrdNur0404Info(hospCode,
				request.getNurPlanJin(), request.getNurPlan(), startNum, offset);
		
		for (NUR0401U01GrdNur0404Info item : items) {
			NuriModelProto.NUR0401U01GrdNur0404Info.Builder info = NuriModelProto.NUR0401U01GrdNur0404Info.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			response.addGrdList(info);
		}
		
		return response.build();
	}

}
