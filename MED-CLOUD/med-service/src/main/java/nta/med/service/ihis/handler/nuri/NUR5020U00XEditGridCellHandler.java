package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.bas.Bas0102;
import nta.med.core.domain.bas.Bas0260;
import nta.med.core.domain.nur.Nur0102;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.dao.medi.nur.Nur0102Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR5020U00XEditGridCellRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR5020U00XEditGridCellResponse;

@Service
@Scope("prototype")
public class NUR5020U00XEditGridCellHandler extends
		ScreenHandler<NuriServiceProto.NUR5020U00XEditGridCellRequest, NuriServiceProto.NUR5020U00XEditGridCellResponse> {

	@Resource
	private Nur0102Repository nur0102Repository;
	
	@Resource
	private Bas0260Repository bas0260Repository;
	
	@Resource
	private Bas0102Repository bas0102Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR5020U00XEditGridCellResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR5020U00XEditGridCellRequest request) throws Exception {
		NuriServiceProto.NUR5020U00XEditGridCellResponse.Builder response = NuriServiceProto.NUR5020U00XEditGridCellResponse
				.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		// xEditGridCell9
		List<Nur0102> xEditGridCell9List = nur0102Repository.findByCodeTypeLanguage(hospCode, "WOICHUL_WOPIBAK_GUBUN", language);
		for (Nur0102 item : xEditGridCell9List) {
			CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder()
					.setCode(item.getCode())
					.setCodeName(item.getCodeName());
			response.addXeditgridcell9(info);
		}
		
		// xEditGridCell39
		List<Nur0102> xEditGridCell39List = nur0102Repository.findByCodeTypeLanguage(hospCode, "JUNGWA_JUNSIL", language);
		for (Nur0102 item : xEditGridCell39List) {
			CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder()
					.setCode(item.getCode())
					.setCodeName(item.getCodeName());
			response.addXeditgridcell39(info);
		}
		
		// xEditGridCell43, xEditGridCell44, xEditGridCell29, xEditGridCell51, xEditGridCell72, fwkGwa
		List<Bas0260> xEditGridCell43List = bas0260Repository.findByHospCodeGwaBuseoGubunSysDate(hospCode, language, "1");
		for (Bas0260 item : xEditGridCell43List) {
			CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder()
					.setCode(item.getGwa())
					.setCodeName(item.getGwaName());
			response.addXeditgridcell43(info);
			response.addXeditgridcell44(info);
			response.addXeditgridcell29(info);
			response.addXeditgridcell51(info);
			response.addXeditgridcell72(info);
			response.addFwkgwa(info);
		}
		
		// xEditGridCell121, xEditGridCell35, xEditGridCell79
		List<Bas0102> blist = bas0102Repository.getByCodeType(hospCode, "SEX", language);
		for (Bas0102 item : blist) {
			CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder()
					.setCode(item.getCode())
					.setCodeName(item.getCodeName());
			response.addXeditgridcell121(info);
			response.addXeditgridcell35(info);
			response.addXeditgridcell79(info);
		}
		
		// xEditGridCell28
		List<Nur0102> xEditGridCell28List = nur0102Repository.findByCodeTypeLanguage(hospCode, "IPWON_TOIWON", language);
		for (Nur0102 item : xEditGridCell28List) {
			CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder()
					.setCode(item.getCode())
					.setCodeName(item.getCodeName());
			response.addXeditgridcell28(info);
		}
		
		// xEditGridCell71
		List<Nur0102> xEditGridCell71List = nur0102Repository.findByCodeTypeLanguage(hospCode, "WATCHLIST", language);
		for (Nur0102 item : xEditGridCell71List) {
			CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder()
					.setCode(item.getCode())
					.setCodeName(item.getCodeName());
			response.addXeditgridcell71(info);
		}
		
		// xEditGridCell21
		List<Nur0102> xEditGridCell21List = nur0102Repository.findByCodeTypeLanguage(hospCode, "NURSE_GRADE", language);
		for (Nur0102 item : xEditGridCell21List) {
			CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder()
					.setCode(item.getCode())
					.setCodeName(item.getCodeName());
			response.addXeditgridcell21(info);
		}
		
		// xEditGridCell22
		List<Nur0102> xEditGridCell22List = nur0102Repository.findByCodeTypeLanguage(hospCode, "WORK_TYPE_IN", language);
		for (Nur0102 item : xEditGridCell22List) {
			CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder()
					.setCode(item.getCode())
					.setCodeName(item.getCodeName());
			response.addXeditgridcell22(info);
		}
		
		return response.build();
	}

}
