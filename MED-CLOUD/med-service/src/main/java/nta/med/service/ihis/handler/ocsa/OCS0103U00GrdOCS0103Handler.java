package nta.med.service.ihis.handler.ocsa;

import java.util.List;
import java.util.concurrent.ConcurrentHashMap;
import java.util.concurrent.ConcurrentMap;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.Language;
import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.adm.Adm0000Repository;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.ifs.Ifs0003Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U00GrdOCS0103Info;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U00GrdOCS0103Request;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U00GrdOCS0103Response;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U00GrdOCS0103Handler extends ScreenHandler<OcsaServiceProto.OCS0103U00GrdOCS0103Request, OcsaServiceProto.OCS0103U00GrdOCS0103Response> {                     
	
	@Resource                                                                                                       
	private Ifs0003Repository ifs0003Repository;                                                                    
	@Resource
	private Bas0001Repository bas0001Repository;
	@Resource
	private Adm0000Repository adm0000Repository;
	
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, OcsaServiceProto.OCS0103U00GrdOCS0103Request request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId)) && !StringUtils.isEmpty(request.getHospCode())) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override      
	@Transactional(readOnly = true)
	public OCS0103U00GrdOCS0103Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0103U00GrdOCS0103Request request) throws Exception {                                                                  
  	   	OcsaServiceProto.OCS0103U00GrdOCS0103Response.Builder response = OcsaServiceProto.OCS0103U00GrdOCS0103Response.newBuilder();
		String offset = request.getOffset();
		Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
		
		// get if_code from java
		List<ComboListItemInfo> ifCodeAndOcsCodes = ifs0003Repository.getIfCodeAndOcsCode(request.getHospCode());
		ConcurrentMap<String, String> ifCodes = new ConcurrentHashMap<String, String>();
		if(!CollectionUtils.isEmpty(ifCodeAndOcsCodes)){
			for(ComboListItemInfo item : ifCodeAndOcsCodes){
				ifCodes.putIfAbsent(item.getCode(), item.getCodeName());
			}
		}
		String hangmogInx = request.getHangmogInx(); 
		if (!StringUtils.isEmpty(hangmogInx) && Language.JAPANESE.toString().equalsIgnoreCase(getLanguage(vertx, sessionId))) {
			hangmogInx = adm0000Repository.callFnAdmConvertKanaFull(request.getHospCode(), hangmogInx);
		}
		hangmogInx = "%" + hangmogInx + "%";
		List<OCS0103U00GrdOCS0103Info> listGrd = ifs0003Repository.getOCS0103U00GrdOCS0103Info(request.getHospCode(), getLanguage(vertx, sessionId),
				request.getSlipCode(),hangmogInx,request.getSlipGubun(),request.getUsedYn(),request.getWonnaeYn(),
				startNum, CommonUtils.parseInteger(offset));
		
		if(!CollectionUtils.isEmpty(listGrd)){
			for(OCS0103U00GrdOCS0103Info item : listGrd){
				OcsaModelProto.OCS0103U00GrdOCS0103Info.Builder info = OcsaModelProto.OCS0103U00GrdOCS0103Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				if (item.getSeq() != null) {
					info.setSeq(String.format("%.0f",item.getSeq()));
				}
				info.setIfCode(StringUtils.isEmpty(ifCodes.get(item.getHangmogCode())) ? "" : ifCodes.get(item.getHangmogCode()));
				response.addGrdOcs0103Item(info);
			}
		}
		
		return response.build();
	}
	
	@Override
	public OCS0103U00GrdOCS0103Response postHandle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS0103U00GrdOCS0103Request request, OCS0103U00GrdOCS0103Response response) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId)) && !StringUtils.isEmpty(request.getHospCode())) {
			setSessionInfo(vertx, sessionId,
					SessionUserInfo.setSessionUserInfoByUserGroup("NTA", getLanguage(vertx, sessionId), "", 0));
		}
		
		return response;
	}

}