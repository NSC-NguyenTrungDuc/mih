package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur0803;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.nur.Nur0803Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0812U00FwkGubunRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

@Service
@Scope("prototype")
public class NUR0812U00FwkGubunHandler
		extends ScreenHandler<NuriServiceProto.NUR0812U00FwkGubunRequest, SystemServiceProto.ComboResponse> {

	@Resource
	private Nur0803Repository nur0803Repository;

	@Override
	@Transactional(readOnly = true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0812U00FwkGubunRequest request) throws Exception {

		SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);

		List<Nur0803> listNur0803 = nur0803Repository.findByNeedGubun(hospCode, request.getNeedGubun());
		if (!CollectionUtils.isEmpty(listNur0803)) {
			for (Nur0803 nur0803 : listNur0803) {
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder()
						.setCode(nur0803.getNeedAsmtCode())
						.setCodeName(nur0803.getNeedAsmtName());
				
				response.addComboItem(info);
			}
		}

		return response.build();
	}

}
