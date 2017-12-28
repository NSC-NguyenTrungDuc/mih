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
import nta.med.data.dao.medi.nur.Nur0115Repository;
import nta.med.data.model.ihis.nuri.NUR0110U00GrdNUR01152Info;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0110U00GrdNUR01152Request;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0110U00GrdNUR01152Response;

@Service
@Scope("prototype")
public class NUR0110U00GrdNUR01152Handler extends
		ScreenHandler<NuriServiceProto.NUR0110U00GrdNUR01152Request, NuriServiceProto.NUR0110U00GrdNUR01152Response> {

	@Resource
	private Nur0115Repository nur0115Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR0110U00GrdNUR01152Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0110U00GrdNUR01152Request request) throws Exception {
		NuriServiceProto.NUR0110U00GrdNUR01152Response.Builder response = NuriServiceProto.NUR0110U00GrdNUR01152Response.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		Integer offset = StringUtils.isEmpty(request.getOffset()) ? null
				: CommonUtils.parseInteger(request.getOffset());
		Integer startNum = StringUtils.isEmpty(request.getOffset()) || StringUtils.isEmpty(request.getPageNumber())
				? null : CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());
		
		List<NUR0110U00GrdNUR01152Info> items = nur0115Repository.getNUR0110U00GrdNUR01152Info(hospCode, language,
				request.getNurGrCode(), request.getNurMdCode(), request.getNurSoCode(), startNum, offset);
		
		for (NUR0110U00GrdNUR01152Info item : items) {
			NuriModelProto.NUR0110U00GrdNUR01152Info.Builder info = NuriModelProto.NUR0110U00GrdNUR01152Info.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			
			
			if (item.getSuryang() != null) {
				info.setSuryang(String.format("%.0f",item.getSuryang()));
			}
			
			if (item.getNalsu() != null) {
				info.setNalsu(String.format("%.0f",item.getNalsu()));
			}
			
			if (item.getSeq() != null) {
				info.setSeq(String.format("%.0f",item.getSeq()));
			}
			response.addGrdList(info);
		}
		
		return response.build();
	}

}
