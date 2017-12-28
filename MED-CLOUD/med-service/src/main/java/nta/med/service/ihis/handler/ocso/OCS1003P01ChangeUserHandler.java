package nta.med.service.ihis.handler.ocso;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS1003P01ChangeUserHandler extends ScreenHandler<OcsoServiceProto.OCS1003P01ChangeUserRequest, OcsoServiceProto.OCS1003P01ChangeUserResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(OCS1003P01ChangeUserHandler.class);                                        
	@Resource                                                                                                       
	private Bas0260Repository bas0260Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OCS1003P01ChangeUserResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OCS1003P01ChangeUserRequest request) throws Exception {
		OcsoServiceProto.OCS1003P01ChangeUserResponse.Builder response = OcsoServiceProto.OCS1003P01ChangeUserResponse.newBuilder();
		String result = bas0260Repository.getOCS1003P01ChangeUserInfo(getHospitalCode(vertx, sessionId), request.getGwa(), getLanguage(vertx, sessionId));
		if(!StringUtils.isEmpty(result)){
			response.setGwaName(result);
		}
		return response.build();
	}                                                                                                                 
}