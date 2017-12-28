package nta.med.service.ihis.handler.bass;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0210U00layDupCheckRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0210U00layDupCheckResponse;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class BAS0210U00layDupCheckHandler extends ScreenHandler<BassServiceProto.BAS0210U00layDupCheckRequest, BassServiceProto.BAS0210U00layDupCheckResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(BAS0210U00layDupCheckHandler.class);                                        
	@Resource                                                                                                       
	private Bas0102Repository bas0102Repository;                                                                    
	                                                                                                                
	@Override     
	@Transactional(readOnly = true)
	public BAS0210U00layDupCheckResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			BAS0210U00layDupCheckRequest request) throws Exception {                                                                   
  	   	BassServiceProto.BAS0210U00layDupCheckResponse.Builder response = BassServiceProto.BAS0210U00layDupCheckResponse.newBuilder();                      
		String layDupChk=bas0102Repository.getBAS0210U00layDupCheck(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),request.getCode());
		if(!StringUtils.isEmpty(layDupChk)){
			response.setLayDupCheck(layDupChk);
		}
		return response.build();
	}                                                                                                                 
}
