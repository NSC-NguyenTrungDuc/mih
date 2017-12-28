package nta.med.service.ihis.handler.system;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto.IsToiwonGojiYNandEndOrderRequestInfo;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.IsToiwonGojiYNandEndOrderRequest;
import nta.med.service.ihis.proto.SystemServiceProto.IsToiwonGojiYNandEndOrderResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class IsToiwonGojiYNandEndOrderHandler
	extends ScreenHandler<SystemServiceProto.IsToiwonGojiYNandEndOrderRequest, SystemServiceProto.IsToiwonGojiYNandEndOrderResponse> {                     
	@Resource                                                                                                       
	private Out0101Repository out0101Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public IsToiwonGojiYNandEndOrderResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			IsToiwonGojiYNandEndOrderRequest request) throws Exception {                                                                 
      	   	SystemServiceProto.IsToiwonGojiYNandEndOrderResponse.Builder response = SystemServiceProto.IsToiwonGojiYNandEndOrderResponse.newBuilder();                      
		IsToiwonGojiYNandEndOrderRequestInfo inputInfo = request.getInputInfo();
		if(inputInfo != null){
			String result = out0101Repository.OCSLibOrderBizGetIsToiwonGojiYNandEndOrder(getHospitalCode(vertx, sessionId),CommonUtils.parseDouble(inputInfo.getPkinp1001()));
			if(!StringUtils.isEmpty(result)){
				response.setToiwonGojiYn(result);
			}
		}
		return response.build();
	}
}