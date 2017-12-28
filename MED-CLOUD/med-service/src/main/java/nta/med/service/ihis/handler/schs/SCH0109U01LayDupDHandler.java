package nta.med.service.ihis.handler.schs;

import javax.annotation.Resource;

import nta.med.data.dao.medi.sch.Sch0109Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SCH0109U01LayDupDRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SCH0109U01StringResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class SCH0109U01LayDupDHandler
	extends ScreenHandler<SchsServiceProto.SCH0109U01LayDupDRequest, SchsServiceProto.SCH0109U01StringResponse> {                     
	@Resource                                                                                                       
	private Sch0109Repository sch0109Repository;                                                                   
	                                                                                                                
	@Override         
	@Transactional(readOnly=true)
	public SCH0109U01StringResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, SCH0109U01LayDupDRequest request)
			throws Exception {                                                                  
  	   	SchsServiceProto.SCH0109U01StringResponse.Builder response = SchsServiceProto.SCH0109U01StringResponse.newBuilder();                      
		String retVal = sch0109Repository.getSCH0109U00LayDupD(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getCodeType(), request.getCode());
    	if (!StringUtils.isEmpty(retVal)) {
    		response.setResStr(retVal);
		}
    	return response.build();
	}

}