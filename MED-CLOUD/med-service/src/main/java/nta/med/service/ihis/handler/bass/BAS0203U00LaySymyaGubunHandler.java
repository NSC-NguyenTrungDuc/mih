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
import nta.med.service.ihis.proto.BassServiceProto.BAS0203U00LaySymyaGubunRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0203U00StringResponse;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class BAS0203U00LaySymyaGubunHandler extends ScreenHandler<BassServiceProto.BAS0203U00LaySymyaGubunRequest, BassServiceProto.BAS0203U00StringResponse> {                     
	
	private static final Log LOGGER = LogFactory.getLog(BAS0203U00LaySymyaGubunHandler.class);                                    
	
	@Resource                                                                                                       
	private Bas0102Repository bas0102Repository;                                                                    
	
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, BAS0203U00LaySymyaGubunRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override    
	@Transactional(readOnly = true)
	public BAS0203U00StringResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			BAS0203U00LaySymyaGubunRequest request) throws Exception {
  	   	BassServiceProto.BAS0203U00StringResponse.Builder response = BassServiceProto.BAS0203U00StringResponse.newBuilder();                      
		List<Bas0102> listBas0102 = bas0102Repository.getByCodeAndCodeType(request.getHospCode(), request.getCode(), "SYMYA_GUBUN",  getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listBas0102)){
			String codeName = listBas0102.get(0).getCodeName();
			if(!StringUtils.isEmpty(codeName)){
				response.setResStr(codeName);
			}
		}
		return response.build();
	}                                                                                                                 
}