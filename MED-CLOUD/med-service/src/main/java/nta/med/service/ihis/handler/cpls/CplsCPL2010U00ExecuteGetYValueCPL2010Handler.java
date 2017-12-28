package nta.med.service.ihis.handler.cpls;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U00ExecuteGetYValueRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U00ExecuteGetYValueResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class CplsCPL2010U00ExecuteGetYValueCPL2010Handler extends ScreenHandler <CplsServiceProto.CPL2010U00ExecuteGetYValueRequest, CplsServiceProto.CPL2010U00ExecuteGetYValueResponse> {
	@Resource
	private Cpl2010Repository cpl2010Repsository;
	@Override
	@Transactional(readOnly = true)
	public CPL2010U00ExecuteGetYValueResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CPL2010U00ExecuteGetYValueRequest request) throws Exception{
		 CplsServiceProto.CPL2010U00ExecuteGetYValueResponse.Builder response=CplsServiceProto.CPL2010U00ExecuteGetYValueResponse.newBuilder();
		 String getYValue=cpl2010Repsository.getCPL2010U00ExecuteGetYValue(getHospitalCode(vertx, sessionId) ,CommonUtils.parseDouble(request.getPkcpl2010()));
		 if(!StringUtils.isEmpty(getYValue)){
			 response.setYValue(getYValue);
		 }
		 return response.build();
	}
}
