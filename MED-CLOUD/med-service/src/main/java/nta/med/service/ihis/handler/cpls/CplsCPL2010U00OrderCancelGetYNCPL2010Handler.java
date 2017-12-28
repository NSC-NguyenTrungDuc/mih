package nta.med.service.ihis.handler.cpls;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U00OrderCancelGetYNRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U00OrderCancelGetYNResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class CplsCPL2010U00OrderCancelGetYNCPL2010Handler extends ScreenHandler <CplsServiceProto.CPL2010U00OrderCancelGetYNRequest, CplsServiceProto.CPL2010U00OrderCancelGetYNResponse> {
	@Resource
	private Ocs1003Repository ocs1003Repository;
	@Override
	@Transactional(readOnly = true)
	public CPL2010U00OrderCancelGetYNResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CPL2010U00OrderCancelGetYNRequest request) throws Exception {
		 CplsServiceProto.CPL2010U00OrderCancelGetYNResponse.Builder response=CplsServiceProto.CPL2010U00OrderCancelGetYNResponse.newBuilder();
		 String getYN=ocs1003Repository.getOrderCancelGetYN(CommonUtils.parseDouble(request.getFkocs1003()));
		 if(!StringUtils.isEmpty(getYN)){
			 response.setYnValue(getYN);
		 }
		 return response.build();
	}
}
