package nta.med.service.ihis.handler.ocsa;

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
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.dao.medi.drg.Drg0120Repository;
import nta.med.data.dao.medi.ocs.Ocs0102Repository;
import nta.med.data.dao.medi.ocs.Ocs0116Repository;
import nta.med.data.dao.medi.ocs.Ocs0128Repository;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.dao.medi.ocs.Ocs0170Repository;
import nta.med.data.dao.medi.ocs.Ocs0803Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U00FindBoxDataValidatingRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U00StringResponse;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U00FindBoxDataValidatingHandler extends ScreenHandler<OcsaServiceProto.OCS0103U00FindBoxDataValidatingRequest, OcsaServiceProto.OCS0103U00StringResponse> {                     
	
	private static final Log LOGGER = LogFactory.getLog(OCS0103U00FindBoxDataValidatingHandler.class);                                    
	
	@Resource                                                                                                       
	private Ocs0102Repository ocs0102Repository; 
	
	@Resource
	private Ocs0128Repository ocs0128Repository;
	
	@Resource
	private Bas0260Repository bas0260Repository;
	
	@Resource
	private Drg0120Repository drg0120Repository;
	
	@Resource
	private Ocs0132Repository ocs0132Repository; 
	
	@Resource
	private Ocs0803Repository ocs0803Repository;
	
	@Resource
	private Ocs0116Repository ocs0116Repository;
	
	@Resource
	private Ocs0170Repository ocs0170Repository;
	
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, OcsaServiceProto.OCS0103U00FindBoxDataValidatingRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override           
	@Transactional(readOnly = true)
	public OCS0103U00StringResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0103U00FindBoxDataValidatingRequest request) throws Exception {                                                                 
  	   	OcsaServiceProto.OCS0103U00StringResponse.Builder response = OcsaServiceProto.OCS0103U00StringResponse.newBuilder();
  	   	String hospCode = request.getHospCode();
  	   	String language = getLanguage(vertx, sessionId);
		String result = null;
		switch (request.getFbName()) {
		case "fbxQrySlipCode":
		case "fbxSlipCode":	
			result = ocs0102Repository.getLoadColumnCodeNameSlipCodeCase(request.getDataValue(), hospCode, language);
			break;
		case "fbxJundalPartOut":
			result = ocs0128Repository.getOCS0103U00GrdOCS0115ColChangedJundalPartOut(hospCode, language, request.getDataValue(), true, "O");
			break;
		case "fbxJundalPartInp":
			result = ocs0128Repository.getOCS0103U00GrdOCS0115ColChangedJundalPartOut(hospCode, language, request.getDataValue(),true, "I");
			break;
		case "fbxMovePart":
			result = bas0260Repository.getBasLoadGwaName(request.getDataValue(), request.getStartDate(), hospCode, language);
			break;
		case "fbxBogyongCode":
			if("C".equalsIgnoreCase(request.getOrderGubun())){
				result = drg0120Repository.getBogyongName(hospCode, request.getDataValue(), false, language);
			}else if("D".equalsIgnoreCase(request.getOrderGubun())){
				result = drg0120Repository.getBogyongName(hospCode, request.getDataValue(), true, language);
			}if("B".equalsIgnoreCase(request.getOrderGubun())){
				List<String> listResult = ocs0132Repository.getOCS0132CodeNameList(hospCode, language, "JUSA", request.getDataValue(), true);
				if(!CollectionUtils.isEmpty(listResult)){
					result = listResult.get(0);
				}
			}
			break;
		case "fbxSpecimenDefault":
			result = ocs0116Repository.getOCS0116GetCodeNameByCode(request.getDataValue(), hospCode);
			break;
		case "fbxPatStatusGr":
			result = ocs0803Repository.getOCS0803U00GetCodeNameCasePatStatusGr(hospCode, request.getDataValue(), language);
			break;
		case "fbxSpecificComment":
			result = ocs0170Repository.getLoadColumnCodeNameSpecificCommentCase(request.getDataValue(), hospCode);
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