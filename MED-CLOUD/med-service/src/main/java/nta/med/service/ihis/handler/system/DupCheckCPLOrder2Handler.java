package nta.med.service.ihis.handler.system;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.cpl.Cpl0101Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.DupCheckCPLOrder2Request;
import nta.med.service.ihis.proto.SystemServiceProto.DupCheckCPLOrder2Response;

@Service
@Scope("prototype")
public class DupCheckCPLOrder2Handler extends
		ScreenHandler<SystemServiceProto.DupCheckCPLOrder2Request, SystemServiceProto.DupCheckCPLOrder2Response> {

	@Resource
	private Cpl0101Repository cpl0101Repository;
	
	@Override
	@Transactional(readOnly = true)
	public DupCheckCPLOrder2Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DupCheckCPLOrder2Request request) throws Exception {
		SystemServiceProto.DupCheckCPLOrder2Response.Builder response = SystemServiceProto.DupCheckCPLOrder2Response.newBuilder();
		
		if(!request.hasInputInfo()) return response.build();
		
		CommonModelProto.DupCheckCPLOrder2RequestInfo info = request.getInputInfo();
		String strCheck = cpl0101Repository.callFnCplLoadDupHangmog(getHospitalCode(vertx, sessionId)
				, getLanguage(vertx, sessionId)
				, info.getIoGubun()
				, info.getBunho()
				, info.getHangmogCode()
				, info.getSpecimenCode()
				, DateUtil.toDate(info.getCheckDate(), DateUtil.PATTERN_YYMMDD));
		
		response.setResult(strCheck);
		return response.build();
	}

}
