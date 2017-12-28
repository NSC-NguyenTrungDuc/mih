package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur1092;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur1092Repository;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1091U00grdDetailRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1091U00grdDetailResponse;

@Service
@Scope("prototype")
public class NUR1091U00grdDetailHandler extends
		ScreenHandler<NuriServiceProto.NUR1091U00grdDetailRequest, NuriServiceProto.NUR1091U00grdDetailResponse> {

	@Resource
	private Nur1092Repository nur1092Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR1091U00grdDetailResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR1091U00grdDetailRequest request) throws Exception {

		NuriServiceProto.NUR1091U00grdDetailResponse.Builder response = NuriServiceProto.NUR1091U00grdDetailResponse
				.newBuilder();
		
		List<Nur1092> items = nur1092Repository.findByHospCodeAndCodeType(getHospitalCode(vertx, sessionId),
				request.getCodeType());
		
		for (Nur1092 item : items) {
			NuriModelProto.NUR1091U00grdDetailInfo.Builder info = NuriModelProto.NUR1091U00grdDetailInfo.newBuilder()
					.setCodeType(item.getCodeType())
					.setCode(item.getCode())
					.setCodeName(item.getCodeName() == null ? "" : item.getCodeName())
					.setScore(item.getScore() == null ? "" : String.format("%.0f", item.getScore()))
					.setFromDate(DateUtil.toString(item.getFromDate(), DateUtil.PATTERN_YYMMDD))
					.setToDate(DateUtil.toString(item.getToDate(), DateUtil.PATTERN_YYMMDD))
					.setSortSeq(item.getSortSeq() == null ? "" : String.format("%.0f", item.getSortSeq()));
			response.addGrdMasterItem(info);
		}
		
		return response.build();
	}

}
