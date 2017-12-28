package nta.med.service.ihis.handler.cpls;

import javax.annotation.Resource;

import nta.med.data.dao.medi.cpl.Cpl1000Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U00BtnUrineClickRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U00BtnUrineClickResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CPL3010U00BtnUrineClickHandler extends ScreenHandler <CplsServiceProto.CPL3010U00BtnUrineClickRequest, CplsServiceProto.CPL3010U00BtnUrineClickResponse> {
	@Resource
	private Cpl1000Repository cpl1000Repository;
	
	@Override
	@Transactional(readOnly = true)
	public CPL3010U00BtnUrineClickResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CPL3010U00BtnUrineClickRequest request) throws Exception {
        CplsServiceProto.CPL3010U00BtnUrineClickResponse.Builder response = CplsServiceProto.CPL3010U00BtnUrineClickResponse.newBuilder();
        String result = cpl1000Repository.checkCPL3010U00BtnUrineClick(getHospitalCode(vertx, sessionId));
		if (!StringUtils.isEmpty(result)) {
			response.setValue(result);
		}
		return response.build();
	}
}
