package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur0102;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.nur.Nur0102Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020U00GrdAndComboRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020U00GrdAndComboResponse;

@Service
@Scope("prototype")
public class NUR1020U00GrdAndComboHandler extends
		ScreenHandler<NuriServiceProto.NUR1020U00GrdAndComboRequest, NuriServiceProto.NUR1020U00GrdAndComboResponse> {

	@Resource
	private Nur0102Repository nur0102Repository;
	
	
	@Override
	@Transactional(readOnly = true)
	public NUR1020U00GrdAndComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR1020U00GrdAndComboRequest request) throws Exception {
		NuriServiceProto.NUR1020U00GrdAndComboResponse.Builder response = NuriServiceProto.NUR1020U00GrdAndComboResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<Nur0102> careList = nur0102Repository.findByCodeTypeLanguage(hospCode, "CARE_LIST", language);
		for (Nur0102 nur0102 : careList) {
			CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder()
					.setCode(nur0102.getCode()).setCodeName(nur0102.getCodeName());
			response.addGrdCare(info);
		}
		
		List<Nur0102> watchTemplateList = nur0102Repository.findByCodeTypeLanguage(hospCode, "WATCH_TEMPLATE", language);
		for (Nur0102 nur0102 : watchTemplateList) {
			CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder()
					.setCode(nur0102.getCode()).setCodeName(nur0102.getCodeName());
			response.addCboWatchTemp(info);
		}
		
		return response.build();
	}
}
