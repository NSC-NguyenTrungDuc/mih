package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0310Repository;
import nta.med.data.model.ihis.bass.BAS0311U00GridListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0311U00GridListRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0311U00GridListResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class BAS0311U00GridListHandler extends ScreenHandler<BassServiceProto.BAS0311U00GridListRequest, BassServiceProto.BAS0311U00GridListResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(BAS0311U00GridListHandler.class);                                    
	@Resource                                                                                                       
	private Bas0310Repository bas0310Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public BAS0311U00GridListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, BAS0311U00GridListRequest request)
			throws Exception {
		BassServiceProto.BAS0311U00GridListResponse.Builder response = BassServiceProto.BAS0311U00GridListResponse.newBuilder();
		List<BAS0311U00GridListItemInfo> listResult = bas0310Repository.getBAS0311U00GridListItemInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getFSgCode());
		if(!CollectionUtils.isEmpty(listResult)){
			for(BAS0311U00GridListItemInfo item : listResult){
				BassModelProto.BAS0311U00GridListItemInfo.Builder info = BassModelProto.BAS0311U00GridListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addDt(info);
			}
		}
		return response.build();
	}                                                                                                                 
}