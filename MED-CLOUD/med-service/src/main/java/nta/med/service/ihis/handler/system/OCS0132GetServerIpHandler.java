package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.OCS0132GetServerIpRequest;
import nta.med.service.ihis.proto.SystemServiceProto.OCS0132GetServerIpResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0132GetServerIpHandler extends ScreenHandler<SystemServiceProto.OCS0132GetServerIpRequest, SystemServiceProto.OCS0132GetServerIpResponse> {                     
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public OCS0132GetServerIpResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, OCS0132GetServerIpRequest request)
			throws Exception{                                                                   
  	   	SystemServiceProto.OCS0132GetServerIpResponse.Builder response = SystemServiceProto.OCS0132GetServerIpResponse.newBuilder();                      
		List<String> listObject = ocs0132Repository.getOCS0132CodeNameList(getHospitalCode(vertx, sessionId),getLanguage(vertx, sessionId), "SERVER_IP","ENDO",false);
		if(!CollectionUtils.isEmpty(listObject)){
			String result = listObject.get(0);
			if(!StringUtils.isEmpty(result)){
				response.setServerIp(result);
			}
		}
		return response.build();
	}
}