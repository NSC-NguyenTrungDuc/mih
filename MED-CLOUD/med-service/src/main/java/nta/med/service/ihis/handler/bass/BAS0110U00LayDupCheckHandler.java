package nta.med.service.ihis.handler.bass;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0110Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0110U00LayDupCheckRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0110U00LayDupCheckResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class BAS0110U00LayDupCheckHandler extends ScreenHandler<BassServiceProto.BAS0110U00LayDupCheckRequest, BassServiceProto.BAS0110U00LayDupCheckResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(BAS0110U00LayDupCheckHandler.class);                                        
	@Resource                                                                                                       
	private Bas0110Repository bas0110Repository;
	
	@Override
	public boolean isValid(BassServiceProto.BAS0110U00LayDupCheckRequest request,Vertx vertx, String clientId, String sessionId) {
		if(!StringUtils.isEmpty(request.getStartDate()) && DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD) == null){
			return false; 
		}
		return true;
	}
	                                                                                                                
	@Override       
	@Transactional(readOnly = true)
	public BAS0110U00LayDupCheckResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			BAS0110U00LayDupCheckRequest request) throws Exception {                                                                   
  	   	BassServiceProto.BAS0110U00LayDupCheckResponse.Builder response = BassServiceProto.BAS0110U00LayDupCheckResponse.newBuilder();                      
		String result = bas0110Repository.getBas0110U00LayDupChk(request.getGubun(), DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD), 
				request.getJohap(), getLanguage(vertx, sessionId));
		if(!StringUtils.isEmpty(result)){
			response.setLayChk(result);
		}
		return response.build();
	}                                                                                                                 
}