package nta.med.service.ihis.handler.cpls;
import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.data.dao.medi.ocs.Ocs5010Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U00PrOcsUpdateResultRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class CPL3020U00PrOcsUpdateResultHandler extends ScreenHandler <CplsServiceProto.CPL3020U00PrOcsUpdateResultRequest, SystemServiceProto.UpdateResponse> {
	@Resource
	private Ocs5010Repository ocs5010Repository;
	
	@Resource
	private Cpl2010Repository cpl2010Repository;
	
	@Override
	public boolean isValid(CPL3020U00PrOcsUpdateResultRequest request,
			Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getResultDate()) && DateUtil.toDate(request.getResultDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CPL3020U00PrOcsUpdateResultRequest request) throws Exception {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        ocs5010Repository.callPrOcsUpdateResult(getHospitalCode(vertx, sessionId), request.getInOutGubun(),
        		CommonUtils.parseDouble(request.getFkocs()), request.getResultBuseo(), DateUtil.toDate(request.getResultDate(), DateUtil.PATTERN_YYMMDD)); 
        response.setResult(true);
        return response.build();
	}
}
