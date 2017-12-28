package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur0803;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.nur.Nur0803Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0802U00fwkGubunRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

@Service
@Scope("prototype")
public class NUR0802U00fwkGubunHandler
		extends ScreenHandler<NuriServiceProto.NUR0802U00fwkGubunRequest, SystemServiceProto.ComboResponse> {

	@Resource
	private Nur0803Repository nur0803Repository;

	@Override
	@Transactional(readOnly = true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0802U00fwkGubunRequest request) throws Exception {
		SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();
		List<Nur0803> items = nur0803Repository.findByNeedGubun(getHospitalCode(vertx, sessionId), request.getNeedGubun());
		
		for (Nur0803 item : items) {
			CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder()
					.setCode(item.getNeedAsmtCode())
					.setCodeName(item.getNeedAsmtName() == null ? "" : item.getNeedAsmtName());
			response.addComboItem(info);
		}
		
		return response.build();
	}
}
