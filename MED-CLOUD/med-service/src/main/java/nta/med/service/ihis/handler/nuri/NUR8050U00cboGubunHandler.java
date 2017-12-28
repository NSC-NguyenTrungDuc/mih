package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur0102;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.nur.Nur0102Repository;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR8050U00cboGubunRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR8050U00cboGubunResponse;

@Service
@Scope("prototype")
public class NUR8050U00cboGubunHandler
		extends ScreenHandler<NuriServiceProto.NUR8050U00cboGubunRequest, NuriServiceProto.NUR8050U00cboGubunResponse> {

	@Resource
	private Nur0102Repository nur0102Repository;

	@Override
	@Transactional(readOnly = true)
	public NUR8050U00cboGubunResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR8050U00cboGubunRequest request) throws Exception {
		NuriServiceProto.NUR8050U00cboGubunResponse.Builder response = NuriServiceProto.NUR8050U00cboGubunResponse
				.newBuilder();

		NuriModelProto.NUR8050U00cboGubunInfo.Builder firstInfo = NuriModelProto.NUR8050U00cboGubunInfo.newBuilder()
				.setCode("%")
				.setCodeName("全体")
				.setSortKey("0");
		response.addCboGubun(firstInfo);
		
		List<Nur0102> items = nur0102Repository.findByCodeTypeLanguage(getHospitalCode(vertx, sessionId),
				"ADL_WORK_GUBUN", getLanguage(vertx, sessionId));
		for (Nur0102 item : items) {
			NuriModelProto.NUR8050U00cboGubunInfo.Builder info = NuriModelProto.NUR8050U00cboGubunInfo.newBuilder()
					.setCode(item.getCode())
					.setCodeName(item.getCodeName())
					.setSortKey(item.getSortKey() == null ? "" : String.format("%.0f", item.getSortKey()));
			response.addCboGubun(info);
		}
		
		return response.build();
	}

}
