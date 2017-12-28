package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.nur.Nur9002Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020Q00layQueryRemarkRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020Q00layQueryRemarkResponse;

@Service
@Scope("prototype")
public class NUR1020Q00layQueryRemarkHandler extends
		ScreenHandler<NuriServiceProto.NUR1020Q00layQueryRemarkRequest, NuriServiceProto.NUR1020Q00layQueryRemarkResponse> {

	@Resource
	private Nur9002Repository nur9002Repository;

	@Override
	@Transactional(readOnly = true)
	public NUR1020Q00layQueryRemarkResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR1020Q00layQueryRemarkRequest request) throws Exception {
		NuriServiceProto.NUR1020Q00layQueryRemarkResponse.Builder response = NuriServiceProto.NUR1020Q00layQueryRemarkResponse
				.newBuilder();

		String rs = nur9002Repository.callFnNurMergeRemark(getHospitalCode(vertx, sessionId), request.getBunho(),
				request.getInputDate());
		
		CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder()
				.setDataValue(rs);
		
		response.addLayItem(info);
		return response.build();
	}

}
