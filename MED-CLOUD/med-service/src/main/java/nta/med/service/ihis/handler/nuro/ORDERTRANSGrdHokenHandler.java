package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.out.Out0102Repository;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdHokenInfo;
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
public class ORDERTRANSGrdHokenHandler extends ScreenHandler<NuroServiceProto.ORDERTRANSGrdHokenRequest, NuroServiceProto.ORDERTRANSGrdHokenResponse> {                    
	private static final Log LOGGER = LogFactory.getLog(ORDERTRANSGrdHokenHandler.class);                                    
	@Resource                                                                                                       
	private Out0102Repository out0102Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.ORDERTRANSGrdHokenResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.ORDERTRANSGrdHokenRequest request) throws Exception {
		NuroServiceProto.ORDERTRANSGrdHokenResponse.Builder response = NuroServiceProto.ORDERTRANSGrdHokenResponse.newBuilder();
		List<ORDERTRANSGrdHokenInfo> listResult = out0102Repository.getORDERTRANSGrdHokenInfo(getHospitalCode(vertx, sessionId), request.getActingDate(),
				 request.getGubun(), request.getBunho(), request.getSendYn());
		if(!CollectionUtils.isEmpty(listResult)){
			for(ORDERTRANSGrdHokenInfo item : listResult){
				NuroModelProto.ORDERTRANSGrdHokenInfo.Builder info = NuroModelProto.ORDERTRANSGrdHokenInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdHokenItem(info);
			}
		}
		
		return response.build();
	}                                                                                                                 
}