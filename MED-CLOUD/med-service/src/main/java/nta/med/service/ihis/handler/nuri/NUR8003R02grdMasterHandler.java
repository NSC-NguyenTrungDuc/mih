package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.nur.Nur8003Repository;
import nta.med.data.model.ihis.nuri.NUR8003R02grdMasterInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR8003R02grdMasterRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR8003R02grdMasterResponse;

@Service
@Scope("prototype")
public class NUR8003R02grdMasterHandler extends
		ScreenHandler<NuriServiceProto.NUR8003R02grdMasterRequest, NuriServiceProto.NUR8003R02grdMasterResponse> {

	@Resource
	private Nur8003Repository nur8003Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR8003R02grdMasterResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR8003R02grdMasterRequest request) throws Exception {
		NuriServiceProto.NUR8003R02grdMasterResponse.Builder response = NuriServiceProto.NUR8003R02grdMasterResponse
				.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<NUR8003R02grdMasterInfo> items = nur8003Repository.getNUR8003R02grdMasterInfo(hospCode,
				request.getFromDate(), request.getToDate(), request.getHodong(), request.getNeedHType(), request.getBunho(), language);
		
		for (NUR8003R02grdMasterInfo item : items) {
			NuriModelProto.NUR8003R02grdMasterInfo.Builder info = NuriModelProto.NUR8003R02grdMasterInfo.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			response.addGrdMasterItem(info);
		}
		
		return response.build();
	}

}
