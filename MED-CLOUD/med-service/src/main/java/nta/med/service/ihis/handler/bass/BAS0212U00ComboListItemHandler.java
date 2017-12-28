package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0212U00ComboListItemRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0212U00ComboListItemResponse;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class BAS0212U00ComboListItemHandler  extends ScreenHandler<BassServiceProto.BAS0212U00ComboListItemRequest, BassServiceProto.BAS0212U00ComboListItemResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(BAS0212U00ComboListItemHandler.class);                                    
	@Resource                                                                                                       
	private Bas0102Repository bas0102Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public BAS0212U00ComboListItemResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			BAS0212U00ComboListItemRequest request) throws Exception {
		BassServiceProto.BAS0212U00ComboListItemResponse.Builder response = BassServiceProto.BAS0212U00ComboListItemResponse.newBuilder();  
		List<ComboListItemInfo> listResult = bas0102Repository.getCht0115Q01xEditGridCell10ListItem(getHospitalCode(vertx, sessionId), "GONGBI_JIYEOK", getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listResult)){
			for(ComboListItemInfo item : listResult){
				BassModelProto.BAS0212U00ComboListItemInfo.Builder info = BassModelProto.BAS0212U00ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addComboItem(info);
			}
		}
		return response.build();
	}                                                                                                                 
}