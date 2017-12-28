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
import nta.med.data.dao.medi.nur.Nur8033Repository;
import nta.med.data.model.ihis.nuri.NUR8003U03GrdAInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR8003U03GrdARequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR8003U03GrdAResponse;

@Service
@Scope("prototype")
public class NUR8003U03GrdAHandler
		extends ScreenHandler<NuriServiceProto.NUR8003U03GrdARequest, NuriServiceProto.NUR8003U03GrdAResponse> {

	@Resource
	private Nur8033Repository nur8033Repository;

	@Override
	@Transactional(readOnly = true)
	public NUR8003U03GrdAResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR8003U03GrdARequest request) throws Exception {
		NuriServiceProto.NUR8003U03GrdAResponse.Builder response = NuriServiceProto.NUR8003U03GrdAResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);

		List<NUR8003U03GrdAInfo> items = nur8033Repository.getNUR8003U03GrdAInfo(hospCode, request.getBunho(),
				DateUtil.toDate(request.getWriteDate(), DateUtil.PATTERN_YYMMDD), request.getHoDong(),
				request.getNeedGubun(), request.getMigrationDisp());

		for (NUR8003U03GrdAInfo item : items) {
			NuriModelProto.NUR8003U03GrdAInfo.Builder info = NuriModelProto.NUR8003U03GrdAInfo.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			
			info.setNurPoint(String.format("%.0f",item.getNurPoint()));
			info.setNewNurPoint(String.format("%.0f",item.getNewNurPoint()));
			info.setSortKey(String.format("%.0f",item.getSortKey()));
			
			response.addGrdList(info);
		}

		return response.build();
	}

}