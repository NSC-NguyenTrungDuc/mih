package nta.med.service.ihis.handler.system;

import javax.annotation.Resource;

import nta.med.data.dao.medi.cpl.Cpl0108Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.OBLoadSimsaCommentRequest;
import nta.med.service.ihis.proto.SystemServiceProto.OBLoadSimsaCommentResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OBLoadSimsaCommentHandler 
	extends ScreenHandler<SystemServiceProto.OBLoadSimsaCommentRequest, SystemServiceProto.OBLoadSimsaCommentResponse> {                     
	@Resource                                                                                                       
	private Cpl0108Repository cpl0108Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public OBLoadSimsaCommentResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, OBLoadSimsaCommentRequest request)
			throws Exception {                                                                  
      	   	SystemServiceProto.OBLoadSimsaCommentResponse.Builder response = SystemServiceProto.OBLoadSimsaCommentResponse.newBuilder();                      
		String temp=null;
		if(!StringUtils.isEmpty(temp)){
			response.setResult(temp);
		}
		return response.build();
	}
}