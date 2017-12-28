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
import nta.med.data.dao.medi.nur.Nur8003Repository;
import nta.med.data.model.ihis.nuri.NUR8003U03CopyDataInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR8003U03CopyDataRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR8003U03CopyDataResponse;

@Service
@Scope("prototype")
public class NUR8003U03CopyDataHandler
		extends ScreenHandler<NuriServiceProto.NUR8003U03CopyDataRequest, NuriServiceProto.NUR8003U03CopyDataResponse> {

	@Resource
	private Nur8003Repository nur8003Repository;

	@Override
	@Transactional(readOnly = true)
	public NUR8003U03CopyDataResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR8003U03CopyDataRequest request) throws Exception {
		NuriServiceProto.NUR8003U03CopyDataResponse.Builder response = NuriServiceProto.NUR8003U03CopyDataResponse
				.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);

		List<NUR8003U03CopyDataInfo> items = nur8003Repository.getNUR8003U03CopyDataInfo(hospCode, request.getBunho(),
				DateUtil.toDate(request.getFromWriteDate(), DateUtil.PATTERN_YYMMDD));

		for (NUR8003U03CopyDataInfo item : items) {
			NuriModelProto.NUR8003U03CopyDataInfo.Builder info = NuriModelProto.NUR8003U03CopyDataInfo.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			response.addDataLst(info);
		}

		return response.build();
	}

}
