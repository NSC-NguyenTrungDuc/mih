package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.nur.Nur0115Repository;
import nta.med.data.model.ihis.nuri.NUR0110U00GrdNUR0115Info;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0110U00GrdNUR0115Request;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0110U00GrdNUR0115Response;

@Service
@Scope("prototype")
public class NUR0110U00GrdNUR0115Handler extends
		ScreenHandler<NuriServiceProto.NUR0110U00GrdNUR0115Request, NuriServiceProto.NUR0110U00GrdNUR0115Response> {

	@Resource
	private Nur0115Repository nur0115Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR0110U00GrdNUR0115Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0110U00GrdNUR0115Request request) throws Exception {
		NuriServiceProto.NUR0110U00GrdNUR0115Response.Builder response = NuriServiceProto.NUR0110U00GrdNUR0115Response.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<NUR0110U00GrdNUR0115Info> items = nur0115Repository.getNUR0110U00GrdNUR0115Info(hospCode, language,
				request.getNurGrCode(), request.getNurMdCode(), request.getNurSoCode());
		
		for (NUR0110U00GrdNUR0115Info item : items) {
			NuriModelProto.NUR0110U00GrdNUR0115Info.Builder info = NuriModelProto.NUR0110U00GrdNUR0115Info.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			if(item.getSuryang() != null){
				info.setSuryang(String.format("%.0f",item.getSuryang()));
			}
			
			if(item.getDv() != null){
				info.setDv(String.format("%.0f",item.getDv()));
			}
			
			if(item.getNalsu() != null){
				info.setNalsu(String.format("%.0f",item.getNalsu()));
			}
			
			if(item.getSeq() != null){
				info.setSeq(String.format("%.0f",item.getSeq()));
			}
			
			response.addGrdList(info);
		}
		
		return response.build();
	}

	
}
