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
import nta.med.data.model.ihis.nuri.NUR8003R02grdDetailInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR8003R02grdDetailRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR8003R02grdDetailResponse;

@Service
@Scope("prototype")
public class NUR8003R02grdDetailHandler extends
		ScreenHandler<NuriServiceProto.NUR8003R02grdDetailRequest, NuriServiceProto.NUR8003R02grdDetailResponse> {

	@Resource
	private Nur0102Repository nur0102Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR8003R02grdDetailResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR8003R02grdDetailRequest request) throws Exception {
		NuriServiceProto.NUR8003R02grdDetailResponse.Builder response = NuriServiceProto.NUR8003R02grdDetailResponse
				.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<NUR8003R02grdDetailInfo> items = nur0102Repository.getNUR8003R02grdDetailInfo(hospCode, language,
				request.getBunho(), request.getNeedHType(), request.getFromDate(), request.getToDate(), request.getWriteDong());
		
		for (NUR8003R02grdDetailInfo item : items) {
			NuriModelProto.NUR8003R02grdDetailInfo.Builder info = NuriModelProto.NUR8003R02grdDetailInfo.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			response.addGrdMasterItem(info);
		}
		
		return response.build();
	}

}
