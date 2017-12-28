package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.drg.Drg0120;
import nta.med.core.domain.inv.Inv0110;
import nta.med.core.domain.ocs.Ocs0132;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.cht.Cht0118Repository;
import nta.med.data.dao.medi.drg.Drg0120Repository;
import nta.med.data.dao.medi.inv.Inv0110Repository;
import nta.med.data.dao.medi.ocs.Ocs0108Repository;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0110U00GrdNUR0115ColChangeRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class NUR0110U00GrdNUR0115ColChangeHandler extends
		ScreenHandler<NuriServiceProto.NUR0110U00GrdNUR0115ColChangeRequest, SystemServiceProto.StringResponse> {

	@Resource
	private Drg0120Repository drg0120Repository;
	
	@Resource
	private Cht0118Repository cht0118Repository;
	
	@Resource
	private Ocs0132Repository ocs0132Repository;
	
	@Resource
	private Inv0110Repository inv0110Repository;
	
	@Resource
	private Ocs0108Repository ocs0108Repository;
	
	@Override
	@Transactional(readOnly = true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0110U00GrdNUR0115ColChangeRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		String caseVal = request.getCaseVal();
		String param1 = request.getParam1();
		String param2 = request.getParam2();
		String strResult = "";
		
		switch (caseVal) {
		case "bogyong_code1":
			List<Drg0120> lstDrg0120 = drg0120Repository.getObjectOBGetBogyongInfo(hospCode, param1, language);
			strResult = CollectionUtils.isEmpty(lstDrg0120) ? "" : lstDrg0120.get(0).getBogyongName();
			break;

		case "bogyong_code2":
			strResult = cht0118Repository.getOCS2005U00BuwiName(hospCode, param1);
			break;

		case "jusa_code":
			List<Ocs0132> lstOcs0132 = ocs0132Repository.findByHospCodeCodeTypeCode(hospCode, language, "JUSA", param1);
			strResult = CollectionUtils.isEmpty(lstOcs0132) ? "" : lstOcs0132.get(0).getCodeName();
			break;

		case "bom_source_key":
			List<Inv0110> lstInv0110 = inv0110Repository.findByHospCodeJaeryoCode(hospCode, param1);
			strResult = CollectionUtils.isEmpty(lstInv0110) ? "" : lstInv0110.get(0).getJaeryoName();
			break;

		case "ord_danui":
			List<String> rs = ocs0108Repository.getNUR0110U00GrdNUR0115ColChangeCaseOrdDanui(hospCode, language, param1, param2);
			strResult = CollectionUtils.isEmpty(rs) ? "" : rs.get(0);
			break;
		default:
			break;
		}
		
		response.setResult(strResult == null ? "" : strResult);
		return response.build();
	}

}
