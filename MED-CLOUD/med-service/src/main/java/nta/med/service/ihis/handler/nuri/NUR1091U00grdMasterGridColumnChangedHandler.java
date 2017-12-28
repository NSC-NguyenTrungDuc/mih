package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur1091;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.nur.Nur1091Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1091U00grdMasterGridColumnChangedRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1091U00grdMasterGridColumnChangedResponse;

@Service
@Scope("prototype")
public class NUR1091U00grdMasterGridColumnChangedHandler extends
		ScreenHandler<NuriServiceProto.NUR1091U00grdMasterGridColumnChangedRequest, NuriServiceProto.NUR1091U00grdMasterGridColumnChangedResponse> {

	@Resource
	private Nur1091Repository nur1091Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR1091U00grdMasterGridColumnChangedResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, NUR1091U00grdMasterGridColumnChangedRequest request) throws Exception {
		NuriServiceProto.NUR1091U00grdMasterGridColumnChangedResponse.Builder response = NuriServiceProto.NUR1091U00grdMasterGridColumnChangedResponse
				.newBuilder();
		
		List<Nur1091> items = nur1091Repository.findByHospCodeAndCodeType(getHospitalCode(vertx, sessionId),
				request.getCodeType());
		
		CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder()
				.setDataValue(CollectionUtils.isEmpty(items) ? "" : "X");
		
		response.setCmdItem(info);
		return response.build();
	}

}
