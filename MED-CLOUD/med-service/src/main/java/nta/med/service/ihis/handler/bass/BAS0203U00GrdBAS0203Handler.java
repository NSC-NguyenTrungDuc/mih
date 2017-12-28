package nta.med.service.ihis.handler.bass;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0203Repository;
import nta.med.data.model.ihis.bass.BAS0203U00GrdBAS0203Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0203U00GrdBAS0203Request;
import nta.med.service.ihis.proto.BassServiceProto.BAS0203U00GrdBAS0203Response;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class BAS0203U00GrdBAS0203Handler extends ScreenHandler<BassServiceProto.BAS0203U00GrdBAS0203Request, BassServiceProto.BAS0203U00GrdBAS0203Response> {                     
	private static final Log LOGGER = LogFactory.getLog(BAS0203U00GrdBAS0203Handler.class);                                    
	
	@Resource                                                                                                       
	private Bas0203Repository bas0203Repository;                                                                    
	        
	@Override
	public boolean isValid(BAS0203U00GrdBAS0203Request request, Vertx vertx,
			String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getJyDate()) && DateUtil.toDate(request.getJyDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, BAS0203U00GrdBAS0203Request request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override  
	@Transactional(readOnly = true)
	public BAS0203U00GrdBAS0203Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			BAS0203U00GrdBAS0203Request request) throws Exception {
  	   	BassServiceProto.BAS0203U00GrdBAS0203Response.Builder response = BassServiceProto.BAS0203U00GrdBAS0203Response.newBuilder();                      
    	Date jyDate = DateUtil.toDate(request.getJyDate(), DateUtil.PATTERN_YYMMDD);
    	List<BAS0203U00GrdBAS0203Info> listGrd = bas0203Repository.getBAS0203U00GrdBAS0203Info(request.getHospCode(), getLanguage(vertx, sessionId), jyDate, request.getSymyaGubun());
    	if(!CollectionUtils.isEmpty(listGrd)){
    		for(BAS0203U00GrdBAS0203Info item : listGrd){
    			BassModelProto.BAS0203U00GrdBAS0203Info.Builder info = BassModelProto.BAS0203U00GrdBAS0203Info.newBuilder();
    			BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdBas0203Item(info);
    		}
    	}
            	
		return response.build();
	}                                                                                                                 
}