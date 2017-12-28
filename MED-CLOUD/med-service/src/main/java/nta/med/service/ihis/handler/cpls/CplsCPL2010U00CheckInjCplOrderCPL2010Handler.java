package nta.med.service.ihis.handler.cpls;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U00CheckInjCplOrderRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U00CheckInjCplOrderResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class CplsCPL2010U00CheckInjCplOrderCPL2010Handler extends ScreenHandler<CplsServiceProto.CPL2010U00CheckInjCplOrderRequest, CplsServiceProto.CPL2010U00CheckInjCplOrderResponse> {
	@Resource
	private Cpl2010Repository cpl2010Repository;
	
	@Override
	public boolean isValid(CPL2010U00CheckInjCplOrderRequest request,
			Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getOrderDate()) && DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	} 
	
	@Override
	@Transactional(readOnly = true)
	public CPL2010U00CheckInjCplOrderResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CPL2010U00CheckInjCplOrderRequest request) throws Exception {
		CplsServiceProto.CPL2010U00CheckInjCplOrderResponse.Builder response=CplsServiceProto.CPL2010U00CheckInjCplOrderResponse.newBuilder();
    	String checkInjCplOrder=cpl2010Repository.getCPL2010U00CheckInjCplOrder(request.getIoGubun(), request.getBunho(),
				 DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD), getHospitalCode(vertx, sessionId));
	
		 if(!StringUtils.isEmpty(checkInjCplOrder)){
			 response.setFnInjCplChkYn(checkInjCplOrder);
		 }
		 return response.build();
	}
}
