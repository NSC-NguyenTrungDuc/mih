package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.nur.Nur0101Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR0101U00layComboItemsHandler extends ScreenHandler<NuriServiceProto.NUR0101U00layComboItemsRequest, SystemServiceProto.ComboResponse> {   
	
	@Resource                                   
	private Nur0101Repository nur0101Repository;

	@Override
	@Transactional(readOnly = true)
	public SystemServiceProto.ComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR0101U00layComboItemsRequest request) throws Exception {
				
		SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();
		
		String language = getLanguage(vertx, sessionId);
		List<ComboListItemInfo> result = nur0101Repository.getNUR0101U00layComboItems(language);
		
		if(!CollectionUtils.isEmpty(result)){
			for(ComboListItemInfo item : result){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addComboItem(info);
			}
		}
		
		return response.build();
	}
}
