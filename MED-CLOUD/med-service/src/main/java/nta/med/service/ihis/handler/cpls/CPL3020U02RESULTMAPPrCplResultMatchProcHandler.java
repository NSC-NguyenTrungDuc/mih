package nta.med.service.ihis.handler.cpls;

import javax.annotation.Resource;

import nta.med.data.dao.medi.cpl.Cpl3020Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U02RESULTMAPPrCplResultMatchProcRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class CPL3020U02RESULTMAPPrCplResultMatchProcHandler extends ScreenHandler<CplsServiceProto.CPL3020U02RESULTMAPPrCplResultMatchProcRequest, SystemServiceProto.UpdateResponse> {                             
	@Resource                                                                                                       
	private Cpl3020Repository cpl3020Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CPL3020U02RESULTMAPPrCplResultMatchProcRequest request)
			throws Exception { 
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
    	String result = cpl3020Repository.callPrCplResultMatchProc(request.getProcGubun() , getHospitalCode(vertx, sessionId), request.getSpecimenSer(), request.getHangmogCode(),
    			request.getResultVal(), request.getJangbiCode(), request.getResultDate(), request.getSampleId(), request.getResultCode(), "");
    	if(request != null && !result.isEmpty()){
    		response.setResult(true);
    	}else{
    		response.setResult(false);
    	}
    	return response.build();
	}
}                                                                                                                 
