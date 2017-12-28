package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0001U00FbxDodobuHyeunDataValidatingRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0001U00FbxDodobuHyeunDataValidatingResponse;

@Service                                                                                                          
@Scope("prototype")    
public class BAS0001U00FbxDodobuHyeunDataValidatingHandler extends ScreenHandler<BassServiceProto.BAS0001U00FbxDodobuHyeunDataValidatingRequest, BassServiceProto.BAS0001U00FbxDodobuHyeunDataValidatingResponse> {
	
	private static final Log LOGGER = LogFactory.getLog(BAS0001U00FbxDodobuHyeunDataValidatingHandler.class);                                        
	
	@Resource                                                                                                       
	private Bas0102Repository bas0102Repository;                                                                    
	                  
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, BAS0001U00FbxDodobuHyeunDataValidatingRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override
	@Transactional(readOnly = true)
	public BAS0001U00FbxDodobuHyeunDataValidatingResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			BAS0001U00FbxDodobuHyeunDataValidatingRequest request)
			throws Exception {
  	   	
		BassServiceProto.BAS0001U00FbxDodobuHyeunDataValidatingResponse.Builder response = BassServiceProto.BAS0001U00FbxDodobuHyeunDataValidatingResponse.newBuilder();
		List<ComboListItemInfo> listFbxDodobHyeunValidating  = bas0102Repository.getBAS0001U00FbxDodobuHyeunDataValidating(request.getHospCode(), getLanguage(vertx, sessionId),request.getCodeType(),request.getCode());
		
		if(!CollectionUtils.isEmpty(listFbxDodobHyeunValidating)){	
			for(ComboListItemInfo item :listFbxDodobHyeunValidating){
				BassModelProto.BAS0001U00FbxDodobuHyeunDataValidatingInfo.Builder info = BassModelProto.BAS0001U00FbxDodobuHyeunDataValidatingInfo.newBuilder();
				if(!StringUtils.isEmpty(item.getCode())){
					info.setCodeName(item.getCode());
				}
				if(!StringUtils.isEmpty(item.getCodeName())){
					info.setSortKey(item.getCodeName());
				}
				response.addFbxDodobHyeunValidating(info);
			}
		}
		
		return response.build();
	}                                                                                                                                                   
}