package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.nur.Nur0102Repository;
import nta.med.data.model.ihis.nuri.NUR0801U00GrdMasterInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0801U00GrdMasterRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0801U00GrdMasterResponse;

@Service
@Scope("prototype")
public class NUR0801U00GrdMasterHandler extends
		ScreenHandler<NuriServiceProto.NUR0801U00GrdMasterRequest, NuriServiceProto.NUR0801U00GrdMasterResponse> {

	@Resource
	private Nur0102Repository nur0102Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR0801U00GrdMasterResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0801U00GrdMasterRequest request) throws Exception {
		NuriServiceProto.NUR0801U00GrdMasterResponse.Builder response = NuriServiceProto.NUR0801U00GrdMasterResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<NUR0801U00GrdMasterInfo> items = nur0102Repository.getNUR0801U00GrdMasterInfo(hospCode, language, request.getNeedType());
		for (NUR0801U00GrdMasterInfo item : items) {
			NuriModelProto.NUR0801U00GrdMasterInfo.Builder info = NuriModelProto.NUR0801U00GrdMasterInfo.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			response.addGrdList(info);
		}
		
		return response.build();
	}

}
