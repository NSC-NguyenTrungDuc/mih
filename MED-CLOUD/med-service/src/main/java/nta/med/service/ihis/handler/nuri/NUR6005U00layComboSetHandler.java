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
import nta.med.service.ihis.proto.NuriServiceProto.NUR6005U00layComboSetRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR6005U00layComboSetResponse;

@Service
@Scope("prototype")
public class NUR6005U00layComboSetHandler extends
		ScreenHandler<NuriServiceProto.NUR6005U00layComboSetRequest, NuriServiceProto.NUR6005U00layComboSetResponse> {

	@Resource
	private Nur0102Repository nur0102Repository;

	@Override
	@Transactional(readOnly = true)
	public NUR6005U00layComboSetResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR6005U00layComboSetRequest request) throws Exception {
		NuriServiceProto.NUR6005U00layComboSetResponse.Builder response = NuriServiceProto.NUR6005U00layComboSetResponse
				.newBuilder();

		List<Nur0102> items = nur0102Repository.findByCodeTypeLanguage(getHospitalCode(vertx, sessionId),
				request.getCodeType(), getLanguage(vertx, sessionId));
		
		for (Nur0102 item : items) {
			NuriModelProto.NUR6005U00layComboSetInfo.Builder info = NuriModelProto.NUR6005U00layComboSetInfo.newBuilder()
					.setCode(item.getCode())
					.setCodeName(item.getCodeName())
					.setSortKey(item.getSortKey() == null ? "" : String.format("%.0f",item.getSortKey()));
			
			response.addLayItem(info);
		}
		
		return response.build();
	}

}
