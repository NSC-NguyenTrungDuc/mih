package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0130Repository;
import nta.med.data.model.ihis.nuro.OcsLoadInputControlListItemInfo;
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
public class OcsLoadInputControlHandler extends ScreenHandler<NuroServiceProto.OcsLoadInputControlRequest, NuroServiceProto.OcsLoadInputControlResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(OcsLoadInputControlHandler.class);                                        
	@Resource                                                                                                       
	private Ocs0130Repository ocs0130Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.OcsLoadInputControlResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.OcsLoadInputControlRequest request) throws Exception {
		NuroServiceProto.OcsLoadInputControlResponse.Builder response = NuroServiceProto.OcsLoadInputControlResponse.newBuilder();
		List<OcsLoadInputControlListItemInfo> listResult = ocs0130Repository.getOcslibControlListItem(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getInputControl());
		if(!CollectionUtils.isEmpty(listResult)){
			for(OcsLoadInputControlListItemInfo item : listResult){
				NuroModelProto.OcsLoadInputControlListItemInfo.Builder info = NuroModelProto.OcsLoadInputControlListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addControlList(info);
			}
		}
		return response.build();
	}                                                                                                                 
}