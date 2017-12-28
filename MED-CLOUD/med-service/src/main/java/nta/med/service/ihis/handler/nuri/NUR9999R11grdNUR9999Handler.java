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
import nta.med.data.dao.medi.nur.Nur9999Repository;
import nta.med.data.model.ihis.nuri.NUR9999R11grdNUR9999Info;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR9999R11grdNUR9999Request;
import nta.med.service.ihis.proto.NuriServiceProto.NUR9999R11grdNUR9999Response;

@Service
@Scope("prototype")
public class NUR9999R11grdNUR9999Handler extends
		ScreenHandler<NuriServiceProto.NUR9999R11grdNUR9999Request, NuriServiceProto.NUR9999R11grdNUR9999Response> {

	@Resource
	private Nur9999Repository nur9999Repository;

	@Override
	@Transactional(readOnly = true)
	public NUR9999R11grdNUR9999Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR9999R11grdNUR9999Request request) throws Exception {
		NuriServiceProto.NUR9999R11grdNUR9999Response.Builder response = NuriServiceProto.NUR9999R11grdNUR9999Response
				.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);

		List<NUR9999R11grdNUR9999Info> items = nur9999Repository.getNUR9999R11grdNUR9999Info(hospCode,
				CommonUtils.parseDouble(request.getFkinp1001()), getLanguage(vertx, sessionId));
		
		for (NUR9999R11grdNUR9999Info item : items) {
			NuriModelProto.NUR9999R11grdNUR9999Info.Builder info = NuriModelProto.NUR9999R11grdNUR9999Info.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			response.addGrdMasterItem(info);
		}
		
		return response.build();
	}

}
