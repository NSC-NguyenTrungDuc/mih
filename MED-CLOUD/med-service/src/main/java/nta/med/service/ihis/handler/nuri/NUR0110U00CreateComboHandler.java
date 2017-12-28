package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.ocs.Ocs0132;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0110U00CreateComboRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0110U00CreateComboResponse;

@Service
@Scope("prototype")
public class NUR0110U00CreateComboHandler extends
		ScreenHandler<NuriServiceProto.NUR0110U00CreateComboRequest, NuriServiceProto.NUR0110U00CreateComboResponse> {

	@Resource
	private Ocs0132Repository ocs0132Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR0110U00CreateComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0110U00CreateComboRequest request) throws Exception {
		NuriServiceProto.NUR0110U00CreateComboResponse.Builder response = NuriServiceProto.NUR0110U00CreateComboResponse.newBuilder();
		
		List<Ocs0132> jisiOrderGubunList = ocs0132Repository.getByCodeType(getHospitalCode(vertx, sessionId),
				getLanguage(vertx, sessionId), "JISI_ORDER_GUBUN");
		for (Ocs0132 item : jisiOrderGubunList) {
			CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder()
					.setCode(item.getCode())
					.setCodeName(item.getCodeName() == null ? "" : item.getCodeName());
			response.addJisiOrderGubun(info);
		}	
		
		List<Ocs0132> ordDanuiList = ocs0132Repository.getByCodeType(getHospitalCode(vertx, sessionId),
				getLanguage(vertx, sessionId), "ORD_DANUI");
		for (Ocs0132 item : ordDanuiList) {
			CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder()
					.setCode(item.getCode())
					.setCodeName(item.getCodeName() == null ? "" : item.getCodeName());
			response.addOrdDanui(info);
		}
		
		List<Ocs0132> dvTimeList = ocs0132Repository.getByCodeType(getHospitalCode(vertx, sessionId),
				getLanguage(vertx, sessionId), "DV_TIME");
		for (Ocs0132 item : dvTimeList) {
			CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder()
					.setCode(item.getCode())
					.setCodeName(item.getCodeName() == null ? "" : item.getCodeName());
			response.addDvTime(info);
		}
		
		List<Ocs0132> jusaSpdGubun = ocs0132Repository.getByCodeType(getHospitalCode(vertx, sessionId),
				getLanguage(vertx, sessionId), "JUSA_SPD_GUBUN");
		for (Ocs0132 item : jusaSpdGubun) {
			CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder()
					.setCode(item.getCode())
					.setCodeName(item.getCodeName() == null ? "" : item.getCodeName());
			response.addJusaSpdGubun(info);
		}
		
		return response.build();
	}

}
