package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur5200Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR5020U00layConfirmYnRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR5020U00layConfirmYnResponse;

@Service
@Scope("prototype")
public class NUR5020U00layConfirmYnHandler extends
		ScreenHandler<NuriServiceProto.NUR5020U00layConfirmYnRequest, NuriServiceProto.NUR5020U00layConfirmYnResponse> {

	@Resource
	private Nur5200Repository nur5200Repository;

	@Override
	@Transactional(readOnly = true)
	public NUR5020U00layConfirmYnResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR5020U00layConfirmYnRequest request) throws Exception {
		NuriServiceProto.NUR5020U00layConfirmYnResponse.Builder response = NuriServiceProto.NUR5020U00layConfirmYnResponse
				.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);

		String rs = nur5200Repository.getNUR5020U00layConfirmYn(hospCode,
				DateUtil.toDate(request.getDate(), DateUtil.PATTERN_YYMMDD), request.getHoDong());
		CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder()
				.setDataValue(rs);
		response.addLayItem(info);
		return response.build();
	}

}
