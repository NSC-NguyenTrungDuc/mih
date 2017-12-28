package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0212Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0212U00CListItemResponse;
import nta.med.service.ihis.proto.BassServiceProto.BAS0212U00ListItemRequest;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class BAS0212U00ListItemHandler extends ScreenHandler<BassServiceProto.BAS0212U00ListItemRequest, BassServiceProto.BAS0212U00CListItemResponse> {                      
	private static final Log LOGGER = LogFactory.getLog(BAS0212U00ListItemHandler.class);                                    
	@Resource                                                                                                       
	private Bas0212Repository bas0212Repository;                                                                    
	                                                                                                               

	@Override
	@Transactional(readOnly = true)
	public BAS0212U00CListItemResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, BAS0212U00ListItemRequest request)
			throws Exception {
		BassServiceProto.BAS0212U00CListItemResponse.Builder response = BassServiceProto.BAS0212U00CListItemResponse.newBuilder();
		List<String> lisResult = bas0212Repository.getBAS0212U00ListItem(request.getCode(), request.getStartDate(), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(lisResult)){
			for(String item : lisResult){
				BassModelProto.BAS0212U00ListItemRequestInfo.Builder info = BassModelProto.BAS0212U00ListItemRequestInfo.newBuilder();
				if(!StringUtils.isEmpty(item)){
					info.setGongbiName(item);
				}
				response.addComboName(info);
			}
		}
		return response.build();
	}                                                                                                                 
}