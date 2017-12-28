package nta.med.service.ihis.handler.ocsa;

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
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.dao.medi.ocs.Ocs0116Repository;
import nta.med.data.dao.medi.ocs.Ocs0128Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U00GridColumnChangedRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U00StringResponse;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U00GridColumnChangedHandler extends ScreenHandler<OcsaServiceProto.OCS0103U00GridColumnChangedRequest, OcsaServiceProto.OCS0103U00StringResponse> {                     
	
	private static final Log LOGGER = LogFactory.getLog(OCS0103U00GridColumnChangedHandler.class);                                    
	
	@Resource                                                                                                       
	private Bas0260Repository bas0260Repository;   
	
	@Resource
	private Ocs0128Repository ocs0128Repository;
	
	@Resource
	private Ocs0116Repository ocs0116Repository;
	
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, OCS0103U00GridColumnChangedRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override         
	@Transactional(readOnly = true)
	public OCS0103U00StringResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0103U00GridColumnChangedRequest request) throws Exception {                                                                   
  	   	OcsaServiceProto.OCS0103U00StringResponse.Builder response = OcsaServiceProto.OCS0103U00StringResponse.newBuilder();                      
		String result = null;
		String hospCode = request.getHospCode();
		String language = getLanguage(vertx, sessionId);
		
		switch (request.getGridName()) {
		case "grdOCS0115":
			if("input_part".equalsIgnoreCase(request.getColName())){
				result = bas0260Repository.getOCS0103U00GrdOCS0115ColChangedJundalPart(hospCode, language, request.getChangeValue());
			}else if("jundal_part_out".equalsIgnoreCase(request.getColName())){
				result = ocs0128Repository.getOCS0103U00GrdOCS0115ColChangedJundalPartOut(hospCode, language, request.getChangeValue(), false, "O");
			}else if("jundal_part_inp".equalsIgnoreCase(request.getColName()) || "move_part".equalsIgnoreCase(request.getColName())){
				result = bas0260Repository.getOCS1003P01ChangeUserInfo(hospCode, request.getChangeValue(), language);
			}
			break;
		 case "grdOCS0113":
			 result = ocs0116Repository.getOCS0116GetCodeNameByCode(request.getChangeValue(), hospCode);
			 break;
		default:
			break;
		}
		if(!StringUtils.isEmpty(result)){
			response.setResStr(result);
		}
		return response.build();
	}

}