package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur0401;
import nta.med.core.domain.nur.Nur0404;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.nur.Nur0401Repository;
import nta.med.data.dao.medi.nur.Nur0403Repository;
import nta.med.data.dao.medi.nur.Nur0404Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0401U01IsExistDetailRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class NUR0401U01IsExistDetailHandler
		extends ScreenHandler<NuriServiceProto.NUR0401U01IsExistDetailRequest, SystemServiceProto.StringResponse> {

	@Resource
	private Nur0401Repository nur0401Repository;
	
	@Resource
	private Nur0403Repository nur0403Repository;
	
	@Resource
	private Nur0404Repository nur0404Repository;
	
	@Override
	@Transactional(readOnly = true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0401U01IsExistDetailRequest request) throws Exception {
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String caseVal = request.getCaseValue();
		String param1 = request.getParam1();
		String param2 = request.getParam2();
		String rs = "";
		
		if("grdNUR0102".equals(caseVal)){
			List<Nur0401> items = nur0401Repository.findByHospCodeNurPlanBunryu(hospCode, param1);
			rs = CollectionUtils.isEmpty(items) ? "" : "Y";
		}
		else if("grdNUR0401".equals(caseVal)){
			List<String> items = nur0403Repository.findNurPlanOteByHospCodeNurPlanJin(hospCode, param1);
			rs = CollectionUtils.isEmpty(items) ? "" : "Y";
		}
		else if("grdNUR0403".equals(caseVal)){
			List<Nur0404> items = nur0404Repository.findByHospCodeNurPlanJinNurPlan(hospCode, param1, CommonUtils.parseDouble(param2));
			rs = CollectionUtils.isEmpty(items) ? "" : "Y";
		}
			
		response.setResult(rs);
		return response.build();
	}

}
