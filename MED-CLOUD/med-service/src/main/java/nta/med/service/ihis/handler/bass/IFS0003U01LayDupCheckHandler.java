package nta.med.service.ihis.handler.bass;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ifs.Ifs0003Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.IFS0003U01LayDupCheckRequest;
import nta.med.service.ihis.proto.BassServiceProto.IFS0003U01StringResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class IFS0003U01LayDupCheckHandler extends ScreenHandler<BassServiceProto.IFS0003U01LayDupCheckRequest, BassServiceProto.IFS0003U01StringResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(IFS0003U01LayDupCheckHandler.class);                                    
	@Resource                                                                                                       
	private Ifs0003Repository ifs0003Repository;                                                                    
	                  
	@Override
	public boolean isValid(IFS0003U01LayDupCheckRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getMapGubun()) && DateUtil.toDate(request.getMapGubun(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	
	@Override      
	@Transactional(readOnly = true)
	public IFS0003U01StringResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			IFS0003U01LayDupCheckRequest request) throws Exception {
  	   	BassServiceProto.IFS0003U01StringResponse.Builder response = BassServiceProto.IFS0003U01StringResponse.newBuilder();                      
    	Date mapGubunYmd = DateUtil.toDate(request.getMapGubun(), DateUtil.PATTERN_YYMMDD );
		String getY = ifs0003Repository.getIfs003U03LayDupCheck(getHospitalCode(vertx, sessionId), request.getMapGubun(), mapGubunYmd, null, false);
		if(!StringUtils.isEmpty(getY)){
			response.setStrRes(getY);
		}
		return response.build();
	}
}