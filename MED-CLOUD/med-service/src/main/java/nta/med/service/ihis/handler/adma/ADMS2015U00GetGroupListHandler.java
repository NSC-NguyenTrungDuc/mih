package nta.med.service.ihis.handler.adma;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.glossary.UserRole;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm0100Repository;
import nta.med.data.dao.medi.adm.Adm0200Repository;
import nta.med.data.model.ihis.adma.ADMS2015U00GetGroupListInfo;
import nta.med.data.model.ihis.adma.ADMS2015U00GetSystemListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.AdmaModelProto;
import nta.med.service.ihis.proto.AdmaServiceProto;
import nta.med.service.ihis.proto.AdmaServiceProto.ADMS2015U00GetGroupListRequest;
import nta.med.service.ihis.proto.AdmaServiceProto.ADMS2015U00GetGroupListResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class ADMS2015U00GetGroupListHandler extends ScreenHandler<AdmaServiceProto.ADMS2015U00GetGroupListRequest, AdmaServiceProto.ADMS2015U00GetGroupListResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(ADMS2015U00GetGroupListHandler.class);                                    
	@Resource                                                                                                       
	private Adm0100Repository adm0100Repository;
	@Resource                                                                                                       
	private Adm0200Repository adm0200Repository;
	@Override
	public boolean isAuthorized(Vertx vertx, String sessionId){

		return UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId));
	}
	@Override             
	@Transactional(readOnly = true)    
	public ADMS2015U00GetGroupListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			ADMS2015U00GetGroupListRequest request) throws Exception {
  	   	AdmaServiceProto.ADMS2015U00GetGroupListResponse.Builder response = AdmaServiceProto.ADMS2015U00GetGroupListResponse.newBuilder();  
  	   	String language = getLanguage(vertx, sessionId);
		List<ADMS2015U00GetGroupListInfo> listGroup = adm0100Repository.getADMS2015U00GetGroupListInfo(language);
		if(!CollectionUtils.isEmpty(listGroup)) {
			for (ADMS2015U00GetGroupListInfo itemGroup : listGroup) {
				AdmaModelProto.ADMS2015U00GetGroupListInfo.Builder infoGroup = AdmaModelProto.ADMS2015U00GetGroupListInfo.newBuilder();
				BeanUtils.copyProperties(itemGroup, infoGroup, getLanguage(vertx, sessionId));
				if (itemGroup.getGrpSeq() != null) {
        			infoGroup.setGrpSeq(String.format("%.0f",itemGroup.getGrpSeq()));
        		}
				response.addGroupListInfo(infoGroup);
			}
			if (!listGroup.get(0).getGrpId().isEmpty()) {
				List<ADMS2015U00GetSystemListInfo> listSystem = adm0200Repository.getADMS2015U00GetSystemListInfo(listGroup.get(0).getGrpId(), language);
				for (ADMS2015U00GetSystemListInfo itemSystem : listSystem) {
					AdmaModelProto.ADMS2015U00GetSystemListInfo.Builder infoSystem = AdmaModelProto.ADMS2015U00GetSystemListInfo.newBuilder();
					BeanUtils.copyProperties(itemSystem, infoSystem, getLanguage(vertx, sessionId));
					if (itemSystem.getSysSeq() != null) {
            			infoSystem.setSysSeq(String.format("%.0f",itemSystem.getSysSeq()));
            		}
					response.addSystemListInfo(infoSystem);
				}
			}
		}
				
		return response.build();
	}                                                                                                                 
}