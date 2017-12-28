package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR5020U00fwkNurseRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

@Service
@Scope("prototype")
public class NUR5020U00fwkNurseHandler
		extends ScreenHandler<NuriServiceProto.NUR5020U00fwkNurseRequest, SystemServiceProto.ComboResponse> {

	@Resource
	private Adm3200Repository adm3200Repository;

	@Override
	@Transactional(readOnly = true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR5020U00fwkNurseRequest request) throws Exception {
		SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);

		List<ComboListItemInfo> items = adm3200Repository.getNUR5020U00fwkNurse(hospCode, request.getBuseoCode(),
				request.getFind1() + "%");
		for (ComboListItemInfo item : items) {
			CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder()
					.setCode(item.getCode()).setCodeName(item.getCodeName());
			response.addComboItem(info);
		}

		return response.build();
	}

}
