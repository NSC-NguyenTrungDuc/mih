package nta.med.service.ihis.handler.clis;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.clis.ClisProtocolRepository;
import nta.med.data.model.ihis.clis.CLIS2015U03ProtocolListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.ClisModelProto;
import nta.med.service.ihis.proto.ClisServiceProto;
import nta.med.service.ihis.proto.ClisServiceProto.CLIS2015U03ProtocolListRequest;
import nta.med.service.ihis.proto.ClisServiceProto.CLIS2015U03ProtocolListResponse;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class CLIS2015U03ProtocolListHandler extends ScreenHandler<ClisServiceProto.CLIS2015U03ProtocolListRequest, ClisServiceProto.CLIS2015U03ProtocolListResponse>{                     
	private static final Log LOGGER = LogFactory.getLog(CLIS2015U03ProtocolListHandler.class);                                    
	@Resource                                                                                                       
	private ClisProtocolRepository clisProtocolRepository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public CLIS2015U03ProtocolListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CLIS2015U03ProtocolListRequest request) throws Exception {
		ClisServiceProto.CLIS2015U03ProtocolListResponse.Builder response = ClisServiceProto.CLIS2015U03ProtocolListResponse.newBuilder(); 
		List<CLIS2015U03ProtocolListInfo> listResult = clisProtocolRepository.getCLIS2015U03ProtocolListInfo(getHospitalCode(vertx, sessionId), request.getUserId());
		if(!CollectionUtils.isEmpty(listResult)){
			for(CLIS2015U03ProtocolListInfo item : listResult){
				ClisModelProto.CLIS2015U03ProtocolListInfo.Builder info = ClisModelProto.CLIS2015U03ProtocolListInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addProtocolListItem(info);
			}
		}
		return response.build();
	}                                                                                                                 
}