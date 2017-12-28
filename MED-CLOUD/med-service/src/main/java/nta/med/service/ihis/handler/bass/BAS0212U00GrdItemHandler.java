package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0212Repository;
import nta.med.data.model.ihis.bass.BAS0212U00GrdItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0212U00GrdItemRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0212U00GrdItemResponse;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class BAS0212U00GrdItemHandler extends ScreenHandler<BassServiceProto.BAS0212U00GrdItemRequest, BassServiceProto.BAS0212U00GrdItemResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(BAS0212U00GrdItemHandler.class);                                    
	@Resource                                                                                                       
	private Bas0212Repository bas0212Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public BAS0212U00GrdItemResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, BAS0212U00GrdItemRequest request)
			throws Exception {
		BassServiceProto.BAS0212U00GrdItemResponse.Builder response = BassServiceProto.BAS0212U00GrdItemResponse.newBuilder();
		List<BAS0212U00GrdItemInfo> listResult =  bas0212Repository.getBAS0212U00GrdItemInfo(request.getGongbiCode(), request.getStartDate(), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listResult)){
			for(BAS0212U00GrdItemInfo item : listResult){
				BassModelProto.BAS0212U00GrdItemInfo.Builder info = BassModelProto.BAS0212U00GrdItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdInit(info);
			}
		}
		return response.build();
	}                                                                                                                 
}