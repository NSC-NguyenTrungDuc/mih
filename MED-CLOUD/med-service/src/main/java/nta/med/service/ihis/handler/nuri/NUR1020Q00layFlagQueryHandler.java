package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.nur.Nur9002Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020Q00layFlagQueryRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020Q00layFlagQueryResponse;

@Service
@Scope("prototype")
public class NUR1020Q00layFlagQueryHandler extends
		ScreenHandler<NuriServiceProto.NUR1020Q00layFlagQueryRequest, NuriServiceProto.NUR1020Q00layFlagQueryResponse> {

	@Resource
	private Nur9002Repository nur9002Repository;

	@Override
	@Transactional(readOnly = true)
	public NUR1020Q00layFlagQueryResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR1020Q00layFlagQueryRequest request) throws Exception {
		NuriServiceProto.NUR1020Q00layFlagQueryResponse.Builder response = NuriServiceProto.NUR1020Q00layFlagQueryResponse
				.newBuilder();
		
		List<String> rs = nur9002Repository.getNUR1020Q00layFlagInfo(getHospitalCode(vertx, sessionId),
				request.getBunho(), request.getStartDate());
		
		for (String s : rs) {
			CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder()
					.setDataValue(s);
			response.addLayItem(info);
		}
		
		return response.build();
	}

}
