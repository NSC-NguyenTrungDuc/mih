package nta.med.service.ihis.handler.cpls;

import javax.annotation.Resource;

import nta.med.data.dao.medi.cpl.Cpl0101Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0101U00CheckHangMogCopyRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0101U00CheckHangMogCopyResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CPL0101U00CheckHangMogCopyHandler extends ScreenHandler<CplsServiceProto.CPL0101U00CheckHangMogCopyRequest, CplsServiceProto.CPL0101U00CheckHangMogCopyResponse> {
	private static final Log LOGGER = LogFactory.getLog(CPL0101U00CheckHangMogCopyHandler.class);
	@Resource
	private Cpl0101Repository cpl0101Repository;
	
	@Override
	@Transactional(readOnly = true)
	public CPL0101U00CheckHangMogCopyResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CPL0101U00CheckHangMogCopyRequest request) throws Exception {
		CplsServiceProto.CPL0101U00CheckHangMogCopyResponse.Builder response = CplsServiceProto.CPL0101U00CheckHangMogCopyResponse.newBuilder();
		String result = cpl0101Repository.getCPL0101U00CheckHangmogCopy(getHospitalCode(vertx, sessionId), request.getHangmogCode(), request.getSpecimenCode(), request.getNewEmergency());
		if(result != null && !result.isEmpty()){
			response.setResult(true);
		} else {
			response.setResult(false);
		}
		return response.build();
	}
}
