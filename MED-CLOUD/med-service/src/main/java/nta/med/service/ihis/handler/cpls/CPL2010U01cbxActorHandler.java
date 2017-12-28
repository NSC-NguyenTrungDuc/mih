package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U01cbxActorRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

@Service
@Scope("prototype")
public class CPL2010U01cbxActorHandler
		extends ScreenHandler<CplsServiceProto.CPL2010U01cbxActorRequest, SystemServiceProto.ComboResponse> {

	@Resource
	private Adm3200Repository adm3200Repository;

	@Override
	@Transactional(readOnly = true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			CPL2010U01cbxActorRequest request) throws Exception {

		SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();
		CommonModelProto.ComboListItemInfo.Builder firstInfo = CommonModelProto.ComboListItemInfo.newBuilder()
				.setCode("").setCodeName("");

		response.addComboItem(firstInfo);

		List<ComboListItemInfo> infos = adm3200Repository.getCbxActorKist(getHospitalCode(vertx, sessionId));
		if (!CollectionUtils.isEmpty(infos)) {
			for (ComboListItemInfo info : infos) {
				CommonModelProto.ComboListItemInfo.Builder pInfo = CommonModelProto.ComboListItemInfo.newBuilder()
						.setCode(info.getCode()).setCodeName(info.getCodeName());
				response.addComboItem(pInfo);
			}
		}

		return response.build();
	}

}
