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
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0271Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0270U00LayDupCheckRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0270U00LayDupCheckResponse;
import nta.med.service.ihis.proto.CommonModelProto;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class BAS0270U00LayDupCheckHandler extends ScreenHandler<BassServiceProto.BAS0270U00LayDupCheckRequest, BassServiceProto.BAS0270U00LayDupCheckResponse> {                             
	
	private static final Log LOG = LogFactory.getLog(BAS0270U00LayDupCheckHandler.class);                                        
	
	@Resource                                                                                                       
	private Bas0271Repository bas0271Repository;                                                                    
	                                                                                                                
	@Override                                                                                                       
	public boolean isValid(BAS0270U00LayDupCheckRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getDoctorYmd())&& DateUtil.toDate(request.getDoctorYmd(),DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	            
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, BAS0270U00LayDupCheckRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override          
	@Transactional(readOnly = true)
	public BAS0270U00LayDupCheckResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			BAS0270U00LayDupCheckRequest request) throws Exception { 
		
		BassServiceProto.BAS0270U00LayDupCheckResponse.Builder response = BassServiceProto.BAS0270U00LayDupCheckResponse.newBuilder();
		List<String> listItem = bas0271Repository.getBAS0270LayDupCheckRequest(request.getHospCode(), request.getDoctorYmd(), request.getDoctor());
		
		if(!CollectionUtils.isEmpty(listItem)) {
			for (String item : listItem) {
				CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addY(info);
			}
		}
				
		return response.build();
	}
}
