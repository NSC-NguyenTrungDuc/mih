package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.nur.Nur0403Repository;
import nta.med.data.model.ihis.nuri.NUR4001U00LayPlanQueryStartInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;

@Service
@Scope("prototype")
public class NUR4001U00LayPlanQueryStartHandler extends
		ScreenHandler<NuriServiceProto.NUR4001U00LayPlanQueryStartRequest, NuriServiceProto.NUR4001U00LayPlanQueryStartResponse> {

	@Resource
	private Nur0403Repository nur0403Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR4001U00LayPlanQueryStartResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, NuriServiceProto.NUR4001U00LayPlanQueryStartRequest request) throws Exception {

		NuriServiceProto.NUR4001U00LayPlanQueryStartResponse.Builder response = NuriServiceProto.NUR4001U00LayPlanQueryStartResponse
				.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		String caseVal = request.getCaseVal();
		String nurPlanJin = request.getNurPlanJin();
		Double fknur4001 = CommonUtils.parseDouble(request.getFknur4001());
		
		List<NUR4001U00LayPlanQueryStartInfo> infos;
		
		if("1".equals(caseVal)){
			infos = nur0403Repository.getNUR4001U00LayPlanQueryStartInfoCase1(hospCode, nurPlanJin, fknur4001);
		}
		else {
			infos = nur0403Repository.getNUR4001U00LayPlanQueryStartInfoCase2(hospCode, fknur4001);
		}
		
		for (NUR4001U00LayPlanQueryStartInfo item : infos) {
			NuriModelProto.NUR4001U00LayPlanQueryStartInfo.Builder info = NuriModelProto.NUR4001U00LayPlanQueryStartInfo.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			response.addLayList(info);
		}
		
		return response.build();
	}
}
