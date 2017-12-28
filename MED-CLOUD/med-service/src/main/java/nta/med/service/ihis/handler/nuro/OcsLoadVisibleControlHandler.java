package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0141Repository;
import nta.med.data.model.ihis.nuro.OcsLoadVisibleControlListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OcsLoadVisibleControlHandler extends ScreenHandler<NuroServiceProto.OcsLoadVisibleControlRequest, NuroServiceProto.OcsLoadVisibleControlResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(OcsLoadVisibleControlHandler.class);                                        
	@Resource                                                                                                       
	private Ocs0141Repository ocs0141Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.OcsLoadVisibleControlResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.OcsLoadVisibleControlRequest request) throws Exception {
		NuroServiceProto.OcsLoadVisibleControlResponse.Builder response = NuroServiceProto.OcsLoadVisibleControlResponse.newBuilder();
		List<OcsLoadVisibleControlListItemInfo> listResult = ocs0141Repository.getOcslibVisibleListItem(request.getInputTab());
		if(!CollectionUtils.isEmpty(listResult)){
			for(OcsLoadVisibleControlListItemInfo item : listResult){
				NuroModelProto.OcsLoadVisibleControlListItemInfo.Builder info = NuroModelProto.OcsLoadVisibleControlListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addVisibleControlList(info);
			}
		}
		return response.build();
	}                                                                                                                 
}