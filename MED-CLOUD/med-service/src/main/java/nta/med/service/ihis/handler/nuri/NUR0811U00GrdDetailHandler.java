package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur0811;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.nur.Nur0811Repository;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0811U00GrdDetailRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0811U00GrdDetailResponse;

@Service
@Scope("prototype")
public class NUR0811U00GrdDetailHandler extends
		ScreenHandler<NuriServiceProto.NUR0811U00GrdDetailRequest, NuriServiceProto.NUR0811U00GrdDetailResponse> {

	@Resource
	private Nur0811Repository nur0811Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR0811U00GrdDetailResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0811U00GrdDetailRequest request) throws Exception {
		
		NuriServiceProto.NUR0811U00GrdDetailResponse.Builder response = NuriServiceProto.NUR0811U00GrdDetailResponse.newBuilder();
		
		List<Nur0811> listNur0811 = nur0811Repository.findByHospCodeNeedHType(getHospitalCode(vertx, sessionId), request.getNeedHType());
		if(!CollectionUtils.isEmpty(listNur0811)){
			for (Nur0811 nur0811 : listNur0811) {
				NuriModelProto.NUR0811U00GrdDetailInfo.Builder info = NuriModelProto.NUR0811U00GrdDetailInfo.newBuilder()
						.setNeedHType(nur0811.getNeedHType() == null ? "" : nur0811.getNeedHType())
						.setNeedType(nur0811.getNeedType() == null ? "" : nur0811.getNeedType());
				response.addGrdList(info);
			}
		}
		
		return response.build();
	}

}
