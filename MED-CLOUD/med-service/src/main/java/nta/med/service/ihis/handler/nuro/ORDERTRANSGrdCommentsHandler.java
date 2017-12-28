package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.out.Out0106Repository;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdCommentsInfo;
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
public class ORDERTRANSGrdCommentsHandler extends ScreenHandler<NuroServiceProto.ORDERTRANSGrdCommentsRequest, NuroServiceProto.ORDERTRANSGrdCommentsResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(ORDERTRANSGrdCommentsHandler.class);                                    
	@Resource                                                                                                       
	private Out0106Repository out0106Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.ORDERTRANSGrdCommentsResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.ORDERTRANSGrdCommentsRequest request) throws Exception {
		NuroServiceProto.ORDERTRANSGrdCommentsResponse.Builder response = NuroServiceProto.ORDERTRANSGrdCommentsResponse.newBuilder();
		List<ORDERTRANSGrdCommentsInfo> listResult = out0106Repository.getORDERTRANSGrdCommentsInfo(getHospitalCode(vertx, sessionId), request.getBunho());
		if(!CollectionUtils.isEmpty(listResult)){
			for(ORDERTRANSGrdCommentsInfo item : listResult){
				NuroModelProto.ORDERTRANSGrdCommentsInfo.Builder info = NuroModelProto.ORDERTRANSGrdCommentsInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdCommentsItem(info);
			}
		}
		return response.build();
	}                                                                                                                 
}