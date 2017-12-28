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
import nta.med.service.ihis.proto.NuriServiceProto.NUR9999R11comboBoxRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR9999R11comboBoxResponse;

@Service
@Scope("prototype")
public class NUR9999R11comboBoxHandler
		extends ScreenHandler<NuriServiceProto.NUR9999R11comboBoxRequest, NuriServiceProto.NUR9999R11comboBoxResponse> {

	@Resource
	private Nur0102Repository nur0102Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR9999R11comboBoxResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR9999R11comboBoxRequest request) throws Exception {
		NuriServiceProto.NUR9999R11comboBoxResponse.Builder response = NuriServiceProto.NUR9999R11comboBoxResponse
				.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<Nur0102> lstSumaryAdl = nur0102Repository.findByCodeTypeLanguage(hospCode, "SUMMARY_ADL", language);
		for (Nur0102 item : lstSumaryAdl) {
			CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder()
					.setCode(item.getCode())
					.setCodeName(item.getCodeName());
			response.addCbomoveadl(info);
			response.addCboexcretionadl(info);
			response.addCbowashadl(info);
			response.addCbowareadl(info);
			response.addCbofoodadl(info);
		}
		
		List<Nur0102> lstSumaryMoveWay = nur0102Repository.findByCodeTypeLanguage(hospCode, "SUMMARY_MOVE_WAY", language);
		for (Nur0102 item : lstSumaryMoveWay) {
			CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder()
					.setCode(item.getCode())
					.setCodeName(item.getCodeName());
			response.addCbomove(info);
		}
		
		List<Nur0102> lstcmtAdl = nur0102Repository.findByCodeTypeLanguage(hospCode, "COMMUNICATION_ADL", language);
		for (Nur0102 item : lstcmtAdl) {
			CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder()
					.setCode(item.getCode())
					.setCodeName(item.getCodeName());
			response.addCbocommunication(info);
		}
		
		List<Nur0102> lstSumaryGubun = nur0102Repository.findByCodeTypeLanguage(hospCode, "SUMMARY_GUBUN", language);
		for (Nur0102 item : lstSumaryGubun) {
			CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder()
					.setCode(item.getCode())
					.setCodeName(item.getCodeName());
			response.addCbogubun(info);
		}
		
		return response.build();
	}

}
