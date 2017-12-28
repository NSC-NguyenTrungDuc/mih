package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.nur.Nur0801Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR8003R02cboHoDongRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

@Service
@Scope("prototype")
public class NUR8003R02cboHoDongHandler
		extends ScreenHandler<NuriServiceProto.NUR8003R02cboHoDongRequest, SystemServiceProto.ComboResponse> {

	@Resource
	private Nur0801Repository nur0801Repository;

	@Override
	@Transactional(readOnly = true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR8003R02cboHoDongRequest request) throws Exception {
		SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();

		List<ComboListItemInfo> items = nur0801Repository.getNUR8003R02cboHoDong(getHospitalCode(vertx, sessionId),
				request.getCboneedhtype());
		for (ComboListItemInfo item : items) {
			CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder()
					.setCode(item.getCode())
					.setCodeName(item.getCodeName());
			response.addComboItem(info);
		}
		
		return response.build();
	}

}
