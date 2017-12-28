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

import nta.med.core.domain.bas.Bas0102;
import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0270U00LayDoctorGradeRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0270U00LayDoctorGradeResponse;
import nta.med.service.ihis.proto.CommonModelProto;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class BAS0270U00LayDoctorGradeHandler extends ScreenHandler<BassServiceProto.BAS0270U00LayDoctorGradeRequest, BassServiceProto.BAS0270U00LayDoctorGradeResponse>{                             
	
	private static final Log LOG = LogFactory.getLog(BAS0270U00LayDoctorGradeHandler.class);                                        
	
	@Resource                                                                                                       
	private Bas0102Repository bas0102Repository;                                                                    
	                  
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, BAS0270U00LayDoctorGradeRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override
	@Transactional(readOnly = true)
	public BAS0270U00LayDoctorGradeResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			BAS0270U00LayDoctorGradeRequest request) throws Exception {                                                                   
	
		BassServiceProto.BAS0270U00LayDoctorGradeResponse.Builder response = BassServiceProto.BAS0270U00LayDoctorGradeResponse.newBuilder();
		List<Bas0102> listItem = bas0102Repository.getByCodeAndCodeType(request.getHospCode(), request.getCode(), "DOCTOR_GRADE", getLanguage(vertx, sessionId));
		
		if(!CollectionUtils.isEmpty(listItem)) {
			for (Bas0102 item : listItem) {
				CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
				if(!StringUtils.isEmpty(item.getCodeName())) {
					info.setDataValue(item.getCodeName());
				}
				response.addCodeName(info);
			}
		}
		
		return response.build();
	}
}
