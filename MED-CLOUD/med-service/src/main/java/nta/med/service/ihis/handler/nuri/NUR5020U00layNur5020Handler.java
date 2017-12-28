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
import nta.med.data.dao.medi.nur.Nur5022Repository;
import nta.med.data.model.ihis.nuri.NUR5020U00layNur5020Info;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR5020U00layNur5020Request;
import nta.med.service.ihis.proto.NuriServiceProto.NUR5020U00layNur5020Response;

@Service
@Scope("prototype")
public class NUR5020U00layNur5020Handler extends
		ScreenHandler<NuriServiceProto.NUR5020U00layNur5020Request, NuriServiceProto.NUR5020U00layNur5020Response> {

	@Resource
	private Nur5022Repository nur5022Repository;

	@Override
	@Transactional(readOnly = true)
	public NUR5020U00layNur5020Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR5020U00layNur5020Request request) throws Exception {
		NuriServiceProto.NUR5020U00layNur5020Response.Builder response = NuriServiceProto.NUR5020U00layNur5020Response
				.newBuilder();

		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);

		List<NUR5020U00layNur5020Info> items = nur5022Repository.getNUR5020U00layNur5020Info(hospCode, language,
				request.getHoDong(), DateUtil.toDate(request.getDate(), DateUtil.PATTERN_YYMMDD));

		for (NUR5020U00layNur5020Info item : items) {
			NuriModelProto.NUR5020U00layNur5020Info.Builder info = NuriModelProto.NUR5020U00layNur5020Info.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			response.addLayItem(info);
		}

		return response.build();
	}

}
