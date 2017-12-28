package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0001U00FbxDodobuHyeunFindClickRequest;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

@Service                                                                                                          
@Scope("prototype")
public class BAS0001U00FbxDodobuHyeunFindClickHandler extends ScreenHandler<BassServiceProto.BAS0001U00FbxDodobuHyeunFindClickRequest, SystemServiceProto.ComboResponse> {                             
	
	private static final Log LOGGER = LogFactory.getLog(BAS0001U00FbxDodobuHyeunFindClickHandler.class);                                        
	
	@Resource                                                                                                       
	private Bas0102Repository bas0102Repository;
	
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, BAS0001U00FbxDodobuHyeunFindClickRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override
	@Transactional(readOnly = true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, BAS0001U00FbxDodobuHyeunFindClickRequest request)
					throws Exception {
		SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();    
		List<ComboListItemInfo> listfbxDodobuHyeunFindClick = bas0102Repository.getBAS0001U00FbxDodobuHyeunFindClick(request.getHospCode(), getLanguage(vertx,sessionId),request.getCodeType(),request.getFind1());
		
		if(!CollectionUtils.isEmpty(listfbxDodobuHyeunFindClick)){
			for(ComboListItemInfo item :listfbxDodobuHyeunFindClick){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();	
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addComboItem(info);
			}
		}
		
		return response.build();
	}                                                                                                                                                   
}