package nta.med.service.ihis.handler.cpls;
import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.cpl.Cpl0101Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U00Execute2ProceduresCheckRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U00Execute2ProceduresCheckResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CPL3020U00Execute2ProceduresCheckHandler extends ScreenHandler <CplsServiceProto.CPL3020U00Execute2ProceduresCheckRequest, CplsServiceProto.CPL3020U00Execute2ProceduresCheckResponse > {
	@Resource
	private Cpl0101Repository cpl0101Repository;
	
	@Override
	public boolean isValid(CPL3020U00Execute2ProceduresCheckRequest request,
			Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getOrderDateCplPanic()) && DateUtil.toDate(request.getOrderDateCplPanic(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	@Override
	@Transactional
	public CPL3020U00Execute2ProceduresCheckResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CPL3020U00Execute2ProceduresCheckRequest request) throws Exception {
        CplsServiceProto.CPL3020U00Execute2ProceduresCheckResponse.Builder response = CplsServiceProto.CPL3020U00Execute2ProceduresCheckResponse.newBuilder();
		String standardCplNum = cpl0101Repository.callPrCplNumStandardCheck(request.getResultCplNum(), request.getFromStandardCplNum(),
    			request.getToStandardCplNum(), "");
    	if(standardCplNum != null && !standardCplNum.isEmpty()){
    		response.setStandardCplNum(standardCplNum);
    	}
    	
    	String panicYn = cpl0101Repository.callPrCplPanicChk(getHospitalCode(vertx, sessionId), request.getBunhoCplPanic(), 
    			DateUtil.toDate(request.getOrderDateCplPanic(),DateUtil.PATTERN_YYMMDD), 
    			request.getGumsaCodeCplPanic(),request.getSpecimenCodeCplPanic(), request.getEmergencyCplPanic(), request.getResultCplNum(), "");
    	if(panicYn != null && !panicYn.isEmpty()){
    		response.setPanicYnCplPanic(panicYn);
    	}
    	return response.build();
	}
}
