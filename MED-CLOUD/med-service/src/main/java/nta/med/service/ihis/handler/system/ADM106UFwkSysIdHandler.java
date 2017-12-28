package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.glossary.UserRole;
import nta.med.data.dao.medi.adm.Adm0200Repository;
import nta.med.data.model.ihis.adma.ADM103LaySysListGrpInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ADM106UFwkSysIdRequest;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class ADM106UFwkSysIdHandler
	extends ScreenHandler<SystemServiceProto.ADM106UFwkSysIdRequest, SystemServiceProto.ComboResponse> {                     
	@Resource                                                                                                       
	private Adm0200Repository adm0200Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, ADM106UFwkSysIdRequest request) throws Exception {                                                                  
  	   	SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();
  	   	String userRole = getUserRole(vertx, sessionId);
  	  List<ADM103LaySysListGrpInfo> listItem = null;
  	   	if (UserRole.SUPER_ADMIN.getValue().equals(userRole)) {
  	   		listItem = adm0200Repository.getADM103LaySysListGrpInfoSAM(getLanguage(vertx, sessionId));
  	   	} else {
  	   		listItem = adm0200Repository.getADM103LaySysListGrpInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
  	   	}
		if (!CollectionUtils.isEmpty(listItem)) {
			for (ADM103LaySysListGrpInfo item : listItem) {
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder(); 
				if(!StringUtils.isEmpty(item.getSysId())) {
					info.setCode(item.getSysId());
				}
				if(!StringUtils.isEmpty(item.getSysNm())) {
					info.setCodeName(item.getSysNm());
				}
				response.addComboItem(info);
			}
		}
		return response.build();
	}
}