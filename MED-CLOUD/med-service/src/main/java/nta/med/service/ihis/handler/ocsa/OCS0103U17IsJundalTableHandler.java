package nta.med.service.ihis.handler.ocsa;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U17IsJundalTableRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U17IsJundalTableResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U17IsJundalTableHandler
	extends ScreenHandler<OcsaServiceProto.OCS0103U17IsJundalTableRequest, OcsaServiceProto.OCS0103U17IsJundalTableResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0103U17IsJundalTableHandler.class);                                    
	@Resource                                                                                                       
	private Ocs0103Repository ocs0103Repository;                                                                    
	                                                                                                                
	@Override               
	@Transactional(readOnly = true)
	public OCS0103U17IsJundalTableResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0103U17IsJundalTableRequest request) throws Exception {                                                                  
  	   	OcsaServiceProto.OCS0103U17IsJundalTableResponse.Builder response = OcsaServiceProto.OCS0103U17IsJundalTableResponse.newBuilder();                      
		String result = ocs0103Repository.getOCS0103U17IsJundalTable(getHospitalCode(vertx, sessionId), request.getHangmogCode(), request.getIoGubun(), request.getJundalTable());
		if(!StringUtils.isEmpty(result)){
			response.setCnt(result);
		}
		return response.build();
	}

}