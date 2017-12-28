package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0142Repository;
import nta.med.data.model.ihis.nuro.OcsLoadInputTabListItemInfo;
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
public class OcsLoadInputTabHandler extends ScreenHandler<NuroServiceProto.OcsLoadInputTabRequest, NuroServiceProto.OcsLoadInputTabResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(OcsLoadInputTabHandler.class);                                        
	@Resource                                                                                                       
	private Ocs0142Repository ocs0142Repository;                                                                    
	                                                                                                               
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.OcsLoadInputTabResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.OcsLoadInputTabRequest request) throws Exception {
		NuroServiceProto.OcsLoadInputTabResponse.Builder response = NuroServiceProto.OcsLoadInputTabResponse.newBuilder();
		List<OcsLoadInputTabListItemInfo> listResult = ocs0142Repository.getOcslibTabListItem(getHospitalCode(vertx, sessionId), request.getInputTab());
		if(!CollectionUtils.isEmpty(listResult)){
			for(OcsLoadInputTabListItemInfo item : listResult){
				NuroModelProto.OcsLoadInputTabListItemInfo.Builder info = NuroModelProto.OcsLoadInputTabListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addTabList(info);
			}
		}
		return response.build();
	}                                                                                                                 
}