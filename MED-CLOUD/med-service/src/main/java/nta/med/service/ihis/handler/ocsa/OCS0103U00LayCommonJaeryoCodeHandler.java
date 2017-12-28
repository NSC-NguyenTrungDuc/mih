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
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inv.Inv0110Repository;
import nta.med.data.model.ihis.ocsa.OCS0103U00LayCommonJaeryoCodeInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U00LayCommonJaeryoCodeRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U00LayCommonJaeryoCodeHandler extends ScreenHandler<OcsaServiceProto.OCS0103U00LayCommonJaeryoCodeRequest, SystemServiceProto.ComboResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0103U00LayCommonJaeryoCodeHandler.class);                                    
	
	@Resource                                                                                                       
	private Inv0110Repository inv0110Repository;                                                                    
	
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, OCS0103U00LayCommonJaeryoCodeRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override      
	@Transactional(readOnly = true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, OCS0103U00LayCommonJaeryoCodeRequest request)
			throws Exception {                                                                 
  	   	SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();                      
		List<OCS0103U00LayCommonJaeryoCodeInfo> listLay = inv0110Repository.getOCS0103U00LayCommonJaeryoCodeInfo(request.getHospCode(),request.getJaeryoCode());
		if(!CollectionUtils.isEmpty(listLay)){
			for(OCS0103U00LayCommonJaeryoCodeInfo item : listLay){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				if (!StringUtils.isEmpty(item.getJaeryoName())) {
					info.setCode(item.getJaeryoName());
				}
				if (item.getBulyongDate() != null) {
					info.setCodeName(DateUtil.toString(item.getBulyongDate(), DateUtil.PATTERN_YYMMDD));
				}
				response.addComboItem(info);
			}
		}
		return response.build();
	}                                                                                                                                                   
}