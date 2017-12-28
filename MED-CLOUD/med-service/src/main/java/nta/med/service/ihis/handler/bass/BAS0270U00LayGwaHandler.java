package nta.med.service.ihis.handler.bass;

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
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0270U00LayGwaRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0270U00LayGwaResponse;
import nta.med.service.ihis.proto.CommonModelProto;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class BAS0270U00LayGwaHandler extends ScreenHandler<BassServiceProto.BAS0270U00LayGwaRequest, BassServiceProto.BAS0270U00LayGwaResponse>{                             
	
	private static final Log LOG = LogFactory.getLog(BAS0270U00LayGwaHandler.class);                                        
	
	@Resource                                                                                                       
	private Bas0260Repository bas0260Repository;                                                                    
	
	@Override
	public boolean isValid(BAS0270U00LayGwaRequest request, Vertx vertx,
			String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getBuseoYmd())&& DateUtil.toDate(request.getBuseoYmd(),DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	          
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, BAS0270U00LayGwaRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override
	@Transactional(readOnly = true)
	public BAS0270U00LayGwaResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, BAS0270U00LayGwaRequest request)
					throws Exception {
		
		BassServiceProto.BAS0270U00LayGwaResponse.Builder response = BassServiceProto.BAS0270U00LayGwaResponse.newBuilder();
		List<String> listItem = bas0260Repository.getBAS0270LayGwa(request.getHospCode(), getLanguage(vertx, sessionId), request.getBuseoYmd(), request.getGwa());
		
		if(!CollectionUtils.isEmpty(listItem)) {
			for (String item : listItem) {
				CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
				if(!StringUtils.isEmpty(item)) {
					info.setDataValue(item);
				}
				response.addGwaName(info);
			}
		}
				
		return response.build();
	}
}
