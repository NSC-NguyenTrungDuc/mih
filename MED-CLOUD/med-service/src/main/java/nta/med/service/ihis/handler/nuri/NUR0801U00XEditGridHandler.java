package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur0102;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.dao.medi.nur.Nur0102Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0801U00XEditGridRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0801U00XEditGridResponse;

@Service
@Scope("prototype")
public class NUR0801U00XEditGridHandler extends
		ScreenHandler<NuriServiceProto.NUR0801U00XEditGridRequest, NuriServiceProto.NUR0801U00XEditGridResponse> {

	@Resource
	private Bas0260Repository bas0260Repository;

	@Resource
	private Nur0102Repository nur0102Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR0801U00XEditGridResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0801U00XEditGridRequest request) throws Exception {
		NuriServiceProto.NUR0801U00XEditGridResponse.Builder response = NuriServiceProto.NUR0801U00XEditGridResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<ComboListItemInfo> cell12 = bas0260Repository.getBuseoCodeBuseoNameInVwGwaName(hospCode, language, "2");
		for (ComboListItemInfo item : cell12) {
			CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder()
					.setCode(item.getCode()).setCodeName(item.getCodeName());
			response.addCell12(info);
		}
		
		List<Nur0102> cell14 = nur0102Repository.findByCodeTypeLanguage(hospCode, "NEED_TYPE", language);
		for (Nur0102 item : cell14) {
			CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder()
					.setCode(item.getCode()).setCodeName(item.getCodeName());
			response.addCell14(info);
		}
		
		return response.build();
	}

}
