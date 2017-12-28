package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.nur.Nur1122Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020Q00layNUR1122ListRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020Q00layNUR1122ListResponse;

@Service
@Scope("prototype")
public class NUR1020Q00layNUR1122ListHandler extends
		ScreenHandler<NuriServiceProto.NUR1020Q00layNUR1122ListRequest, NuriServiceProto.NUR1020Q00layNUR1122ListResponse> {

	@Resource
	private Nur1122Repository nur1122Repository;

	@Override
	@Transactional(readOnly = true)
	public NUR1020Q00layNUR1122ListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR1020Q00layNUR1122ListRequest request) throws Exception {
		NuriServiceProto.NUR1020Q00layNUR1122ListResponse.Builder response = NuriServiceProto.NUR1020Q00layNUR1122ListResponse.newBuilder();
		
		List<ComboListItemInfo> items = nur1122Repository.getNUR1020Q00layNUR1122List(getHospitalCode(vertx, sessionId),
				request.getBunho(), CommonUtils.parseDouble(request.getFkinp1001()), request.getYmd());
		
		for (ComboListItemInfo item : items) {
			CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder()
					.setCode(item.getCode())
					.setCodeName(item.getCodeName());
			response.addLayItem(info);
		}
		
		return response.build();
	}

}
