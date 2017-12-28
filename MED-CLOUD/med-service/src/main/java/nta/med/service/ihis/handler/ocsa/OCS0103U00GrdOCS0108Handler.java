package nta.med.service.ihis.handler.ocsa;

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
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.dao.medi.ocs.Ocs0108Repository;
import nta.med.data.model.ihis.ocsa.OCS0103U00GrdOCS0108Info;
import nta.med.data.model.ihis.ocsa.OCS0103U00SunalAndSubulInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U00GrdOCS0108Request;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U00GrdOCS0108Response;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U00GrdOCS0108Handler extends ScreenHandler<OcsaServiceProto.OCS0103U00GrdOCS0108Request, OcsaServiceProto.OCS0103U00GrdOCS0108Response> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0103U00GrdOCS0108Handler.class);                                    
	@Resource                                                                                                       
	private Ocs0108Repository ocs0108Repository;                                                                    
	@Resource
	private Ocs0103Repository ocs0103Repository;
	
	@Override
	public boolean isValid(OCS0103U00GrdOCS0108Request request, Vertx vertx, String clientId, String sessionId) {
	   if(!StringUtils.isEmpty(request.getHangmogStartDate()) && DateUtil.toDate(request.getHangmogStartDate(), DateUtil.PATTERN_YYMMDD) == null){
	       return false;
	   }
	   return true;
	}
	
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, OcsaServiceProto.OCS0103U00GrdOCS0108Request request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId)) && !StringUtils.isEmpty(request.getHospCode())) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override                       
	@Transactional(readOnly = true)
	public OCS0103U00GrdOCS0108Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0103U00GrdOCS0108Request request) throws Exception {  
		String hospCode = request.getHospCode();
		Date hangmogStartDate = DateUtil.toDate(request.getHangmogStartDate(), DateUtil.PATTERN_YYMMDD);
		String sunal = null;
		String subul = null;
  	   	OcsaServiceProto.OCS0103U00GrdOCS0108Response.Builder response = OcsaServiceProto.OCS0103U00GrdOCS0108Response.newBuilder();  
  	   	//start tuning performance
  	   	OCS0103U00SunalAndSubulInfo fnResult = ocs0103Repository.callFnOcsLoadSunalAndSubulDanuiName(hospCode, getLanguage(vertx, sessionId), 
  	   			request.getHangmogCode(), hangmogStartDate);
  	   	if(fnResult != null){
  	   		sunal = fnResult.getSunal();
  	   		subul = fnResult.getSubul();
  	   	}
  	   	//end tuning performance
		List<OCS0103U00GrdOCS0108Info> listGrd = ocs0108Repository.getOCS0103U00GrdOCS0108Info(request.getHospCode(), request.getHangmogCode(), hangmogStartDate, getLanguage(vertx, sessionId));
		
		if(!CollectionUtils.isEmpty(listGrd)){
			for(OCS0103U00GrdOCS0108Info item : listGrd){
				OcsaModelProto.OCS0103U00GrdOCS0108Info.Builder info = OcsaModelProto.OCS0103U00GrdOCS0108Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				//start tuning performance
				if(item.getCodeName1() != null){
					if(sunal != null){
						info.setCodeName1(item.getCodeName1().concat("/").concat(sunal));
					}else{
						info.setCodeName1(item.getCodeName1().concat("/"));
					}
				}
				if(item.getCodeName2() != null){
					if(subul != null){
						info.setCodeName2(item.getCodeName2().concat("/").concat(subul));	
					}else{
						info.setCodeName2(item.getCodeName2().concat("/"));
					}
				}
				//end tuning performance
				response.addGrdOcs0108Item(info);
			}
		}
		return response.build();
	}                                                                                                                                                   

	@Override
	public OCS0103U00GrdOCS0108Response postHandle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS0103U00GrdOCS0108Request request, OCS0103U00GrdOCS0108Response response) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId)) && !StringUtils.isEmpty(request.getHospCode())) {
			setSessionInfo(vertx, sessionId,
					SessionUserInfo.setSessionUserInfoByUserGroup("NTA", getLanguage(vertx, sessionId), "", 1));
		}
		
		return response;
	}
	
}