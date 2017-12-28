package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur0105;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.nur.Nur0105Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020U00btnTimeApplyClickRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020U00btnTimeApplyClickResponse;

@Service
@Scope("prototype")
public class NUR1020U00btnTimeApplyClickHandler extends
		ScreenHandler<NuriServiceProto.NUR1020U00btnTimeApplyClickRequest, NuriServiceProto.NUR1020U00btnTimeApplyClickResponse> {

	@Resource
	private Nur0105Repository nur0105Repository;

	@Override
	@Transactional(readOnly = true)
	public NUR1020U00btnTimeApplyClickResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR1020U00btnTimeApplyClickRequest request) throws Exception {
		NuriServiceProto.NUR1020U00btnTimeApplyClickResponse.Builder response = NuriServiceProto.NUR1020U00btnTimeApplyClickResponse.newBuilder();
		List<Nur0105> items = nur0105Repository.findByHospCodeVspatnGubun(getHospitalCode(vertx, sessionId), request.getVspatnGubun());
		for (Nur0105 nur0105 : items) {
			CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder()
					.setDataValue(nur0105.getVspatnTime());
			response.addVspatnTime(info);
		}
		
		return response.build();
	}

}
