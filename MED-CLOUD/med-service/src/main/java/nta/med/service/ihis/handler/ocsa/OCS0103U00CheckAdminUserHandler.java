package nta.med.service.ihis.handler.ocsa;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U00CheckAdminUserRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U00CheckAdminUserResponse;

/**
 * @author DEV-NgocNV
 *
 */
@Service
@Scope("prototype")
public class OCS0103U00CheckAdminUserHandler extends ScreenHandler<OcsaServiceProto.OCS0103U00CheckAdminUserRequest, OcsaServiceProto.OCS0103U00CheckAdminUserResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0103U00CheckAdminUserHandler.class);        
	
	@Resource                                                                                                       
	private Bas0001Repository bas0001Repository;                                                                        
	                                                                                                                
	@Override                       
	@Transactional(readOnly = true)
	public OCS0103U00CheckAdminUserResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0103U00CheckAdminUserRequest request) throws Exception {                                                                 
  	   	OcsaServiceProto.OCS0103U00CheckAdminUserResponse.Builder response = OcsaServiceProto.OCS0103U00CheckAdminUserResponse.newBuilder();
		String masterGroupHosp = bas0001Repository.checkAdminUser(request.getHospCode());
		if(!StringUtils.isEmpty(masterGroupHosp)){
			response.setMasterGroupHosp(masterGroupHosp);
		}
		return response.build();
	}

}
