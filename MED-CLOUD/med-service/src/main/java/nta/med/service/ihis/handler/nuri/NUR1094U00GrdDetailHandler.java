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
import nta.med.data.dao.medi.nur.Nur1092Repository;
import nta.med.data.model.ihis.nuri.NUR1094U00GrdDetailInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1094U00GrdDetailRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1094U00GrdDetailResponse;

@Service
@Scope("prototype")
public class NUR1094U00GrdDetailHandler extends
		ScreenHandler<NuriServiceProto.NUR1094U00GrdDetailRequest, NuriServiceProto.NUR1094U00GrdDetailResponse> {

	@Resource
	private Nur1092Repository nur1092Repository;

	@Override
	@Transactional(readOnly = true)
	public NUR1094U00GrdDetailResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR1094U00GrdDetailRequest request) throws Exception {
		NuriServiceProto.NUR1094U00GrdDetailResponse.Builder response = NuriServiceProto.NUR1094U00GrdDetailResponse
				.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<NUR1094U00GrdDetailInfo> items = nur1092Repository.getNUR1094U00GrdDetailInfo(hospCode, CommonUtils.parseDouble(request.getFknur1094()));
		for (NUR1094U00GrdDetailInfo item : items) {
			NuriModelProto.NUR1094U00GrdDetailInfo.Builder info = NuriModelProto.NUR1094U00GrdDetailInfo.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			response.addGrdLst(info);
		}
		
		return response.build();
	}

}
