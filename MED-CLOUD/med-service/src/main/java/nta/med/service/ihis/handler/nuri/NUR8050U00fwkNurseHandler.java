package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.adm.Adm3200;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR8050U00fwkNurseRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

@Service
@Scope("prototype")
public class NUR8050U00fwkNurseHandler
		extends ScreenHandler<NuriServiceProto.NUR8050U00fwkNurseRequest, SystemServiceProto.ComboResponse> {

	@Resource
	private Adm3200Repository adm3200Repository;

	@Override
	@Transactional(readOnly = true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR8050U00fwkNurseRequest request) throws Exception {
		SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();

		List<Adm3200> items = adm3200Repository.getNUR8050U00fwkNurse(getHospitalCode(vertx, sessionId),
				request.getSabun() + "%", request.getBuseoCode());

		for (Adm3200 item : items) {
			CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder()
					.setCode(item.getUserId()).setCodeName(item.getUserNm());
			response.addComboItem(info);
		}

		return response.build();
	}

}
