package nta.med.service.ihis.handler.system;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.service.ihis.proto.CommonModelProto.DupCheckInputInpOrderRequestInfo;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.DupCheckInputInpOrderRequest;
import nta.med.service.ihis.proto.SystemServiceProto.DupCheckInputInpOrderResponse;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class DupCheckInputInpOrderHandler 
	extends ScreenHandler<SystemServiceProto.DupCheckInputInpOrderRequest, SystemServiceProto.DupCheckInputInpOrderResponse> {        
	
	@Resource                                                                                                       
	private Inp1001Repository inp1001Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public DupCheckInputInpOrderResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			DupCheckInputInpOrderRequest request) throws Exception {                                                                
  	   	SystemServiceProto.DupCheckInputInpOrderResponse.Builder response = SystemServiceProto.DupCheckInputInpOrderResponse.newBuilder();                      
		DupCheckInputInpOrderRequestInfo info=request.getInputInfo();
		if(info !=null){
        	String checkInput=inp1001Repository.callFnOcsDupInpOrderCheck(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),
					info.getBunho(),CommonUtils.parseInteger(info.getFkinp1001()),info.getOrderDate(),info.getHangmogCode(),info.getHopeDate());
        	if(!StringUtils.isEmpty(checkInput)){
        		response.setResult(checkInput);
        	}
		}
		return response.build();
	}
}