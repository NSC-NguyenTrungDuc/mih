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
import nta.med.data.dao.medi.nur.Nur1093Repository;
import nta.med.data.model.ihis.nuri.NUR1094U00GrdMasterInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1094U00GrdMasterRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1094U00GrdMasterResponse;

@Service
@Scope("prototype")
public class NUR1094U00GrdMasterHandler extends
		ScreenHandler<NuriServiceProto.NUR1094U00GrdMasterRequest, NuriServiceProto.NUR1094U00GrdMasterResponse> {

	@Resource
	private Nur1093Repository nur1093Repository;

	@Override
	@Transactional(readOnly = true)
	public NUR1094U00GrdMasterResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR1094U00GrdMasterRequest request) throws Exception {
		NuriServiceProto.NUR1094U00GrdMasterResponse.Builder response = NuriServiceProto.NUR1094U00GrdMasterResponse
				.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);

		List<NUR1094U00GrdMasterInfo> items = nur1093Repository.getNUR1094U00GrdMasterInfo(hospCode,
				CommonUtils.parseDouble(request.getPkinp1001()));
		
		for (NUR1094U00GrdMasterInfo item : items) {
			NuriModelProto.NUR1094U00GrdMasterInfo.Builder info = NuriModelProto.NUR1094U00GrdMasterInfo.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			response.addGrdLst(info);
		}
		
		return response.build();
	}

}
