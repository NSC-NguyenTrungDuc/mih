package nta.med.service.ihis.handler.adma;

import nta.med.core.common.annotation.Route;
import nta.med.core.glossary.UserRole;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm0300Repository;
import nta.med.data.model.ihis.adma.Adm102UGrdListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.AdmaModelProto;
import nta.med.service.ihis.proto.AdmaServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

import java.util.List;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class ADM102UGrdListHandler extends ScreenHandler<AdmaServiceProto.ADM102UGrdListRequest, AdmaServiceProto.ADM102UGrdListResponse> {
	
	private static final Log LOGGER = LogFactory.getLog(ADM102UGrdListHandler.class);                                    
	
	@Resource                                                                                                       
	private Adm0300Repository adm0300Repository;
	
	@Override
	public boolean isAuthorized(Vertx vertx, String sessionId){

		return UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId));
	}
	
	@Override
	@Transactional(readOnly = true)
	@Route(global = true)
	public AdmaServiceProto.ADM102UGrdListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.ADM102UGrdListRequest request) throws Exception {
		AdmaServiceProto.ADM102UGrdListResponse.Builder response = AdmaServiceProto.ADM102UGrdListResponse.newBuilder();
		List<Adm102UGrdListItemInfo> list =  adm0300Repository.getAdm102UGrdListItem(getLanguage(vertx, sessionId), request.getSysId());
		if(!CollectionUtils.isEmpty(list)){
			for(Adm102UGrdListItemInfo item : list){
				AdmaModelProto.ADM102UGrdListItemInfo.Builder info = AdmaModelProto.ADM102UGrdListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdList(info);
			}
		}
		
		return response.build();
	}
	
}