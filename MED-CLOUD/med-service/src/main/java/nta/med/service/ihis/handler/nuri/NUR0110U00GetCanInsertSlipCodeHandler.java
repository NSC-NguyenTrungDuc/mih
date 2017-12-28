package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0110U00GetCanInsertSlipCodeRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class NUR0110U00GetCanInsertSlipCodeHandler extends
		ScreenHandler<NuriServiceProto.NUR0110U00GetCanInsertSlipCodeRequest, SystemServiceProto.StringResponse> {

	@Resource
	private Ocs0132Repository ocs0132Repository;

	@Override
	@Transactional(readOnly = true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0110U00GetCanInsertSlipCodeRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();

		List<String> ments = ocs0132Repository.getMintByCodeAndCodeType(getHospitalCode(vertx, sessionId),
				getLanguage(vertx, sessionId), "JISI_ORDER_GUBUN", request.getCode());

		response.setResult(CollectionUtils.isEmpty(ments) ? "" : (ments.get(0) == null ? "" : ments.get(0)));
		return response.build();
	}

}
