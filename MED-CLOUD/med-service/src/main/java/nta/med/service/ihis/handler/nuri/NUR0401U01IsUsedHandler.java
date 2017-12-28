package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur4001;
import nta.med.core.domain.nur.Nur4003;
import nta.med.core.domain.nur.Nur4004;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.nur.Nur0401Repository;
import nta.med.data.dao.medi.nur.Nur4001Repository;
import nta.med.data.dao.medi.nur.Nur4003Repository;
import nta.med.data.dao.medi.nur.Nur4004Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0401U01IsUsedRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class NUR0401U01IsUsedHandler
		extends ScreenHandler<NuriServiceProto.NUR0401U01IsUsedRequest, SystemServiceProto.StringResponse> {

	@Resource
	private Nur0401Repository nur0401Repository;
	
	@Resource
	private Nur4001Repository nur4001Repository;
	
	@Resource
	private Nur4003Repository nur4003Repository;
	
	@Resource
	private Nur4004Repository nur4004Repository;
	
	@Override
	@Transactional(readOnly = true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0401U01IsUsedRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String caseVal = request.getCaseValue();
		String param1 = request.getParam1();
		String param2 = request.getParam2();
		String rs = "";
		
		switch (caseVal) {
		case "grdNUR0102":
			//TODO Wrong original SQL
			break;
		case "grdNUR0401":
			List<Nur4001> chk1 = nur4001Repository.findByHospCodeNurPlanJin(hospCode, param1);
			rs = CollectionUtils.isEmpty(chk1) ? "" : "Y";
			break;
		case "grdNUR0403":
			List<Nur4003> chk2 = nur4003Repository.findByHospCodeNurPlan(hospCode, CommonUtils.parseDouble(param1));
			rs = CollectionUtils.isEmpty(chk2) ? "" : "Y";
			break;
		case "grdNUR0404":
			List<Nur4004> chk3 = nur4004Repository.findByHospCodeNurPlanNurPlanDetail(hospCode, CommonUtils.parseDouble(param1), param2);
			rs = CollectionUtils.isEmpty(chk3) ? "" : "Y";
			break;
		default:
			break;
		}

		response.setResult(rs);
		return response.build();
	}

}
