package nta.med.service.ihis.handler.nuri;

import java.util.ArrayList;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.drg.Drg0120Repository;
import nta.med.data.dao.medi.inv.Inv0110Repository;
import nta.med.data.dao.medi.ocs.Ocs0108Repository;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0110U00SetFindWorkerRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

@Service
@Scope("prototype")
public class NUR0110U00SetFindWorkerHandler
		extends ScreenHandler<NuriServiceProto.NUR0110U00SetFindWorkerRequest, SystemServiceProto.ComboResponse> {

	@Resource
	private Drg0120Repository drg0120Repository;
	
	@Resource
	private Ocs0132Repository ocs0132Repository;
	
	@Resource
	private Inv0110Repository inv0110Repository;
	
	@Resource
	private Ocs0108Repository ocs0108Repository;
	
	@Override
	@Transactional(readOnly = true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0110U00SetFindWorkerRequest request) throws Exception {
		SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		String caseVal = request.getCaseVal();
		String find1 = request.getFind1();
		String hangmogCode = request.getHangmogCode();
		
		List<ComboListItemInfo> cboItems = new ArrayList<ComboListItemInfo>();
		
		switch (caseVal) {
		case "bogyong_code1":
			cboItems = drg0120Repository.getNUR0110U00SetFindWorkerCombo(hospCode, language, find1, false);
			break;
			
		case "bogyong_code2":
			cboItems = drg0120Repository.getNUR0110U00SetFindWorkerCombo(hospCode, language, find1, true);
			break;
			
		case "jusa_code":
			cboItems = ocs0132Repository.findCbxByCodeTypeTextSearch(hospCode, language, "JUSA", find1);
			break;

		case "bom_source_key":
			cboItems = inv0110Repository.getOCS0103U00ComboListItemInfo(hospCode, find1);
			break;
		case "ord_danui":
			cboItems = ocs0108Repository.getComboNUR0110U00SetFindWorker(hospCode, language, hangmogCode);
			break;
		default:
			break;
		}
		
		if(!CollectionUtils.isEmpty(cboItems)){
			for (ComboListItemInfo item : cboItems) {
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder()
						.setCode(item.getCode())
						.setCodeName(item.getCodeName() == null ? "" : item.getCodeName());
				response.addComboItem(info);
			}
		}
		
		return response.build();
	}

	
}
