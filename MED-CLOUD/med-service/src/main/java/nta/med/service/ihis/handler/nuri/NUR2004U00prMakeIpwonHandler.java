package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.model.ihis.inps.PrIfsMakeIpwonHistoryResultInfo;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U00prMakeIpwonRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U00prMakeIpwonResponse;

@Service
@Scope("prototype")
public class NUR2004U00prMakeIpwonHandler extends
		ScreenHandler<NuriServiceProto.NUR2004U00prMakeIpwonRequest, NuriServiceProto.NUR2004U00prMakeIpwonResponse> {

	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Override
	@Transactional
	public NUR2004U00prMakeIpwonResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2004U00prMakeIpwonRequest request) throws Exception {
		NuriServiceProto.NUR2004U00prMakeIpwonResponse.Builder response = NuriServiceProto.NUR2004U00prMakeIpwonResponse.newBuilder();
		
		PrIfsMakeIpwonHistoryResultInfo pResult = inp1001Repository.callPrIfsMakeIpwonHistory(getHospitalCode(vertx, sessionId)
				, request.getProcGubun()
				, request.getBunho()
				, DateUtil.toDate(request.getDataDate(), DateUtil.PATTERN_YYMMDD)
				, request.getHoDong()
				, request.getHoCode()
				, request.getBedNo()
				, request.getIpwonGwa()
				, request.getDoctor()
				, CommonUtils.parseDouble(request.getFkinp1001())
				, request.getUserId()
				, request.getDataGubun()
				, request.getToiwonGubun());
		
		response.setPkifs3011(pResult.getPkifs3011() == null ? "" : String.valueOf(pResult.getPkifs3011()));
		response.setErr(pResult.getErr() == null ? "" : pResult.getErr());
		return response.build();
	}

}
