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
import nta.med.data.model.ihis.bass.BAS0270GrdBAS0271Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0270U00GrdBAS0271Request;
import nta.med.service.ihis.proto.BassServiceProto.BAS0270U00GrdBAS0271Response;

@Service                                                                                                          
@Scope("prototype")
public class BAS0270U00GrdBAS0271Handler extends ScreenHandler<BassServiceProto.BAS0270U00GrdBAS0271Request, BassServiceProto.BAS0270U00GrdBAS0271Response> {                             
	
	private static final Log LOG = LogFactory.getLog(BAS0270U00GrdBAS0271Handler.class);                                        
	@Resource                                                                                                       
	private Bas0271Repository bas0271Repository;  
	@Override
	public boolean isValid(BassServiceProto.BAS0270U00GrdBAS0271Request request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getDoctorYmd())&& DateUtil.toDate(request.getDoctorYmd(),DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	 
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, BAS0270U00GrdBAS0271Request request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override
	@Transactional(readOnly = true)
	public BAS0270U00GrdBAS0271Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			BAS0270U00GrdBAS0271Request request) throws Exception {
		
		BassServiceProto.BAS0270U00GrdBAS0271Response.Builder response = BassServiceProto.BAS0270U00GrdBAS0271Response.newBuilder();
		List<BAS0270GrdBAS0271Info> listItem = bas0271Repository.getBAS0270GrdBAS0271Info(request.getHospCode(), getLanguage(vertx, sessionId), request.getDoctorYmd(), request.getDoctorName());
	
		if(!CollectionUtils.isEmpty(listItem)) {
			for (BAS0270GrdBAS0271Info item : listItem) {
				BassModelProto.BAS0270U00GrdBAS0271Info.Builder info = BassModelProto.BAS0270U00GrdBAS0271Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdBAS0271(info);
			}
		}
		
		return response.build();
	}
}                                                                                                               
