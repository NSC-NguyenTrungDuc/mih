package nta.med.service.ihis.handler.system;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.adm.Adm0003Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.FormEnvironInfoMessageRequest;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")   
public class FormEnvironInfoMessageHandler
	extends ScreenHandler<SystemServiceProto.FormEnvironInfoMessageRequest, SystemServiceProto.StringResponse> {                     
	@Resource
	private Adm0003Repository adm0003Repository;
	
	@Override
	@Transactional(readOnly = true)
	public StringResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			FormEnvironInfoMessageRequest request) throws Exception {                                                                 
  	   	SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();                      
		Double adm0003Pk = CommonUtils.parseDouble(request.getMsgNum());
		String result = adm0003Repository.getFormEnvironInfoMessage(getLanguage(vertx, sessionId), adm0003Pk);
		response.setResult(result);
		return response.build();
	}
}
