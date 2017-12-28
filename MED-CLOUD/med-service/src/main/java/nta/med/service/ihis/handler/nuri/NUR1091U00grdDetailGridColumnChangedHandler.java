package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur1092;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.nur.Nur1092Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1091U00grdDetailGridColumnChangedRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1091U00grdDetailGridColumnChangedResponse;

@Service
@Scope("prototype")
public class NUR1091U00grdDetailGridColumnChangedHandler extends
		ScreenHandler<NuriServiceProto.NUR1091U00grdDetailGridColumnChangedRequest, NuriServiceProto.NUR1091U00grdDetailGridColumnChangedResponse> {

	@Resource
	private Nur1092Repository nur1092Repository;

	@Override
	@Transactional(readOnly = true)
	public NUR1091U00grdDetailGridColumnChangedResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, NUR1091U00grdDetailGridColumnChangedRequest request) throws Exception {
		NuriServiceProto.NUR1091U00grdDetailGridColumnChangedResponse.Builder response = NuriServiceProto.NUR1091U00grdDetailGridColumnChangedResponse
				.newBuilder();
		
		List<Nur1092> items = nur1092Repository.findByHospCodeAndCodeTypeAndCode(getHospitalCode(vertx, sessionId),
				request.getCodeType(), request.getCode());
		
		for (Nur1092 item : items) {
			CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder()
					.setDataValue(item.getCode());
			response.addCmdItem(info);
		}
		
		return response.build();
	}

}
