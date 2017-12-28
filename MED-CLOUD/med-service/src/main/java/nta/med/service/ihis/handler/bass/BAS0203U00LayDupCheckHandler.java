package nta.med.service.ihis.handler.bass;

import java.util.Date;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0203Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0203U00LayDupCheckRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0203U00StringResponse;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class BAS0203U00LayDupCheckHandler extends ScreenHandler<BassServiceProto.BAS0203U00LayDupCheckRequest, BassServiceProto.BAS0203U00StringResponse> {                     
	
	private static final Log LOGGER = LogFactory.getLog(BAS0203U00LayDupCheckHandler.class);                                    
	
	@Resource                                                                                                       
	private Bas0203Repository bas0203Repository;   
	
	@Override
	public boolean isValid(BAS0203U00LayDupCheckRequest request, Vertx vertx,
			String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getJyDate()) && DateUtil.toDate(request.getJyDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	         
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, BAS0203U00LayDupCheckRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override     
	@Transactional(readOnly = true)
	public BAS0203U00StringResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			BAS0203U00LayDupCheckRequest request) throws Exception {
  	   	BassServiceProto.BAS0203U00StringResponse.Builder response = BassServiceProto.BAS0203U00StringResponse.newBuilder();                      
    	Date jyDate = DateUtil.toDate(request.getJyDate(), DateUtil.PATTERN_YYMMDD);
    	String result = bas0203Repository.getBAS0203U00LayDupCheckRequest(request.getHospCode(), request.getSymyaGubun(), request.getBunCode(),
    			request.getSgCode(), jyDate, request.getFromTime());
    	if(!StringUtils.isEmpty(result)){
    		response.setResStr(result);
    	}
    	return response.build();
	}

}