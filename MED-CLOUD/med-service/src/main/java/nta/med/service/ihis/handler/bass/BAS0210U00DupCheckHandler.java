package nta.med.service.ihis.handler.bass;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0210Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0210U00DupCheckRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0210U00DupCheckResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class BAS0210U00DupCheckHandler extends ScreenHandler<BassServiceProto.BAS0210U00DupCheckRequest, BassServiceProto.BAS0210U00DupCheckResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(BAS0210U00DupCheckHandler.class);                                        
	@Resource                                                                                                       
	private Bas0210Repository bas0210Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public BAS0210U00DupCheckResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, BAS0210U00DupCheckRequest request)
					throws Exception {
  	   	BassServiceProto.BAS0210U00DupCheckResponse.Builder response = BassServiceProto.BAS0210U00DupCheckResponse.newBuilder();                      
    	String dupChk=bas0210Repository.getBAS0210U00DupCheck(request.getGubun(), DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD), getLanguage(vertx, sessionId));
    	if(!StringUtils.isEmpty(dupChk)){
    		response.setDupCheck(dupChk);
    	}
		return response.build();
	}
	
	@Override
	public boolean isValid(BassServiceProto.BAS0210U00DupCheckRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getStartDate()) && DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
}