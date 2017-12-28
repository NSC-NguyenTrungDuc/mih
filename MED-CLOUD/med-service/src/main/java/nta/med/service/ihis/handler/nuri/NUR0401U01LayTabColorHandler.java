package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.nur.Nur0403Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0401U01LayTabColorRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0401U01LayTabColorResponse;

@Service
@Scope("prototype")
public class NUR0401U01LayTabColorHandler extends
		ScreenHandler<NuriServiceProto.NUR0401U01LayTabColorRequest, NuriServiceProto.NUR0401U01LayTabColorResponse> {

	@Resource
	private Nur0403Repository nur0403Repository;

	@Override
	@Transactional(readOnly = true)
	public NUR0401U01LayTabColorResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0401U01LayTabColorRequest request) throws Exception {
		NuriServiceProto.NUR0401U01LayTabColorResponse.Builder response = NuriServiceProto.NUR0401U01LayTabColorResponse
				.newBuilder();
		
		List<String> items = nur0403Repository.findNurPlanOteByHospCodeNurPlanJin(getHospitalCode(vertx, sessionId),
				request.getNurPlanJin());
		
		for (String item : items) {
			if(item != null){
				CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder().setDataValue(item);
				response.addLayList(info);
			}
		}
		
		return response.build();
	}

}
