package nta.med.service.ihis.handler.system;

import javax.annotation.Resource;

import nta.med.data.dao.medi.cpl.Cpl0101Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto.DupCheckCPLOrder1RequestInfo;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.DupCheckCPLOrder1Request;
import nta.med.service.ihis.proto.SystemServiceProto.DupCheckCPLOrder1Response;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class DupCheckCPLOrder1Handler
	extends ScreenHandler<SystemServiceProto.DupCheckCPLOrder1Request, SystemServiceProto.DupCheckCPLOrder1Response> {                     
	@Resource                                                                                                       
	private Cpl0101Repository cpl0101Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public DupCheckCPLOrder1Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId, DupCheckCPLOrder1Request request)
			throws Exception {                                                                   
  	   	SystemServiceProto.DupCheckCPLOrder1Response.Builder response = SystemServiceProto.DupCheckCPLOrder1Response.newBuilder();                      
		DupCheckCPLOrder1RequestInfo inputInfo = request.getInputInfo();
		if(inputInfo != null){
			String result = cpl0101Repository.callFnCplLoadDupGrdHangmog(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), inputInfo.getNewHangmogCode(), 
					inputInfo.getNewSpecimenCode(), inputInfo.getOldHangmogCode(), inputInfo.getOldSpecimenCode());
			if(!StringUtils.isEmpty(result)){
				response.setResult(result);
			}
		}
		return response.build();
	}
}