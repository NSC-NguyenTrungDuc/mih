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
import nta.med.data.dao.medi.nur.Nur1020Repository;
import nta.med.data.model.ihis.nuri.NUR8003U03QueryFormGrdBPInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR8003U03QueryFormGrdBPRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR8003U03QueryFormGrdBPResponse;

@Service
@Scope("prototype")
public class NUR8003U03QueryFormGrdBPHandler extends
		ScreenHandler<NuriServiceProto.NUR8003U03QueryFormGrdBPRequest, NuriServiceProto.NUR8003U03QueryFormGrdBPResponse> {

	@Resource
	private Nur1020Repository nur1020Repository;

	@Override
	@Transactional(readOnly = true)
	public NUR8003U03QueryFormGrdBPResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR8003U03QueryFormGrdBPRequest request) throws Exception {
		NuriServiceProto.NUR8003U03QueryFormGrdBPResponse.Builder response = NuriServiceProto.NUR8003U03QueryFormGrdBPResponse
				.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);

		List<NUR8003U03QueryFormGrdBPInfo> items = nur1020Repository.getNUR8003U03QueryFormGrdBPInfo(hospCode,
				request.getBunho(), CommonUtils.parseDouble(request.getFkinp1001()),
				DateUtil.toDate(request.getWriteDate(), DateUtil.PATTERN_YYMMDD));
		
		for (NUR8003U03QueryFormGrdBPInfo item : items) {
			NuriModelProto.NUR8003U03QueryFormGrdBPInfo.Builder info = NuriModelProto.NUR8003U03QueryFormGrdBPInfo.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			response.addGrdList(info);
		}
		
		return response.build();
	}

}
