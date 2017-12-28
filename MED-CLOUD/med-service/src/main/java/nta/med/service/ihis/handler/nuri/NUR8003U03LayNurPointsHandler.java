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
import nta.med.data.dao.medi.nur.Nur0803Repository;
import nta.med.data.model.ihis.nuri.NUR8003U03LayNurPointsInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR8003U03LayNurPointsRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR8003U03LayNurPointsResponse;

@Service
@Scope("prototype")
public class NUR8003U03LayNurPointsHandler extends
		ScreenHandler<NuriServiceProto.NUR8003U03LayNurPointsRequest, NuriServiceProto.NUR8003U03LayNurPointsResponse> {

	@Resource
	private Nur0803Repository nur0803Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR8003U03LayNurPointsResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR8003U03LayNurPointsRequest request) throws Exception {
		NuriServiceProto.NUR8003U03LayNurPointsResponse.Builder response = NuriServiceProto.NUR8003U03LayNurPointsResponse
				.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<NUR8003U03LayNurPointsInfo> items = nur0803Repository.getNUR8003U03LayNurPointsInfo(hospCode,
				request.getBunho(), request.getStartDate(), DateUtil.toDate(request.getQueryDate(), DateUtil.PATTERN_YYMMDD));
		
		for (NUR8003U03LayNurPointsInfo item : items) {
			NuriModelProto.NUR8003U03LayNurPointsInfo.Builder info = NuriModelProto.NUR8003U03LayNurPointsInfo.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			response.addLayList(info);
		}
		
		return response.build();
	}

}
