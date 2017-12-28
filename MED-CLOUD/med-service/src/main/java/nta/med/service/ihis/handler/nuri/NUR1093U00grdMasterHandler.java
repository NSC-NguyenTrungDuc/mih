package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur1093;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur1093Repository;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1093U00grdMasterRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1093U00grdMasterResponse;

@Service
@Scope("prototype")
public class NUR1093U00grdMasterHandler extends
		ScreenHandler<NuriServiceProto.NUR1093U00grdMasterRequest, NuriServiceProto.NUR1093U00grdMasterResponse> {

	@Resource
	private Nur1093Repository nur1093Repository;

	@Override
	@Transactional(readOnly = true)
	public NUR1093U00grdMasterResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR1093U00grdMasterRequest request) throws Exception {
		NuriServiceProto.NUR1093U00grdMasterResponse.Builder response = NuriServiceProto.NUR1093U00grdMasterResponse
				.newBuilder();
		
		List<Nur1093> items = nur1093Repository.findByHospCode(getHospitalCode(vertx, sessionId));
		
		for (Nur1093 item : items) {
			NuriModelProto.NUR1093U00grdMasterInfo.Builder info = NuriModelProto.NUR1093U00grdMasterInfo.newBuilder()
					.setCode(item.getCode())
					.setCodeName(item.getCodeName() == null ? "" : item.getCodeName())
					.setFromScore(item.getFromScore() == null ? "" : String.format("%.0f", item.getFromScore()))
					.setToScore(item.getToScore() == null ? "" : String.format("%.0f", item.getToScore()))
					.setFromDate(DateUtil.toString(item.getFromDate(), DateUtil.PATTERN_YYMMDD))
					.setToDate(DateUtil.toString(item.getToDate(), DateUtil.PATTERN_YYMMDD))
					.setSortSeq(item.getSortSeq() == null ? "" : String.format("%.0f", item.getSortSeq()))
					.setCodeCmt(item.getCodeCmt() == null ? "" : item.getCodeCmt())
					.setBedDisplayYn(item.getBedDisplayYn() == null ? "" : item.getBedDisplayYn());
			
			response.addItems(info);
		}
		
		return response.build();
	}

}
