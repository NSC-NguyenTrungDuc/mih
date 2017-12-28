package nta.med.service.emr.handler;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.emr.proto.EmrModelProto;
import nta.med.service.emr.proto.EmrServiceProto;
import nta.med.service.emr.proto.EmrServiceProto.OCS2015U06OrderTypeComboRequest;
import nta.med.service.emr.proto.EmrServiceProto.OCS2015U06OrderTypeComboResponse;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS2015U06OrderTypeComboHandler extends ScreenHandler<EmrServiceProto.OCS2015U06OrderTypeComboRequest, EmrServiceProto.OCS2015U06OrderTypeComboResponse> {                     
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;                                                                    
	                                                                                                                
	@Override    
	@Transactional(readOnly = true)
	public OCS2015U06OrderTypeComboResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS2015U06OrderTypeComboRequest request) throws Exception {                                                                   
      	   	EmrServiceProto.OCS2015U06OrderTypeComboResponse.Builder response = EmrServiceProto.OCS2015U06OrderTypeComboResponse.newBuilder();                
      	   	List<String> list = ocs0132Repository.getOCS2015U06OrderTypeComboInfo(getHospitalCode(vertx, sessionId), "ORDER_GUBUN", "0%",  getLanguage(vertx, sessionId));
      	   	if(!CollectionUtils.isEmpty(list)){
      	   		for(String item : list){
      	   			EmrModelProto.OCS2015U06OrderTypeComboInfo.Builder info = EmrModelProto.OCS2015U06OrderTypeComboInfo.newBuilder();
      	   			info.setCodeName(item);
      	   			response.addOrderTypes(info);
      	   		}
      	   	}
      	   	return response.build();
	}	
}