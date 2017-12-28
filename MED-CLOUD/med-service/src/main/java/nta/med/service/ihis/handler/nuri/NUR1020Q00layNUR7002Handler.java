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
import nta.med.data.dao.medi.nur.Nur1020Repository;
import nta.med.data.model.ihis.nuri.NUR1020Q00layNUR7002Info;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020Q00layNUR7002Request;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020Q00layNUR7002Response;

@Service
@Scope("prototype")
public class NUR1020Q00layNUR7002Handler extends
		ScreenHandler<NuriServiceProto.NUR1020Q00layNUR7002Request, NuriServiceProto.NUR1020Q00layNUR7002Response> {

	@Resource
	private Nur1020Repository nur1020Repository;
	
	@Override
	@Transactional
	public NUR1020Q00layNUR7002Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR1020Q00layNUR7002Request request) throws Exception {
		NuriServiceProto.NUR1020Q00layNUR7002Response.Builder response = NuriServiceProto.NUR1020Q00layNUR7002Response
				.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<NUR1020Q00layNUR7002Info> items = nur1020Repository.getNUR1020Q00layNUR7002Info(hospCode,
				CommonUtils.parseDouble(request.getFkinp1001()), request.getYmd());
		
		for (NUR1020Q00layNUR7002Info item : items) {
			NuriModelProto.NUR1020Q00layNUR7002Info.Builder info = NuriModelProto.NUR1020Q00layNUR7002Info.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			response.addLayItem(info);
		}
		
		return response.build();
	}

}
