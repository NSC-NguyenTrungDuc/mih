package nta.med.service.ihis.handler.system;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto.IsOrderDataChangedEnabledRequestInfo;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.IsOrderDataChangedEnabledRequest;
import nta.med.service.ihis.proto.SystemServiceProto.IsOrderDataChangedEnabledResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class IsOrderDataChangedEnabledHandler
	extends ScreenHandler<SystemServiceProto.IsOrderDataChangedEnabledRequest, SystemServiceProto.IsOrderDataChangedEnabledResponse> {                             
	@Resource                                                                                                       
	private Ocs1003Repository ocs1003Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public IsOrderDataChangedEnabledResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			IsOrderDataChangedEnabledRequest request) throws Exception {                                                             
      	   	SystemServiceProto.IsOrderDataChangedEnabledResponse.Builder response = SystemServiceProto.IsOrderDataChangedEnabledResponse.newBuilder();                      
		IsOrderDataChangedEnabledRequestInfo item = request.getInputInfo();
		if(item != null){
			String result = ocs1003Repository.callFnOcsCheckOrderInputYn(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), item.getIudGubun(), item.getAioeGubun(), CommonUtils.parseDouble(item.getPkocskey()));
			if(!StringUtils.isEmpty(result)){
				response.setResult(result);
			}
		}
		return response.build();
	}
}