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
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur1001Repository;
import nta.med.data.model.ihis.nuri.NUR9999R11layPaInfoInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR9999R11layPaInfoRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR9999R11layPaInfoResponse;

@Service
@Scope("prototype")
public class NUR9999R11layPaInfoHandler extends
		ScreenHandler<NuriServiceProto.NUR9999R11layPaInfoRequest, NuriServiceProto.NUR9999R11layPaInfoResponse> {

	@Resource
	private Nur1001Repository nur1001Repository;

	@Override
	@Transactional(readOnly = true)
	public NUR9999R11layPaInfoResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR9999R11layPaInfoRequest request) throws Exception {
		NuriServiceProto.NUR9999R11layPaInfoResponse.Builder response = NuriServiceProto.NUR9999R11layPaInfoResponse
				.newBuilder();

		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);

		List<NUR9999R11layPaInfoInfo> items = nur1001Repository.getNUR9999R11layPaInfoInfo(hospCode, language,
				DateUtil.toDate(request.getWriteDate(), DateUtil.PATTERN_YYMMDD),
				CommonUtils.parseDouble(request.getFkinp1001()));

		for (NUR9999R11layPaInfoInfo item : items) {
			NuriModelProto.NUR9999R11layPaInfoInfo.Builder info = NuriModelProto.NUR9999R11layPaInfoInfo.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			response.addLayItem(info);
		}

		return response.build();
	}

}
