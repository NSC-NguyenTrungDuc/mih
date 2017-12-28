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
import nta.med.service.ihis.proto.BassServiceProto.BAS0110U00CodeNameResponse;
import nta.med.service.ihis.proto.BassServiceProto.BAS0110U00getCodeNameRequest;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class BAS0110U00GetCodeNameHandler extends ScreenHandler<BassServiceProto.BAS0110U00getCodeNameRequest, BassServiceProto.BAS0110U00CodeNameResponse>{                             
	private static final Log LOGGER = LogFactory.getLog(BAS0110U00GetCodeNameHandler.class);                                        
	@Resource                                                                                                       
	private Bas0102Repository bas0102Repository;                                                                    
	                                                                                                                
	@Override    
	@Transactional(readOnly = true)
	public BAS0110U00CodeNameResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
		BAS0110U00getCodeNameRequest request) throws Exception {                                                                   
  	   	BassServiceProto.BAS0110U00CodeNameResponse.Builder response = BassServiceProto.BAS0110U00CodeNameResponse.newBuilder();                      
		String result = bas0102Repository.getCodeNameByCodeTypeAndCode(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), "JOHAP_GUBUN ", request.getCode());
		if(!StringUtils.isEmpty(result)){
			response.setCodeName(result);
		}
		return response.build();
	}                                                                                                                 
}