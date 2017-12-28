package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020U00SetCycleOrderGroupRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class NUR1020U00SetCycleOrderGroupHandler
		extends ScreenHandler<NuriServiceProto.NUR1020U00SetCycleOrderGroupRequest, SystemServiceProto.UpdateResponse> {

	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR1020U00SetCycleOrderGroupRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String caseVal = request.getCaseVal();
		Double pkinp1001 = CommonUtils.parseDouble(request.getPkinp1001());
		
		String cycleOrderGroup = "";
		if("1".equals(caseVal)){
			cycleOrderGroup = "P";
		} else if("2".equals(caseVal)){
			cycleOrderGroup = "G";
		} else if("3".equals(caseVal)){
			cycleOrderGroup = null;
		}
		
		inp1001Repository.updateCycleOrderGroupByPkInp1001(hospCode, pkinp1001, cycleOrderGroup);
		
		response.setResult(true);
		return response.build();
	}

}
