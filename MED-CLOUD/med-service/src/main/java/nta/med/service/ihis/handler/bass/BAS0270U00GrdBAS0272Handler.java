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
import nta.med.data.dao.medi.bas.Bas0272Repository;
import nta.med.data.model.ihis.bass.BAS0270GrdBAS0272Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0270U00GrdBAS0272Request;
import nta.med.service.ihis.proto.BassServiceProto.BAS0270U00GrdBAS0272Response;

@Service                                                                                                          
@Scope("prototype")
public class BAS0270U00GrdBAS0272Handler extends ScreenHandler<BassServiceProto.BAS0270U00GrdBAS0272Request, BassServiceProto.BAS0270U00GrdBAS0272Response> {                             
	
	private static final Log LOG = LogFactory.getLog(BAS0270U00GrdBAS0272Handler.class);                                        
	
	@Resource                                                                                                       
	private Bas0272Repository bas0272Repository;                                                                     
	        
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, BAS0270U00GrdBAS0272Request request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override
	@Transactional(readOnly = true)
	public BAS0270U00GrdBAS0272Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			BAS0270U00GrdBAS0272Request request) throws Exception {                                                                   
		
		BassServiceProto.BAS0270U00GrdBAS0272Response.Builder response = BassServiceProto.BAS0270U00GrdBAS0272Response.newBuilder();
		List<BAS0270GrdBAS0272Info> listItem = bas0272Repository.getBAS0270GrdBAS0272Info(request.getHospCode(), getLanguage(vertx, sessionId),  DateUtil.toDate(request.getDoctorYmd(),DateUtil.PATTERN_YYMMDD) , request.getDoctor());
		
		if(!CollectionUtils.isEmpty(listItem)) {
			for (BAS0270GrdBAS0272Info item : listItem) {
				BassModelProto.BAS0270U00GrdBAS0272Info.Builder info = BassModelProto.BAS0270U00GrdBAS0272Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdBAS0272(info);
			}
		}
		
		return response.build();
	}
				
	@Override
	public boolean isValid(BassServiceProto.BAS0270U00GrdBAS0272Request request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getDoctorYmd())&& DateUtil.toDate(request.getDoctorYmd(),DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
}                                                                                                               
