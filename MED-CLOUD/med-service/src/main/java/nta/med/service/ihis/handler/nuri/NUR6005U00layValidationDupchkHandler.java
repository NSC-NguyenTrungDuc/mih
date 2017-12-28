package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur6005;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur6005Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR6005U00layValidationDupchkRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR6005U00layValidationDupchkResponse;

@Service
@Scope("prototype")
public class NUR6005U00layValidationDupchkHandler extends
		ScreenHandler<NuriServiceProto.NUR6005U00layValidationDupchkRequest, NuriServiceProto.NUR6005U00layValidationDupchkResponse> {

	@Resource
	private Nur6005Repository nur6005Repository;

	@Override
	@Transactional(readOnly = true)
	public NUR6005U00layValidationDupchkResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR6005U00layValidationDupchkRequest request) throws Exception {
		NuriServiceProto.NUR6005U00layValidationDupchkResponse.Builder response = NuriServiceProto.NUR6005U00layValidationDupchkResponse
				.newBuilder();

		List<Nur6005> items = nur6005Repository.findByHospCodeBunhoStartDate(getHospitalCode(vertx, sessionId),
				request.getBunho(), DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD));
		CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder()
				.setDataValue(CollectionUtils.isEmpty(items) ? "" : "Y");

		response.addLayItem(info);
		return response.build();
	}

}
