package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur1091;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur1091Repository;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1091U00grdMasterRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1091U00grdMasterResponse;

@Service
@Scope("prototype")
public class NUR1091U00grdMasterHandler extends
		ScreenHandler<NuriServiceProto.NUR1091U00grdMasterRequest, NuriServiceProto.NUR1091U00grdMasterResponse> {

	@Resource
	private Nur1091Repository nur1091Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR1091U00grdMasterResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR1091U00grdMasterRequest request) throws Exception {

		NuriServiceProto.NUR1091U00grdMasterResponse.Builder response = NuriServiceProto.NUR1091U00grdMasterResponse
				.newBuilder();
		
		List<Nur1091> items = nur1091Repository.findByHospCode(getHospitalCode(vertx, sessionId));
		for (Nur1091 item : items) {
			NuriModelProto.NUR1091U00grdMasterInfo.Builder info = NuriModelProto.NUR1091U00grdMasterInfo.newBuilder()
					.setCodeType(item.getCodeType())
					.setCodeTypeName(item.getCodeTypeName() == null ? "" : item.getCodeTypeName())
					.setMaxScore(item.getMaxScore() == null ? "" : String.format("%.0f", item.getMaxScore()))
					.setFromDate(DateUtil.toString(item.getFromDate(), DateUtil.PATTERN_YYMMDD))
					.setToDate(DateUtil.toString(item.getToDate(), DateUtil.PATTERN_YYMMDD))
					.setSortSeq(item.getSortSeq() == null ? "" : String.format("%.0f", item.getSortSeq()));
			
			response.addGrdMasterItem(info);
		}
		
		return response.build();
	}

}
