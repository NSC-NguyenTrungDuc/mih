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
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.model.ihis.nuri.NUR8050U00grdNur8050AllInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR8050U00grdNur8050AllRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR8050U00grdNur8050AllResponse;

@Service
@Scope("prototype")
public class NUR8050U00grdNur8050AllHandler extends
		ScreenHandler<NuriServiceProto.NUR8050U00grdNur8050AllRequest, NuriServiceProto.NUR8050U00grdNur8050AllResponse> {

	@Resource
	private Inp1001Repository inp1001Repository;

	@Override
	@Transactional(readOnly = true)
	public NUR8050U00grdNur8050AllResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR8050U00grdNur8050AllRequest request) throws Exception {
		NuriServiceProto.NUR8050U00grdNur8050AllResponse.Builder response = NuriServiceProto.NUR8050U00grdNur8050AllResponse
				.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);

		List<NUR8050U00grdNur8050AllInfo> items = inp1001Repository.getNUR8050U00grdNur8050AllInfo(hospCode,
				DateUtil.toDate(request.getDate(), DateUtil.PATTERN_YYMMDD));

		for (NUR8050U00grdNur8050AllInfo item : items) {
			NuriModelProto.NUR8050U00grdNur8050AllInfo.Builder info = NuriModelProto.NUR8050U00grdNur8050AllInfo.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			response.addListGrdnur8050(info);
		}

		return response.build();
	}

}
