package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur0101;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.nur.Nur0101Repository;
import nta.med.data.dao.medi.nur.Nur0102Repository;
import nta.med.data.dao.medi.nur.Nur0801Repository;
import nta.med.data.dao.medi.nur.Nur0802Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0802U00xEditGridCelRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0802U00xEditGridCelResponse;

@Service
@Scope("prototype")
public class NUR0802U00xEditGridCelHandler extends
		ScreenHandler<NuriServiceProto.NUR0802U00xEditGridCelRequest, NuriServiceProto.NUR0802U00xEditGridCelResponse> {

	@Resource
	private Nur0101Repository nur0101Repository;
	
	@Resource
	private Nur0102Repository nur0102Repository;
	
	@Resource
	private Nur0802Repository nur0802Repository;
	
	@Resource
	private Nur0801Repository nur0801Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR0802U00xEditGridCelResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0802U00xEditGridCelRequest request) throws Exception {
		NuriServiceProto.NUR0802U00xEditGridCelResponse.Builder response = NuriServiceProto.NUR0802U00xEditGridCelResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<Nur0101> lstNur0101 = nur0101Repository.findByAdminGubun(language, "USER");
		for (Nur0101 item : lstNur0101) {
			CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder()
					.setCode(item.getCodeType() == null ? "" : item.getCodeType())
					.setCodeName(item.getCodeTypeName() == null ? "" : item.getCodeTypeName());
			response.addLaycomboitems(info);
		}
		
		List<ComboListItemInfo> cbx1 = nur0802Repository.getNUR0802U00xEditGridCel1(hospCode, language);
		for (ComboListItemInfo item : cbx1) {
			CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder()
					.setCode(item.getCode())
					.setCodeName(item.getCodeName());
			response.addXeditgridcell1(info);
		}
		
		List<ComboListItemInfo> cbx3 = nur0801Repository.getNUR0802U00xEditGridCel3(hospCode, language);
		for (ComboListItemInfo item : cbx3) {
			CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder()
					.setCode(item.getCode())
					.setCodeName(item.getCodeName());
			response.addXeditgridcell3(info);
		}
		
		return response.build();
	}

	
}
