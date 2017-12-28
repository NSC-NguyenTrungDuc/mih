package nta.med.service.ihis.handler.bass;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ifs.Ifs0003Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.IFS0003U00LayDupCheckRequest;
import nta.med.service.ihis.proto.BassServiceProto.IFS0003U00LayDupCheckResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class IFS0003U00LayDupCheckHandler extends ScreenHandler<BassServiceProto.IFS0003U00LayDupCheckRequest, BassServiceProto.IFS0003U00LayDupCheckResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(IFS0003U00LayDupCheckHandler.class);                                    
	@Resource                                                                                                       
	private Ifs0003Repository ifs0003Repository;                                                                    
	                                                                                                                
	@Override         
	@Transactional(readOnly = true)
	public IFS0003U00LayDupCheckResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			IFS0003U00LayDupCheckRequest request) throws Exception {
  	   	BassServiceProto.IFS0003U00LayDupCheckResponse.Builder response = BassServiceProto.IFS0003U00LayDupCheckResponse.newBuilder();                      
		String result = ifs0003Repository.getIfs003U03LayDupCheck(getHospitalCode(vertx, sessionId), request.getMapGubun(), DateUtil.toDate(request.getMapGubunYmd(), DateUtil.PATTERN_YYMMDD) , "", false);
		if(!StringUtils.isEmpty(result)){
			response.setYValue(result);
		}
		return response.build();
	}																																						
}