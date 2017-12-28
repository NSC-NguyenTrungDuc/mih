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
import nta.med.data.dao.medi.nur.Nur8050Repository;
import nta.med.data.model.ihis.nuri.NUR8050U00grdNur8050HisInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR8050U00grdNur8050HisRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR8050U00grdNur8050HisResponse;

@Service
@Scope("prototype")
public class NUR8050U00grdNur8050HisHandler extends
		ScreenHandler<NuriServiceProto.NUR8050U00grdNur8050HisRequest, NuriServiceProto.NUR8050U00grdNur8050HisResponse> {

	@Resource
	private Nur8050Repository nur8050Repository;

	@Override
	@Transactional(readOnly = true)
	public NUR8050U00grdNur8050HisResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR8050U00grdNur8050HisRequest request) throws Exception {
		NuriServiceProto.NUR8050U00grdNur8050HisResponse.Builder response = NuriServiceProto.NUR8050U00grdNur8050HisResponse
				.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);

		List<NUR8050U00grdNur8050HisInfo> items = nur8050Repository.getNUR8050U00grdNur8050HisInfo(hospCode,
				request.getBunho(), CommonUtils.parseDouble(request.getFkinp1001()), request.getGubun());

		for (NUR8050U00grdNur8050HisInfo item : items) {
			NuriModelProto.NUR8050U00grdNur8050HisInfo.Builder info = NuriModelProto.NUR8050U00grdNur8050HisInfo
					.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			response.addListGrdnur8050His(info);
		}

		return response.build();
	}

}
